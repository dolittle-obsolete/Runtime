/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.TimeSeries.Runtime.Identity;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an endpoint for getting timeseries
    /// </summary>
    public class TimeSeriesEndpoint
    {
        readonly ITimeSeriesState _timeSeriesState;

        /// <summary>
        /// Initializes a new instance of <see cref="TimeSeriesEndpoint"/>
        /// </summary>
        /// <param name="timeSeriesState"><see cref="ITimeSeriesState"/> for working with the state</param>
        public TimeSeriesEndpoint(ITimeSeriesState timeSeriesState)
        {
            _timeSeriesState = timeSeriesState;
        }

        /// <inheritdoc/>
        public void Start()
        {
            Task.Run(() =>
            {
                using (var listener = new HttpListener())
                {
                    listener.Prefixes.Add("http://*:8080/timeseries/");
                    listener.Start();

                    for (; ; )
                    {
                        var context = listener.GetContext();
                        var response = context.Response;

                        var state = _timeSeriesState.GetAll();
                        foreach ((var timeSeriesId, var value) in state)
                        {
                            List<string> valueStrings = GetValueStrings(timeSeriesId, value);

                            valueStrings.ForEach(_ =>
                            {
                                var bytes = Encoding.UTF8.GetBytes(_);
                                response.OutputStream.Write(bytes, 0, bytes.Length);
                            });
                        }

                        response.OutputStream.Close();
                    }
                }
            });
        }

        List<string> GetValueStrings(TimeSeriesId timeSeriesId, Value value)
        {
            var valueStrings = new List<string>();

            void AddValueString(double actualValue, string postfix = "")
            {
                var idAsString = $"{timeSeriesId.ToString().Replace("-", "_")}";
                if (!string.IsNullOrEmpty(postfix)) idAsString = $"{idAsString}:{postfix}";
                valueStrings.Add($"id:{idAsString} {actualValue}\n");
            }

            switch (value.ValueCase)
            {
                case Value.ValueOneofCase.MeasurementValue:
                    AddValueString(value.MeasurementValue.Value);
                    break;

                case Value.ValueOneofCase.Vector2Value:
                    AddValueString(value.Vector2Value.X.Value);
                    AddValueString(value.Vector2Value.Y.Value);
                    break;

                case Value.ValueOneofCase.Vector3Value:
                    AddValueString(value.Vector3Value.X.Value);
                    AddValueString(value.Vector3Value.Y.Value);
                    AddValueString(value.Vector3Value.Y.Value);
                    break;
            }

            return valueStrings;
        }
    }
}
