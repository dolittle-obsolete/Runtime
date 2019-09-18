/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Exception that gets thrown when the 'tags' is missing from a request header on a call
    /// </summary>
    public class MissingTagsOnRequestHeader : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MissingTagsOnRequestHeader"/>
        /// </summary>
        public MissingTagsOnRequestHeader() : base("The request header requires the 'tags' to be set to comma separated list of tags available") {}
    }
}