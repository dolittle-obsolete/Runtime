/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Concurrent;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client.DataPointProcessor;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="IDataPointProcessors"/>
    /// </summary>
    [Singleton]
    public class DataPointProcessors : IDataPointProcessors
    {
        readonly ConcurrentDictionary<DataPointProcessor, DataPointProcessorProcessor> _processors = new ConcurrentDictionary<DataPointProcessor, DataPointProcessorProcessor>();
        readonly IClientFor<DataPointProcessorClient> _client;
        readonly ILogger _logger;
        private readonly IInputStreams _inputStreams;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessors"/>
        /// </summary>
        /// <param name="inputStreams"></param>
        /// <param name="client"></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointProcessors(
            IInputStreams inputStreams,
            IClientFor<DataPointProcessorClient> client,
            ILogger logger)
        {
            _logger = logger;
            _client = client;
            _inputStreams = inputStreams;
        }

        /// <inheritdoc/>
        public void Register(DataPointProcessor dataPointProcessor)
        {
            try
            {
                var processorProcessor = new DataPointProcessorProcessor(dataPointProcessor, _client);

                _logger.Information($"Registering '{dataPointProcessor.Id}'");
                _processors[dataPointProcessor] = processorProcessor;
                _inputStreams.DataPointReceived += processorProcessor.Process;
            } catch( Exception ex )
            {
                _logger.Error(ex, $"Error registering data point processor '{dataPointProcessor.Id}'");
            }
        }

        /// <inheritdoc/>
        public void Unregister(DataPointProcessor dataPointProcessor)
        {
            _logger.Information($"Unregistering '{dataPointProcessor.Id}'");
            
            if (_processors.TryRemove(dataPointProcessor, out DataPointProcessorProcessor processorProcessor))
            {
                _inputStreams.DataPointReceived -= processorProcessor.Process;
                processorProcessor.Dispose();
            }
        }
    }

}