using System.Collections.Generic;
using FluentDynamoDb.Mappers;
using NUnit.Framework;

namespace FluentDynamoDb.Tests.Mappers
{
    public class DynamoDbMapperWithComplexClassBase
    {
        protected DynamoDbMapper<Foo> Mapper;

        [SetUp]
        public virtual void SetUp()
        {
            var configuration = new DynamoDbEntityConfiguration();

            configuration.AddFieldConfiguration(new FieldConfiguration("FooName", typeof (string)));
            configuration.AddFieldConfiguration(new FieldConfiguration("Bar", typeof (Bar), true,
                new List<FieldConfiguration>
                {
                    new FieldConfiguration("BarName", typeof (string)),
                    new FieldConfiguration("Other", typeof (Other), true, new List<FieldConfiguration>
                    {
                        new FieldConfiguration("OtherName", typeof (string))
                    })
                }));

            Mapper = new DynamoDbMapper<Foo>(configuration);
        }

        public class Foo
        {
            public string FooName { get; set; }
            public Bar Bar { get; set; }
        }

        public class Bar
        {
            public string BarName { get; set; }
            public Other Other { get; set; }
        }

        public class Other
        {
            public string OtherName { get; set; }
        }
    }
}