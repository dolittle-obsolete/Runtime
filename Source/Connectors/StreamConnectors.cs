/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Lifecycle;
using Dolittle.Logging;
using System.Collections.Generic;

namespace Dolittle.TimeSeries.Runtime.Connectors
{

    /// <summary>
    /// Represent an implementation of <see cref="IStreamConnectors"/>
    /// </summary>
    [Singleton]
    public class StreamConnectors : IStreamConnectors
    {
        readonly List<StreamConnector> _connectors = new List<StreamConnector>();
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
            lock( _connectors ) _connectors.Add(connector);
        }

        /// <inheritdoc/>
        public void Unregister(StreamConnector connector)
        {
             _logger.Information($"Unregister '{connector.Id}'");
           lock( _connectors ) _connectors.Remove(connector);
        }
    }
}