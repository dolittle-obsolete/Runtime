/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Defines a system for working with all available pull connectors
    /// </summary>
    public interface IPullConnectors
    {
        /// <summary>
        /// Register a <see cref="PullConnector"/>
        /// </summary>
        /// <param name="pullConnector"><see cref="PullConnector"/> to register</param>
        void Register(PullConnector pullConnector);

        /// <summary>
        /// Unregister a <see cref="PullConnector"/>
        /// </summary>
        /// <param name="pullConnector"><see cref="PullConnector"/> to unregister</param>
        void Unregister(PullConnector pullConnector);
    }
}