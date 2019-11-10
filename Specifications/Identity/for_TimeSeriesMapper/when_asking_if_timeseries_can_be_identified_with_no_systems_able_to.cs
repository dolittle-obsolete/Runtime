/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Types.Testing;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.TimeSeries.Runtime.Identity.for_TimeSeriesMapper
{
    public class when_asking_if_timeseries_can_be_identified_with_no_systems_able_to
    {
        static TimeSeriesMapper mapper;
        static Mock<ICanIdentifyTimeSeries> identifier;
        static bool result;

        Establish context = () => 
        {
            identifier = new Mock<ICanIdentifyTimeSeries>();
            
            mapper = new TimeSeriesMapper(new StaticInstancesOf<ICanIdentifyTimeSeries>(
                identifier.Object
            ));
        };

        Because of = () => result = mapper.CanIdentify("Some Source", "Some Tag");

        It should_not_be_able_to_identify = () => result.ShouldBeFalse();
    }
}