using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	class MarkDrawer
	{
		public Dictionary<MarkEnum, Action<Mark, Graphics>> Drawers { get; private set; }

		public MarkDrawer()
		{
			Drawers = new Dictionary<MarkEnum, Action<Mark, Graphics>>()
			{
				[MarkEnum.EndLevel] = DrawEnd,
				[MarkEnum.GiveWepon] = DrawWepon
			};
		}



		private void DrawEnd(Mark mark, Graphics graphics)
		{
			graphics.DrawRectangle(new Pen(Color.Brown, 2), mark.Location);
			graphics.FillRectangle(Brushes.Red, new Rectangle(mark.Location.Location, new Size(30, 10)));
		}

		private void DrawWepon(Mark mark, Graphics graphics)
		{
			graphics.FillRectangle(Brushes.Coral, mark.Location.Left, mark.Location.Top, 20, 5);
			graphics.DrawEllipse(Pens.Coral, mark.Location.X, mark.Location.Y,
				10, 10);
		}
	}
}
