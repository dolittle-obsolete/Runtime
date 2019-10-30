/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Exception that gets thrown when the 'pushconnectorname' is missing from a request header on a call
    /// </summary>
    public class MissingConnectorNameOnRequestHeader : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MissingConnectorNameOnRequestHeader"/>
        /// </summary>
        public MissingConnectorNameOnRequestHeader() : base("The request header requires the 'pushconnectorname' to be set to the valid name of the connector") {}
    }
}