using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public static class TrackMove
	{
		public static int RecalculateX(Enemy enemy, int deltaMove = Config.EnemyDefautMoveDelta)
		{
			var delta = enemy.Track[enemy.CurrentDestinationPoint].X - enemy.Location.Left;
			if (Math.Abs(delta) <= deltaMove)
				return enemy.Track[enemy.CurrentDestinationPoint].X;
			return delta < 0
				? enemy.Location.Left - deltaMove
				: enemy.Location.Left + deltaMove;
		}

		public static int RecalculateY(Enemy enemy, int deltaMove = Config.EnemyDefautMoveDelta)
		{
			var delta = enemy.Track[enemy.CurrentDestinationPoint].Y - enemy.Location.Top;
			if (Math.Abs(delta) <= deltaMove)
				return enemy.Track[enemy.CurrentDestinationPoint].Y;
			return delta < 0
				? enemy.Location.Top - deltaMove
				: enemy.Location.Top + deltaMove;
		}
	}
}
