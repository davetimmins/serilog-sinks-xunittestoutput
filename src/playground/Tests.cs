namespace playground
{
    using playground.Logging;
    using Xunit;
    using Xunit.Abstractions;

    public class Tests1 : CaptureTests
    {
        public Tests1(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void FirstTest()
        {
            new NewThing("First");
            Assert.True(true);
        }
    }

    public class Tests2 : CaptureTests
    {
        public Tests2(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        public void SecondTest()
        {
            new NewThing("Second");
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
