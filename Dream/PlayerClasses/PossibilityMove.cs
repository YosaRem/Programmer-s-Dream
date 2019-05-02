using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class PossibilityMove
	{
		public Nullable<Rectangle> Ceiling { get; set; }
		public Nullable<Rectangle> Floor { get; set; }
		public Nullable<Rectangle> RightWall { get; set; }
		public Nullable<Rectangle> LeftWall { get; set; }

		public void RecalculatePossibilitys(Player player, List<Rectangle> platforms)
		{
			CanGoDawn(player, platforms);
			CanGoUp(player, platforms);
			CanGoRight(player, platforms);
			CanGoLeft(player, platforms);
		}

		private void CanGoDawn(Player player, List<Rectangle> platforms)
		{
			foreach (var platform in platforms)
				if (player.Location.Right >= platform.Left
					&& player.Location.Left <= platform.Right
					&& player.Location.Bottom >= platform.Top
					&& player.Location.Top <= platform.Top)
					{
						Floor = platform;
						return;
					}
			Floor = null;
		}

		private void CanGoUp(Player player, List<Rectangle> platforms)
		{
			foreach (var platform in platforms)
			{
				if (player.Location.Right >= platform.Left
					&& player.Location.Left <= platform.Right
					&& player.Location.Top <= platform.Bottom
					&& player.Location.Bottom >= platform.Bottom)
				{
					Ceiling = platform;
					return;
				}
			}
			Ceiling = null;
		}

		private void CanGoLeft(Player player, List<Rectangle> platforms)
		{
			foreach (var platform in platforms)
			{
				if (player.Location.Right >= platform.Right
					&& player.Location.Left <= platform.Right
					&& player.Location.Top < platform.Bottom
					&& player.Location.Bottom > platform.Top)
				{
					LeftWall = platform;
					return;
				}
			}
			LeftWall = null;
		}

		private void CanGoRight(Player player, List<Rectangle> platforms)
		{
			foreach (var platform in platforms)
			{
				if (player.Location.Right >= platform.Left
					&& player.Location.Left <= platform.Left
					&& player.Location.Top < platform.Bottom
					&& player.Location.Bottom > platform.Top)
				{
					RightWall = platform;
					return;
				}
			}
			RightWall = null;
		}
	}
}
