﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class BugEnemy : Enemy
	{
		public Image BugImage { get; set; }

		public BugEnemy(Point location, List<Point> track) : base(location, track) 
		{
			//TODO load Bug image and override Draw
		}
	}
}
