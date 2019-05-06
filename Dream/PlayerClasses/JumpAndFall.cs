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
		public int CurrentJumpHeight { get; set; }
		public int JumpCount { get; set; }

		public void Jump()
		{
			if (JumpCount < Config.MaxJumpCount)
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
			if(CurrentJumpHeight >= Config.MaxJumpHeight)
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
				CurrentJumpHeight += Config.PlayerJumpDelta; ;
				return player.Location.Top - Config.PlayerJumpDelta; ;
			}
			if (IsFalling)
				return player.Location.Top + Config.PlayerJumpDelta; ;
			return player.Location.Top;
		}
	}
}
