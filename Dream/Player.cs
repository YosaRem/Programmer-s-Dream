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
		public bool IsJumping { get; set; }
		public bool IsFalling { get; set; }
		private const int MaxJumpHeight = 100;
		private int currentJumpHeight;
		public int CurrentJumpHeight
		{
			get { return currentJumpHeight; }
			set
			{
				if (currentJumpHeight > MaxJumpHeight)
				{
					IsFalling = true;
					currentJumpHeight = 0;
				}

				currentJumpHeight++;
			}
		}

		public Player(Point startLocation)
		{
			MovementSet = new Dictionary<MoveType, Action<Player, Graphics>>();
			MovementSet[MoveType.Down] = PlayerAnimation.Fall;
			MovementSet[MoveType.Up] = PlayerAnimation.Jump;
			MovementSet[MoveType.Right] = PlayerAnimation.GoRight;
			MovementSet[MoveType.Left] = PlayerAnimation.GoLeft;
			MovementSet[MoveType.Stand] = PlayerAnimation.Stand;

			Location = startLocation;
			CurrentTypeMovement = MoveType.Stand;
			CurrentJumpHeight = 0;
			PlayerSize = new Size(25, 25);
		}

		public void DrawPlayer(Graphics graphics) => MovementSet[CurrentTypeMovement](this, graphics);

		public void ChangeMoveType(MoveType newMove, List<Rectangle> platforms)
		{
			if ((newMove == MoveType.Left || newMove == MoveType.Right) && IsStandOnPlatform(platforms))
				CurrentTypeMovement = newMove;
			if (newMove == MoveType.Up && !IsJumping)
				IsJumping = true;

			if (newMove == MoveType.Stand && IsStandOnPlatform(platforms))
				CurrentTypeMovement = MoveType.Stand;
		}

		public bool IsStandOnPlatform(List<Rectangle> platforms)
		{
			return true;
		}

		public void Move(List<Rectangle> platforms)
		{
			var newX = Location.X;
			var newY = Location.Y;
			if (CurrentTypeMovement == MoveType.Right)
				newX++;
			if (CurrentTypeMovement == MoveType.Left)
				newX--;
			if (IsJumping && !IsFalling)
			{
				CurrentJumpHeight++;
				newY--;
			}

			if (IsStandOnPlatform(platforms))
			{
				IsFalling = IsJumping = false;
			}

			if (IsFalling)
				newY++;	
			Location = new Point(newX, newY);
		}
	}
}
