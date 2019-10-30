/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using System;
using Dolittle.Logging;
using Google.Protobuf.WellKnownTypes;
using static Dolittle.TimeSeries.Connectors.Runtime.PushConnectors;
using grpc = Dolittle.TimeSeries.Connectors.Runtime;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="PushConnectorsBase"/>
    /// </summary>
    public class PushConnectorsService : PushConnectorsBase
    {
        readonly IPushConnectors _pushConnectors;
        readonly ILogger _logger;
        readonly ITagDataPointCoordinator _tagDataPointCoordinator;


        /// <summary>
        /// Initializes a new instance of <see cref="PullConnectorsService"/>
        /// </summary>
        /// <param name="pushConnectors">Actual <see cref="IPushConnectors"/></param>
        /// <param name="tagDataPointCoordinator"><see cref="ITagDataPointCoordinator"/> for coordinator datapoints</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public PushConnectorsService(
            IPushConnectors pushConnectors,
            ITagDataPointCoordinator tagDataPointCoordinator,
            ILogger logger)
        {
            _pushConnectors = pushConnectors;
            _tagDataPointCoordinator = tagDataPointCoordinator;
            _logger = logger;
        }

        /// <inheritdoc/>
        public override async Task<Empty> Open(IAsyncStreamReader<grpc.PushTagDataPoints> requestStream, ServerCallContext context)
        {
            var pushConnectorIdAsString = context.RequestHeaders.SingleOrDefault(_ => string.Equals(_.Key, "pushconnectorid", StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (string.IsNullOrEmpty(pushConnectorIdAsString)) throw new MissingConnectorIdentifierOnRequestHeader();
            var pushConnectorName = context.RequestHeaders.SingleOrDefault(_ => string.Equals(_.Key, "pushconnectorname", StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (string.IsNullOrEmpty(pushConnectorName)) throw new MissingConnectorNameOnRequestHeader();
            var id = (ConnectorId)Guid.Parse(pushConnectorIdAsString);

            PushConnector pushConnector = null;
            try
            {
                _logger.Information($"Register connector : '{pushConnectorName}' with Id: '{id}'");
                pushConnector = new PushConnector(id, pushConnectorName);
                _pushConnectors.Register(pushConnector);

                while (await requestStream.MoveNext().ConfigureAwait(false))
                {
                    _tagDataPointCoordinator.Handle(pushConnector.Name, requestStream.Current.DataPoints);
                }
            }
            finally
            {
                if (pushConnector != null) _pushConnectors.Unregister(pushConnector);
            }

            return new Empty();
        }
    }
}