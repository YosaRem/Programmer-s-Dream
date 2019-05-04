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
		public List<Bonus> Bonuses { get; private set; }
		private LevelFiles Files { get; set; }
		private LevelInformationExtractor Extractor { get; set; }

		public LevelInformation(LevelFiles files)
		{
			Files = files;
			Enemies = new List<Enemy>();
			Platforms = new List<Rectangle>();
			Bonuses = new List<Bonus>();
			Extractor = new LevelInformationExtractor(this, files);
			ExtractLevelFromFile();
		}

		public void ExtractLevelFromFile() => Extractor.ExtractLevelFromFile();
	}
}