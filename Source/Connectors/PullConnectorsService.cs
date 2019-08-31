/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.Runtime.Connectors.Server.Grpc;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Server.Grpc.PullConnectors;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="PullConnectorsBase"/>
    /// </summary>
    public class PullConnectorsService : PullConnectorsBase
    {
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public PullConnectorsService(ILogger logger)
        {
            
            _logger = logger;
        }

        /// <inheritdoc/>
        public override async Task<RegisterResult> Register(PullConnector pullConnector, ServerCallContext context)
        {
            _logger.Information($"Application client connected");

            await Task.CompletedTask;
            
            return new RegisterResult();
        }
    }
}