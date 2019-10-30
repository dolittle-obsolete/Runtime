/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.Protobuf;
using Grpc.Core;
using Dolittle.TimeSeries.DataTypes.Runtime;
using static Dolittle.TimeSeries.DataPoints.Runtime.DataPointProcessors;
using grpc = Dolittle.TimeSeries.DataPoints.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointProcessorsBase"/>
    /// </summary>
    public class DataPointProcessorsService : DataPointProcessorsBase
    {
        readonly IDataPointProcessors _dataPointProcessors;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessorsService"/>
        /// </summary>
        /// <param name="dataPointProcessors">Actual <see cref="IDataPointProcessors"/></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointProcessorsService(
            IDataPointProcessors dataPointProcessors,
            ILogger logger)
        {
            _dataPointProcessors = dataPointProcessors;
            _logger = logger;
        }

        /// <inheritdoc/>
        public override Task Open(grpc.DataPointProcessor request, IServerStreamWriter<grpc.DataPoints> responseStream, ServerCallContext context)
        {
            DataPointProcessor dataPointProcessor = null;
            var id = request.Id.To<DataPointProcessorId>();

            void Received(IEnumerable<DataPoint> dataPoints) => Process(responseStream, dataPoints);

            try
            {
                _logger.Information($"Register processor with identifier '{id}'");
                dataPointProcessor = new DataPointProcessor(id);
                _dataPointProcessors.Register(dataPointProcessor);

                dataPointProcessor.Received += Received;

                context.CancellationToken.ThrowIfCancellationRequested();
                context.CancellationToken.WaitHandle.WaitOne();
            }
            finally
            {
                if (dataPointProcessor != null)
                {
                    dataPointProcessor.Received -= Received;

                    _logger.Information($"Unregister processor with identifier '{id}'");
                    _dataPointProcessors.Unregister(dataPointProcessor);
                }
            }

            return Task.CompletedTask;
        }

        void Process(IServerStreamWriter<grpc.DataPoints> responseStream, IEnumerable<DataPoint> dataPoints)
        {
            if(!dataPoints.Any()) return;

            _logger.Information("Process datapoint");

            try
            {
                var message = new grpc.DataPoints();
                message.DataPoints_.Add(dataPoints);
                responseStream.WriteAsync(message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Couldn't write datapoint");
            }
        }
    }
}
