/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Logging;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.TimeSeries.Runtime.Connectors.for_PullConnectors
{
    public class when_registering
    {
        static ConnectorId connector_id;
        static PullConnector pull_connector;
        static PullConnectors pull_connectors;

        Establish context = () =>
        {
            connector_id = Guid.NewGuid();
            pull_connector = new PullConnector(connector_id, "Fourty Two", 42);
            pull_connectors = new PullConnectors(Mock.Of<ILogger>());
        };

        Because of = () => pull_connectors.Register(pull_connector);

        It should_consider_having_the_connector = () => pull_connectors.Has(connector_id).ShouldBeTrue();
        It should_have_the_connector = () => pull_connectors.GetById(connector_id).ShouldEqual(pull_connector);
    }
}