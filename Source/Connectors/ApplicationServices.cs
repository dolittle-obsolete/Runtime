/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Server;
using Grpc.Core;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindApplicationServices"/> - providing application services
    /// for working with connectors
    /// </summary>
    public class ApplicationServices : ICanBindApplicationServices
    {
        /// <inheritdoc/>
        public IEnumerable<ServerServiceDefinition> BindServices()
        {
            return new ServerServiceDefinition[0];
        }
    }
}