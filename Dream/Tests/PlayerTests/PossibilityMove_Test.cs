using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Dream
{
	[TestFixture]
	public class PossibilityMove_Test
	{
		public Player CreatePlayer()
		{
			var gamesFiles = new GamesFiles();
			var level = new Level(gamesFiles.CurrentLevel);
			return level.Player;
		}

		[Test]
		public void CanMoveIfNoPlatform()
		{
			var player = CreatePlayer();
			player.PossibilityMove.RecalculatePossibilitys(player, new List<Rectangle>());

			Assert.IsFalse(player.PossibilityMove.Ceiling.HasValue);
			Assert.IsFalse(player.PossibilityMove.Floor.HasValue);
			Assert.IsFalse(player.PossibilityMove.LeftWall.HasValue);
			Assert.IsFalse(player.PossibilityMove.RightWall.HasValue);
		}

		[Test]
		public void CanMoveIfPlatformFar()
		{
			var player = CreatePlayer();
			var playerLocation = player.Location;
			var platforms = new List<Rectangle>()
			{
				new Rectangle(playerLocation.Left - 2, playerLocation.Bottom + 2, 50, 20),
				new Rectangle(playerLocation.Left - 2, playerLocation.Top, 1, playerLocation.Height),
				new Rectangle(playerLocation.Right + 2, playerLocation.Top, 1, playerLocation.Height),
				new Rectangle(playerLocation.Left - 2, playerLocation.Top - 2, 1, 50)
			};

			player.PossibilityMove.RecalculatePossibilitys(player, platforms);

			Assert.IsFalse(player.PossibilityMove.Floor.HasValue);
			Assert.IsFalse(player.PossibilityMove.RightWall.HasValue);
			Assert.IsFalse(player.PossibilityMove.LeftWall.HasValue);
			Assert.IsFalse(player.PossibilityMove.Ceiling.HasValue);

		}

		[Test]
		public void CanNotMoveDawn()
		{
			var player = CreatePlayer();
			var playerLocation = player.Location;
			var platforms = new List<Rectangle>()
			{
				new Rectangle(playerLocation.Left, playerLocation.Bottom, 50, 20),
				new Rectangle(playerLocation.Left, playerLocation.Top, 1, playerLocation.Height),
				new Rectangle(playerLocation.Right, playerLocation.Top, 1, playerLocation.Height),
				new Rectangle(playerLocation.Left, playerLocation.Y, 1, 50)
			};

			player.PossibilityMove.RecalculatePossibilitys(player, platforms);

			Assert.IsTrue(player.PossibilityMove.Floor.HasValue);
			Assert.IsTrue(player.PossibilityMove.RightWall.HasValue);
			Assert.IsTrue(player.PossibilityMove.LeftWall.HasValue);
			Assert.IsTrue(player.PossibilityMove.Ceiling.HasValue);
		}
	}
}
