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
			DrawBullets(level.Player.PlayerWepon, graphics);
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
			var platformBrush = new SolidBrush(Color.DarkSlateGray);
            var triangleBrush = new SolidBrush(Color.DarkRed);
            graphics.DrawImage(level.Files.Background, new Point(0, 0));
			foreach (var platform in level.LevelInform.Platforms)
		        graphics.FillRectangle(platformBrush, platform);
			foreach (var mark in level.LevelInform.Marks)
				mark.Draw(graphics);
		    foreach (var triangle in level.LevelInform.Triangles)
		        graphics.FillPolygon(triangleBrush, triangle.Points);
		}

		public static void DrawBullets(Wepon wepon, Graphics graphics)
		{
			if (wepon != null)
			{
				var bulletDrawer = new BulletDrawer();
				foreach (var bullet in wepon.Bullets)
					bulletDrawer.Draw(bullet, graphics);
			}
		}
	}
}
