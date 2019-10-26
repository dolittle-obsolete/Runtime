/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Configuration;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents a <see cref="ICanProvideDefaultConfigurationFor{T}">default configuration provider</see>
    /// for <see cref="DataPointsStatePullersConfiguration"/>
    /// </summary>
    public class DataPointsStatePullersDefaultConfigurationProvider : ICanProvideDefaultConfigurationFor<DataPointsStatePullersConfiguration>
    {
        /// <inheritdoc/>
        public DataPointsStatePullersConfiguration Provide()
        {
            return new DataPointsStatePullersConfiguration(new DataPointsStateEndPoint[0]);
        }
    }
}
