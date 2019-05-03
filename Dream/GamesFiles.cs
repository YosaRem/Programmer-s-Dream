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
                Levels.Enqueue(new LevelFiles(CurrentDirectory + @"\Images\background.JPG",
                    new List<string>(),
                    new List<string>(),
                    CurrentDirectory + @"\Levels\" + i.ToString() + ".txt" ));
            CurrentLevel = Levels.Dequeue();
        }

        static string GetCurrentDirectory()
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
        public List<Image> EnemyImages;
        public List<Image> BonusImages;
        public string Path;

        public LevelFiles(string background, List<string> enemy, List<string> bonus, string path)
        {
            Background = Image.FromFile(background);
            EnemyImages = GetImages(enemy);
            BonusImages = GetImages(bonus);
            Path = path;
        }

        List<Image> GetImages(List<string> paths)
        {
            var images = new List<Image>();
            foreach (var path in paths)
                images.Add(Image.FromFile(path));
            return images;
        }
    }
}
