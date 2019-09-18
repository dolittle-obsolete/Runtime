/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.TimeSeries.DataTypes.Protobuf;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Defines the system for working with all output streams connected
    /// </summary>
    public interface IOutputStreams
    {
        /// <summary>
        /// Event for when a <see cref="DataPoint"/> has received
        /// </summary>
        event DataPointReceived Received;

        /// <summary>
        /// Write to all output streams
        /// </summary>
        /// <param name="dataPoint"><see cref="DataPoint"/> to write</param>
        void Write(DataPoint dataPoint);
    }
}