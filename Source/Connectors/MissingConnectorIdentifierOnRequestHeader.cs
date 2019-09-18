/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Exception that gets thrown when the 'streamconnectorid' is missing from a request header on a call
    /// </summary>
    public class MissingConnectorIdentifierOnRequestHeader : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MissingConnectorIdentifierOnRequestHeader"/>
        /// </summary>
        public MissingConnectorIdentifierOnRequestHeader() : base("The request header requires the 'streamconnectorid' to be set to a valid GUID representing the connector") {}
    }
}