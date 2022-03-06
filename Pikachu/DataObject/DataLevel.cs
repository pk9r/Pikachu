using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu
{
	/// <summary>Đối tượng thể hiện dữ liệu cấp độ trò chơi.</summary>
	internal class DataLevel
	{
		/// <summary>Số màn chơi.</summary>
		public int level;

		/// <summary>Tổng thời gian màn chơi.</summary>
		public int totalTime;

		/// <summary>Số lượng pokemon của màn chơi.</summary>
		public int numOfType;

		/// <summary>Số hàng của màn chơi.</summary>
		public int numOfRows = GameControlManagement.TOTAL_ROWS;

		/// <summary>Số cột của màn chơi.</summary>
		public int numOfCols = GameControlManagement.TOTAL_COLUMNS;

		public static DataLevel customLevel = new() { level = 0, numOfRows = 9, numOfCols = 16, numOfType = 25, totalTime = 400};

		public static List<DataLevel> levelGames = new()
		{
			new() { level = 1, totalTime = 600, numOfType = 15 },
			new() { level = 2, totalTime = 600, numOfType = 20 },
			new() { level = 3, totalTime = 550, numOfType = 20 },
			new() { level = 4, totalTime = 550, numOfType = 25 },
			new() { level = 5, totalTime = 550, numOfType = 25 },
			new() { level = 6, totalTime = 500, numOfType = 25 },
			new() { level = 7, totalTime = 500, numOfType = 30 },
			new() { level = 8, totalTime = 450, numOfType = 30 },
			new() { level = 9, totalTime = 450, numOfType = 36 },
			new() { level = 10, totalTime = 400, numOfType = 36 },
		};

		public static DataLevel GetLevelGame(int index)
		{
			if (index == -1)
				return customLevel;

			if (index < 0)
				return levelGames.First();

			if (index >= levelGames.Count)
				return levelGames.Last();

			return levelGames[index];
		}
	}
}
