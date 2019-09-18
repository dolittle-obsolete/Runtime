/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.TimeSeries.Runtime.Identity.for_TimeSeriesMapper
{
    public class when_getting_timeseries_for_existing_tag_in_existing_source
    {
        const string source = "MySource";
        const string other_source = "MyOtherSource";
        const string tag = "MyTag";
        const string other_tag = "MyOtherTag";
        static Guid time_series = Guid.NewGuid();
        static Guid other_time_series = Guid.NewGuid();

        static TimeSeriesId result;


        static TimeSeriesMapper mapper;
        Establish context = () =>
        {
            mapper = new TimeSeriesMapper(new TimeSeriesMap(
                new Dictionary<Source, TimeSeriesByTag>
                {
                    { source, new TimeSeriesByTag(new Dictionary<Tag, TimeSeriesId> {{ tag, time_series }} )},
                    { other_source, new TimeSeriesByTag(new Dictionary<Tag, TimeSeriesId> {{ other_tag, other_time_series }} )}
                }
            ));
        };

        Because of = () => result = mapper.GetTimeSeriesFor(source,tag);

        It should_return_the_timeseries = () => result.ShouldEqual((TimeSeriesId)time_series);
    }
}