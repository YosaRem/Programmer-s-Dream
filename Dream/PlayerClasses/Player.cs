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
		public Rectangle Location { get; set; }
		public Dictionary<MoveType, Action<Player, Graphics>> MovementSet { get; private set; }
		public MoveType CurrentTypeMovement { get; set; }
		public JumpAndFall JumpAbility { get; set; }
		public RightAndLeft GoAbility { get; set; }
		public PossibilityMove PossibilityMove { get; set; }

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

			PossibilityMove = new PossibilityMove();
			Location = new Rectangle(startLocation, new Size(25, 25));
			CurrentTypeMovement = MoveType.Stand;
			JumpAbility = new JumpAndFall(50, 2, 2);
			GoAbility = new RightAndLeft(2);
		}

		public void DrawPlayer(Graphics graphics) => MovementSet[CurrentTypeMovement](this, graphics);

		public void ChangeMoveType(MoveType newMove, List<Rectangle> platforms)
		{
			if (newMove == MoveType.Right || newMove == MoveType.Left)
				CurrentTypeMovement = newMove;
			if (newMove == MoveType.Up)
				JumpAbility.Jump();
			if (newMove == MoveType.Stand)
				CurrentTypeMovement = MoveType.Stand;
		}		

		public void Move(List<Rectangle> platforms)
		{
			PossibilityMove.RecalculatePossibilitys(this, platforms);
			var newX = GoAbility.RecalculateX(this, PossibilityMove);
			var newY = JumpAbility.RecalculateY(this, PossibilityMove);
			Location = new Rectangle(new Point(newX, newY), Location.Size);
		}
	}
}
