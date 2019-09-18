/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.OutputStream;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="OutputStreamBase"/>
    /// </summary>
    public class OutputStreamService : OutputStreamBase
    {
        readonly IOutputStreams _outputStreams;
        private readonly ILogger _logger;

        /// <summary>
        /// Initalizes a new instance of <see cref="OutputStreamService"/>
        /// </summary>
        /// <param name="outputStreams"><see cref="IOutputStreams"/> for receiving datapoints</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public OutputStreamService(IOutputStreams outputStreams, ILogger logger)
        {
            _outputStreams = outputStreams;
            _logger = logger;
        }

        /// <inheritdoc/>
        public override Task Open(Empty request, IServerStreamWriter<DataPoint> responseStream, ServerCallContext context)
        {
            void DataPointReceived(DataPoint dataPoint)
            {
                responseStream.WriteAsync(dataPoint);
            }

            _logger.Information("OutputStream opened");

            _outputStreams.Received += DataPointReceived;
            for(;;)
            {
                if( context.CancellationToken.IsCancellationRequested ) break;
                Thread.Sleep(20);
            }
            _outputStreams.Received -= DataPointReceived;

            _logger.Information("OutputStream closed");

            return Task.CompletedTask;
        }
    }
}