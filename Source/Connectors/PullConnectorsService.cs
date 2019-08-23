/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries.Runtime.Connectors.Grpc;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.PullConnectors;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="PullConnectorsBase"/>
    /// </summary>
    public class PullConnectorsService : PullConnectorsBase
    {
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public PullConnectorsService(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public override Task Register(IAsyncStreamReader<PullConnectorGetData> requestStream, IServerStreamWriter<PullConnectorData> responseStream, ServerCallContext context)
        {
            _logger.Information($"Application client connected");

            using(var disconnected = new ManualResetEventSlim(false))
            {
                Task.Run(() => HandleRequestStream(requestStream, context, disconnected));
                Task.Run(() => HandleResponseStream(responseStream, context, disconnected));

                try
                { 
                    disconnected.Wait(context.CancellationToken);
                }
                finally
                {
                    _logger.Information("Client disconnected");
                }
            }

            return Task.CompletedTask;
        }

        async Task HandleRequestStream(IAsyncStreamReader<PullConnectorGetData> requestStream, ServerCallContext context, ManualResetEventSlim disconnected)
        {
            try
            {
                while (await requestStream.MoveNext(context.CancellationToken))
                {
                    context.CancellationToken.ThrowIfCancellationRequested();
                    _logger.Information("Message received");
                }
            }
            finally
            {
                disconnected.Set();
            }

            await Task.CompletedTask;
        }

        async Task HandleResponseStream(IServerStreamWriter<PullConnectorData> responseStream, ServerCallContext context, ManualResetEventSlim disconnected)
        {
            try
            {
                for (;;)
                {
                    context.CancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(1000);
                    if( context.CancellationToken.IsCancellationRequested ) break;
                    _logger.Information("Tell client to pull");
                    await responseStream.WriteAsync(new PullConnectorData());
                }
            }
            finally
            {
                disconnected.Set();
            }
        }
    }
}