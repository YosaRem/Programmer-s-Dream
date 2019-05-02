using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class RightAndLeft
	{
		public int RecalculateX(Player player, PossibilityMove possibility)
		{
			if (player.CurrentTypeMovement == MoveType.Stand)
				return player.Location.Left;
			if (player.CurrentTypeMovement == MoveType.Right)
				return possibility.RightWall.HasValue
					? possibility.RightWall.Value.Left - player.Location.Width
					: player.Location.Left + Config.PlayerGoDelta;
			if (player.CurrentTypeMovement == MoveType.Left)
				return possibility.LeftWall.HasValue
					? possibility.LeftWall.Value.Right
					: player.Location.Left - Config.PlayerGoDelta;
			return player.Location.Left;
		}
	}
}
