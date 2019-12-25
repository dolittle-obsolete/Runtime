// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.DataTypes.Runtime;
using Dolittle.TimeSeries.Runtime.DataTypes;
using Dolittle.TimeSeries.Runtime.State;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Dolittle.TimeSeries.DataPoints.Runtime.DataPointStream;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointStreamBase"/>.
    /// </summary>
    public class DataPointStreamService : DataPointStreamBase
    {
        readonly IDataPointsState _dataPointsState;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPointStreamService"/> class.
        /// </summary>
        /// <param name="dataPointsState"><see cref="IDataPointsState"/> for working with state.</param>
        /// <param name="logger"><see cref="ILogger"/> for logging.</param>
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
            while (await requestStream.MoveNext().ConfigureAwait(false))
            {
                _dataPointsState.Set(requestStream.Current.ToMicroservice());
            }

            _logger.Information($"DataPointStream closed");

            return new Empty();
        }
    }
}