using System;
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

		public Enemy(Point location, List<Point> track)
		{
			Location = new Rectangle(location.X, location.Y, 25, 25);
			Track = track;
			CurrentDestinationPoint = 0;
		}

		public virtual void Draw(Graphics graphics)
		{
			graphics.DrawRectangle(new Pen(Color.Black, 1), Location.X, Location.Y,
				Location.Width, Location.Height);
		}	

		public virtual void Move()
		{
			var newX = TrackMove.RecalculateX(this);
			var newY = TrackMove.RecalculateY(this);
			if (newX == Track[CurrentDestinationPoint].X && newY == Track[CurrentDestinationPoint].Y)
				CurrentDestinationPoint = ((CurrentDestinationPoint + Track.Count + 1) % Track.Count);
			Location = new Rectangle(newX, newY, 25, 25);
		}
	}
}
