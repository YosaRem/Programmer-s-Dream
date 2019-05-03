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
        public List<Bonus> Bonuses { get; set; }
        public Image LavelImage { get; set; }
        public LevelFiles Files { get; set; }

		public Level(LevelFiles files)
		{
			Platforms = new List<Rectangle>();
            Enemies = new List<Enemy>();
            Bonuses = new List<Bonus>();
			ExtractLevelFormFile(files.Path);
			LavelImage = files.Background;
		}

		public void ExtractLevelFormFile(string path)
		{
		    var level = new StreamReader(path);
		    var line = level.ReadLine();
		    while (line != null)
		    {
		        try
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
		            {
		                var location = new Point(Convert.ToInt32(splitLine[1]), Convert.ToInt32(splitLine[2]));
		                var track = ParseTrack(splitLine);
		                Enemies.Add(new Enemy(location, track));
		            }

		            if (splitLine[0] == "B")
		            {
		                var start = new Point(Convert.ToInt32(splitLine[1]), Convert.ToInt32(splitLine[2]));
		                var end = new Point(Convert.ToInt32(splitLine[3]), Convert.ToInt32(splitLine[4]));
		                Bonuses.Add(new Bonus(start, end));
		            }
                }
		        catch
		        {
		            Console.WriteLine("Incorrect data");
		            throw;
		        }

		        line = level.ReadLine();
            }
		}

	    public List<Point> ParseTrack(string[] line)
	    {
            var track = new List<Point>();
	        for (var i = 3; i < line.Length; i += 2)
	        {
	            var x = Convert.ToInt32(line[i]);
                var y = Convert.ToInt32(line[i + 1]);
	            track.Add(new Point(x, y));
	        }

	        return track;
	    }

		public void MoveEnemy()
		{
			foreach (var enemy in Enemies)
				enemy.Move();
		}

		public void DrawLavel(Graphics graphics)
		{
            var brush = new SolidBrush(Color.DarkSlateGray);
            graphics.DrawImage(LavelImage, new Point(0, 0));
		    foreach (var platform in Platforms)
		        graphics.FillRectangle(brush, platform);
			foreach (var enemy in Enemies)
				enemy.Draw(graphics);
		    //foreach (var bonus in Bonuses)
		    //    bonus.Draw(graphics);
		}
	}
}
