using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream
{
	public class GameInfo
	{
		public bool IsPlayerAlive { get; set; }
		public bool IsLevelCompleated { get; set; }

		public GameInfo()
		{
			IsPlayerAlive = true;
			IsLevelCompleated = false;
		}

		public void Reset()
		{
			IsPlayerAlive = true;
			IsLevelCompleated = false;
		}
	}
}
