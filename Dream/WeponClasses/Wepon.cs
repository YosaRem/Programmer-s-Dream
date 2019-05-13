using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class Wepon
	{
		public List<Bullet> Bullets { get; set; }
		private int MaxBulletCount { get; set; }
		private Level CurrentLevel { get; set; }

		public Wepon(Level level)
		{
			CurrentLevel = level;
			Bullets = new List<Bullet>();
			MaxBulletCount = 5;
		}

		public void MakeShot(Player player)
		{
			if (Bullets.Count < MaxBulletCount)
				Bullets.Add(new Bullet(new Point(player.Location.X, player.Location.Y + 5),
					player.CurrentTypeMovement));
		}

		public void MoveBullets()
		{
			foreach (var bullet in Bullets)
			{
				if(bullet.IsBulletDestroydAndMove(this, CurrentLevel))
					break;
			}
		}
	}
}
