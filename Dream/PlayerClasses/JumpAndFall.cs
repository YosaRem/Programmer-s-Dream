using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class JumpAndFall
	{
		public bool IsJumping { get; set; }
		public bool IsFalling { get; set; }
		private int MaxJumpHeight { get; set; }
		private int JumpDelta { get; set; }
		public int CurrentJumpHeight { get; set; }
		public int JumpCount { get; set; }
		private int MaxJumpCount { get; set; }

		public JumpAndFall(int maxHeight, int jumpDelta, int maxJumpCount)
		{
			MaxJumpCount = maxJumpCount;
			MaxJumpHeight = maxHeight;
			JumpDelta = jumpDelta;
		}

		public void Jump()
		{
			if (JumpCount < MaxJumpCount)
			{
				JumpCount++;
				CurrentJumpHeight = 0;
				IsJumping = true;
				IsFalling = false;
			}
		}

		public int RecalculateY(Player player, PossibilityMove possibility)
		{
			if(possibility.Floor.HasValue && IsFalling)
			{
				IsFalling = IsJumping = false;
				CurrentJumpHeight = 0;
				JumpCount = 0;
				return possibility.Floor.Value.Top - player.Location.Height;
			}			
			if(CurrentJumpHeight >= MaxJumpHeight)
			{
				CurrentJumpHeight = 0;
				IsJumping = false;
				IsFalling = true;
			}
			if (!possibility.Floor.HasValue && !IsJumping)
				IsFalling = true;
			if (IsJumping)
			{
				if (possibility.Ceiling.HasValue)
				{
					IsFalling = true;
					IsJumping = false;
					CurrentJumpHeight = 0;
					return possibility.Ceiling.Value.Bottom;
				}
				CurrentJumpHeight += JumpDelta;
				return player.Location.Top - JumpDelta;
			}
			if (IsFalling)
				return player.Location.Top + JumpDelta;
			return player.Location.Top;
		}
	}
}
