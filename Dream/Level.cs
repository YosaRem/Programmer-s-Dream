﻿using System;
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
			StartPlayerLocation = new Point(300, 300);
		}

		public void ExtractLavelFormFile(string path)
		{
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
		            Enemies.Add(new Enemy(new Point(Convert.ToInt32(splitLine[1]),
		                Convert.ToInt32(splitLine[2]))));

		    }
		}

		public void DrawLavel(Graphics graphics)
		{
			graphics.DrawImage(LavelImage, new Point(0, 0));
			throw new System.NotImplementedException();
		}
	}
}
