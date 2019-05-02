using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Dream
{
	public class Level : ILevel
	{
		public Point StartPlayerLocation { get; set; }
        public List<Enemy> Enemies { get; set; }
		public List<Rectangle> Platforms { get; set; }
		public Image LavelImage { get; set; }

		public Level()
		{
			Platforms = new List<Rectangle>();
            Enemies = new List<Enemy>();
			ExtractLavelFormFile(@"C:\Users\Yosa Rem\Source\Repos\YosaRem\Programmer-s-Dream\Dream\Leveles\1_HelloWorld.txt");
			LavelImage = Image.FromFile(@"C:\Users\Yosa Rem\Source\Repos\YosaRem\Programmer-s-Dream\Dream\Images\background.JPG");
		}

		public void ExtractLavelFormFile(string path)
		{
			//TODO опасное место, здесь может вылететь исключение, добавить try
		    var level = new StreamReader(path);
		    var line = level.ReadLine();
		    while (line != null)
		    {
		        var splitLine = line.Split(' ');
		        if (splitLine[0] == "R")
		            Platforms.Add(new Rectangle(Convert.ToInt32(splitLine[1]),
		                Convert.ToInt32(splitLine[2]),
		                Convert.ToInt32(splitLine[3]),
		                Convert.ToInt32(splitLine[4])));
		        if (splitLine[0] == "P")
		            StartPlayerLocation = new Point(Convert.ToInt32(splitLine[1]),
		                Convert.ToInt32(splitLine[2]));
				if (splitLine[0] == "E")
					Enemies.Add(new BugEnemy(new Point(Convert.ToInt32(splitLine[1]),
						Convert.ToInt32(splitLine[2])), new List<Point>() {new Point(40, 40), new Point(100, 100), new Point(200, 10)}));
				line = level.ReadLine();

			}
		}

		public void MoveEnemy()
		{
			foreach (var enemy in Enemies)
				enemy.Move();
		}

		public void DrawLavel(Graphics graphics)
		{
            var brush = new SolidBrush(
                Color.DarkSlateGray);
            graphics.DrawImage(LavelImage, new Point(0, 0));
		    foreach (var platform in Platforms)
		        graphics.FillRectangle(brush, platform);
			foreach (var enemy in Enemies)
				enemy.Draw(graphics);
		}
	}
}
