using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class RunTimeEnemy : Enemy
	{
		private Image RTImage { get; set; }
		private int Leap { get; set; }
		private Rectangle RecalculatedLocation { get; set; }

		public RunTimeEnemy(Point location, List<Point> track, string dir) : base(location, track)
		{ 
			Leap = Config.Leap;
			RTImage = Image.FromFile(dir + @"\RT.png");
			RecalculatedLocation = Location;
		}

		public override void Draw(Graphics graphics)
		{
			if (Leap == Config.Leap)
			{
				Location = RecalculatedLocation;
				Leap = 0;
			}
			Leap++;
			graphics.DrawImage(RTImage, Location);
		}

		public override void Move()
		{
			var newX = TrackMove.RecalculateX(this, Config.RunTimeEnemyMoveDelta);
			var newY = TrackMove.RecalculateY(this, Config.RunTimeEnemyMoveDelta);
			if (newX == Track[CurrentDestinationPoint].X && newY == Track[CurrentDestinationPoint].Y)
				CurrentDestinationPoint = ((CurrentDestinationPoint + Track.Count + 1) % Track.Count);
			RecalculatedLocation = new Rectangle(newX, newY, 25, 25);
		}
	}
}
