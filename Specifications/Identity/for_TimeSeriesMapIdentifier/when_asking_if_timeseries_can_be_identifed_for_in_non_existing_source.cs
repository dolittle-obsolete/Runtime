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
    public class when_asking_if_timeseries_can_be_identifed_for_in_non_existing_source
    {
        const string source = "MySource";
        const string tag = "MyTag";

        static bool result;

        static TimeSeriesMapIdentifier identifier;

        Establish context = () => identifier = new TimeSeriesMapIdentifier(new TimeSeriesMap(new Dictionary<Source, TimeSeriesByTag>()));

        Because of = () => result = identifier.CanIdentify(source, tag);

        It should_consider_not_having_it = () => result.ShouldBeFalse();
    }
}