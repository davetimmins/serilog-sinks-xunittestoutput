namespace playground
{
    using playground.Logging;
    using Xunit;
    using Xunit.Abstractions;

    public class Tests1 : CaptureTests
    {
        public Tests1(CaptureFixture fixture, ITestOutputHelper output)
            : base(fixture, output) { }

        [Fact]
        public void FirstTest()
        {
            new NewThing("First", LogProvider.For<Tests1>());
            Assert.True(true);
        }
    }

    public class Tests2 : CaptureTests
    {
        public Tests2(CaptureFixture fixture, ITestOutputHelper output)
            : base(fixture, output) { }

        [Fact]
        public void SecondTest()
        {
            new NewThing("Second", LogProvider.For<Tests2>());
            Assert.True(true);
        }

        [Fact]
        public void ThirdTest()
        {
            new NewerThing("Third");
            Assert.True(true);
        }
    }

    class NewThing
    {
        public NewThing (string message, ILog log)
	    {
            log.Info(message);
	    }
    }

    class NewerThing
    {
        readonly ILog log;
        public NewerThing(string message)
        {
            log = LogProvider.For<NewerThing>();
            log.Info(message);
        }
    }
}
