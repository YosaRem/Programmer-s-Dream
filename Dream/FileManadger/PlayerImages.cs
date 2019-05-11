using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public static class PlayerImages
	{
		public static List<Image> runFrames = new List<Image>();
		public static List<Image> jumpFrames = new List<Image>();
		public static List<Image> fallFrames = new List<Image>();
		public static List<Image> standFrames = new List<Image>();
		public static Dictionary<string, List<Image>> frames = new Dictionary<string, List<Image>>()
		{
			["Run"] = runFrames,
			["Fall"] = fallFrames,
			["Jump"] = jumpFrames,
			["Stand"] = standFrames
		};
	}
}
