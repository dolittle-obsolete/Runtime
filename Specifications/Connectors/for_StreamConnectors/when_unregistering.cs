/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Logging;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.TimeSeries.Runtime.Connectors.for_StreamConnectors
{
    public class when_unregistering
    {
        static ConnectorId connector_id;
        static StreamConnector stream_connector;
        static StreamConnectors stream_connectors;

        Establish context = () =>
        {
            connector_id = Guid.NewGuid();
            stream_connector = new StreamConnector(connector_id, "Fourty Two");
            stream_connectors = new StreamConnectors(Mock.Of<ILogger>());
            stream_connectors.Register(stream_connector);
        };

        Because of = () => stream_connectors.Unregister(stream_connector);

        It should_not_consider_having_the_connector = () => stream_connectors.Has(connector_id).ShouldBeFalse();
    }    
}

