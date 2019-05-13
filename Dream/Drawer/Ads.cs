using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public static class Ads
	{
		public static void YouDied(Graphics graphics)
		{
			graphics.DrawString("YouDiedException\npress R to restart", new Font(FontFamily.GenericSerif, 50),
				Brushes.Black, 100, 100);
		}

		public static void LevelCompleted(Graphics graphics)
		{
			graphics.DrawString("LevelCompleted\npress SPACE to continue", new Font(FontFamily.GenericSerif, 50),
				Brushes.Black, 100, 100);
		}
	}
}
