/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Lifecycle;
using Dolittle.TimeSeries.DataTypes.Protobuf;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="IInputStreams"/>
    /// </summary>
    [Singleton]
    public class InputStreams : IInputStreams
    {
        /// <inheritdoc/>
        public event DataPointReceived DataPointReceived = (d) => {};

        /// <inheritdoc/>
        public void OnDataPointReceived(DataPoint dataPoint)
        {
            DataPointReceived(dataPoint);
        }
    }
}