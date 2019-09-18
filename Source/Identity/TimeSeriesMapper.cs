/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.TimeSeries.Runtime.Identity
{
    /// <summary>
    /// Represents an implementation of <see cref="ITimeSeriesMapper"/>
    /// </summary>
    public class TimeSeriesMapper : ITimeSeriesMapper
    {
        readonly TimeSeriesMap _timeSeriesMap;

        /// <summary>
        /// Initializes a new instance of <see cref="TimeSeriesMapper"/>
        /// </summary>
        /// <param name="timeSeriesMap"><see cref="TimeSeriesMap"/></param>
        public TimeSeriesMapper(TimeSeriesMap timeSeriesMap)
        {
            _timeSeriesMap = timeSeriesMap;
        }

        /// <inheritdoc/>
        public TimeSeriesId GetTimeSeriesFor(Source source, Tag tag)
        {
            ThrowIfMissingSystem(source);
            ThrowIfTagIsMissingInSystem(source, tag);
            return _timeSeriesMap[source][tag];
        }

        /// <inheritdoc/>
        public bool HasTimeSeriesFor(Source source, Tag tag)
        {
            if( !_timeSeriesMap.ContainsKey(source)) return false;
            if( !_timeSeriesMap[source].ContainsKey(tag)) return false;
            return true;
        }

        void ThrowIfMissingSystem(Source source)
        {
            if( !_timeSeriesMap.ContainsKey(source)) throw new MissingSource(source);
        }

        void ThrowIfTagIsMissingInSystem(Source source, Tag tag)
        {
            if( !_timeSeriesMap[source].ContainsKey(tag)) throw new MissingTagInSource(source, tag);
        }
    }
}