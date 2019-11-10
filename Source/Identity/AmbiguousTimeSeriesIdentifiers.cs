/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dolittle.TimeSeries.Runtime.Identity
{
    /// <summary>
    /// Exception that gets thrown when are multiple <see cref="ICanIdentifyTimeSeries">time series identifiers</see> 
    /// that can identify a <see cref="TimeSeriesId"/>
    /// </summary>
    public class AmbiguousTimeSeriesIdentifiers : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AmbiguousTimeSeriesIdentifiers"/>
        /// </summary>
        /// <param name="source"><see cref="Source"/> that has ambiguity</param>
        /// <param name="tag"><see cref="Tag"/> that has ambiguity</param>
        /// <param name="identifiers"><see cref="IEnumerable{T}"/> of <see cref="ICanIdentifyTimeSeries"/> that are able to identify</param>
        public AmbiguousTimeSeriesIdentifiers(Source source, Tag tag, IEnumerable<ICanIdentifyTimeSeries> identifiers)
            : base($"Ambiguous TimeSeries identity when identifying '{source}' and '{tag}' - identifiers : '{string.Join(", ", identifiers.Select(_ => _.GetType().AssemblyQualifiedName))}'")
        {

        }
    }
}