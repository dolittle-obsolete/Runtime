/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Lifecycle;
using Dolittle.Logging;
using System.Collections.Concurrent;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represent an implementation of <see cref="IPullConnectors"/>
    /// </summary>
    [Singleton]
    public class PullConnectors : IPullConnectors
    {
        readonly ConcurrentDictionary<ConnectorId, PullConnector> _connectors = new ConcurrentDictionary<ConnectorId, PullConnector>();
        readonly ILogger _logger;

        /// <summary>
        /// Initalizes a new instance of <see cref="PullConnectors"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public PullConnectors(
            ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public void Register(PullConnector connector)
        {
            _logger.Information($"Register '{connector.Id}'");
            _connectors[connector.Id] = connector;
        }

        /// <inheritdoc/>
        public bool Has(ConnectorId connectorId)
        {
            return _connectors.ContainsKey(connectorId);
        }

        /// <inheritdoc/>
        public PullConnector GetById(ConnectorId connectorId)
        {
            return _connectors[connectorId];
        }

        /// <inheritdoc/>
        public void Unregister(PullConnector connector)
        {
            if (_connectors.ContainsKey(connector.Id))
            {
                _logger.Information($"Unregister '{connector.Id}'");
                _connectors.TryRemove(connector.Id, out PullConnector _);
            }
            else
            {
                _logger.Warning($"Connector with id '{connector.Id}' is not registered");
            }
        }
    }
}