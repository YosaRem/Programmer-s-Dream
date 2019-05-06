using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dream.PlayerClasses
{
	[TestFixture]
	public class IsPlayerAlive_Test
	{
		public Player CreatePlayer()
		{
			var gamesFiles = new GamesFiles();
			var level = new Level(gamesFiles.CurrentLevel);
			return level.Player;
		}

		[Test]
		public void PlayerAliveWhenNoEnemy()
		{
			var player = CreatePlayer();

			Assert.IsTrue(player.IsPlayerAlive(new List<Enemy>()));
		}

		[Test]
		public void PlayerDieWhenIntersectWithEnemy()
		{
			var player = CreatePlayer();
			var enemy = new Enemy(new Point(player.Location.X, player.Location.Y),
				new List<Point>());

			Assert.IsFalse(player.IsPlayerAlive(new List<Enemy>() {enemy}));
		}

		[Test]
		public void PlayerDieWhenPlayerGoOnEnemy()
		{
			var player = CreatePlayer();
			var enemy = new Enemy(new Point(player.Location.Right + 2, player.Location.Y),
				new List<Point>(){ new Point(player.Location.Right + 2, player.Location.Y) });
			var platform = new Rectangle(player.Location.Left, player.Location.Bottom, 100, 20);

			Assert.IsTrue(player.IsPlayerAlive(new List<Enemy>() { enemy }));

			player.ChangeMoveType(MoveType.Right,
				new List<Rectangle>(new List<Rectangle>(){platform}));
			player.Move(new List<Rectangle>() {platform});

			Assert.IsFalse(player.IsPlayerAlive(new List<Enemy>() { enemy }));
		}
	}
}
