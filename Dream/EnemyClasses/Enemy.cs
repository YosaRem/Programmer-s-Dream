﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class Enemy
	{
		public Rectangle Location { get; set; }
		public List<Point> Track { get; set; }
		public int CurrentDestinationPoint { get; set; }
		public EnemyType TypeEnemy { get; set; }

		public Enemy(Point location, List<Point> track)
		{
			Location = new Rectangle(location.X, location.Y, EnemyImages.Bug.Width, EnemyImages.Bug.Height);
			Track = track;
			CurrentDestinationPoint = 0;
		}

		public virtual void Move()
		{
			var newX = this.RecalculateX();
			var newY = this.RecalculateY();
			if (newX == Track[CurrentDestinationPoint].X && newY == Track[CurrentDestinationPoint].Y)
				CurrentDestinationPoint = ((CurrentDestinationPoint + Track.Count + 1) % Track.Count);
			Location = new Rectangle(newX, newY, Location.Width, Location.Height);
		}
	}
}
