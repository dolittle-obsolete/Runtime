/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Configuration;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents the configuration object for pulling datapoints
    /// </summary>
    [Name("datapointsstate")]
    public class DataPointsStatePullersConfiguration : IConfigurationObject
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DataPointsStatePullersConfiguration"/>
        /// </summary>
        /// <param name="endPoints">All the <see cref="DataPointsStateEndPoint">endpoints</see></param>
        public DataPointsStatePullersConfiguration(IEnumerable<DataPointsStateEndPoint> endPoints)
        {
            EndPoints = endPoints;
        }

        /// <summary>
        /// Gets the <see cref="DataPointsStateEndPoint">endpoints</see>
        /// </summary>
        public IEnumerable<DataPointsStateEndPoint> EndPoints { get; }
    }
}
