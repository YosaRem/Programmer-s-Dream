using System.Collections.Generic;
using System.Drawing;

namespace Dream
{
	public class Level : ILevel
	{
		public Point StartPlayerLocation { get; set; }
		public List<Rectangle> Platforms { get; set; }
		public Image LavelImage { get; set; }

		public Level()
		{
			Platforms = new List<Rectangle>();
			StartPlayerLocation = new Point(300, 300);
		}

		public void ExtractLavelFormFile(string path)
		{
			throw new System.NotImplementedException();
		}

		public void DrawLavel(Graphics graphics)
		{
			graphics.DrawImage(LavelImage, new Point(0, 0));
			throw new System.NotImplementedException();
		}
	}
}
