/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.TimeSeries.Runtime.Identity.for_TimeSeriesMapIdentifier
{
    public class when_identifying_timeseries_for_non_existing_source
    {
        const string source = "MySource";
        const string tag = "MyTag";
        static Exception result;
        static TimeSeriesMapIdentifier identifier;

        Establish context = () => identifier = new TimeSeriesMapIdentifier(new TimeSeriesMap(new Dictionary<Source, TimeSeriesByTag>()));


        Because of = () => result = Catch.Exception(() => identifier.Identify(source,tag));

        It should_throw_missing_source = () => result.ShouldBeOfExactType<MissingSource>();
    }
}