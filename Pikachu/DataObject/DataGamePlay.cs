using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.DataObject
{
	/// <summary>Đối tượng thể hiện dữ liệu trong màn chơi.</summary>
	internal class DataGamePlay
	{
		public const int NONE_CELL = 0;

		public int numOfRows, numOfCols;

		/// <summary>Số lượng pokemon trong màn chơi.</summary>
		public int numOfType;

		/// <summary>Thời gian lần bắt đầu màn chơi cuối.</summary>
		public long timeLastStarted;

		/// <summary>Tổng thời gian màn chơi.</summary>
		public int totalTime;

		/// <summary>Thời gian còn lại của màn chơi.</summary>
		public int timeRemaining;

		/// <summary>Số lượt gợi ý.</summary>
		public int countHint;

		/// <summary>Số lượt trộn.</summary>
		public int countShuffle;

		/// <summary>Bảng dữ liệu của màn chơi.</summary>
		public int[,] data;

		/// <summary>Set các ô còn dữ liệu.</summary>
		public SortedSet<int> setCells = new();

		public DataGamePlay(int numOfRows, int numOfCols)
		{
			this.numOfRows = numOfRows;
			this.numOfCols = numOfCols;

			data = new int[numOfRows, numOfCols];
		}

		public int GetValue(int row, int col)
		{
			if (row < 0 || col < 0 || row >= data.GetLength(0) || col >= data.GetLength(1))
				return NONE_CELL;

			return data[row, col];
		}

		public int GetValue(int index)
		{
			return GetValue(index / numOfCols, index % numOfCols);
		}

		public void RemoveCell(int row, int col)
		{
			data[row, col] = NONE_CELL;
			setCells.Remove(row * numOfCols + col);
		}

		/// <summary>Tạo dữ liệu ngẫu nhiên mới.</summary>
		public void GetNewData(DataLevel dataLevel)
		{
			numOfType = dataLevel.numOfType;
			totalTime = dataLevel.totalTime;

			timeLastStarted = DateTime.Now.Ticks;

			List<int> indexes = Enumerable.Range(0, data.Length).ToList();

			Random random = new();
			setCells.Clear();

			int index, typeOfPokemon;

			for (int i = 0; i < data.Length / 2; i++)
			{
				typeOfPokemon = random.Next(1, numOfType + 1);

				index = random.Next(0, indexes.Count);
				int cell1 = indexes[index];
				indexes.RemoveAt(index);
				data[cell1 / numOfCols, cell1 % numOfCols] = typeOfPokemon;
				setCells.Add(cell1);

				index = random.Next(0, indexes.Count);
				int cell2 = indexes[index];
				indexes.RemoveAt(index);
				data[cell2 / numOfCols, cell2 % numOfCols] = typeOfPokemon;
				setCells.Add(cell2);
			}
		}

		/// <summary>Trộn ngẫu nhiên bảng dữ liệu trò chơi.</summary>
		public void Shuffle()
		{
			List<int> vals = new();
			int index;

			Random random = new();

			foreach (var cell in setCells)
			{
				vals.Add(data[cell / numOfCols, cell % numOfCols]);
			}

			foreach (var cell in setCells)
			{
				index = random.Next(0, vals.Count);
				data[cell / numOfCols, cell % numOfCols] = vals[index];
				vals.RemoveAt(index);
			}
		}
	}
}