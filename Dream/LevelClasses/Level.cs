using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Dream
{
	public class Level
	{
        public LevelFiles Files { get; private set; }
		public LevelInformation LevelInform { get; private set; }
		public Player Player { get; set; }
		private GameInfo GameStat { get; set; }

		public Level(LevelFiles files)
		{
			Files = files;
			LevelInform = new LevelInformation(Files);
			Player = new Player(LevelInform.StartPlayerLocation);
			GameStat = new GameInfo();
		}

		public void Move()
		{
			if (GameStat.CanGameContinue())
			{
				foreach (var enemy in LevelInform.Enemies)
					enemy.Move();
				Player.Move(LevelInform.Platforms);
				if(Player.PlayerWepon != null)
					Player.PlayerWepon.MoveBullets();
				IsPlayerIntersectMark();
			}
		}

		public void TransformGameStat(GameInfo gameInfo)
		{
			gameInfo.IsPlayerAlive = Player.IsPlayerAlive(LevelInform.Enemies, LevelInform.Triangles);
			gameInfo.IsLevelCompleated = IsLevelCompeted();
			GameStat = gameInfo;
		}

		private void IsPlayerIntersectMark()
		{
			foreach (var mark in LevelInform.Marks)
			{
				if (mark.MarkType == MarkEnum.GiveWepon)
				{
					if(Player.Location.IntersectsWith(mark.Location))
						Player.SetWepon(this);
				}
			}
		}

		private bool IsLevelCompeted()
		{
			if (!(LevelInform.LevelBoss == null) && LevelInform.LevelBoss.Helth <= 0)
				return true;
			else if (Player.Location.IntersectsWith(LevelInform.LevelFinish))
				return true;
			return false;
		}
	}
}
