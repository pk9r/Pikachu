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
		/// <summary>Số lượng pokemon</summary>
		public static readonly int numOfType = 10;

		/// <summary>Bảng dữ liệu của màn chơi.</summary>
		public int[,] data;

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
		public void GetNewData()
		{
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
	}
}