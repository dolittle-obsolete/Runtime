/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Dolittle.TimeSeries.Runtime.DataTypes
{
    /// <summary>
    /// Holds converters to convert between different Protobuf representations of types
    /// </summary>
    public static class TypeConversion
    {
        /// <summary>
        /// Convert from a <see cref="TimeSeries.DataTypes.Runtime.DataPoint"/> to <see cref="TimeSeries.DataTypes.Microservice.DataPoint"/>
        /// </summary>
        /// <param name="dataPoint"><see cref="TimeSeries.DataTypes.Runtime.DataPoint"/> to convert from</param>
        /// <returns>Converted <see cref="TimeSeries.DataTypes.Microservice.DataPoint"/></returns>
        public static TimeSeries.DataTypes.Microservice.DataPoint ToMicroservice(this TimeSeries.DataTypes.Runtime.DataPoint dataPoint)
        {
            return new TimeSeries.DataTypes.Microservice.DataPoint
            {
                TimeSeries = dataPoint.TimeSeries,
                Value = dataPoint.Value.ToMicroservice(),
                Timestamp = dataPoint.Timestamp
            };
        }

        /// <summary>
        /// Convert from a <see cref="TimeSeries.DataTypes.Runtime.Value"/> to <see cref="TimeSeries.DataTypes.Microservice.Value"/>
        /// </summary>
        /// <param name="value"><see cref="TimeSeries.DataTypes.Runtime.Value"/> to convert from</param>
        /// <returns>Converted <see cref="TimeSeries.DataTypes.Microservice.Value"/></returns>
        public static TimeSeries.DataTypes.Microservice.Value ToMicroservice(this TimeSeries.DataTypes.Runtime.Value value)
        {
            var converted = new TimeSeries.DataTypes.Microservice.Value();
            switch (value.ValueCase)
            {
                case TimeSeries.DataTypes.Runtime.Value.ValueOneofCase.MeasurementValue:
                    converted.MeasurementValue = value.MeasurementValue.ToMicroservice();
                    break;
                case TimeSeries.DataTypes.Runtime.Value.ValueOneofCase.Vector2Value:
                    converted.Vector2Value = new TimeSeries.DataTypes.Microservice.Vector2
                    {
                        X = value.Vector2Value.X.ToMicroservice(),
                        Y = value.Vector2Value.Y.ToMicroservice()
                    };
                    break;
                case TimeSeries.DataTypes.Runtime.Value.ValueOneofCase.Vector3Value:
                    converted.Vector3Value = new TimeSeries.DataTypes.Microservice.Vector3
                    {
                        X = value.Vector3Value.X.ToMicroservice(),
                        Y = value.Vector3Value.Y.ToMicroservice(),
                        Z = value.Vector3Value.Z.ToMicroservice()
                    };
                    break;
            }

            return converted;
        }

        /// <summary>
        /// Convert from a <see cref="TimeSeries.DataTypes.Runtime.Measurement"/> to <see cref="TimeSeries.DataTypes.Microservice.Measurement"/>
        /// </summary>
        /// <param name="measurement"><see cref="TimeSeries.DataTypes.Runtime.Measurement"/> to convert from</param>
        /// <returns>Converted <see cref="TimeSeries.DataTypes.Microservice.Measurement"/></returns>
        public static TimeSeries.DataTypes.Microservice.Measurement ToMicroservice(this TimeSeries.DataTypes.Runtime.Measurement measurement)
        {
            return new TimeSeries.DataTypes.Microservice.Measurement
            {
                Value = measurement.Value,
                Error = measurement.Error
            };
        }


        /// <summary>
        /// Convert from a <see cref="TimeSeries.DataTypes.Microservice.DataPoint"/> to <see cref="TimeSeries.DataTypes.Runtime.DataPoint"/>
        /// </summary>
        /// <param name="dataPoint"><see cref="TimeSeries.DataTypes.Microservice.DataPoint"/> to convert from</param>
        /// <returns>Converted <see cref="TimeSeries.DataTypes.Runtime.DataPoint"/></returns>
        public static TimeSeries.DataTypes.Runtime.DataPoint ToRuntime(this TimeSeries.DataTypes.Microservice.DataPoint dataPoint)
        {
            return new TimeSeries.DataTypes.Runtime.DataPoint
            {
                TimeSeries = dataPoint.TimeSeries,
                Value = dataPoint.Value.ToRuntime(),
                Timestamp = dataPoint.Timestamp
            };
        }

        /// <summary>
        /// Convert from a <see cref="TimeSeries.DataTypes.Microservice.Value"/> to <see cref="TimeSeries.DataTypes.Runtime.Value"/>
        /// </summary>
        /// <param name="value"><see cref="TimeSeries.DataTypes.Microservice.Value"/> to convert from</param>
        /// <returns>Converted <see cref="TimeSeries.DataTypes.Runtime.Value"/></returns>
        public static TimeSeries.DataTypes.Runtime.Value ToRuntime(this TimeSeries.DataTypes.Microservice.Value value)
        {
            var converted = new TimeSeries.DataTypes.Runtime.Value();
            switch (value.ValueCase)
            {
                case TimeSeries.DataTypes.Microservice.Value.ValueOneofCase.MeasurementValue:
                    converted.MeasurementValue = value.MeasurementValue.ToRuntime();
                    break;
                case TimeSeries.DataTypes.Microservice.Value.ValueOneofCase.Vector2Value:
                    converted.Vector2Value = new TimeSeries.DataTypes.Runtime.Vector2
                    {
                        X = value.Vector2Value.X.ToRuntime(),
                        Y = value.Vector2Value.Y.ToRuntime()
                    };
                    break;
                case TimeSeries.DataTypes.Microservice.Value.ValueOneofCase.Vector3Value:
                    converted.Vector3Value = new TimeSeries.DataTypes.Runtime.Vector3
                    {
                        X = value.Vector3Value.X.ToRuntime(),
                        Y = value.Vector3Value.Y.ToRuntime(),
                        Z = value.Vector3Value.Z.ToRuntime()
                    };
                    break;
            }

            return converted;
        }

        /// <summary>
        /// Convert from a <see cref="TimeSeries.DataTypes.Microservice.Measurement"/> to <see cref="TimeSeries.DataTypes.Runtime.Measurement"/>
        /// </summary>
        /// <param name="measurement"><see cref="TimeSeries.DataTypes.Microservice.Measurement"/> to convert from</param>
        /// <returns>Converted <see cref="TimeSeries.DataTypes.Runtime.Measurement"/></returns>
        public static TimeSeries.DataTypes.Runtime.Measurement ToRuntime(this TimeSeries.DataTypes.Microservice.Measurement measurement)
        {
            return new TimeSeries.DataTypes.Runtime.Measurement
            {
                Value = measurement.Value,
                Error = measurement.Error
            };
        }
    }
}