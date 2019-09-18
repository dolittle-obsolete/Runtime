/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.TimeSeries.DataTypes.Protobuf;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// 
    /// </summary>
    [Singleton]
    public class OutputStreams : IOutputStreams
    {
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="OutputStreams"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public OutputStreams(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public event DataPointReceived Received = (d) => { };

        /// <inheritdoc/>
        public void Write(DataPoint dataPoint)
        {
            try
            {
                Received(dataPoint);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error writing data point to output stream");
            }
        }
    }
}