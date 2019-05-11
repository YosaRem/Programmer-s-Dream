using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
    public class GamesFiles
    {
        private string CurrentDirectory { get; set; }
        public Queue<LevelFiles> Levels { get; set; }
        public LevelFiles CurrentLevel { get; set; }
        private string PlayerFilesPath { get; set; }
        private string EnemyFilesPath { get; set; }

        public GamesFiles()
        {
            Levels = new Queue<LevelFiles>();
			CurrentDirectory = GetCurrentDirectory();
            PlayerFilesPath = CurrentDirectory + @"Player\";
            EnemyFilesPath = CurrentDirectory + @"Enemys\";
            ExtractLevelFiles();
            FillPlayerImages();
			ExtractEnemyImages();
            CurrentLevel = Levels.Dequeue();
        }

        public void GetNextLevel() => CurrentLevel = Levels.Dequeue();

        public string GetCurrentDirectory()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            var dir = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();
            return dir + @"\GameData\";
        }

        private void ExtractEnemyImages()
        {
            EnemyImages.Bug = Image.FromFile(EnemyFilesPath + "Bug.png");
            EnemyImages.RunTime = Image.FromFile(EnemyFilesPath + "RT.png");
            EnemyImages.Style = Image.FromFile(EnemyFilesPath + "Style.png");
            EnemyImages.Boss = Image.FromFile(EnemyFilesPath + "Boss.png");
		}

        private void FillPlayerImages()
        {
            var folders = new List<string>() { "Run", "Fall", "Jump", "Stand" };
            foreach (var folder in folders)
            {
				var countFile = new DirectoryInfo(PlayerFilesPath + folder).GetFiles().Length;
                for (var i = 0; i < countFile; i++)
                    PlayerImages.frames[folder].Add(Image.FromFile(PlayerFilesPath + folder + "\\" + i.ToString() + ".png"));
			}
		}

        private void ExtractLevelFiles()
        {
            var quantityLevel = new DirectoryInfo(CurrentDirectory + @"Leveles").GetFiles().Length;
            for (var i = 0; i < quantityLevel; i++)
                Levels.Enqueue(new LevelFiles(CurrentDirectory, i));
		}
    }
}
