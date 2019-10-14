/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.TimeSeries.Runtime.Identity;
using System.Collections.Generic;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Defines a system that holds the current state of any <see cref="TimeSeriesId">TimeSeries</see>
    /// going through the runtime
    /// </summary>
    public interface ITimeSeriesState
    {
        /// <summary>
        /// Set the value for a <see cref="TimeSeriesId"/>
        /// </summary>
        /// <param name="timeSeriesId"><see cref="TimeSeriesId"/> to set for</param>
        /// <param name="value">Value to set</param>
        void Set(TimeSeriesId timeSeriesId, Value value);

        /// <summary>
        /// Get state for all <see cref="TimeSeriesId">TimeSeries</see>
        /// </summary>
        /// <returns><see cref="IDictionary{TKey,TValue}"/></returns>
        IDictionary<TimeSeriesId, Value> GetAll();
    }
}