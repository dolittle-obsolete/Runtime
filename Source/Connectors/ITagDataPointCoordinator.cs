/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.TimeSeries.Runtime.DataPoints.Grpc;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Defines a system that is capable of coordinating the work for <see cref="TagDataPoint">tag based datapoints</see>
    /// </summary>
    public interface ITagDataPointCoordinator
    {
        /// <summary>
        /// Handle <see cref="IEnumerable{T}"/> of <see cref="TagDataPoint"/>
        /// </summary>
        /// <param name="connectorName">Name of the connector</param>
        /// <param name="dataPoints"><see cref="TagDataPoint">Tag data points</see> to handle</param>
        void Handle(string connectorName, IEnumerable<TagDataPoint> dataPoints);
    }
}