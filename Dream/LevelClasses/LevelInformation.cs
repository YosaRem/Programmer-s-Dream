using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class LevelInformation
	{
		public Point StartPlayerLocation { get; set; }
		public List<Enemy> Enemies { get; private set; }
		public List<Rectangle> Platforms { get; private set; }
	    public List<Triangle> Triangles { get; private set; }
        public List<Mark> Marks { get; private set; }
		public Rectangle LevelFinish { get; set; }
		public Boss LevelBoss { get; set; }
        public string Message { get; set; }
        private LevelFiles Files { get; set; }
		public LevelInformationExtractor Extractor { get; set; }

		public LevelInformation(LevelFiles files)
		{
			Files = files;
			Enemies = new List<Enemy>();
			Platforms = new List<Rectangle>();
			Marks = new List<Mark>();
            Triangles = new List<Triangle>();
		    Extractor = new LevelInformationExtractor(this, files);
			ExtractLevelFromFile();
			FindFinish();
			FindBoss();
		}

		private void ExtractLevelFromFile() => Extractor.ExtractLevelFromFile();

		private void FindFinish()
		{
			foreach (var mark in Marks)
			{
				if (mark.MarkType == MarkEnum.EndLevel)
				{
					LevelFinish = mark.Location;
					break;
				}
			}
		}

		private void FindBoss()
		{
			foreach (var enemy in Enemies)
			{
				if (enemy.TypeEnemy == EnemyType.Boss)
				{
					LevelBoss = (Boss) enemy;
					break;
				}
			}
		}
	}
}