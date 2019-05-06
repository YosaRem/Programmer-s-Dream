using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class LevelInformationExtractor
	{
		public LevelInformation LevelInform { get; set; }
		public LevelFiles Files { get; set; }
		public Dictionary<string, Action<string>> LineParser { get; set; }

		public LevelInformationExtractor(LevelInformation level, LevelFiles files)
		{
			LevelInform = level;
			Files = files;
			LineParser = new Dictionary<string, Action<string>>()
			{
				["PLAT"] = ExtractPlatform,
				["PLE"] = ExtractPlayer,
				["BUG"] = ExtractBugEnemy,
				["RTE"] = ExtractRunTimeEnemy,
				["END"] = ExtractEndMark
			};
		}

		public void ExtractLevelFromFile()
		{
			var level = new StreamReader(Files.Path);
			var line = level.ReadLine();
			while (line != null)
			{
				try
				{
					var splitLine = line.Split(' ');
					LineParser[splitLine[0]](line);
				}
				catch
				{
                    throw new Exception();
					//throw new Exception("Can's cast file with level in line - " + line);
				}

				line = level.ReadLine();
			}
		}

		private void ExtractPlatform(string line)
		{
			var splitLine = line.Split(' ');
			LevelInform.Platforms.Add(new Rectangle(Convert.ToInt32(splitLine[1]),
				Convert.ToInt32(splitLine[2]),
				Convert.ToInt32(splitLine[3]),
				Convert.ToInt32(splitLine[4])));
		}

		private void ExtractPlayer(string line)
		{
			var splitLine = line.Split(' ');
			LevelInform.StartPlayerLocation = new Point(Convert.ToInt32(splitLine[1]),
				Convert.ToInt32(splitLine[2]));
		}

		private void ExtractBugEnemy(string line)
		{
			var splitLine = line.Split(' ');
			var location = new Point(Convert.ToInt32(splitLine[1]), Convert.ToInt32(splitLine[2]));
			var track = ParseTrack(splitLine);
			LevelInform.Enemies.Add(new BugEnemy(location, track, Files.EnemyImagesPath));
		}

		private void ExtractRunTimeEnemy(string line)
		{
			var splitLine = line.Split(' ');
			var location = new Point(Convert.ToInt32(splitLine[1]), Convert.ToInt32(splitLine[2]));
			var track = ParseTrack(splitLine);
			LevelInform.Enemies.Add(new RunTimeEnemy(location, track, Files.EnemyImagesPath));
		}

		private void ExtractEndMark(string line)
		{
			var splitLine = line.Split(' ');
			var start = new Point(Convert.ToInt32(splitLine[1]), Convert.ToInt32(splitLine[2]));
			var end = new Point(Convert.ToInt32(splitLine[3]), Convert.ToInt32(splitLine[4]));
			LevelInform.Marks.Add(new EndLevel(start, end));
		}

		private List<Point> ParseTrack(string[] line)
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
	}
}
