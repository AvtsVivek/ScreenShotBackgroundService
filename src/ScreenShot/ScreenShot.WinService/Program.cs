using ScreenShot.WinService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<WindowsBackgroundJokeService>();
    })
    .Build();

await host.RunAsync();
