/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Client.Grpc.PullConnector;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents the <see cref="ClientServiceDefinition">definitions</see> of exposed client services
    /// </summary>
    public class ClientServices : IDefineApplicationClientServices
    {
        /// <inheritdoc/>

        public IEnumerable<ClientServiceDefinition> Services => new []
        {
            new ClientServiceDefinition(typeof(PullConnectorClient), Descriptor)
        };
    }
}