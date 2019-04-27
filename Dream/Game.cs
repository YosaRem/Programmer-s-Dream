using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Dream
{
	public class Game : Form
	{
		public int GameState { get; set; }
		public Player Player { get; set; }
		public Level CurrentLevel { get; set; }

		public Game(Level level)
		{
			ClientSize = new Size(600, 800);
			DoubleBuffered = true;
			CurrentLevel = level;
			var timer = new Timer();
			Player = new Player(CurrentLevel.StartPlayerLocation);
			timer.Interval = 1;

			KeyPressing();
			Paint += (sender, args) =>
			{
				CurrentLevel.DrawLavel(args.Graphics);
				Player.DrawPlayer(args.Graphics);
			};

			timer.Tick += (sender, args) => Invalidate();
			timer.Tick += (sender, args) => Player.Move(CurrentLevel.Platforms);
			timer.Start();
		}

		public void KeyPressing()
		{
			KeyDown += (sender, args) =>
			{
				if (args.KeyCode == Keys.Up)
					Player.ChangeMoveType(MoveType.Up, CurrentLevel.Platforms);
				if (args.KeyCode == Keys.Right)
					Player.ChangeMoveType(MoveType.Right, CurrentLevel.Platforms);
				if (args.KeyCode == Keys.Left)
					Player.ChangeMoveType(MoveType.Left, CurrentLevel.Platforms);
				if (args.KeyCode == Keys.R)
					ResetLevel();
			};
			KeyUp += (sender, args) =>
			{
				Player.ChangeMoveType(MoveType.Stand, CurrentLevel.Platforms);
			};
		}

		public void ResetLevel()
		{
			CurrentLevel = new Level();
			Player = new Player(CurrentLevel.StartPlayerLocation);
		}
	}
}
