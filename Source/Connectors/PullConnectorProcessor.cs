/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client;
using System.Threading;
using Dolittle.Logging;
using Dolittle.Protobuf;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.PullConnector;
using System;
using Dolittle.Runtime.Application;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents a processor that process a <see cref="PullConnector"/>
    /// </summary>
    public class PullConnectorProcessor : IDisposable
    {
        readonly PullConnector _pullConnector;
        readonly IClientFor<PullConnectorClient> _pullConnectorClient;
        readonly ILogger _logger;
        CancellationTokenSource _cancellationTokenSource;
        System.Timers.Timer _timer;

        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorProcessor"/>
        /// </summary>
        /// <param name="pullConnector"><see cref="PullConnector"/> to process</param>
        /// <param name="pullConnectorClient"></param>
        /// <param name="logger"></param>
        public PullConnectorProcessor(PullConnector pullConnector, IClientFor<PullConnectorClient> pullConnectorClient, ILogger logger)
        {
            _logger = logger;
            _pullConnector = pullConnector;
            _cancellationTokenSource = new CancellationTokenSource();
            _timer = new System.Timers.Timer(1000);
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Elapsed += (s, e) => Process();

            _logger.Information($"Starting '{_pullConnector.Name}'");
            
            _timer.Start();

            _pullConnectorClient = pullConnectorClient;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _logger.Information($"Disposing processor for '{_pullConnector.Id}'");
            if (_timer != null) Stop();
            _timer?.Dispose();
            _cancellationTokenSource?.Dispose();
            _timer = null;
            _cancellationTokenSource = null;
        }

        /// <summary>
        /// Stop processing
        /// </summary>
        public void Stop()
        {
            _logger.Information($"Stopping processor for '{_pullConnector.Id}'");
            _timer?.Stop();
            _cancellationTokenSource?.Cancel();
            _timer = null;
            _cancellationTokenSource = null;
        }

        void Process()
        {
            if (_pullConnector.Tags.Count() == 0)
            {
                _logger.Warning($"Connector '{_pullConnector.Name}' does not have any tags - ignoring it completely");
                return;
            }
            

            if (_cancellationTokenSource.Token.IsCancellationRequested)
            {
                _timer.Stop();
                return;
            }

            _logger.Information($"Call connector '{_pullConnector.Name}' - '{_pullConnector.Id}'");
            var request = new grpc.PullRequest
            {
                ConnectorId = _pullConnector.Id.ToProtobuf(),
            };
            request.Tags.Add(_pullConnector.Tags.Select(_ => _.Value));
            _pullConnectorClient.Instance.Pull(request);

            /*
            var data = _connectors[source].GetAllData();
            data.ForEach(dataPoint => 
            {
                _communicationClient.SendAsJson("output", new TagDataPoint<object>
                {
                    Source = source,
                    Tag = dataPoint.Tag,
                    Value = dataPoint.Data,
                    Timestamp = Timestamp.UtcNow
                });
            });
            */

        }

    }

}