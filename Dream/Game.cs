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
			var timer = new Timer();		
			timer.Interval = 10;

			KeyPressing();
			TickCommands(timer);
			timer.Start();

			Paint += (sender, args) =>
			{
				if (CurrentGameInfo.IsLevelCompleated)
					Ads.LevelCompleted(args.Graphics);
				else if (CurrentGameInfo.IsPlayerAlive)
					Drawer.DrawAll(CurrentLevel, args.Graphics);
				else
					Ads.YouDied(args.Graphics);
			};
		}

		public void KeyPressing()
		{
			KeyDown += (sender, args) =>
			{
				if (args.KeyCode == Keys.Up)
					CurrentLevel.Player.ChangeMoveType(MoveType.Up, CurrentLevel.LevelInform.Platforms);
				if (args.KeyCode == Keys.Right)
					CurrentLevel.Player.ChangeMoveType(MoveType.Right, CurrentLevel.LevelInform.Platforms);
				if (args.KeyCode == Keys.Left)
					CurrentLevel.Player.ChangeMoveType(MoveType.Left, CurrentLevel.LevelInform.Platforms);
				if (args.KeyCode == Keys.R)
					ResetLevel();
				if (args.KeyCode == Keys.Space)
				{
					if (CurrentGameInfo.IsLevelCompleated)
					{
						GameFiles.GetNextLevel();
						CurrentLevel = new Level(GameFiles.CurrentLevel);
					}
				}
			};
			KeyUp += (sender, args) =>
			{
				if(args.KeyCode == Keys.Right || args.KeyCode == Keys.Left)
					CurrentLevel.Player.ChangeMoveType(MoveType.Stand, CurrentLevel.LevelInform.Platforms);
			};
		}

		public void TickCommands(Timer timer)
		{
			timer.Tick += (sender, args) => CurrentLevel.Move();
			timer.Tick += (sender, args) => CurrentLevel.TransformGameStat(CurrentGameInfo);
			timer.Tick += (sender, args) => Invalidate();
		}

		public void ResetLevel()
		{
			CurrentLevel = new Level(GameFiles.CurrentLevel);
			CurrentLevel.Player = new Player(CurrentLevel.LevelInform.StartPlayerLocation);
			CurrentGameInfo.Reset();
		}
	}
}
