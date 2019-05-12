﻿using System;
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
			var brush = new SolidBrush(Color.DarkSlateGray);
			graphics.DrawImage(level.Files.Background, new Point(0, 0));
			foreach (var platform in level.LevelInform.Platforms)
			{
				graphics.DrawRectangle(new Pen(brush), platform);
				graphics.DrawString("USING SYSTEM.DRAWING;", new Font("Arial", 10),
					Brushes.Blue, platform,
					new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center,
						FormatFlags = StringFormatFlags.FitBlackBox
					});
			}
				
			foreach (var mark in level.LevelInform.Marks)
				mark.Draw(graphics);
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
