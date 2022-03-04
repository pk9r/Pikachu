using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.DataObject
{
	internal class DataGamePlay
	{
		/// <summary>Số lượng pokemon</summary>
		public static readonly int numOfType = 36;

		public int[,] data;

		public DataGamePlay(int row, int col)
		{
			data = new int[row, col];
		}

		/// <summary>Khởi tạo dữ liệu ngẫu nhiên</summary>
		public void GenerationData()
		{
			HashSet<int> cellIndex = new();

			Random random = new();

			int col = data.GetLength(1);

			for (int i = 0; i < data.Length / 2; i++)
			{
				int typeOfPokemon = random.Next(1, numOfType + 1);

				int cell1 = random.Next(random.Next(0, data.Length + 1));
				while (cellIndex.Contains(cell1))
					cell1 = random.Next(random.Next(0, data.Length + 1));
				data[cell1 / col, cell1 % col] = typeOfPokemon;
				cellIndex.Add(cell1);

				int cell2 = random.Next(random.Next(0, data.Length + 1));
				while (cellIndex.Contains(cell2))
					cell2 = random.Next(random.Next(0, data.Length + 1));
				data[cell2 / col, cell2 % col] = typeOfPokemon;
				cellIndex.Add(cell2);
			}
		}
	}
}