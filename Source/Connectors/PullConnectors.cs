/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.PullConnector;
using System.Collections.Concurrent;
using Dolittle.TimeSeries.Runtime.DataPoints;
using Dolittle.TimeSeries.Runtime.Identity;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represent an implementation of <see cref="IPullConnectors"/>
    /// </summary>
    [Singleton]
    public class PullConnectors : IPullConnectors
    {
        readonly ConcurrentDictionary<PullConnector, PullConnectorProcessor> _connectors = new ConcurrentDictionary<PullConnector, PullConnectorProcessor>();
        readonly ILogger _logger;
        readonly IClientFor<PullConnectorClient> _client;
        readonly IOutputStreams _outputStreams;
        readonly ITimeSeriesMapper _timeSeriesMapper;

        /// <summary>
        /// Initalizes a new instance of <see cref="PullConnectors"/>
        /// </summary>
        /// <param name="client">Client for <see cref="PullConnectorClient"/></param>
        /// <param name="outputStreams">All <see cref="IOutputStreams"/></param>
        /// <param name="timeSeriesMapper"><see cref="ITimeSeriesMapper"/> for mapping data points</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public PullConnectors(
            IClientFor<PullConnectorClient> client,
            IOutputStreams outputStreams,
            ITimeSeriesMapper timeSeriesMapper,
            ILogger logger)
        {
            _logger = logger;
            _client = client;
            _outputStreams = outputStreams;
            _timeSeriesMapper = timeSeriesMapper;
        }

        /// <inheritdoc/>
        public void Register(PullConnector connector)
        {
            _logger.Information($"Register '{connector.Id}'");
            _connectors[connector] = new PullConnectorProcessor(
                                            connector,
                                            _client,
                                            _outputStreams,
                                            _timeSeriesMapper,
                                            _logger);
        }

        /// <inheritdoc/>
        public void Unregister(PullConnector connector)
        {
            if( _connectors.ContainsKey(connector) )
            {
                if (_connectors.TryRemove(connector, out PullConnectorProcessor processor))
                {
                    processor.Stop();
                    processor.Dispose();
                }
            }
        }
    }
}