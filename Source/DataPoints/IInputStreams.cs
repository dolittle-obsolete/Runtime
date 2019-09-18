/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.TimeSeries.DataTypes.Protobuf;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Defines a system that receives <see cref="DataPoint">data points</see> from input streams
    /// </summary>
    public interface IInputStreams
    {
        /// <summary>
        /// Event that fires when a <see cref="DataPoint"/> is received
        /// </summary>
        event DataPointReceived DataPointReceived;

        /// <summary>
        /// Method called by streams when a <see cref="DataPoint"/> is received
        /// </summary>
        /// <param name="dataPoint">Received <see cref="DataPoint"/></param>
        void OnDataPointReceived(DataPoint dataPoint);
    }
}