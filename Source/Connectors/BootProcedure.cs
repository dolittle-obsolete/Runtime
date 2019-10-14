/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Booting;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents the <see cref="ICanPerformBootProcedure">boot procedure</see> 
    /// </summary>
    public class BootProcedure : ICanPerformBootProcedure
    {
        readonly TimeSeriesEndpoint _timeSeriesEndpoint;

        /// <summary>
        /// Initializes a new instance of <see cref="BootProcedure"/>
        /// </summary>
        /// <param name="timeSeriesEndpoint"><see cref="TimeSeriesEndpoint"/> to start</param>
        public BootProcedure(TimeSeriesEndpoint timeSeriesEndpoint)
        {
            _timeSeriesEndpoint = timeSeriesEndpoint;
        }

        /// <inheritdoc/>
        public bool CanPerform() => true;

        /// <inheritdoc/>
        public void Perform()
        {
            _timeSeriesEndpoint.Start();
        }
    }
}
