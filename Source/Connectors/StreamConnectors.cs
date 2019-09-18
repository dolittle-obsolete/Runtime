/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.StreamConnector;
using System.Collections.Concurrent;
using Dolittle.TimeSeries.Runtime.DataPoints;

namespace Dolittle.TimeSeries.Runtime.Connectors
{

    /// <summary>
    /// Represent an implementation of <see cref="IStreamConnectors"/>
    /// </summary>
    [Singleton]
    public class StreamConnectors : IStreamConnectors
    {
        readonly ConcurrentDictionary<StreamConnector, StreamConnectorProcessor> _connectors = new ConcurrentDictionary<StreamConnector, StreamConnectorProcessor>();
        readonly ILogger _logger;
        readonly IClientFor<StreamConnectorClient> _streamConnectorClient;
        readonly IOutputStreams _outputStreams;

        /// <summary>
        /// Initializes a new instance of <see cref="StreamConnectors"/>
        /// </summary>
        /// <param name="streamConnectorClient"></param>
        /// <param name="outputStreams">All <see cref="IOutputStreams"/></param>
        /// <param name="logger"></param>
        public StreamConnectors(
            IClientFor<StreamConnectorClient> streamConnectorClient,
            IOutputStreams outputStreams,
            ILogger logger)
        {
            _logger = logger;
            _streamConnectorClient = streamConnectorClient;
            _outputStreams = outputStreams;
        }

        /// <inheritdoc/>
        public void Register(StreamConnector connector)
        {
            _logger.Information($"Register '{connector.Id}'");
            _connectors[connector] = new StreamConnectorProcessor(
                                            connector, 
                                            _streamConnectorClient, 
                                            _outputStreams,
                                            _logger);
        }

        /// <inheritdoc/>
        public void Unregister(StreamConnector connector)
        {
            if( _connectors.ContainsKey(connector))
            {
                if(_connectors.TryRemove(connector, out StreamConnectorProcessor processor))
                {
                    processor.Stop();
                    processor.Dispose();
                }
            }
        }
    }
}