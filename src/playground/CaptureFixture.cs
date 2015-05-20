namespace playground
{
    using Serilog;
    using Serilog.Sinks.XunitTestOutput;
    using System;
    using Xunit.Abstractions;

    public abstract class CaptureTests : IDisposable
    {
        IDisposable _logCapture;

        static CaptureTests()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.XunitTestOutput()
                .CreateLogger();
        }

        protected CaptureTests(ITestOutputHelper output)
        {
            _logCapture = XUnitTestOutputSink.Capture(output);
        }

        public void Dispose()
        {
            _logCapture.Dispose();
        }
    }
}
