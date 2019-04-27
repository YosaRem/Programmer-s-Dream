using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Dream
{
	public class Player
	{
		public Point Location { get; set; }
		public Size PlayerSize { get; set; }
		public Dictionary<MoveType, Action<Player, Graphics>> MovementSet { get; set; }
		public MoveType CurrentTypeMovement { get; set; }
		public JumpAndFall JumpAbility { get; set; }

		public Player(Point startLocation)
		{
			MovementSet = new Dictionary<MoveType, Action<Player, Graphics>>
			{
				[MoveType.Down] = PlayerAnimation.Fall,
				[MoveType.Up] = PlayerAnimation.Jump,
				[MoveType.Right] = PlayerAnimation.GoRight,
				[MoveType.Left] = PlayerAnimation.GoLeft,
				[MoveType.Stand] = PlayerAnimation.Stand
			};

			Location = startLocation;
			CurrentTypeMovement = MoveType.Stand;
			JumpAbility = new JumpAndFall(50, 4);
			PlayerSize = new Size(25, 25);
		}

		public void DrawPlayer(Graphics graphics) => MovementSet[CurrentTypeMovement](this, graphics);

		public void ChangeMoveType(MoveType newMove, List<Rectangle> platforms)
		{
			if (newMove == MoveType.Left || newMove == MoveType.Right)
				CurrentTypeMovement = newMove;
			if (newMove == MoveType.Up && !JumpAbility.IsJumping)
				JumpAbility.IsJumping = true;

			if (newMove == MoveType.Stand)
				CurrentTypeMovement = MoveType.Stand;
		}

		public bool IsStandOnPlatform(List<Rectangle> platforms)
		{
			foreach (var platform in platforms)
				if(platform.X < Location.X && platform.X + platform.Width > Location.X)
					if (platform.Y <= Location.Y + PlayerSize.Height)
						return true;
			return false;
		}

		public void Move(List<Rectangle> platforms)
		{
			var newX = Location.X;
			var newY = Location.Y;
			if (CurrentTypeMovement == MoveType.Right)
				newX++;
			if (CurrentTypeMovement == MoveType.Left)
				newX--;
			newY += JumpAbility.RecalculateY(this, IsStandOnPlatform(platforms));
			Location = new Point(newX, newY);
		}
	}
}
