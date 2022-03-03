using Pikachu.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameControl
{
	internal class GameControlManagement
	{
		private static readonly GameControlManagement instance = new();

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static GameControlManagement()
		{
		}

		private GameControlManagement()
		{
		}

		public static GameControlManagement Instance => instance;

		public LevelGame CurrentLevel => LevelGame.GetLevelGame(indexCurrentLevel);

		public int indexCurrentLevel = 0;

		public bool isStarted = false;

		public void GameOver()
		{
			indexCurrentLevel = 0;
			isStarted = false;
			MessageBox.Show("Game Over");
		}

		public void StartGame()
		{
			GameObjectManagement.Instance.timeBar.timeStart = DateTime.Now.Ticks;
			GameObjectManagement.Instance.timeBar.totalTime = CurrentLevel.totalTime;
			isStarted = true;
		}

		public void Update()
		{
			if (isStarted)
			{
				GameObjectManagement.Instance.timeBar.Update();
			}
		}
	}
}
