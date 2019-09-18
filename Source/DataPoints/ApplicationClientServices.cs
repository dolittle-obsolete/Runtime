/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Application;
using grpc = Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents the client services representation for the runtime
    /// </summary>
    public class ApplicationClientServices : IDefineApplicationClientServices
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationClientServices"/>
        /// </summary>
        public ApplicationClientServices()
        {
            Services = new [] {
                new ClientServiceDefinition(typeof(grpc.DataPointProcessor.DataPointProcessorClient), grpc.DataPointProcessor.Descriptor)
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ClientServiceDefinition> Services { get; }
    }
}