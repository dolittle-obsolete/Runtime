/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Threading.Tasks;
using Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.StreamConnectors;
using System;
using Dolittle.Logging;
using Google.Protobuf.WellKnownTypes;
using Dolittle.Collections;
using Dolittle.TimeSeries.Runtime.Identity;
using Dolittle.TimeSeries.Runtime.DataPoints;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.Protobuf;

namespace Dolittle.TimeSeries.Runtime.Connectors
{

    /// <summary>
    /// Represents an implementation of <see cref="StreamConnectorsBase"/>
    /// </summary>
    public class StreamConnectorsService : StreamConnectorsBase
    {
        readonly ITimeSeriesMapper _timeSeriesMapper;
        readonly IStreamConnectors _streamConnectors;
        readonly IOutputStreams _outputStreams;
        readonly ILogger _logger;
        readonly ITimeSeriesState _timeSeriesState;


        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="streamConnectors">Actual <see cref="IStreamConnectors"/></param>
        /// <param name="timeSeriesMapper"><see cref="ITimeSeriesMapper"/> for mapping data points</param>
        /// <param name="outputStreams">All <see cref="IOutputStreams"/></param>
        /// <param name="timeSeriesState"></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public StreamConnectorsService(
            IStreamConnectors streamConnectors,
            ITimeSeriesMapper timeSeriesMapper,
            IOutputStreams outputStreams,
            ITimeSeriesState timeSeriesState,
            ILogger logger)
        {
            _logger = logger;
            _streamConnectors = streamConnectors;
            _timeSeriesMapper = timeSeriesMapper;
            _outputStreams = outputStreams;
            _timeSeriesState = timeSeriesState;
        }

        /// <inheritdoc/>
        public override async Task<Empty> Open(IAsyncStreamReader<StreamTagDataPoints> requestStream, ServerCallContext context)
        {
            var streamConnectorIdAsString = context.RequestHeaders.SingleOrDefault(_ => string.Equals(_.Key, "streamconnectorid", StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (string.IsNullOrEmpty(streamConnectorIdAsString)) throw new MissingConnectorIdentifierOnRequestHeader();
            var streamConnectorName = context.RequestHeaders.SingleOrDefault(_ => string.Equals(_.Key, "streamconnectorname", StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (string.IsNullOrEmpty(streamConnectorName)) throw new MissingConnectorNameOnRequestHeader();
            var id = (ConnectorId) Guid.Parse(streamConnectorIdAsString);

            StreamConnector streamConnector = null;
            try
            {
                _logger.Information($"Register connector : '{streamConnectorName}' with Id: '{id}'");
                streamConnector = new StreamConnector(id, streamConnectorName);
                _streamConnectors.Register(streamConnector);

                while (await requestStream.MoveNext().ConfigureAwait(false))
                {
                    requestStream.Current.DataPoints.ForEach(tagDataPoint =>
                    {
                        if (!_timeSeriesMapper.HasTimeSeriesFor(streamConnectorName, tagDataPoint.Tag))
                        {
                            _logger.Information($"Unidentified tag '{tagDataPoint.Tag}' from '{streamConnectorName}'");
                        }
                        else
                        {
                            _logger.Information("DataPoint received");
                            var timeSeriesId = _timeSeriesMapper.GetTimeSeriesFor(streamConnectorName, tagDataPoint.Tag);

                            var dataPoint = new DataPoint
                            {
                                TimeSeries = timeSeriesId.ToProtobuf(),
                                Value = tagDataPoint.Value,
                                Timestamp = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
                            };
                            _outputStreams.Write(dataPoint);
                            _timeSeriesState.Set(timeSeriesId, dataPoint.Value);
                        }
                    });
               }
            }
            finally
            {
                if( streamConnector != null ) _streamConnectors.Unregister(streamConnector);
            }

            return new Empty();
        }
    }
}