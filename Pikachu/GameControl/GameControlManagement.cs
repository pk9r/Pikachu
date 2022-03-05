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
			dataGamePlay = new(TOTAL_ROWS, TOTAL_COLUMNS);
			gamePlayChecker = new(dataGamePlay);

			dataGamePlay.Timeout += DataGamePlay_Timeout;
		}

		public static GameControlManagement Instance => instance;
		#endregion

		/* Đây là bàn chơi tiêu chuẩn của pikachu classic
		 * Đã phù hợp với kích thước form
		 * Không nên thay đổi nếu không đổi kích thước form */
		public const int TOTAL_ROWS = 9;
		public const int TOTAL_COLUMNS = 16;

		public DataLevel CurrentLevel => DataLevel.GetLevelGame(indexCurrentLevel);

		public int indexCurrentLevel = -1;

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

		/// <summary>Chuyển level tiếp theo.</summary>
		public void NextLevel()
		{
			indexCurrentLevel++;
			dataGamePlay.GetNewData(CurrentLevel);

			GameObjectManagement.Instance.timeBar.UpdateData();
			GameObjectManagement.Instance.gamePlay.UnselectAll();

			isStarted = true;
		}

		/// <summary>Lựa chọn 1 cặp ô.</summary>
		/// <param name="r1">The r1.</param>
		/// <param name="c1">The c1.</param>
		/// <param name="r2">The r2.</param>
		/// <param name="c2">The c2.</param>
		/// <returns>
		///   <para>Các đoạn thẳng kết nối cặp ô pokemon (nếu lựa chọn hợp lệ)</para>
		///   <para>Danh sách rỗng (nếu lựa chọn không hợp lệ)<br /></para>
		/// </returns>
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
				GameObjectManagement.Instance.Update();

				dataGamePlay.Update();
			}
		}
		private void DataGamePlay_Timeout(object? sender, EventArgs e)
		{
			Instance.GameOver();
		}
	}
}
