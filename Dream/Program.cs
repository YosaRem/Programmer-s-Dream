using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dream
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            var level = new Level();
            level.ExtractLavelFormFile(
                @"C:\Users\Даша\source\repos\YosaRem\Programmer-s-Dream\Dream\Leveles\1_HelloWorld.txt");
		    level.LavelImage =
		        Image.FromFile(@"C:\Users\Даша\source\repos\YosaRem\Programmer-s-Dream\Dream\Images\background.JPG");
            Application.Run(new Game(level));
		}
	}
}
