using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	interface ILevel
	{
		Point StartPlayerLocation { get; set; }
		List<Rectangle> Platforms { get; set; }
		Image LavelImage { get; set; }
		void ExtractLavelFormFile(string path);
		void DrawLavel(Graphics graphics);
	}
}
