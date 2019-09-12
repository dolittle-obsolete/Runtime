/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.StreamConnector;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client;
using System.Threading;
using Dolittle.Protobuf;
using System.Threading.Tasks;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represent an implementation of <see cref="IStreamConnectors"/>
    /// </summary>
    [Singleton]
    public class StreamConnectors : IStreamConnectors
    {
        readonly List<StreamConnector> _connectors = new List<StreamConnector>();
        readonly ILogger _logger;
        readonly IClientFor<StreamConnectorClient> _streamConnectorClient;

        /// <summary>
        /// Initializes a new instance of <see cref="StreamConnectors"/>
        /// </summary>
        /// <param name="streamConnectorClient"></param>
        /// <param name="logger"></param>
        public StreamConnectors(
            IClientFor<StreamConnectorClient> streamConnectorClient,
            ILogger logger)
        {
            _logger = logger;
            _streamConnectorClient = streamConnectorClient;
        }

        /// <inheritdoc/>
        public void Register(StreamConnector streamConnector)
        {
            lock(_connectors)
            {
                _connectors.Add(streamConnector);
                var cancellationToken = new CancellationToken();
                Process(streamConnector, cancellationToken);
            }
        }

        void Process(StreamConnector streamConnector, CancellationToken cancellationToken)
        {
            if (streamConnector.Tags.Count() == 0)
            {
                _logger.Warning($"Connector '{streamConnector.Name}' does not have any tags - ignoring it completely");
                return;
            }
            _logger.Information($"Connecting to '{streamConnector.Name}' - {streamConnector.Id}");

            var request = new grpc.StreamRequest
            {
                ConnectorId = streamConnector.Id.ToProtobuf(),
            };
            request.Tags.Add(streamConnector.Tags.Select(_ => _.Value));

            Task.Run(async() =>
            {
                var stream = _streamConnectorClient.Instance.Connect(request);
                while (await stream.ResponseStream.MoveNext(cancellationToken))
                {
                    _logger.Information("Data received");
                }

                _logger.Information("Stream disconnected");
            });
        }
    }
}