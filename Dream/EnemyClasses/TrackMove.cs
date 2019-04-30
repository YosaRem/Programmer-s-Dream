using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	class TrackMove
	{
		public int RecalculateX(Enemy enemy)
		{
			return enemy.CurrentDestinationPoint.X < enemy.Location.Left
				? enemy.Location.Left - Config.EnemyDefautMoveDelta
				: enemy.Location.Left + Config.EnemyDefautMoveDelta;
		}

		public int RecalculateY(Enemy enemy)
		{
			return 0;
		}
	}
}
