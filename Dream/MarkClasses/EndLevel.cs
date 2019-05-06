using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class EndLevel : Mark
	{
		public EndLevel(Point start, Point end) : base(start, end)
		{
			MarkType = MarkEnum.EndLevel;
		}
	}
}
