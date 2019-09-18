/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.InputStream;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="InputStreamBase"/>
    /// </summary>
    public class InputStreamService : InputStreamBase
    {
        readonly ILogger _logger;
        readonly IInputStreams _inputStreams;

        /// <summary>
        /// Initializes a new instance of <see cref="InputStreamService"/>
        /// </summary>
        /// <param name="inputStreams">All <see cref="IInputStreams"/></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public InputStreamService(IInputStreams inputStreams, ILogger logger)
        {
            _inputStreams = inputStreams;
            _logger = logger;
        }

        /// <inheritdoc/>
        public override async Task Open(IAsyncStreamReader<DataPoint> requestStream, IServerStreamWriter<TimeSerie> responseStream, ServerCallContext context)
        {
            _logger.Information($"Input Stream opened");

            while (await requestStream.MoveNext(context.CancellationToken))
            {
                _logger.Information($"DataPoint received");
                try
                {
                    _inputStreams.OnDataPointReceived(requestStream.Current);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, $"Error in receiving data point");
                }

            }

            _logger.Information($"Input Stream closed");
        }
    }
}