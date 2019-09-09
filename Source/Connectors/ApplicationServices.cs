/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Application;
using Dolittle.Services;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindApplicationServices"/> - providing application services
    /// for working with connectors
    /// </summary>
    public class ApplicationServices : ICanBindApplicationServices
    {
        readonly PullConnectorsService _pullConnectorsService;

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationServices"/>
        /// </summary>
        /// <param name="pullConnectorsService"><see cref="PullConnectorsService"/></param>
        public ApplicationServices(PullConnectorsService pullConnectorsService)
        {
            _pullConnectorsService = pullConnectorsService;
        }

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(Server.Grpc.PullConnectors.BindService(_pullConnectorsService), Server.Grpc.PullConnectors.Descriptor)
            };
        }
    }
}