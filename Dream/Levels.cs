using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dream
{
    public static class Levels
    {
        public static void FirstLevel()
        {
            level.ExtractLavelFormFile(
                @"C:\Users\Даша\source\repos\YosaRem\Programmer-s-Dream\Dream\Leveles\1_HelloWorld.txt");
            level.LavelImage =
                Image.FromFile(@"C:\Users\Даша\source\repos\YosaRem\Programmer-s-Dream\Dream\Images\background.JPG");
            level.DrawLavel();
        }
    }
}