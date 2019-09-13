/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.PullConnector;
using System.Collections.Concurrent;
using System.Threading;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represent an implementation of <see cref="IPullConnectors"/>
    /// </summary>
    [Singleton]
    public class PullConnectors : IPullConnectors
    {
        readonly ConcurrentDictionary<PullConnector, PullConnectorProcessor> _connectorProcessorsByConnector = new ConcurrentDictionary<PullConnector, PullConnectorProcessor>();
        readonly ILogger _logger;
        readonly IClientFor<PullConnectorClient> _pullConnectorClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pullConnectorClient"></param>
        /// <param name="logger"></param>
        public PullConnectors(
            IClientFor<PullConnectorClient> pullConnectorClient,
            ILogger logger)
        {
            _logger = logger;
            _pullConnectorClient = pullConnectorClient;
        }

        /// <inheritdoc/>
        public void Register(PullConnector pullConnector)
        {
            _logger.Information($"Register '{pullConnector.Id}'");
            _connectorProcessorsByConnector[pullConnector] = new PullConnectorProcessor(pullConnector,_pullConnectorClient, _logger);
        }

        /// <inheritdoc/>
        public void Unregister(PullConnector pullConnector)
        {
            if( _connectorProcessorsByConnector.ContainsKey(pullConnector) )
            {
                if (_connectorProcessorsByConnector.TryRemove(pullConnector, out PullConnectorProcessor processor))
                {
                    processor.Stop();
                    processor.Dispose();
                }
            }
        }
    }
}