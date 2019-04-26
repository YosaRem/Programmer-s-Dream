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
				player.PlayerSize.Width,
				player.PlayerSize.Height);
		}

		public static void Jump(Player player, Graphics graphics)
		{
			var image = Image.FromFile(@"C:\Users\Yosa Rem\source\repos\Dream\Dream\Sprites\Player\Stand\Player.png");
			graphics.DrawImage(image, player.Location);
		}

		public static void GoRight(Player player, Graphics graphics)
		{
			graphics.DrawEllipse(new Pen(Color.Brown, 3),
				player.Location.X,
				player.Location.Y,
				player.PlayerSize.Width,
				player.PlayerSize.Height);
		}

		public static void GoLeft(Player player, Graphics graphics)
		{
			graphics.DrawEllipse(new Pen(Color.Brown, 3),
				player.Location.X,
				player.Location.Y,
				player.PlayerSize.Width,
				player.PlayerSize.Height);
		}

		public static void Stand(Player player, Graphics graphics)
		{
			var image = Image.FromFile(@"C:\Users\Yosa Rem\source\repos\Dream\Dream\Sprites\Player\Stand\Player.png");
			graphics.DrawImage(image, player.Location);
		}
	}
}
