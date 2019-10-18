/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
extern alias contracts;
using System.Threading.Tasks;
using Dolittle.Logging;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Dolittle.TimeSeries.Runtime.State;
using contracts::Dolittle.TimeSeries.Runtime.DataTypes;
using static contracts::Dolittle.TimeSeries.Runtime.DataPoints.DataPointStream;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointStreamBase"/>
    /// </summary>
    public class DataPointStreamService : DataPointStreamBase
    {
        readonly ITimeSeriesState _timeSeriesState;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes an instance of <see cref="DataPointStreamService"/>
        /// </summary>
        /// <param name="timeSeriesState"><see cref="ITimeSeriesState"/> for working with state</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointStreamService(
            ITimeSeriesState timeSeriesState,
            ILogger logger)
        {
            _timeSeriesState = timeSeriesState;
            _logger = logger;
        }


        /// <inheritdoc/>
        public override async Task<Empty> Open(IAsyncStreamReader<DataPoint> requestStream, ServerCallContext context)
        {
            _logger.Information($"DataPointStream opened");
            while( await requestStream.MoveNext() )
            {
                //_timeSeriesState.Set(requestStream.Current.TimeSeries, requestStream.Current.Value);
            }
            _logger.Information($"DataPointStream closed");

            return new Empty();
        }
    }
}