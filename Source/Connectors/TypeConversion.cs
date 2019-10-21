/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Holds converters to convert between different Protobuf representations of types
    /// </summary>
    public static class TypeConversion
    {
        /// <summary>
        /// Convert from a <see cref="DataTypes.Runtime.Value"/> to <see cref="DataTypes.Microservice.Value"/>
        /// </summary>
        /// <param name="value"><see cref="DataTypes.Runtime.Value"/> to convert from</param>
        /// <returns>Converted <see cref="DataTypes.Microservice.Value"/></returns>
        public static DataTypes.Microservice.Value ToMicroservice(this DataTypes.Runtime.Value value)
        {
            var converted = new DataTypes.Microservice.Value();
            switch (value.ValueCase)
            {
                case DataTypes.Runtime.Value.ValueOneofCase.MeasurementValue:
                    converted.MeasurementValue = value.MeasurementValue.ToMicroservice();
                    break;
                case DataTypes.Runtime.Value.ValueOneofCase.Vector2Value:
                    converted.Vector2Value = new DataTypes.Microservice.Vector2
                    {
                        X = value.Vector2Value.X.ToMicroservice(),
                        Y = value.Vector2Value.Y.ToMicroservice()
                    };
                    break;
                case DataTypes.Runtime.Value.ValueOneofCase.Vector3Value:
                    converted.Vector3Value = new DataTypes.Microservice.Vector3
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
        /// Convert from a <see cref="DataTypes.Runtime.Measurement"/> to <see cref="DataTypes.Microservice.Measurement"/>
        /// </summary>
        /// <param name="measurement"><see cref="DataTypes.Runtime.Measurement"/> to convert from</param>
        /// <returns>Converted <see cref="DataTypes.Microservice.Measurement"/></returns>
        public static DataTypes.Microservice.Measurement ToMicroservice(this DataTypes.Runtime.Measurement measurement)
        {
            return new DataTypes.Microservice.Measurement
            {
                Value = measurement.Value,
                Error = measurement.Error
            };
        }
    }
}