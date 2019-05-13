using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class LevelFiles
	{
		public Image Background;
		public string PathToLevelFile;

		public LevelFiles(string dir, int levelNumber)
		{
			Background = Image.FromFile(dir + @"\Images\background" + levelNumber.ToString() + ".JPG");
			PathToLevelFile = dir + @"\Leveles\" + levelNumber.ToString() + ".txt";
		}
	}
}
