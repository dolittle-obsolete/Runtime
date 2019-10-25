/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Defines a system that is capable of pulling data point state from other Microservice runtimes
    /// </summary>
    public interface IDataPointsStatePullers
    {
        /// <summary>
        /// Start the puller mechanism
        /// </summary>
        void Start();
    }
}
