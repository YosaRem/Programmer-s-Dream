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
		public int Leap { get; set; }
		public Rectangle RecalculatedLocation { get; private set; }

		public RunTimeEnemy(Point location, List<Point> track) : base(location, track)
		{
			TypeEnemy = EnemyType.RunTime;
			Leap = Config.Leap;
			RecalculatedLocation = Location;
		}

		public override void Move()
		{
			var newX = TrackMove.RecalculateX(this, Config.RunTimeEnemyMoveDelta);
			var newY = TrackMove.RecalculateY(this, Config.RunTimeEnemyMoveDelta);
			if (newX == Track[CurrentDestinationPoint].X && newY == Track[CurrentDestinationPoint].Y)
				CurrentDestinationPoint = ((CurrentDestinationPoint + Track.Count + 1) % Track.Count);
			RecalculatedLocation = new Rectangle(newX, newY, Location.Width, Location.Height);
		}
	}
}
