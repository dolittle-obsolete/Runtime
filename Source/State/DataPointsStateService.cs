/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Dolittle.TimeSeries.State.Microservice.DataPointsState;
using grpc = Dolittle.TimeSeries.State.Microservice;

namespace Dolittle.TimeSeries.Runtime.State
{
    /// <summary>
    /// Represents an implementation of <see cref="DataPointsStateBase"/>
    /// </summary>
    public class DataPointsStateService : DataPointsStateBase
    {
        readonly IDataPointsState _dataPointsState;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointsStateService"/>
        /// </summary>
        /// <param name="dataPointsState"><see cref="IDataPointsState"/> that keeps the actual state</param>
        public DataPointsStateService(IDataPointsState dataPointsState)
        {
            _dataPointsState = dataPointsState;
        }

        /// <inheritdoc/>
        public override Task<grpc.DataPoints> GetAll(Empty request, ServerCallContext context)
        {
            var dataPoints = new grpc.DataPoints();
            dataPoints.DataPoints_.Add(_dataPointsState.GetAll());
            return Task.FromResult(dataPoints);
        }
    }
}