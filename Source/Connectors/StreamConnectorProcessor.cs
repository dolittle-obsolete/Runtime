/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Logging;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.StreamConnector;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.Collections;
using Dolittle.Protobuf;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.TimeSeries.Runtime.DataPoints;
using Google.Protobuf.WellKnownTypes;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents a processor that process a <see cref="StreamConnector"/>
    /// </summary>
    public class StreamConnectorProcessor : IDisposable
    {
        readonly StreamConnector _connector;
        readonly IClientFor<StreamConnectorClient> _client;
        readonly ILogger _logger;
        readonly IOutputStreams _outputStreams;
        CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// Initializes a new instance of <see cref="StreamConnectorProcessor"/>
        /// </summary>
        /// <param name="connector"><see cref="StreamConnector"/> to process for</param>
        /// <param name="client"><see cref="IClientFor{T}">Client for</see> <see cref="StreamConnectorClient"/></param>
        /// <param name="outputStreams">All <see cref="IOutputStreams"/></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public StreamConnectorProcessor(
            StreamConnector connector,
            IClientFor<StreamConnectorClient> client,
            IOutputStreams outputStreams,
            ILogger logger)
        {
            _connector = connector;
            _client = client;
            _logger = logger;
            _cancellationTokenSource = new CancellationTokenSource();

            Process();
            _outputStreams = outputStreams;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        /// <summary>
        /// Stop processing
        /// </summary>
        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
        }

        void Process()
        {
            if (_connector.Tags.Count() == 0)
            {
                _logger.Warning($"Connector '{_connector.Name}' does not have any tags - ignoring it completely");
                return;
            }
            _logger.Information($"Connecting to '{_connector.Name}' - {_connector.Id}");

            var request = new grpc.StreamRequest
            {
                ConnectorId = _connector.Id.ToProtobuf(),
            };
            request.Tags.Add(_connector.Tags.Select(_ => _.Value));

            Task.Run(async() =>
            {
                var stream = _client.Instance.Connect(request);
                while (await stream.ResponseStream.MoveNext(_cancellationTokenSource.Token))
                {
                    var dataPointTags = string.Join(", ", stream.ResponseStream.Current.DataPoints.Select(_ => _.Tag));

                    _logger.Information($"Data received for tags {dataPointTags}");

                    stream.ResponseStream.Current.DataPoints.ForEach(tagDataPoint =>
                    {
                        var dataPoint = new DataPoint
                        {
                            Value = tagDataPoint.Value,
                            Timestamp = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
                        };
                        _outputStreams.Write(dataPoint);
                    });
                }

                _logger.Information("Stream disconnected");
            });
        }

    }
}