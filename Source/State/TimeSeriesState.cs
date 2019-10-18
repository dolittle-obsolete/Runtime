/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Dolittle.Lifecycle;
using Dolittle.TimeSeries.Runtime.DataTypes;
using Dolittle.TimeSeries.Runtime.Identity;

namespace Dolittle.TimeSeries.Runtime.State
{
    /// <summary>
    /// Represents an implementation of <see cref="ITimeSeriesState"/>
    /// </summary>
    [Singleton]
    public class TimeSeriesState : ITimeSeriesState
    {
        readonly ConcurrentDictionary<TimeSeriesId, Value> _dataPointsPerTimeSeries = new ConcurrentDictionary<TimeSeriesId, Value>();

        /// <inheritdoc/>
        public IDictionary<TimeSeriesId, Value> GetAll()
        {
            return _dataPointsPerTimeSeries.ToDictionary(_ => _.Key, _ => _.Value);
        }

        /// <inheritdoc/>
        public void Set(TimeSeriesId timeSeriesId, Value value)
        {
            _dataPointsPerTimeSeries[timeSeriesId] = value;
        }
    }
}