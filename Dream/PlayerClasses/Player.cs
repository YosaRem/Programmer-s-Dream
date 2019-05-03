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
		private Dictionary<MoveType, Action<Player, Graphics>> MovementSet { get; set; }
		public MoveType CurrentTypeMovement { get; set; }
		public JumpAndFall JumpAbility { get; set; }
		public RightAndLeft GoAbility { get; set; }
		public PossibilityMove PossibilityMove { get; set; }
        public Image Image { get; set; }

		public Player(Point startLocation, Image playerImage)
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
			JumpAbility = new JumpAndFall(50, 2);
			GoAbility = new RightAndLeft();
		    Image = playerImage;
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

		public bool IsPlayerAlive(List<Enemy> enemies)
		{
			foreach (var enemy in enemies)
				return !(enemy.Location.Left <= Location.Right
				        && Location.Left <= enemy.Location.Right
				        && enemy.Location.Top <= Location.Bottom
				        && Location.Top <= enemy.Location.Bottom);
			return true;
		}
	}
}
