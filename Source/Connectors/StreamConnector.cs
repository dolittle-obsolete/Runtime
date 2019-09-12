/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Defines a pull connector
    /// </summary>
    public class StreamConnector
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PullConnector"/>
        /// </summary>
        /// <param name="id">Unique <see cref="ConnectorId"/></param>
        /// <param name="name">Name of the connector</param>
        /// <param name="tags">Collection of <see cref="Tag">tags</see> the connector has</param>
        public StreamConnector(
            ConnectorId id,
            string name,
            IEnumerable<Tag> tags)
        {
            Id = id;
            Name = name;
            Tags = tags;
        }

        /// <summary>
        /// Gets the <see cref="ConnectorId"/> for the <see cref="PullConnector"/>
        /// </summary>
        public ConnectorId Id { get; }

        /// <summary>
        /// Gets the name of the <see cref="PullConnector"/>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the collection of <see cref="Tag">tags</see> this connector exposes
        /// </summary>
        public IEnumerable<Tag> Tags { get; }
    }
}