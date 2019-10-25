/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.TimeSeries.DataTypes.Microservice;
using Dolittle.TimeSeries.Runtime.Identity;

namespace Dolittle.TimeSeries.Runtime.State
{
    /// <summary>
    /// Defines a system that holds the current state of any <see cref="TimeSeriesId">TimeSeries</see>
    /// going through the runtime
    /// </summary>
    public interface IDataPointsState
    {
        /// <summary>
        /// Set the value for a <see cref="TimeSeriesId"/>
        /// </summary>
        /// <param name="dataPoint">DataPoint to set</param>
        void Set(DataPoint dataPoint);

        /// <summary>
        /// Get state for all <see cref="TimeSeriesId">TimeSeries</see> - one <see cref="DataPoint"/> for each
        /// <see cref="TimeSeriesId"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="DataPoint"/></returns>
        IEnumerable<DataPoint> GetAll();
    }
}