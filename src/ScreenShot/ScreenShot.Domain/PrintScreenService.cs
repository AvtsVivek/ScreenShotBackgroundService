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
}
public class PrintScreenService : IPrintScreenService
{
  public void CaptureScreenEvery(short seconds)
  {
    DirectoryInfo di = new DirectoryInfo(@"D:\\ss");
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
