using Pikachu.DataObject;
using Pikachu.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameControl
{
	/// <summary>Đối tượng kiểm tra, xử lý các thao tác lựa chọn của game.</summary>
	internal class SelectChecker
	{
		readonly DataGamePlay dataGamePlay;

		// Toạ độ ngoại lệ của rào chắn
		int rowE1, colE1, rowE2, colE2;

		public SelectChecker(DataGamePlay dataGamePlay)
		{
			this.dataGamePlay = dataGamePlay;
		}

		/// <summary>Lấy các đường thẳng nối cặp pokemon với nhau.</summary>
		public List<LineConnect> GetLines(int r1, int c1, int r2, int c2)
		{
			List<LineConnect> lines = new();

			if (dataGamePlay.GetValue(r1, c1) != dataGamePlay.GetValue(r2, c2))
				return lines; // Giá trị 2 ô khác nhau

			rowE1 = r1;
			colE1 = c1;
			rowE2 = r2;
			colE2 = c2;

			if (c1 == c2 && CheckLineC(r1, r2, c1))
			{
				lines.Add(new LineConnect(r1, c1, r2, c2));
				return lines;
			}

			if (r1 == r2 && CheckLineR(c1, c2, r1))
			{
				lines.Add(new LineConnect(r1, c1, r2, c2));
				return lines;
			}

			int col, row;

			col = CheckL(r1, c1, r2, c2);
			if (col != int.MaxValue)
			{
				if (col == c1)
				{
					lines.Add(new LineConnect(r1, c1, r2, c1));
					lines.Add(new LineConnect(r2, c1, r2, c2));
				}
				else
				{
					lines.Add(new LineConnect(r1, c1, r1, c2));
					lines.Add(new LineConnect(r1, c2, r2, c2));
				}
				return lines;
			}

			row = Check3R(r1, c1, r2, c2);
			if (row != int.MaxValue)
			{
				lines.Add(new LineConnect(r1, c1, row, c1));
				lines.Add(new LineConnect(row, c1, row, c2));
				lines.Add(new LineConnect(row, c2, r2, c2));
				return lines;
			}

			col = Check3C(r1, c1, r2, c2);
			if (col != int.MaxValue)
			{
				lines.Add(new LineConnect(r1, c1, r1, col));
				lines.Add(new LineConnect(r1, col, r2, col));
				lines.Add(new LineConnect(r2, col, r2, c2));
				return lines;
			}

			return lines;
		}

		public List<LineConnect> GetLines(int index1, int index2)
		{
			int r1 = index1 / dataGamePlay.numOfCols;
			int c1 = index1 % dataGamePlay.numOfCols;
			int r2 = index2 / dataGamePlay.numOfCols;
			int c2 = index2 % dataGamePlay.numOfCols;

			return GetLines(r1, c1, r2, c2);
		}

		/// <summary>Kiểm tra toạ độ rào chắn.</summary>
		/// <param name="row">The row.</param>
		/// <param name="col">The col.</param>
		bool IsBarrier(int row, int col)
		{
			return (dataGamePlay.GetValue(row, col) != 0 &&
				(row != rowE1 || col != colE1) &&
				(row != rowE2 || col != colE2));
		}

		private bool CheckLineR(int c1, int c2, int r)
		{
			int min = c1, max = c2;
			if (min > max) { max = c1; min = c2; }

			for (int col = min; col <= max; col++)
				if (IsBarrier(r, col))
					return false;

			return true;
		}

		private bool CheckLineC(int r1, int r2, int c)
		{
			int min = r1, max = r2;
			if (min > max) { max = r1; min = r2; }

			for (int row = min; row <= max; row++)
				if (IsBarrier(row, c))
					return false;

			return true;
		}

		private int CheckL(int r1, int c1, int r2, int c2)
		{
			if (CheckLineR(c1, c2, r1) && CheckLineC(r1, r2, c2))
			{
				return c2;
			}

			if (CheckLineC(r1, r2, c1) && CheckLineR(c1, c2, r2))
			{
				return c1;
			}

			return int.MaxValue;
		}

		private int Check3R(int r1, int c1, int r2, int c2)
		{
			int rowP = r1;

			while (rowP < GameControlManagement.TOTAL_ROWS)
			{
				rowP++;

				if (!CheckLineC(r1, rowP, c1))
					break;

				if (CheckL(rowP, c1, r2, c2) != int.MaxValue)
					return rowP;
			}

			int rowS = r1;

			while (rowS >= 0)
			{
				rowS--;
				if (!CheckLineC(r1, rowS, c1))
					break;

				if (CheckL(rowS, c1, r2, c2) != int.MaxValue)
					return rowS;
			}

			return int.MaxValue;
		}

		private int Check3C(int r1, int c1, int r2, int c2)
		{
			int colP = c1;

			while (colP < GameControlManagement.TOTAL_COLUMNS)
			{
				colP++;

				if (!CheckLineR(c1, colP, r1))
					break;

				if (CheckL(r1, colP, r2, c2) != int.MaxValue)
					return colP;
			}


			int colS = c1;

			while (colS >= 0)
			{
				colS--;

				if (!CheckLineR(c1, colS, r1))
					break;

				if (CheckL(r1, colS, r2, c2) != int.MaxValue)
					return colS;
			}

			return int.MaxValue;
		}
	}
}
