/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Dolittle.Collections;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Protobuf;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.TimeSeries.Runtime.DataPoints;
using Dolittle.TimeSeries.Runtime.DataPoints.Grpc;
using Dolittle.TimeSeries.Runtime.Identity;
using Google.Protobuf.WellKnownTypes;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="ITagDataPointCoordinator"/>
    /// </summary>
    [Singleton]
    public class TagDataPointCoordinator : ITagDataPointCoordinator
    {
        readonly ITimeSeriesMapper _timeSeriesMapper;
        readonly IOutputStreams _outputStreams;
        readonly ITimeSeriesState _timeSeriesState;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="TagDataPointCoordinator"/>
        /// </summary>
        /// <param name="timeSeriesMapper"><see cref="ITimeSeriesMapper"/> for identity mapping of TimeSeries</param>
        /// <param name="outputStreams">All <see cref="IOutputStreams"/></param>
        /// <param name="timeSeriesState"><see cref="ITimeSeriesState"/> for working with the state</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public TagDataPointCoordinator(
            ITimeSeriesMapper timeSeriesMapper,
            IOutputStreams outputStreams,
            ITimeSeriesState timeSeriesState,
            ILogger logger)
        {
            _timeSeriesMapper = timeSeriesMapper;
            _logger = logger;
            _outputStreams = outputStreams;
            _timeSeriesState = timeSeriesState;
        }

        /// <inheritdoc/>
        public void Handle(string connectorName, IEnumerable<TagDataPoint> dataPoints)
        {
            dataPoints.ForEach(tagDataPoint =>
            {
                if (!_timeSeriesMapper.HasTimeSeriesFor(connectorName, tagDataPoint.Tag))
                {
                    _logger.Information($"Unidentified tag '{tagDataPoint.Tag}' from '{connectorName}'");
                }
                else
                {
                    _logger.Information("DataPoint received");
                    var timeSeriesId = _timeSeriesMapper.GetTimeSeriesFor(connectorName, tagDataPoint.Tag);

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
}