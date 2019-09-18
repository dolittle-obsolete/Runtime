/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Services;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents a <see cref="IRepresentServiceType">host type</see> that is for application communication
    /// </summary>
    /// <remarks>
    /// Application is considered the channel in which a representation of the application is talking - 
    /// typically and SDK
    /// </remarks>
    public class ApplicationServiceType : IRepresentServiceType
    {
        /// <inheritdoc/>
        public ServiceType Identifier => "DataPoint";

        /// <inheritdoc/>
        public Type BindingInterface => typeof(ICanBindDataPointServices);

        /// <inheritdoc/>
        public EndpointVisibility Visibility => EndpointVisibility.Public;
    }
}