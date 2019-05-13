using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dream.LevelClasses
{

    [TestFixture]
    public class Extractor_Test
    {
        public string GetDirectory()
        {
            var gameFiles = new GamesFiles();
            return gameFiles.GetCurrentDirectory();
        }

        [Test]
        public void CanExtractPlatforms()
        {
            var level = new Level(new LevelFiles(GetDirectory(), 4));
            Assert.AreEqual(level.LevelInform.Platforms.Count, 3);
        }


        [Test]
        public void CanNotExtractLevelWithIncorrectData()
        {
            var gameFiles = new GamesFiles();
            var dir = gameFiles.GetCurrentDirectory();
            var textMapWithWrongValue = new[]
            {
                "PLAT 0 0 5 5",
                "PLER 0 0",
            };
            GetFileWithLevel(textMapWithWrongValue, 3);
            var levelInf = new LevelFiles(dir, 3);
            var level = new LevelInformation(levelInf);
            Assert.Throws<Exception>(() => level.Extractor.ExtractLevelFromFile());
            System.IO.File.Delete(dir + @"\Leveles\3.txt");
        }


        [Test]
        public void CanExtractWhenNoData()
        {
            var gameFiles = new GamesFiles();
            var dir = gameFiles.GetCurrentDirectory();
            var textMap = new string[0];
            GetFileWithLevel(textMap, 5);
            var levelInf = new LevelFiles(dir, 5);
            var level = new LevelInformation(levelInf);
            Assert.IsEmpty(level.Platforms);
            System.IO.File.Delete(dir + @"\Leveles\5.txt");
        }

        private void GetFileWithLevel(string[] map, int n)
        {
            var gameFiles = new GamesFiles();
            var dir = gameFiles.GetCurrentDirectory();
            System.IO.File.AppendAllLines(dir + @"\Leveles\" + n.ToString() + ".txt", map);
        }


    }
}
