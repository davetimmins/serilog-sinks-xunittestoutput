namespace playground
{
    using Serilog;
    using Serilog.Sinks.XunitTestOutput;
    using System;
    using Xunit.Abstractions;

    public class XUnitTestOutputFixture : IDisposable
    {
        IDisposable _logCapture;

        static XUnitTestOutputFixture()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.XunitTestOutput()
                .CreateLogger();
        }

        public void SetTestOutputHelper(ITestOutputHelper output)
        {
            _logCapture = XUnitTestOutputSink.Capture(output);
        }

        public void Dispose()
        {
            _logCapture.Dispose();
        }
    }
}
