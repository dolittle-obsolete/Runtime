/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Defines a system for working with <see cref="DataPointProcessor"/>
    /// </summary>
    public interface IDataPointProcessors
    {
        /// <summary>
        /// Register a <see cref="DataPointProcessor"/>
        /// </summary>
        /// <param name="dataPointProcessor"><see cref="DataPointProcessor"/> to register</param>
        void Register(DataPointProcessor dataPointProcessor);

        /// <summary>
        /// Unregister a <see cref="DataPointProcessor"/>
        /// </summary>
        /// <param name="dataPointProcessor"><see cref="DataPointProcessor"/> to unregister</param>
        void Unregister(DataPointProcessor dataPointProcessor);
    }

}