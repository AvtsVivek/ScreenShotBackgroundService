// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");
using System;
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
      var ps = new PrintScreen();
      var fileName = DateTime.Now.Ticks;
      System.Console.WriteLine(fileName);
      ps.CaptureScreenToFile(di + $"\\ss{fileName}.png", ImageFormat.Png);
      Thread.Sleep(1000);
    }
  }
}
