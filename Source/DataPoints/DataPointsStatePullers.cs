/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Collections;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Scheduling;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="IDataPointsStatePullers"/>
    /// </summary>
    [Singleton]
    public class DataPointsStatePullers : IDataPointsStatePullers
    {
        readonly DataPointsStatePullersConfiguration _configuration;
        readonly ITimers _timers;
        readonly IDataPointProcessors _processors;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointsStatePullers"/>
        /// </summary>
        /// <param name="configuration">The <see cref="DataPointsStatePullersConfiguration"/></param>
        /// <param name="processors"><see cref="IDataPointProcessors"/> for processing</param>
        /// <param name="timers"><see cref="ITimers"/> for scheduling</param>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public DataPointsStatePullers(
            DataPointsStatePullersConfiguration configuration,
            IDataPointProcessors processors,
            ITimers timers,
            ILogger logger)
        {
            _timers = timers;
            _configuration = configuration;
            _processors = processors;
            _logger = logger;
        }

        /// <inheritdoc/>
        public void Start()
        {
            _logger.Information($"Setting up DataPointsStatePullers for {_configuration.EndPoints.Count()} endpoints");
            _configuration.EndPoints.ForEach(_ => 
            {
                _logger.Information($"Starting a DataPointsStatePuller to pull from '{_.Target}' with interval {_.Interval}");
                new DataPointsStatePuller(_, _processors, _timers, _logger);
            });
        }
    }
}
