namespace playground
{
    using playground.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public class Tests1 : IClassFixture<XUnitTestOutputFixture>
    {
        public Tests1(XUnitTestOutputFixture fixture, ITestOutputHelper output)
        {
            fixture.SetTestOutputHelper(output);
        }

        [Fact]
        public void FirstTest()
        {
            new NewThing("First");
            Assert.True(true);
        }

        [Fact]
        public void FirstSecondTest()
        {
            new NewThing("FirstSecond");
            Assert.True(true);
        }

        [Fact]
        public void FirstThirdTest()
        {
            new NewThing("FirstThird");
            Assert.True(true);
        }
    }

    public class Tests2 : IClassFixture<XUnitTestOutputFixture>
    {
        public Tests2(XUnitTestOutputFixture fixture, ITestOutputHelper output)
        {
            fixture.SetTestOutputHelper(output);
        }

        [Fact]
        public void SecondTest()
        {
            new NewThing("Second");
            Assert.True(true);
        }

        [Fact]
        public void SecondSecondTest()
        {
            new NewThing("SecondSecond");
            Assert.True(true);
        }

        [Fact]
        public void ThirdTest()
        {
            new NewerThing("Third");
            Assert.True(true);
        }

        [Fact]
        public void ThirdSecondTest()
        {
            new NewerThing("ThirdSecond");
            Assert.True(true);
        }
    }

    class NewThing
    {
        static readonly ILog log = LogProvider.For<NewThing>();

        public NewThing(string message)
        {
            log.Info(message);
        }
    }

    class NewerThing
    {
        static readonly ILog log = LogProvider.For<NewerThing>();

        public NewerThing(string message)
        {
            log.Info(message);
            log.Debug(message);
        }
    }
}
