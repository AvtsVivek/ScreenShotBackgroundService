# Worker Service

## Refernce: https://docs.microsoft.com/en-us/dotnet/core/extensions/windows-service


# # Run the followikng command.
sc.exe create ".NET Joke Service" binpath="D:\Trials\ScreenShot\src\ScreenShot\ScreenShot.WinService\bin\Release\net6.0\win-x64\publish\win-x64\ScreenShot.WinService.exe"

sc qfailure ".NET Joke Service"

sc.exe failure ".NET Joke Service" reset=0 actions=restart/60000/restart/60000/run/1000

sc.exe start ".NET Joke Service"

sc.exe delete ".NET Joke Service"
