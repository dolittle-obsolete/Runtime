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
        /// Start all pull connectors
        /// </summary>
        void Start();
    }
}