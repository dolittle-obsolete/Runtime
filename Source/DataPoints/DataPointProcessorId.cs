/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Concepts;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents the unique identifier of a <see cref="DataPointProcessor"/>
    /// </summary>
    public class DataPointProcessorId : ConceptAs<Guid>
    {
        /// <summary>
        /// Implicit convert from a <see cref="Guid"/> to <see cref="DataPointProcessorId"/>
        /// </summary>
        /// <param name="value"><see cref="Guid"/> to convert from</param>
        public static implicit operator DataPointProcessorId(Guid value) => new DataPointProcessorId { Value = value };

    }
}