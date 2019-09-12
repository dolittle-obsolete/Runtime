/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.PullConnector;

namespace Dolittle.TimeSeries.Runtime.Connectors
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
                new ClientServiceDefinition(typeof(PullConnectorClient), Descriptor)
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ClientServiceDefinition> Services { get; }
    }
}