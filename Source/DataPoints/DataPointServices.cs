/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Services;
using Dolittle.TimeSeries.Runtime.DataPoints.Grpc.Server;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{

    /// <summary>
    /// Represents an implementation of <see cref="ICanBindDataPointServices"/> - providing data point services
    /// for working with datapoints
    /// </summary>
    public class DataPointServices : ICanBindDataPointServices
    {
        readonly InputStreamService _inputStreamService;
        readonly OutputStreamService _outputStreamService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStreamService"></param>
        /// <param name="outputStreamService"></param>
        public DataPointServices(
            InputStreamService inputStreamService,
            OutputStreamService outputStreamService)
        {
            _inputStreamService = inputStreamService;
            _outputStreamService = outputStreamService;
        }

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(_inputStreamService, InputStream.BindService(_inputStreamService), InputStream.Descriptor),
                new Service(_outputStreamService, OutputStream.BindService(_outputStreamService), OutputStream.Descriptor)
            };
        }
    }
}