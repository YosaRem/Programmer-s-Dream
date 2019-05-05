using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Dream
{
	public class Level
	{
        public LevelFiles Files { get; private set; }
		public LevelInformation LevelInform { get; private set; }
		public Player Player { get; set; }

		public Level(LevelFiles files)
		{
			Files = files;
			LevelInform = new LevelInformation(Files);
			LevelInform.ExtractLevelFromFile();
			Player = new Player(LevelInform.StartPlayerLocation);
		}

		public void Move()
		{
			foreach (var enemy in LevelInform.Enemies)
				enemy.Move();
			Player.Move(LevelInform.Platforms);
		}

		public void DrawLavel(Graphics graphics)
		{
            var brush = new SolidBrush(Color.DarkSlateGray);
            graphics.DrawImage(Files.Background, new Point(0, 0));
		    foreach (var platform in LevelInform.Platforms)
		        graphics.FillRectangle(brush, platform);
			foreach (var enemy in LevelInform.Enemies)
				enemy.Draw(graphics);
			Player.DrawPlayer(graphics);
			//foreach (var bonus in Marks)
			//    bonus.Draw(graphics);
		}
	}
}
