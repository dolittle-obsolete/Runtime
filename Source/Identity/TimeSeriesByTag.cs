/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dolittle.TimeSeries.Runtime.Identity
{
    /// <summary>
    /// Represents the mapping between a <see cref="Tag"/> and a <see cref="TimeSeriesId"/>
    /// </summary>
    public class TimeSeriesByTag : ReadOnlyDictionary<Tag, TimeSeriesId>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TimeSeriesByTag"/>
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public TimeSeriesByTag(IDictionary<Tag, TimeSeriesId> configuration) : base(configuration) {}
    }
}