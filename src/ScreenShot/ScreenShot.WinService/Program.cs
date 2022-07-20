using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using ScreenShot.Domain;
using ScreenShot.WinService;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
      options.ServiceName = ".NET Joke Service";
    })
    .ConfigureServices(services =>
    {
      LoggerProviderOptions.RegisterProviderOptions<
          EventLogSettings, EventLogLoggerProvider>(services);

      services.AddSingleton<JokeService>();
      services.AddSingleton<IPrintScreenService, PrintScreenService>();
      services.AddHostedService<WindowsBackgroundJokeService>();

    })
    .ConfigureLogging((context, logging) =>
    {
      // See: https://github.com/dotnet/runtime/issues/47303
      logging.AddConfiguration(
          context.Configuration.GetSection("Logging"));
    })
    .Build();

await host.RunAsync();
