using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class Bullet
	{
		private MoveType BulletDirection { get; set; }
		public Point Location { get; private set; }

		public Bullet(Point location, MoveType direction)
		{
			BulletDirection = direction;
			Location = location;
		}

		public bool IsBulletDestroydAndMove(Wepon wepon, Level level)
		{
			if (BulletDirection == MoveType.Left)
				Location = new Point(Location.X - Config.BulletSpeed, Location.Y);
			else
				Location = new Point(Location.X + Config.BulletSpeed, Location.Y);
			if (IsBulletHitSomething(level))
			{
				wepon.Bullets.Remove(this);
				return true;
			}

			return false;
		}

		private bool IsBulletHitSomething(Level level)
		{
			if (!(level.LevelInform.LevelBoss == null))
			{
				var boss = level.LevelInform.LevelBoss;
				if (IsInRectangel(boss.Location))
				{ 
					boss.TakeDamage();
					return true;
				}
			}
			foreach (var enemy in level.LevelInform.Enemies)
				if (IsInRectangel(enemy.Location))
					return true;
			foreach (var platform in level.LevelInform.Platforms)
				if (IsInRectangel(platform))
					return true;
			return false;
		}

		private bool IsInRectangel(Rectangle rect)
		{
			return Location.X > rect.Left &&
			       Location.X < rect.Right &&
			       Location.Y < rect.Bottom &&
			       Location.Y > rect.Top;
		}
	}
}
