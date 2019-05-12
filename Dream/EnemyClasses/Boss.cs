using System.Collections.Generic;
using System.Drawing;

namespace Dream
{
	public class Boss : Enemy
	{
		public int Helth { get; set; }

		public Boss(Point location, List<Point> track) : base(location, track)
		{
			Helth = Config.BossHelth;
			TypeEnemy = EnemyType.Boss;
			Location = new Rectangle(location, new Size(EnemyImages.Boss.Width, EnemyImages.Boss.Height));
		}

		public void TakeDamage() => Helth -= Config.Damage;
	}
}
