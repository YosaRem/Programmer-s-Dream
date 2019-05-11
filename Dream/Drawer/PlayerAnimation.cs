using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Dream
{
	public class PlayerAnimation
	{
		public Dictionary<MoveType, Action<Player, Graphics>> MovementSet { get; private set; }
		private readonly Func<int, int, int> RecalculateCount;
		private int runFrameCount;
		private int jumpFrameCount;
		private int fallFrameCount;
		private int standFrameCount;

		public PlayerAnimation()
		{
			MovementSet = new Dictionary<MoveType, Action<Player, Graphics>>
			{
				[MoveType.Down] = Fall,
				[MoveType.Up] = Jump,
				[MoveType.Right] = GoRight,
				[MoveType.Left] = GoLeft,
				[MoveType.Stand] = Stand
			};
			RecalculateCount = (int x, int y) => ((x + y + 1) % (y));
		}

		public void Fall(Player player, Graphics graphics)
		{
			fallFrameCount = RecalculateCount(fallFrameCount, PlayerImages.fallFrames.Count);
			var frame = (Image)PlayerImages.fallFrames[fallFrameCount].Clone();
			if (player.CurrentTypeMovement == MoveType.Right)
				graphics.DrawImage(frame, player.Location);
			else
			{
				frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
				graphics.DrawImage(frame, player.Location);
			}
		}

		public void Jump(Player player, Graphics graphics)
		{
			jumpFrameCount = RecalculateCount(jumpFrameCount, PlayerImages.jumpFrames.Count);
			var frame = (Image)PlayerImages.jumpFrames[jumpFrameCount].Clone();
			if(player.CurrentTypeMovement == MoveType.Right)
				graphics.DrawImage(frame, player.Location);
			else
			{
				frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
				graphics.DrawImage(frame, player.Location);
			}
		}

		public void GoRight(Player player, Graphics graphics)
		{
			if (player.JumpAbility.IsJumping)
				Jump(player, graphics);
			else if (player.JumpAbility.IsFalling)
				Fall(player, graphics);
			else
			{
				runFrameCount = RecalculateCount(runFrameCount, PlayerImages.runFrames.Count);
				graphics.DrawImage(PlayerImages.runFrames[runFrameCount],
					player.Location);
			}
		}

		public void GoLeft(Player player, Graphics graphics)
		{
			if (player.JumpAbility.IsJumping)
				Jump(player, graphics);
			else if (player.JumpAbility.IsFalling)
				Fall(player, graphics);
			else
			{
				runFrameCount = RecalculateCount(runFrameCount, PlayerImages.runFrames.Count);
				var frame = (Image)PlayerImages.runFrames[runFrameCount].Clone();
				frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
				graphics.DrawImage(frame, player.Location);
			}
		}

		public void Stand(Player player, Graphics graphics)
		{
			standFrameCount = RecalculateCount(standFrameCount, PlayerImages.standFrames.Count);
			graphics.DrawImage(PlayerImages.standFrames[standFrameCount],
				player.Location);
		}
	}
}
