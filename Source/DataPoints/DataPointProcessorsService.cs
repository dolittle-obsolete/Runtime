/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.Protobuf;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using grpc = Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.DataPointProcessors;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointProcessorsBase"/>
    /// </summary>
    public class DataPointProcessorsService : DataPointProcessorsBase
    {
        readonly IDataPointProcessors _dataPointProcessors;
        readonly ILogger _logger;
        private readonly IInputStreams _inputStreams;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessorsService"/>
        /// </summary>
        /// <param name="dataPointProcessors">Actual <see cref="IDataPointProcessors"/></param>
        /// <param name="inputStreams"></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointProcessorsService(
            IDataPointProcessors dataPointProcessors,
            IInputStreams inputStreams,
            ILogger logger)
        {
            _dataPointProcessors = dataPointProcessors;
            _logger = logger;
            _inputStreams = inputStreams;
        }

        /// <inheritdoc/>
        public override Task Open(grpc.DataPointProcessor request, IServerStreamWriter<DataPoint> responseStream, ServerCallContext context)
        {
            DataPointProcessor dataPointProcessor = null;
            var id = request.Id.To<DataPointProcessorId>();

            void received(DataPoint dataPoint) => Process(responseStream, dataPoint);

            try
            {
                _logger.Information($"Register processor with identifier '{id}'");
                dataPointProcessor = new DataPointProcessor(id);
                _dataPointProcessors.Register(dataPointProcessor);

                _inputStreams.DataPointReceived += received;

                context.CancellationToken.ThrowIfCancellationRequested();
                context.CancellationToken.WaitHandle.WaitOne();
            }
            finally
            {
                _inputStreams.DataPointReceived -= received;
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
