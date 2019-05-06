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
		public List<Mark> Marks { get; private set; }
		public Rectangle LevelFinish { get; set; }
		private LevelFiles Files { get; set; }
		public LevelInformationExtractor Extractor { get; set; }

		public LevelInformation(LevelFiles files)
		{
			Files = files;
			Enemies = new List<Enemy>();
			Platforms = new List<Rectangle>();
			Marks = new List<Mark>();
			Extractor = new LevelInformationExtractor(this, files);
			ExtractLevelFromFile();
			FindFinish();
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
	}
}