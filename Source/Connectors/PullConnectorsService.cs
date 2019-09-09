/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.Runtime.Connectors.Server.Grpc;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Server.Grpc.PullConnectors;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Server.Grpc;

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
            var id = new Guid(pullConnector.Id.Value.ToByteArray());
            _logger.Information($"Register connector : '{pullConnector.Name}' with Id: '{id}'");
            _pullConnectors.Register(new PullConnector(id, pullConnector.Name));

            return Task.FromResult(new RegisterResult());
        }
    }
}