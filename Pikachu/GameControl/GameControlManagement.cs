using Pikachu.DataObject;
using Pikachu.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameControl
{
	/// <summary>Đối tượng quản lý các thao tác của trò chơi.</summary>
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
			dataGamePlay = new(GamePlay.totalRows, GamePlay.totalColumns);
			gamePlayChecker = new(dataGamePlay);
		}

		public static GameControlManagement Instance => instance;
		#endregion

		public DataLevel CurrentLevel => DataLevel.GetLevelGame(indexCurrentLevel);

		public int indexCurrentLevel = 0;

		public bool isStarted = false;

		public DataGamePlay dataGamePlay;

		public GamePlayChecker gamePlayChecker;

		/// <summary>Kết thúc trò chơi.</summary>
		public void GameOver()
		{
			indexCurrentLevel = 0;
			isStarted = false;
			MessageBox.Show("Game Over");
		}

		/// <summary>Bắt đầu trò chơi mới.</summary>
		public void StartGame()
		{
			GameObjectManagement.Instance.timeBar.timeStart = DateTime.Now.Ticks;
			GameObjectManagement.Instance.timeBar.totalTime = CurrentLevel.totalTime;

			dataGamePlay.GetNewData();
			GameObjectManagement.Instance.gamePlay.UnselectAll();

			isStarted = true;
		}

		public List<LineConnect> SelectPair(int r1, int c1, int r2, int c2)
		{
			var lines = gamePlayChecker.GetLines(r1, c1, r2, c2);
			if (lines.Count > 0)
			{
				dataGamePlay.data[r1, c1] = 0;
				dataGamePlay.data[r2, c2] = 0;
			}

			return lines;
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
