using ScreenShot.Domain;

namespace ScreenShot.WinService;

public class WindowsBackgroundJokeService : BackgroundService
{
  private readonly JokeService _jokeService;
  private readonly ILogger<WindowsBackgroundJokeService> _logger;
  private readonly IPrintScreenService _printScreenService;

  public WindowsBackgroundJokeService(
      JokeService jokeService,
      IPrintScreenService printScreenService,
      ILogger<WindowsBackgroundJokeService> logger) =>
      (_jokeService, _logger, _printScreenService) = (jokeService, logger, printScreenService);

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    try
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        // string joke = _jokeService.GetJoke();
        // _logger.LogWarning("{Joke}", joke);
        var fileName = _printScreenService.CaptureScreen();
        _logger.LogWarning("{ss fileName}", fileName);
        await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Message}", ex.Message);

      // Terminates this process and returns an exit code to the operating system.
      // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
      // performs one of two scenarios:
      // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
      // 2. When set to "StopHost": will cleanly stop the host, and log errors.
      //
      // In order for the Windows Service Management system to leverage configured
      // recovery options, we need to terminate the process with a non-zero exit code.
      Environment.Exit(1);
    }
  }
}
