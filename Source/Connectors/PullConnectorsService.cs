/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.PullConnectors;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using Dolittle.Protobuf;
using Dolittle.Runtime.Application;
using System;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="PullConnectorsBase"/>
    /// </summary>
    public class PullConnectorsService : PullConnectorsBase
    {
        readonly ILogger _logger;
        readonly IPullConnectors _pullConnectors;
        
        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        /// <param name="pullConnectors">Actual <see cref="IPullConnectors"/></param>
        public PullConnectorsService(ILogger logger, IPullConnectors pullConnectors)
        {
            _logger = logger;
            _pullConnectors = pullConnectors;
        }

        /// <inheritdoc/>
        public override Task<RegisterResult> Register(grpc.PullConnector pullConnector, ServerCallContext context)
        {
            var id = pullConnector.Id.ToGuid();
            var pullConnectorInstance = new PullConnector(id, pullConnector.Name, pullConnector.Interval, pullConnector.Tags.Select(_ => (Tag) _));
            _pullConnectors.Register(pullConnectorInstance);

            context.OnDisconnected(_ => _pullConnectors.Unregister(pullConnectorInstance));
            
            return Task.FromResult(new RegisterResult());
        }
    }
}