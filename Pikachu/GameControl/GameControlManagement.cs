using Pikachu.DataObject;
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
		#region Singleton
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
		#endregion

		public LevelGame CurrentLevel => LevelGame.GetLevelGame(indexCurrentLevel);

		public int indexCurrentLevel = 0;

		public bool isStarted = false;

		public DataGamePlay dataGamePlay = new(GamePlay.totalRows, GamePlay.totalColumns);

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

			dataGamePlay.GenerationData();
			GameObjectManagement.Instance.gamePlay.LoadData(dataGamePlay);
			GameObjectManagement.Instance.gamePlay.UnselectAll();

			isStarted = true;
		}

		public bool CheckRemove(int row1, int col1, int row2, int col2)
		{
			return false;
		}

		public void Update()
		{
			if (isStarted)
			{
				GameObjectManagement.Instance.timeBar.Update();
				GameObjectManagement.Instance.gamePlay.Update();
			}
		}
	}
}
