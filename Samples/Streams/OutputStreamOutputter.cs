/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Logging;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using v = Dolittle.TimeSeries.DataTypes.Protobuf.Value;
using m = Dolittle.TimeSeries.DataTypes.Protobuf.Measurement;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.OutputStream;
using System;
using Newtonsoft.Json;
using Dolittle.Protobuf;

namespace Streams
{
    public class OutputStreamOutputter
    {
        readonly ILogger _logger;

        public OutputStreamOutputter(ILogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            Task.Run(async() =>
            {
                var channel = new Channel("localhost:50052", ChannelCredentials.Insecure);
                var client = new OutputStreamClient(channel);

                _logger.Information("Connecting to output stream");

                var stream = client.Open(new Empty());
                while (await stream.ResponseStream.MoveNext())
                {
                    var dataPoint = stream.ResponseStream.Current;
                    _logger.Information($"DataPoint received {JsonConvert.SerializeObject(dataPoint)}");

                    try
                    {
                        if (dataPoint.Value.ValueCase == v.ValueOneofCase.MeasurementValue)
                        {
                            if (dataPoint.Value.MeasurementValue.ValueCase == m.ValueOneofCase.FloatValue)
                            {
                                _logger.Information($"DataPoint for timeseries '{dataPoint.TimeSeries.ToGuid()}' with value '{dataPoint.Value.MeasurementValue.FloatValue}' generated @ '{dataPoint.Timestamp.ToDateTimeOffset()}'");
                            }
                            else
                            {
                                _logger.Information($"Non float measurement DataPoint received");

                            }
                        }
                        else
                        {
                            _logger.Information($"Non measurement DataPoint received");

                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex,"Error interpreting datapoint");

                    }

                }
            });
        }
    }
}