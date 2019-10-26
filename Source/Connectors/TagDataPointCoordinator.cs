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
using Dolittle.TimeSeries.Runtime.Identity;
using Dolittle.TimeSeries.Runtime.State;
using Google.Protobuf.WellKnownTypes;
using grpc = Dolittle.TimeSeries.DataPoints.Runtime;
using grpcDataTypes = Dolittle.TimeSeries.DataTypes.Runtime;
using microserviceDataTypes = Dolittle.TimeSeries.DataTypes.Microservice;
using Dolittle.TimeSeries.Runtime.DataTypes;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="ITagDataPointCoordinator"/>
    /// </summary>
    [Singleton]
    public class TagDataPointCoordinator : ITagDataPointCoordinator
    {
        readonly ITimeSeriesMapper _timeSeriesMapper;
        readonly IDataPointsState _dataPointsState;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="TagDataPointCoordinator"/>
        /// </summary>
        /// <param name="timeSeriesMapper"><see cref="ITimeSeriesMapper"/> for identity mapping of TimeSeries</param>
        /// <param name="dataPointsState"><see cref="IDataPointsState"/> for working with the state</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public TagDataPointCoordinator(
            ITimeSeriesMapper timeSeriesMapper,
            IDataPointsState dataPointsState,
            ILogger logger)
        {
            _timeSeriesMapper = timeSeriesMapper;
            _logger = logger;
            _dataPointsState = dataPointsState;
        }

        /// <inheritdoc/>
        public void Handle(string connectorName, IEnumerable<grpc.TagDataPoint> dataPoints)
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

                    var dataPoint = new microserviceDataTypes.DataPoint
                    {
                        TimeSeries = timeSeriesId.ToProtobuf(),
                        Timestamp = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
                    };

                    switch (tagDataPoint.MeasurementCase)
                    {
                        case grpc.TagDataPoint.MeasurementOneofCase.SingleValue:
                            dataPoint.SingleValue = tagDataPoint.SingleValue.ToMicroservice();
                            break;
                        case grpc.TagDataPoint.MeasurementOneofCase.Vector2Value:
                            dataPoint.Vector2Value = new microserviceDataTypes.Vector2
                            {
                                X = tagDataPoint.Vector2Value.X.ToMicroservice(),
                                Y = tagDataPoint.Vector2Value.Y.ToMicroservice()
                            };
                            break;
                        case grpc.TagDataPoint.MeasurementOneofCase.Vector3Value:
                            dataPoint.Vector3Value = new microserviceDataTypes.Vector3
                            {
                                X = tagDataPoint.Vector3Value.X.ToMicroservice(),
                                Y = tagDataPoint.Vector3Value.Y.ToMicroservice(),
                                Z = tagDataPoint.Vector3Value.Z.ToMicroservice()
                            };
                            break;
                    }

                    _dataPointsState.Set(dataPoint);
                }
            });
        }
    }
}