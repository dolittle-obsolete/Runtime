/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.TimeSeries.DataTypes.Runtime;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Delegate that represents the callback for when a <see cref="DataPoint"/> has received
    /// </summary>
    /// <param name="dataPoint"></param>
    public delegate void DataPointReceived(DataPoint dataPoint);
}