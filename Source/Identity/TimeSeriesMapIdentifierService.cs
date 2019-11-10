/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Dolittle.TimeSeries.Identity.Runtime.TimeSeriesMapIdentifier;
using grpc = Dolittle.TimeSeries.Identity.Runtime;
using Dolittle.Protobuf;

namespace Dolittle.TimeSeries.Runtime.Identity
{
    /// <summary>
    /// Represents an implementation of <see cref="TimeSeriesMapIdentifierBase"/>
    /// </summary>
    public class TimeSeriesMapIdentifierService : TimeSeriesMapIdentifierBase
    {
        readonly TimeSeriesMapIdentifier _timeSeriesMapIdentifier;

        /// <inheritdoc/>
        public TimeSeriesMapIdentifierService(TimeSeriesMapIdentifier timeSeriesMapIdentifier)
        {
            _timeSeriesMapIdentifier = timeSeriesMapIdentifier;
        }

        /// <inheritdoc/>
        public override Task<Empty> Register(grpc.TimeSeriesMap request, ServerCallContext context)
        {
            foreach( (var tag, var timeSeriesId) in request.TagToTimeSeriesId )
            {
                _timeSeriesMapIdentifier.Register(request.Source, tag, timeSeriesId.To<TimeSeriesId>());
            }

            return Task.FromResult(new Empty());
        }
    }
}