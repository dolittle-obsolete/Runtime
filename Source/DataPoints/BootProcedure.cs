/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Booting;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents the <see cref="ICanPerformBootProcedure">boot procedure</see> for data points
    /// </summary>
    public class BootProcedure : ICanPerformBootProcedure
    {
        private readonly IDataPointsStatePullers _dataPointsStatePullers;

        /// <summary>
        /// Initializes a new instance of <see cref="BootProcedure"/>
        /// </summary>
        /// <param name="dataPointsStatePullers"><see cref="IDataPointsStatePullers"/> for pulling data points</param>
        public BootProcedure(IDataPointsStatePullers dataPointsStatePullers)
        {
            _dataPointsStatePullers = dataPointsStatePullers;
        }

        /// <inheritdoc/>
        public bool CanPerform() => true;

        /// <inheritdoc/>
        public void Perform()
        {
            _dataPointsStatePullers.Start();
        }
    }
}
