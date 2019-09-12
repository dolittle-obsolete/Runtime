/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Runtime.Application;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client.PullConnector;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Grpc.Client;
using System.Threading;
using Dolittle.Protobuf;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represent an implementation of <see cref="IPullConnectors"/>
    /// </summary>
    [Singleton]
    public class PullConnectors : IPullConnectors
    {
        readonly List<PullConnector> _connectors = new List<PullConnector>();
        readonly ILogger _logger;
        readonly IClientFor<PullConnectorClient> _pullConnectorClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pullConnectorClient"></param>
        /// <param name="logger"></param>
        public PullConnectors(
            IClientFor<PullConnectorClient> pullConnectorClient,
            ILogger logger)
        {
            _logger = logger;
            _pullConnectorClient = pullConnectorClient;
        }

        /// <inheritdoc/>
        public void Register(PullConnector pullConnector)
        {
            lock(_connectors)
            {
                _connectors.Add(pullConnector);
                var cancellationToken = new CancellationToken();
                Process(pullConnector, cancellationToken);
            }
        }

        void Process(PullConnector pullConnector, CancellationToken cancellationToken)
        {
            if( pullConnector.Tags.Count() == 0 ) 
            {
                _logger.Warning($"Connector '{pullConnector.Name}' does not have any tags - ignoring it completely");
                return;
            }
            _logger.Information($"Starting '{pullConnector.Name}'");

            var timer = new System.Timers.Timer(pullConnector.Interval);
            timer.Elapsed += (s, e) =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    timer.Stop();
                    return;
                }
                
                _logger.Information($"Call connector '{pullConnector.Name}' - '{pullConnector.Id}'");
                var request = new grpc.PullRequest
                {
                    ConnectorId = pullConnector.Id.ToProtobuf(),
                };
                request.Tags.Add(pullConnector.Tags.Select(_ => _.Value));
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
            };
            timer.AutoReset = true;
            timer.Enabled = true;
        }
    }
}