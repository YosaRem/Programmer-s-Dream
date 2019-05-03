using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dream
{
	public static class PlayerAnimation
	{
		public static void Fall(Player player, Graphics graphics)
		{
			graphics.DrawEllipse(new Pen(Color.Brown, 3),
				player.Location.X,
				player.Location.Y,
				player.Location.Width,
				player.Location.Height);
		}

		public static void Jump(Player player, Graphics graphics)
		{
			graphics.DrawImage(player.Image, player.Location);
		}

		public static void GoRight(Player player, Graphics graphics)
		{
			graphics.DrawEllipse(new Pen(Color.Brown, 3),
				player.Location.X,
				player.Location.Y,
				player.Location.Width,
				player.Location.Height);
		}

		public static void GoLeft(Player player, Graphics graphics)
		{
			graphics.DrawEllipse(new Pen(Color.Brown, 3),
				player.Location.X,
				player.Location.Y,
				player.Location.Width,
				player.Location.Height);
		}

		public static void Stand(Player player, Graphics graphics)
		{
			graphics.DrawImage(player.Image, player.Location);
		}
	}
}
