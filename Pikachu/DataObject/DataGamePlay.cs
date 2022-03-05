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
		/// <summary>Số lượng pokemon trong màn chơi.</summary>
		public int numOfType;

		/// <summary>Thời gian lần bắt đầu màn chơi cuối.</summary>
		public long timeLastStarted;

		/// <summary>Tổng thời gian màn chơi.</summary>
		public int totalTime;

		/// <summary>Thời gian còn lại của màn chơi.</summary>
		public int timeRemaining;

		/// <summary>Bảng dữ liệu của màn chơi.</summary>
		public int[,] data;

		public event EventHandler? Timeout;

		public DataGamePlay(int row, int col)
		{
			data = new int[row, col];
		}

		public int GetValue(int row, int col)
		{
			if (row < 0 || col < 0 || row >= data.GetLength(0) || col >= data.GetLength(1))
				return 0;

			return data[row, col];
		}

		/// <summary>Tạo dữ liệu ngẫu nhiên mới.</summary>
		public void GetNewData(DataLevel dataLevel)
		{
			numOfType = dataLevel.numOfType;
			totalTime = dataLevel.totalTime;

			timeLastStarted = DateTime.Now.Ticks;

			List<int> indexes = Enumerable.Range(0, data.Length).ToList();

			Random random = new();

			int col = data.GetLength(1);
			int index, typeOfPokemon;

			for (int i = 0; i < data.Length / 2; i++)
			{
				typeOfPokemon = random.Next(1, numOfType + 1);

				index = random.Next(0, indexes.Count);
				int cell1 = indexes[index];
				indexes.RemoveAt(index);
				data[cell1 / col, cell1 % col] = typeOfPokemon;

				index = random.Next(0, indexes.Count);
				int cell2 = indexes[index];
				indexes.RemoveAt(index);
				data[cell2 / col, cell2 % col] = typeOfPokemon;
			}
		}

		public void Update()
		{
			timeRemaining = (int)(totalTime - (DateTime.Now.Ticks - timeLastStarted) / 10000000);
			if (timeRemaining < 0)
			{
				timeRemaining = 0;
				OnTimeout();
			}
		}

		private void OnTimeout()
		{
			Timeout?.Invoke(this, new EventArgs());
		}
	}
}