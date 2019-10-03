/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Configuration;

namespace Dolittle.TimeSeries.Runtime.Identity
{
    /// <summary>
    /// Represents a <see cref="ICanProvideDefaultConfigurationFor{T}">default provider</see> for <see cref="TimeSeriesMap"/>
    /// </summary>
    public class TimeSeriesMapConfigurationDefaultProvider : ICanProvideDefaultConfigurationFor<TimeSeriesMap>
    {
        /// <inheritdoc/>
        public TimeSeriesMap Provide()
        {
            return new TimeSeriesMap(new Dictionary<Source, TimeSeriesByTag>());
        }
    }
}