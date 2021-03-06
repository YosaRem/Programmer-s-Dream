﻿using System;
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
		public Rectangle Location { get; private set; }
		public MoveType CurrentTypeMovement { get; private set; }
		public JumpAndFall JumpAbility { get; private set; }
		public RightAndLeft GoAbility { get; private set; }
		public PossibilityMove PossibilityMove { get; set; }
		public Wepon PlayerWepon { get; set; }

		public Player(Point startLocation)
		{		
			PossibilityMove = new PossibilityMove();
			var PlayerSize = PlayerImages.standFrames[0].Size;
			Location = new Rectangle(startLocation, PlayerSize);
			CurrentTypeMovement = MoveType.Stand;
			JumpAbility = new JumpAndFall();
			GoAbility = new RightAndLeft();
		}

		public void MakeShot()
		{
			if(PlayerWepon != null)
				PlayerWepon.MakeShot(this);
		}

		public void SetWepon(Level level)
		{
			PlayerWepon = new Wepon(level);
		}

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

		public bool IsPlayerAlive(List<Enemy> enemies, List<Triangle> triangles)
		{
			foreach (var enemy in enemies)
				if (Location.IntersectsWith(enemy.Location))
					return false;
		    foreach (var triangle in triangles)
		        if (Location.IntersectsWith(triangle.Location))
		            return false;
			return true;
		}
	}
}