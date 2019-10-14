/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Threading.Tasks;
using Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.Connectors.Grpc.Server.StreamConnectors;
using System;
using Dolittle.Logging;
using Google.Protobuf.WellKnownTypes;

namespace Dolittle.TimeSeries.Runtime.Connectors
{

    /// <summary>
    /// Represents an implementation of <see cref="StreamConnectorsBase"/>
    /// </summary>
    public class StreamConnectorsService : StreamConnectorsBase
    {
        readonly IStreamConnectors _streamConnectors;
        readonly ILogger _logger;
        readonly ITagDataPointCoordinator _tagDataPointCoordinator;


        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="streamConnectors">Actual <see cref="IStreamConnectors"/></param>
        /// <param name="tagDataPointCoordinator"><see cref="ITagDataPointCoordinator"/> for coordinator datapoints</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public StreamConnectorsService(
            IStreamConnectors streamConnectors,
            ITagDataPointCoordinator tagDataPointCoordinator,
            ILogger logger)
        {
            _streamConnectors = streamConnectors;
            _tagDataPointCoordinator = tagDataPointCoordinator;
            _logger = logger;
        }

        /// <inheritdoc/>
        public override async Task<Empty> Open(IAsyncStreamReader<StreamTagDataPoints> requestStream, ServerCallContext context)
        {
            var streamConnectorIdAsString = context.RequestHeaders.SingleOrDefault(_ => string.Equals(_.Key, "streamconnectorid", StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (string.IsNullOrEmpty(streamConnectorIdAsString)) throw new MissingConnectorIdentifierOnRequestHeader();
            var streamConnectorName = context.RequestHeaders.SingleOrDefault(_ => string.Equals(_.Key, "streamconnectorname", StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (string.IsNullOrEmpty(streamConnectorName)) throw new MissingConnectorNameOnRequestHeader();
            var id = (ConnectorId)Guid.Parse(streamConnectorIdAsString);

            StreamConnector streamConnector = null;
            try
            {
                _logger.Information($"Register connector : '{streamConnectorName}' with Id: '{id}'");
                streamConnector = new StreamConnector(id, streamConnectorName);
                _streamConnectors.Register(streamConnector);

                while (await requestStream.MoveNext().ConfigureAwait(false))
                {
                    _tagDataPointCoordinator.Handle(streamConnector.Name, requestStream.Current.DataPoints);
                }
            }
            finally
            {
                if (streamConnector != null) _streamConnectors.Unregister(streamConnector);
            }

            return new Empty();
        }
    }
}