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
		public MoveType CurrentTypeMovement { get; set; }
		public JumpAndFall JumpAbility { get; set; }
		public RightAndLeft GoAbility { get; set; }
		public PossibilityMove PossibilityMove { get; set; }
		public PlayerAnimation Animation { get; set; }

		public Player(Point startLocation)
		{			
			Animation = new PlayerAnimation();
			PossibilityMove = new PossibilityMove();
			var PlayerSize = Image.FromFile(GamesFiles.PlayerImages + @"\Stand\0.png").Size;
			Location = new Rectangle(startLocation, PlayerSize);
			CurrentTypeMovement = MoveType.Stand;
			JumpAbility = new JumpAndFall();
			GoAbility = new RightAndLeft();
		}

		public void DrawPlayer(Graphics graphics) => Animation.MovementSet[CurrentTypeMovement](this, graphics);

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
