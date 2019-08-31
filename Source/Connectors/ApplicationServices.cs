/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Logging;
using Dolittle.Runtime.Grpc;
using Grpc.Core;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindApplicationServices"/> - providing application services
    /// for working with connectors
    /// </summary>
    public class ApplicationServices : ICanBindApplicationServices
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationServices"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public ApplicationServices(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public IEnumerable<ServerServiceDefinition> BindServices()
        {
            var service = new PullConnectorsService(_logger);
            return new ServerServiceDefinition[] {
                Server.Grpc.PullConnectors.BindService(service)
            };
        }
    }
}