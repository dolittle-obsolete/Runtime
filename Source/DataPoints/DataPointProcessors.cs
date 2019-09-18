/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Lifecycle;
using Dolittle.Logging;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="IDataPointProcessors"/>
    /// </summary>
    [Singleton]
    public class DataPointProcessors : IDataPointProcessors
    {
        readonly List<DataPointProcessor> _processors = new List<DataPointProcessor>();
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessors"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointProcessors(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public void Register(DataPointProcessor dataPointProcessor)
        {
            _logger.Information($"Registering '{dataPointProcessor.Id}'");
            lock( _processors ) _processors.Add(dataPointProcessor);
        }

        /// <inheritdoc/>
        public void Unregister(DataPointProcessor dataPointProcessor)
        {
            _logger.Information($"Unregistering '{dataPointProcessor.Id}'");
            lock( _processors ) _processors.Remove(dataPointProcessor);
        }
    }

}