namespace playground
{
    using Serilog;
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class CaptureFixture
    {
        public void Capture()
        { }

        public void ConfigureLogging(ITestOutputHelper output)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.XunitTestOutput(output)
                .CreateLogger();
        }
    }

    [CollectionDefinition("Capture")]
    public class CaptureTestCollection : ICollectionFixture<CaptureFixture> { }

    [Collection("Capture")]
    public abstract class CaptureTests : IDisposable
    {
        CaptureFixture _fixture;
        ITestOutputHelper _output;

        protected CaptureTests(CaptureFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;

            _fixture.ConfigureLogging(_output);
        }

        public void Dispose()
        {
        }
    }
}
