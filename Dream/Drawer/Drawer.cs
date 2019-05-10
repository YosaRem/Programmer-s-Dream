using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public static class Drawer
	{
		public static void DrawAll(Level level, Graphics graphics)
		{
			DrawLevel(level, graphics);
			DrawEnemys(level.LevelInform.Enemies, graphics);
			DrawPlayer(level.Player, graphics);
		}

		public static void DrawPlayer(Player player, Graphics graphics)
		{
			var playerAnimation = new PlayerAnimation();
			playerAnimation.MovementSet[player.CurrentTypeMovement](player, graphics);
		}

		public static void DrawEnemys(List<Enemy> enemys, Graphics graphics)
		{
			var enemyDrawer = new EnemyDrawer();
			foreach (var enemy in enemys)
				enemyDrawer.Drawers[enemy.TypeEnemy](enemy, graphics);		
		}

		public static void DrawLevel(Level level, Graphics graphics)
		{
			var brush = new SolidBrush(Color.DarkSlateGray);
			graphics.DrawImage(level.Files.Background, new Point(0, 0));
			foreach (var platform in level.LevelInform.Platforms)
				graphics.FillRectangle(brush, platform);
			foreach (var mark in level.LevelInform.Marks)
				mark.Draw(graphics);
		}
	}
}
