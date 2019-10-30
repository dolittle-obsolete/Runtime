/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Heads;
using Dolittle.Services;
using grpc = Dolittle.TimeSeries.Connectors.Runtime;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindRuntimeServices"/> - providing runtime services
    /// for working with connectors
    /// </summary>
    public class RuntimeServices : ICanBindRuntimeServices
    {
        readonly PullConnectorsService _pullConnectorsService;
        readonly PushConnectorsService _pushConnectorsService;

        /// <summary>
        /// Initializes a new instance of <see cref="RuntimeServices"/>
        /// </summary>
        /// <param name="pullConnectorsService">Instance of <see cref="PullConnectorsService"/></param>
        /// <param name="pushConnectorsService">Instance of <see cref="PushConnectorsService"/></param>
        public RuntimeServices(PullConnectorsService pullConnectorsService, PushConnectorsService pushConnectorsService)
        {
            _pullConnectorsService = pullConnectorsService;
            _pushConnectorsService = pushConnectorsService;
        }

        /// <inheritdoc/>
        public ServiceAspect Aspect => "TimeSeries";

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(_pullConnectorsService, grpc.PullConnectors.BindService(_pullConnectorsService), grpc.PullConnectors.Descriptor),
                new Service(_pushConnectorsService, grpc.PushConnectors.BindService(_pushConnectorsService), grpc.PushConnectors.Descriptor)
            };
        }
    }
}