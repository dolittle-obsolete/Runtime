/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Threading;
using Dolittle.Protobuf;
using Dolittle.Runtime.Application;
using Dolittle.TimeSeries.DataTypes.Protobuf;
using Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Client.DataPointProcessor;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents a processor for <see cref="DataPointProcessorProcessor"/>
    /// </summary>
    public class DataPointProcessorProcessor : IDisposable
    {
        DataPointProcessor _processor;
        CancellationTokenSource _cancellationTokenSource;
        AsyncClientStreamingCall<DataPointMessage, Empty>   _stream;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="client"></param>
        public DataPointProcessorProcessor(
            DataPointProcessor processor,
            IClientFor<DataPointProcessorClient> client)
        {
            _processor = processor;
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.Token.ThrowIfCancellationRequested();
            _stream = client.Instance.Process(cancellationToken:_cancellationTokenSource.Token);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _processor = null;
            
            _stream?.Dispose();
            _stream = null;

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }


        /// <summary>
        /// Process a <see cref="DataPoint"/>
        /// </summary>
        /// <param name="dataPoint"><see cref="DataPoint"/> to process</param>
        public void Process(DataPoint dataPoint)
        {
            _stream.RequestStream.WriteAsync(new DataPointMessage {
                Id = _processor.Id.ToProtobuf(),
                DataPoint = dataPoint
            });
        }
    }
}