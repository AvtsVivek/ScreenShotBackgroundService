using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShot.Domain;
public interface IPrintScreenService
{
  void CaptureScreenEvery(short seconds);
  string CaptureScreen();
}
public class PrintScreenService : IPrintScreenService
{
  public string CaptureScreen()
  {
    var di = new DirectoryInfo(@"D:\\ss");
    if (!di.Exists) { di.Create(); }
    
    var ps = new PrintScreen();
    var tick = DateTime.Now.Ticks;
    var fileName = $"\\ss{tick}.png";
    ps.CaptureScreenToFile(di + fileName, ImageFormat.Png);
    return fileName;
  }

  public void CaptureScreenEvery(short seconds)
  {
    var di = new DirectoryInfo(@"D:\\ss");
    if (!di.Exists) { di.Create(); }


    while (true)
    {
      var ps = new PrintScreen();
      var fileName = DateTime.Now.Ticks;
      System.Console.WriteLine(fileName);
      ps.CaptureScreenToFile(di + $"\\ss{fileName}.png", ImageFormat.Png);
      Thread.Sleep(seconds * 1000);
    }
  }
}

// dotnet new worker --name ScreenShot.WinService
