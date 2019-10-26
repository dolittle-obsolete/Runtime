/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.TimeSeries.DataTypes.Runtime;

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

        /// <summary>
        /// Process a series of <see cref="DataPoint"/> with any of the <see cref="DataPointProcessor"/> that
        /// is interested
        /// </summary>
        void Process(IEnumerable<DataPoint> dataPoints);
    }

}