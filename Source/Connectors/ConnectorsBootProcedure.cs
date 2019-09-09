/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Booting;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Provides a <see cref="ICanPerformBootProcedure">boot procedure</see> for connectors
    /// </summary>
    public class ConnectorsBootProcedure : ICanPerformBootProcedure
    {
        readonly IPullConnectors _pullConnectors;

        /// <summary>
        /// Initializes a new instance of <see cref="ConnectorsBootProcedure"/>
        /// </summary>
        /// <param name="pullConnectors"><see cref="IPullConnectors"/> to boot</param>
        public ConnectorsBootProcedure(IPullConnectors pullConnectors)
        {
            _pullConnectors = pullConnectors;
        }

        /// <inheritdoc/>
        public bool CanPerform() => true;

        /// <inheritdoc/>
        public void Perform()
        {
            _pullConnectors.Start();
        }
    }
}