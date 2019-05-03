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
        public static string CurrentDirectory = GetCurrentDirectory();
        public Image PlayerImage = Image.FromFile(CurrentDirectory + "\\GameData\\Images\\Player.png");
        public LevelFiles HelloWorldLevel = new LevelFiles(
            CurrentDirectory + "\\GameData\\Images\\background.JPG",
            new List<string>(), new List<string>(),
            CurrentDirectory + "\\GameData\\Leveles\\1_HelloWorld.txt");

        static string GetCurrentDirectory()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            var dir = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();
            return dir;
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
