/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Lifecycle;
using Dolittle.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Dolittle.TimeSeries.Runtime.Connectors
{

    /// <summary>
    /// Represent an implementation of <see cref="IStreamConnectors"/>
    /// </summary>
    [Singleton]
    public class StreamConnectors : IStreamConnectors
    {
        readonly ConcurrentDictionary<ConnectorId, StreamConnector> _connectors = new ConcurrentDictionary<ConnectorId, StreamConnector>();
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="StreamConnectors"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public StreamConnectors(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public void Register(StreamConnector connector)
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
        public StreamConnector GetById(ConnectorId connectorId)
        {
            return _connectors[connectorId];
        }


        /// <inheritdoc/>
        public void Unregister(StreamConnector connector)
        {
             if (_connectors.ContainsKey(connector.Id))
            {
                _logger.Information($"Unregister '{connector.Id}'");
                _connectors.TryRemove(connector.Id, out StreamConnector _);
            }
            else
            {
                _logger.Warning($"Connector with id '{connector.Id}' is not registered");
            }
       }
    }
}