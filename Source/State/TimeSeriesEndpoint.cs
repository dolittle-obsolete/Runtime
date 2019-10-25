/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dolittle.TimeSeries.DataTypes.Microservice;
using Dolittle.TimeSeries.Runtime.Identity;
using Dolittle.Collections;
using Dolittle.Protobuf;

namespace Dolittle.TimeSeries.Runtime.State
{
    /// <summary>
    /// Represents an endpoint for getting timeseries
    /// </summary>
    public class TimeSeriesEndpoint
    {
        readonly IDataPointsState _timeSeriesState;

        /// <summary>
        /// Initializes a new instance of <see cref="TimeSeriesEndpoint"/>
        /// </summary>
        /// <param name="timeSeriesState"><see cref="IDataPointsState"/> for working with the state</param>
        public TimeSeriesEndpoint(IDataPointsState timeSeriesState)
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

                        _timeSeriesState.GetAll().ForEach(dataPoint => {

                            var valueStrings = GetValueStrings(dataPoint.TimeSeries.ToGuid(), dataPoint);

                            valueStrings.ForEach(_ =>
                            {
                                var bytes = Encoding.UTF8.GetBytes(_);
                                response.OutputStream.Write(bytes, 0, bytes.Length);
                            });
                        });

                        response.OutputStream.Close();
                    }
                }
            });
        }

        IEnumerable<string> GetValueStrings(TimeSeriesId timeSeriesId, DataPoint dataPoint)
        {
            var valueStrings = new List<string>();

            void AddValueString(double actualValue, string postfix = "")
            {
                var idAsString = $"{timeSeriesId.ToString().Replace("-", "_")}";
                if (!string.IsNullOrEmpty(postfix)) idAsString = $"{idAsString}:{postfix}";
                valueStrings.Add($"id:{idAsString} {actualValue}\n");
            }

            switch (dataPoint.Value.ValueCase)
            {
                case Value.ValueOneofCase.MeasurementValue:
                    AddValueString(dataPoint.Value.MeasurementValue.Value);
                    AddValueString(dataPoint.Value.MeasurementValue.Error, "error");
                    break;

                case Value.ValueOneofCase.Vector2Value:
                    AddValueString(dataPoint.Value.Vector2Value.X.Value,"x");
                    AddValueString(dataPoint.Value.Vector2Value.Y.Value,"y");
                    AddValueString(dataPoint.Value.Vector2Value.X.Error,"x:error");
                    AddValueString(dataPoint.Value.Vector2Value.Y.Error,"y:error");
                    break;

                case Value.ValueOneofCase.Vector3Value:
                    AddValueString(dataPoint.Value.Vector3Value.X.Value,"x");
                    AddValueString(dataPoint.Value.Vector3Value.Y.Value,"y");
                    AddValueString(dataPoint.Value.Vector3Value.Z.Value,"z");
                    AddValueString(dataPoint.Value.Vector3Value.X.Error,"x:error");
                    AddValueString(dataPoint.Value.Vector3Value.Y.Error,"y:error");
                    AddValueString(dataPoint.Value.Vector3Value.Z.Error,"z:error");
                    break;
            }

            return valueStrings;
        }
    }
}
