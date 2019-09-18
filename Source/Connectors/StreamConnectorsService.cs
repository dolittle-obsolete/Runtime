/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Threading.Tasks;
using Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.StreamConnectors;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using Dolittle.Logging;
using Dolittle.Protobuf;
using Dolittle.Runtime.Application;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="StreamConnectorsBase"/>
    /// </summary>
    public class StreamConnectorsService : StreamConnectorsBase
    {
        readonly ILogger _logger;
        readonly IStreamConnectors _streamConnectors;

        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="streamConnectors">Actual <see cref="IStreamConnectors"/></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public StreamConnectorsService(IStreamConnectors streamConnectors, ILogger logger)
        {
            _logger = logger;
            _streamConnectors = streamConnectors;
        }

        /// <inheritdoc/>
        public override Task<RegisterResult> Register(grpc.StreamConnector streamConnector, ServerCallContext context)
        {
            var id = streamConnector.Id.ToGuid();
            _logger.Information($"Register connector : '{streamConnector.Name}' with Id: '{id}'");
            var streamConnectorInstance = new StreamConnector(id, streamConnector.Name, streamConnector.Tags.Select(_ => (Tag) _));
            _streamConnectors.Register(streamConnectorInstance);

            context.OnDisconnected(_ => _streamConnectors.Unregister(streamConnectorInstance));

            return Task.FromResult(new RegisterResult());
        }
    }
}