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

		public JumpAndFall(int maxHeight, int jumpDelta)
		{
			MaxJumpHeight = maxHeight;
			JumpDelta = jumpDelta;
		}

		public int RecalculateY(Player player, bool isOnPlatform)
		{
			if (CurrentJumpHeight >= MaxJumpHeight)
			{
				CurrentJumpHeight = 0;
				IsFalling = true;
			}

			if (!IsJumping && !isOnPlatform)
				IsFalling = true;

			var newY = 0;
			if (IsJumping && !IsFalling)
			{
				CurrentJumpHeight++;
				newY -= JumpDelta;
			}

			if (IsFalling)
				newY += JumpDelta;

			if (isOnPlatform)
			{
				IsFalling = IsJumping = false;
			}

			
			return newY;
		}
	}
}
