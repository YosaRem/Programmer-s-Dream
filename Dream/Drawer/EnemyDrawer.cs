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
				[EnemyType.Style] = DrawStyle,
				[EnemyType.Boss] = DrawBoss
			};
		}

		private void DrawBug(Enemy enemy, Graphics graphics)
		{
			graphics.DrawImage(EnemyImages.Bug, enemy.Location);
		}

		private void DrawRunTime(Enemy enemy, Graphics graphics)
		{
			var runTime = (RunTimeEnemy) enemy;
			if (runTime.Leap == Config.Leap)
			{
				runTime.Location = runTime.RecalculatedLocation;
				runTime.Leap = 0;
			}
			runTime.Leap++;
			graphics.DrawImage(EnemyImages.RunTime, enemy.Location);
		}

		private void DrawBoss(Enemy enemy, Graphics graphics)
		{
			graphics.DrawImage(EnemyImages.Boss, enemy.Location);
		}

		private void DrawStyle(Enemy enemy, Graphics graphics)
		{

		}
	}
}
