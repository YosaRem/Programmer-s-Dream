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
        public static string PlayerImages { get; set; }
        public Queue<LevelFiles> Levels { get; set; }
        public LevelFiles CurrentLevel { get; set; }

        public GamesFiles()
        {
            CurrentDirectory = GetCurrentDirectory();
            PlayerImages = CurrentDirectory + @"\Player";
            Levels = new Queue<LevelFiles>();
			var quantityLevel = new DirectoryInfo(CurrentDirectory + @"\Leveles").GetFiles().Length;
            for (var i = 0; i < quantityLevel; i++)
                Levels.Enqueue(new LevelFiles(CurrentDirectory, i));
            CurrentLevel = Levels.Dequeue();
        }

        public void NextLevel()
        {
            CurrentLevel = Levels.Dequeue();
        }

        public string GetCurrentDirectory()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            var dir = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();
            return dir + @"\GameData";
        }
    }


    public class LevelFiles
    {
        public Image Background;
        public string EnemyImagesPath;
        public string BonusImagesPath;
        public string Path;

        public LevelFiles(string dir, int levelNumber)
        {
            Background = Image.FromFile(dir + @"\Images\background.JPG");
            Path = dir + @"\Leveles\" + levelNumber.ToString() + ".txt";
            EnemyImagesPath = dir + @"\Enemys";
        }
    }
}
