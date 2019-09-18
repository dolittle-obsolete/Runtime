/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents a processor of data points
    /// </summary>
    public class DataPointProcessor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessor"/>
        /// </summary>
        /// <param name="id"></param>
        public DataPointProcessor(DataPointProcessorId id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the unique identifier for a <see cref="DataPointProcessor"/>
        /// </summary>
        public DataPointProcessorId Id {  get; }
    }
}