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
		private List<Image> runFrames = new List<Image>();
		private List<Image> jumpFrames = new List<Image>();
		private List<Image> fallFrames = new List<Image>();
		private List<Image> standFrames = new List<Image>();
		private Func<int, int, int> RecalculateCount;
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
			ExtractFramesFromFolders();
		}

		public void Fall(Player player, Graphics graphics)
		{
			fallFrameCount = RecalculateCount(fallFrameCount, fallFrames.Count);
			var frame = fallFrames[fallFrameCount];
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
			jumpFrameCount = RecalculateCount(jumpFrameCount, jumpFrames.Count);
			var frame = jumpFrames[jumpFrameCount];
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
				runFrameCount = RecalculateCount(runFrameCount, runFrames.Count);
				graphics.DrawImage(runFrames[runFrameCount],
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
				runFrameCount = RecalculateCount(runFrameCount, runFrames.Count);
				var frame = runFrames[runFrameCount];
				frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
				graphics.DrawImage(frame, player.Location);
			}
		}

		public void Stand(Player player, Graphics graphics)
		{
			standFrameCount = RecalculateCount(standFrameCount, standFrames.Count);
			graphics.DrawImage(standFrames[standFrameCount],
				player.Location);
		}

		private void ExtractFramesFromFolders()
		{
			var countFile = new DirectoryInfo(GamesFiles.PlayerImages + @"\Run").GetFiles().Length;
			for (var i = 0; i < countFile; i++)
				runFrames.Add(Image.FromFile(GamesFiles.PlayerImages + @"\Run\" + i.ToString() + ".png"));
			countFile = new DirectoryInfo(GamesFiles.PlayerImages + @"\Fall").GetFiles().Length;
			for (var i = 0; i < countFile; i++)
				fallFrames.Add(Image.FromFile(GamesFiles.PlayerImages + @"\Fall\" + i.ToString() + ".png"));
			countFile = new DirectoryInfo(GamesFiles.PlayerImages + @"\Jump").GetFiles().Length;
			for (var i = 0; i < countFile; i++)
				jumpFrames.Add(Image.FromFile(GamesFiles.PlayerImages + @"\Jump\" + i.ToString() + ".png"));
			countFile = new DirectoryInfo(GamesFiles.PlayerImages + @"\Stand").GetFiles().Length;
			for (var i = 0; i < countFile; i++)
				standFrames.Add(Image.FromFile(GamesFiles.PlayerImages + @"\Stand\" + i.ToString() + ".png"));
		}
	}
}
