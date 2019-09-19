/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Threading.Tasks;
using Dolittle.Logging;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.PullConnectors;
using grpc = Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using System;
using System.Timers;
using Dolittle.Collections;
using Dolittle.Protobuf;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using Dolittle.TimeSeries.Runtime.DataPoints;
using Dolittle.TimeSeries.Runtime.Identity;
using Google.Protobuf.WellKnownTypes;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="PullConnectorsBase"/>
    /// </summary>
    public class PullConnectorsService : PullConnectorsBase
    {
        readonly ILogger _logger;
        readonly IPullConnectors _pullConnectors;
        readonly ITimeSeriesMapper _timeSeriesMapper;
        readonly IOutputStreams _outputStreams;

        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="pullConnectors">Actual <see cref="IPullConnectors"/></param>
        /// <param name="timeSeriesMapper"><see cref="ITimeSeriesMapper"/> for mapping data points</param>
        /// <param name="outputStreams">All <see cref="IOutputStreams"/></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public PullConnectorsService(
            IPullConnectors pullConnectors,
            ITimeSeriesMapper timeSeriesMapper,
            IOutputStreams outputStreams,
            ILogger logger)
        {
            _logger = logger;
            _pullConnectors = pullConnectors;
            _timeSeriesMapper = timeSeriesMapper;
            _outputStreams = outputStreams;
        }

        /// <inheritdoc/>
        public override Task Connect(grpc.PullConnector request, IServerStreamWriter<PullRequest> responseStream, ServerCallContext context)
        {
            var id = request.Id.ToGuid();
            var pullConnector = new PullConnector(id, request.Name, request.Interval, request.Tags.Select(_ => (Tag) _));

            Timer timer = null;

            try
            {
                _pullConnectors.Register(pullConnector);

                timer = new Timer(pullConnector.Interval)
                {
                    Enabled = true,
                    AutoReset = true
                };
                timer.Elapsed += (s, e) => 
                { 
                    var pullRequest = new PullRequest();
                    pullRequest.Tags.Add(pullConnector.Tags.Select(_ => (string)_));
                    responseStream.WriteAsync(pullRequest);
                };
                timer.Start();

                context.CancellationToken.ThrowIfCancellationRequested();
                context.CancellationToken.WaitHandle.WaitOne();
            }
            finally
            {
                timer?.Stop();
                timer?.Dispose();

                _pullConnectors.Unregister(pullConnector);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public override Task<Empty> Write(WriteMessage request, ServerCallContext context)
        {
            var connectorId = request.ConnectorId.To<ConnectorId>();
            if (!_pullConnectors.Has(connectorId)) return Task.FromResult(new Empty());
            var connector = _pullConnectors.GetById(connectorId);

            request.Data.ForEach(tagDataPoint =>
            {
                if (!_timeSeriesMapper.HasTimeSeriesFor(connector.Name, tagDataPoint.Tag))
                    _logger.Information($"Unidentified tag '{tagDataPoint.Tag}' from '{connector.Name}'");
                else
                {
                    var dataPoint = new DataPoint
                    {
                        TimeSeries = _timeSeriesMapper.GetTimeSeriesFor(connector.Name, tagDataPoint.Tag).ToProtobuf(),
                        Value = tagDataPoint.Value,
                        Timestamp = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
                    };
                    _outputStreams.Write(dataPoint);
                }
            });

            return Task.FromResult(new Empty());
        }
    }
}