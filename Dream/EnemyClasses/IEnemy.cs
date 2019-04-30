using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	interface IEnemy
	{
		Rectangle Location { get; set; }
		Image EnemyImage { get; set; }


	}
}
