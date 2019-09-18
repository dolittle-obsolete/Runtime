/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.DataPointStream;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointStreamBase"/>
    /// </summary>
    public class DataPointStreamService : DataPointStreamBase
    {
        readonly IOutputStreams _outputStreams;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes an instance of <see cref="DataPointStreamService"/>
        /// </summary>
        /// <param name="outputStreams"><see cref="IOutputStreams"/> to write any incoming datapoints to</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointStreamService(IOutputStreams outputStreams, ILogger logger)
        {
            _outputStreams = outputStreams;
            _logger = logger;
        }


        /// <inheritdoc/>
        public override async Task<Empty> Open(IAsyncStreamReader<DataPoint> requestStream, ServerCallContext context)
        {
            _logger.Information($"DataPointStream opened");
            while( await requestStream.MoveNext() )
            {
                _outputStreams.Write(requestStream.Current);
            }
            _logger.Information($"DataPointStream closed");

            return new Empty();
        }
    }
}