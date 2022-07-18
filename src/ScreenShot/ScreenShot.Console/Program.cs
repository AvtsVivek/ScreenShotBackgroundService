// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");
using System.Drawing;
using System.Drawing.Imaging;

namespace ScreenShot.Console;

class Program
{
  static void Main(string[] args)
  {
    DirectoryInfo di = new DirectoryInfo(@"D:\\ss");
    if (!di.Exists) { di.Create(); }


    while (true)
    {
      PrintScreen ps = new PrintScreen();
      ps.CaptureScreenToFile(di + $"\\screenShoot{Guid.NewGuid()}.png", ImageFormat.Png);
      Thread.Sleep(10000);

    }
  }
}
