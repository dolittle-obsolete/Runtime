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
    }
}