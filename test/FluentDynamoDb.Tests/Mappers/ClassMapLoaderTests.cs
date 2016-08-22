using System.Reflection;
using FluentDynamoDb.Configuration;
using FluentDynamoDb.Exceptions;
using FluentDynamoDb.Mappers;
using NUnit.Framework;

namespace FluentDynamoDb.Tests.Mappers
{
    [TestFixture]
    public class ClassMapLoaderTests
    {
        [Test]
        public void LoadMapper_GivenFooClass_ShouldCreateInstanceOfFooMap()
        {
            FluentDynamoDbConfiguration.Configure(Assembly.GetExecutingAssembly());

            var classMapLoader = new ClassMapLoader();
            var classMap = classMapLoader.Load<Foo>();

            Assert.IsInstanceOf<FooMap>(classMap);
        }

        [Test]
        public void LoadMapper_FluentDynamoDbConfigurationConfigureWasNotSet_ShouldNotThrowException()
        {
            //This condition is now allowed - ClassMap can load from the hosted assembly if configuration not defined.
            FluentDynamoDbConfiguration.Configure(null);

            var classMapLoader = new ClassMapLoader();

            Assert.That(() => classMapLoader.Load<Foo>(),
                Throws.Nothing);
        }

        public class Foo
        {
            public string Name { get; set; }
        }

        public class FooMap : ClassMap<Foo>
        {
            public FooMap()
            {
                Map(f => f.Name);
            }
        }
    }
}