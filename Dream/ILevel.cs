using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public interface ILevel
	{
		Point StartPlayerLocation { get; set; }
		List<Rectangle> Platforms { get; set; }
        List<Enemy> Enemies { get; set; }
        Image LavelImage { get; set; }
        LevelFiles Files { get; set; }
		void ExtractLevelFormFile(string path);
		void DrawLavel(Graphics graphics);
	}
}