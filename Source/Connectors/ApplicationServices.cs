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
        private readonly StreamConnectorsService _streamConnectorsService;

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationServices"/>
        /// </summary>
        /// <param name="pullConnectorsService">Instance of <see cref="PullConnectorsService"/></param>
        /// <param name="streamConnectorsService">Instance of <see cref="StreamConnectorsService"/></param>
        public ApplicationServices(PullConnectorsService pullConnectorsService, StreamConnectorsService streamConnectorsService)
        {
            _pullConnectorsService = pullConnectorsService;
            _streamConnectorsService = streamConnectorsService;
        }

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(Grpc.Server.PullConnectors.BindService(_pullConnectorsService), Grpc.Server.PullConnectors.Descriptor),
                new Service(Grpc.Server.StreamConnectors.BindService(_streamConnectorsService), Grpc.Server.StreamConnectors.Descriptor)
            };
        }
    }
}