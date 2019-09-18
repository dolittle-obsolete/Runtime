/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.Protobuf;
using Dolittle.Runtime.Application;
using Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server;
using Grpc.Core;
using static Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server.DataPointProcessors;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointProcessorsBase"/>
    /// </summary>
    public class DataPointProcessorsService : DataPointProcessorsBase
    {
        readonly IDataPointProcessors _dataPointProcessors;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessorsService"/>
        /// </summary>
        /// <param name="dataPointProcessors">Actual <see cref="IDataPointProcessors"/></param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointProcessorsService(IDataPointProcessors dataPointProcessors, ILogger logger)
        {
            _dataPointProcessors = dataPointProcessors;
            _logger = logger;
        }

        /// <inheritdoc/>
        public override Task<RegisterResult> Register(Grpc.Server.DataPointProcessor processor, ServerCallContext context)
        {
            var result = new RegisterResult();

            var id = processor.Id.ToGuid();
            _logger.Information($"Register processor witd identifier '{id}'");

            var dataPointProcessor = new DataPointProcessor(id);
            _dataPointProcessors.Register(dataPointProcessor);
            context.OnDisconnected(_ => _dataPointProcessors.Unregister(dataPointProcessor));

            return Task.FromResult(result);
        }
    }
}