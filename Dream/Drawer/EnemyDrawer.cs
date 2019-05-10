using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class EnemyDrawer
	{
		public Dictionary<EnemyType, Action<Enemy, Graphics>> Drawers { get; private set; }

		public EnemyDrawer()
		{
			Drawers = new Dictionary<EnemyType, Action<Enemy, Graphics>>()
			{
				[EnemyType.Bug] = DrawBug,
				[EnemyType.RunTime] = DrawRunTime,
				[EnemyType.Style] = DrawStyle
			};
		}

		private void DrawBug(Enemy enemy, Graphics graphics)
		{

		}

		private void DrawRunTime(Enemy enemy, Graphics graphics)
		{

		}

		private void DrawStyle(Enemy enemy, Graphics graphics)
		{

		}
	}
}
