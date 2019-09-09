/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Dolittle.Runtime.Application;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using static Dolittle.TimeSeries.Runtime.Connectors.Client.Grpc.PullConnector;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Client.Grpc;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represent an implementation of <see cref="IPullConnectors"/>
    /// </summary>
    [Singleton]
    public class PullConnectors : IPullConnectors
    {
        readonly List<PullConnector> _connectors = new List<PullConnector>();

        readonly PullConnectorsConfiguration _configuration;
        readonly ILogger _logger;
        readonly IClientFor<PullConnectorClient> _pullConnectorClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="pullConnectorClient"></param>
        /// <param name="logger"></param>
        public PullConnectors(
            PullConnectorsConfiguration configuration,
            IClientFor<PullConnectorClient> pullConnectorClient,
            ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            _pullConnectorClient = pullConnectorClient;
        }

        /// <inheritdoc/>
        public void Register(PullConnector pullConnector)
        {
            lock(_connectors) _connectors.Add(pullConnector);
        }

        /// <inheritdoc/>
        public void Start()
        {
            lock(_connectors)
            {
                foreach ((Source source, PullConnectorConfiguration configuration) in _configuration)
                {
                    _logger.Information($"Starting '{source}'");
                    var timer = new Timer(configuration.Interval);
                    timer.Elapsed += (s, e) =>
                    {
                        var connector = _connectors.SingleOrDefault(_ => _.Name == source);
                        if (connector != null)
                        {
                            _logger.Information($"Call connector '{source}' - '{connector.Id}'");
                            _pullConnectorClient.Instance.Pull(new grpc.PullRequest());
                        }
                        else
                        {
                            _logger.Information($"Connector '{source}' has not been registered yet");
                       }

                       

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
    }
}