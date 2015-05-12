# Serilog.Sinks.XunitTestOutput
Capture serilog log events to xUnit output

```csharp
public void ConfigureLogging(Xunit.Abstractions.ITestOutputHelper output)
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.XunitTestOutput(output)
        .CreateLogger();
}
```

