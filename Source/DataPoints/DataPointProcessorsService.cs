/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
extern alias contracts;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.Protobuf;
using Grpc.Core;
using contracts::Dolittle.TimeSeries.Runtime.DataTypes;
using static contracts::Dolittle.TimeSeries.Runtime.DataPoints.DataPointProcessors;
using grpc = contracts::Dolittle.TimeSeries.Runtime.DataPoints;

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
        public override Task Open(grpc.DataPointProcessor request, IServerStreamWriter<DataPoint> responseStream, ServerCallContext context)
        {
            DataPointProcessor dataPointProcessor = null;
            var id = request.Id.To<DataPointProcessorId>();

            try
            {
                _logger.Information($"Register processor with identifier '{id}'");
                dataPointProcessor = new DataPointProcessor(id);
                _dataPointProcessors.Register(dataPointProcessor);

                context.CancellationToken.ThrowIfCancellationRequested();
                context.CancellationToken.WaitHandle.WaitOne();
            }
            finally
            {
                if (dataPointProcessor != null)
                {
                    _logger.Information($"Unregister processor with identifier '{id}'");
                    _dataPointProcessors.Unregister(dataPointProcessor);
                }
            }

            return Task.CompletedTask;
        }

        void Process(IServerStreamWriter<DataPoint> responseStream, DataPoint dataPoint)
        {
            _logger.Information("Process datapoint");

            responseStream.WriteAsync(dataPoint);
        }
    }
}
