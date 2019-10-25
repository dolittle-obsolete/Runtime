/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Logging;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Dolittle.TimeSeries.Runtime.State;
using Dolittle.TimeSeries.DataTypes.Runtime;
using static Dolittle.TimeSeries.DataPoints.Runtime.DataPointStream;
using Dolittle.TimeSeries.Runtime.DataTypes;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointStreamBase"/>
    /// </summary>
    public class DataPointStreamService : DataPointStreamBase
    {
        readonly IDataPointsState _dataPointsState;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes an instance of <see cref="DataPointStreamService"/>
        /// </summary>
        /// <param name="dataPointsState"><see cref="IDataPointsState"/> for working with state</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointStreamService(
            IDataPointsState dataPointsState,
            ILogger logger)
        {
            _dataPointsState = dataPointsState;
            _logger = logger;
        }


        /// <inheritdoc/>
        public override async Task<Empty> Open(IAsyncStreamReader<DataPoint> requestStream, ServerCallContext context)
        {
            _logger.Information($"DataPointStream opened");
            while( await requestStream.MoveNext() )
            {
                _dataPointsState.Set(requestStream.Current.ToMicroservice());
            }
            _logger.Information($"DataPointStream closed");

            return new Empty();
        }
    }
}