using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShot.Console;
public static class StringUtlities
{
  public static string RemoveWhitespace(this string input)
  {
    return new string(input.ToCharArray()
        .Where(c => !Char.IsWhiteSpace(c))
        .ToArray());
  }
}
