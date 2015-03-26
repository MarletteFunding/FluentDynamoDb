using System.Collections.Generic;
using NUnit.Framework;

namespace FluentDynamoDb.Tests
{
    public class DynamoDbMapperWithComplexClassBase
    {
        protected DynamoDbMapper<Foo> Mapper;

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

        [SetUp]
        public virtual void SetUp()
        {
            var configuration = new DynamoDbEntityConfiguration();

            configuration.AddFieldConfiguration(new FieldConfiguration("FooName", typeof(string)));
            configuration.AddFieldConfiguration(new FieldConfiguration("Bar", typeof(Bar), true, 
                new List<IFieldConfiguration>
                        {
                            new FieldConfiguration("BarName", typeof(string)),
                            new FieldConfiguration("Other", typeof(Other), true, new List<IFieldConfiguration>
                            {
                                new FieldConfiguration("OtherName", typeof(string))
                            })   
                        }));

            Mapper = new DynamoDbMapper<Foo>(configuration);
        }
    }
}