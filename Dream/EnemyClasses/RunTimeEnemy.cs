using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dream.EnemyClasses
{
	public class RunTimeEnemy : Enemy
	{
		private Image RTImage { get; set; }
		private int Leap { get; set; }
		private Rectangle FreaseLocation { get; set; }

		public RunTimeEnemy(Point location, List<Point> track, string dir) : base(location, track)
		{
			Leap = Config.Leap;
			RTImage = Image.FromFile(dir + @"\RT.png");
		}

		public override void Draw(Graphics graphics)
		{
			if (Leap == Config.Leap)
			{
				FreaseLocation = Location;
				Leap = 0;
			}
			Leap++;
			graphics.DrawImage(RTImage, FreaseLocation);
		}
	}
}
