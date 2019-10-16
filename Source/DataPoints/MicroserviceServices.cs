/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Microservices;
using Dolittle.Services;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{

    /// <summary>
    /// Represents an implementation of <see cref="ICanBindDataPointServices"/> - providing data point services
    /// for working with datapoints
    /// </summary>
    public class MicroserviceServices : ICanBindMicroserviceServices
    {
        /// <summary>
        /// 
        /// </summary>
        public MicroserviceServices()
        {
        }

        /// <inheritdoc/>
        public ServiceAspect Aspect => "TimeSeries";

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                //new Service(_inputStreamService, InputStream.BindService(_inputStreamService), InputStream.Descriptor),
            };
        }
    }
}