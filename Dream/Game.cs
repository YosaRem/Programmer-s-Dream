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
		public GameInfo CurrentGameInfo { get; set; }
		public Player Player { get; set; }
		public Level CurrentLevel { get; set; }
        public GamesFiles GameFiles { get; set; }

		public Game()
		{
			GameFiles = new GamesFiles();
			ClientSize = new Size(GameFiles.CurrentLevel.Background.Width,
				GameFiles.CurrentLevel.Background.Height);
			DoubleBuffered = true;

			CurrentGameInfo = new GameInfo();
			CurrentLevel = new Level(GameFiles.CurrentLevel);
			Player = new Player(CurrentLevel.StartPlayerLocation);
			var timer = new Timer();		
			timer.Interval = 10;

			
			KeyPressing();
			TickCommands(timer);
			timer.Start();

			Paint += (sender, args) =>
			{
				if (CurrentGameInfo.IsPlayerAlive)
				{
					CurrentLevel.DrawLavel(args.Graphics);
					Player.DrawPlayer(args.Graphics);
				}
				else
					Ads.YouDied(args.Graphics);

			};
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
				if(args.KeyCode == Keys.Right || args.KeyCode == Keys.Left)
					Player.ChangeMoveType(MoveType.Stand, CurrentLevel.Platforms);
			};
		}

		public void TickCommands(Timer timer)
		{
			timer.Tick += (sender, args) => CurrentLevel.MoveEnemy();
			timer.Tick += (sender, args) => Player.Move(CurrentLevel.Platforms);
			timer.Tick += (sender, args) =>
			{
				var isPlayerOk = Player.IsPlayerAlive(CurrentLevel.Enemies);
				if (!isPlayerOk)
					CurrentGameInfo.IsPlayerAlive = false;
			};
			timer.Tick += (sender, args) => Invalidate();
		}

		public void ResetLevel()
		{
			CurrentLevel = new Level(GameFiles.CurrentLevel);
			Player = new Player(CurrentLevel.StartPlayerLocation);
			CurrentGameInfo.Reset();
		}
	}
}
