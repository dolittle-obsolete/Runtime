/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Services;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Defines a system that can bind a gRPC service for data point purpose
    /// </summary>
    public interface ICanBindDataPointServices : ICanBindServices
    {
    }
}