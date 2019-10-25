/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Concurrent;
using System.Collections.Generic;
using Dolittle.Lifecycle;
using Dolittle.Protobuf;
using Dolittle.TimeSeries.DataTypes.Microservice;
using Dolittle.TimeSeries.Runtime.Identity;

namespace Dolittle.TimeSeries.Runtime.State
{
    /// <summary>
    /// Represents an implementation of <see cref="IDataPointsState"/>
    /// </summary>
    [Singleton]
    public class DataPointsState : IDataPointsState
    {
        readonly ConcurrentDictionary<TimeSeriesId, DataPoint> _dataPointsPerTimeSeries = new ConcurrentDictionary<TimeSeriesId, DataPoint>();

        /// <inheritdoc/>
        public IEnumerable<DataPoint> GetAll()
        {
            return _dataPointsPerTimeSeries.Values;
        }

        /// <inheritdoc/>
        public void Set(DataPoint dataPoint)
        {
            _dataPointsPerTimeSeries[dataPoint.TimeSeries.ToGuid()] = dataPoint;
        }
    }
}