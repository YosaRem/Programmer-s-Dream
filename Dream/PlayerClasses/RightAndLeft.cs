using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class RightAndLeft
	{
		private int GoDelta { get; set; }

		public RightAndLeft(int goDelta)
		{
			GoDelta = goDelta;
		}

		public int RecalculateX(Player player, PossibilityMove possibility)
		{
			if (player.CurrentTypeMovement == MoveType.Stand)
				return player.Location.Left;
			if (player.CurrentTypeMovement == MoveType.Right)
				return possibility.RightWall.HasValue
					? possibility.RightWall.Value.Left - player.Location.Width
					: player.Location.Left + GoDelta;
			if(player.CurrentTypeMovement == MoveType.Left)
				return possibility.LeftWall.HasValue
					? possibility.LeftWall.Value.Right
					: player.Location.Left - GoDelta;
			return player.Location.Left;
		}
	}
}
