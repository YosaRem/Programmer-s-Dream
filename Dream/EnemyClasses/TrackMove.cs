using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public static class TrackMove
	{
		public static int RecalculateX(Enemy enemy)
		{
			var delta = enemy.Track[enemy.CurrentDestinationPoint].X - enemy.Location.Left;
			if (Math.Abs(delta) <= Config.EnemyDefautMoveDelta)
				return enemy.Track[enemy.CurrentDestinationPoint].X;
			return delta < 0
				? enemy.Location.Left - Config.EnemyDefautMoveDelta
				: enemy.Location.Left + Config.EnemyDefautMoveDelta;
		}

		public static int RecalculateY(Enemy enemy)
		{
			var delta = enemy.Track[enemy.CurrentDestinationPoint].Y - enemy.Location.Top;
			if (Math.Abs(delta) <= Config.EnemyDefautMoveDelta)
				return enemy.Track[enemy.CurrentDestinationPoint].Y;
			return delta < 0
				? enemy.Location.Top - Config.EnemyDefautMoveDelta
				: enemy.Location.Top + Config.EnemyDefautMoveDelta;
		}
	}
}
