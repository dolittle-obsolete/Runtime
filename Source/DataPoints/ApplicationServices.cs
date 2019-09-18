/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Application;
using Dolittle.Services;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindApplicationServices"/> - providing application services
    /// for working with datapoints
    /// </summary>
    public class ApplicationServices : ICanBindApplicationServices
    {
        readonly DataPointProcessorsService _dataPointProcessorsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataPointProcessorsService"></param>
        public ApplicationServices(DataPointProcessorsService dataPointProcessorsService)
        {
            _dataPointProcessorsService = dataPointProcessorsService;
        }        
        
        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(_dataPointProcessorsService, Grpc.Server.DataPointProcessors.BindService(_dataPointProcessorsService), Grpc.Server.DataPointProcessors.Descriptor)
            };
        }
    }
}