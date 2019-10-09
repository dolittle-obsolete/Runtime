/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Defines a system for working with all available stream connectors
    /// </summary>
    public interface IStreamConnectors
    {
        /// <summary>
        /// Register a stream connector
        /// </summary>
        /// <param name="streamConnector"><see cref="StreamConnector"/> to register</param>
        void Register(StreamConnector streamConnector);

        /// <summary>
        /// Check if is registered <see cref="StreamConnector"/> by its identifier
        /// </summary>
        /// <param name="connectorId"><see cref="ConnectorId"/> to check</param>
        /// <returns>True if it is registered, false if not</returns>
        bool Has(ConnectorId connectorId);

        /// <summary>
        /// Get a <see cref="StreamConnector"/> by its identifier
        /// </summary>
        /// <param name="connectorId"><see cref="ConnectorId"/> to get</param>
        /// <returns><see cref="StreamConnector"/></returns>
        StreamConnector GetById(ConnectorId connectorId);



        /// <summary>
        /// Unregister a stream connector
        /// </summary>
        /// <param name="streamConnector"><see cref="StreamConnector"/> to unregister</param>
        void Unregister(StreamConnector streamConnector);
    }
}