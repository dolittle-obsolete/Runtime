/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Dolittle.Configuration;

namespace Dolittle.TimeSeries.Runtime.Identity
{
    /// <summary>
    /// Represents the configuration for timeseries and their relationship to source and tags
    /// </summary>
    [Name("timeseriesmap")]
    public class TimeSeriesMap :
        ReadOnlyDictionary<Source, TimeSeriesByTag>,
        IConfigurationObject
    {
        /// <summary>
        /// Initializes a new instace of <see cref="TimeSeriesMap"/>
        /// </summary>
        /// <param name="timeSeriesByTag">Dictionary to initialize configuration with</param>
        public TimeSeriesMap(IDictionary<Source, TimeSeriesByTag> timeSeriesByTag) : base(timeSeriesByTag){}
    }
}