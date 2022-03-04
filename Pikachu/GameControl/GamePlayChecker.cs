using Pikachu.DataObject;
using Pikachu.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameControl
{
	/// <summary>
	///   <para>Đối tượng kiểm tra, xử lý các thao tác của GamePlay.</para>
	///   <para>
	///     <strong>CẢNH BÁO</strong>
	///   </para>
	///   <para>Đoạn code dưới đây là ma thuật</para>
	///   <para>Lúc tôi code chỉ có tôi và chúa hiểu giờ thì chỉ có mình chúa mới hiểu</para>
	/// </summary>
	internal class GamePlayChecker
	{
		readonly DataGamePlay dataGamePlay;

		// Toạ độ ngoại lệ của rào chắn
		int rowE1, colE1, rowE2, colE2;

		public GamePlayChecker(DataGamePlay dataGamePlay)
		{
			this.dataGamePlay = dataGamePlay;
		}

		/// <summary>Lấy các đường thẳng nối cặp pokemon với nhau.</summary>
		/// <param name="r1">The r1.</param>
		/// <param name="c1">The c1.</param>
		/// <param name="r2">The r2.</param>
		/// <param name="c2">The c2.</param>
		/// <returns>Các đường thẳng nối cặp pokemon được chọn lại với nhau.</returns>
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

			int row = CheckRectR(r1, c1, r2, c2);
			if (row != -1)
			{
				lines.Add(new LineConnect(r1, c1, row, c1));
				lines.Add(new LineConnect(row, c1, row, c2));
				lines.Add(new LineConnect(row, c2, r2, c2));
				return lines;
			}

			int col = CheckRectC(r1, c1, r2, c2);
			if (col != -1)
			{
				lines.Add(new LineConnect(r1, c1, r1, col));
				lines.Add(new LineConnect(r1, col, r2, col));
				lines.Add(new LineConnect(r2, col, r2, c2));
				return lines;
			}

			col = CheckMoreLineR(r1, c1, r2, c2, 1);
			if (col != -1)
			{
				lines.Add(new LineConnect(r1, c1, r1, col));
				lines.Add(new LineConnect(r1, col, r2, col));
				lines.Add(new LineConnect(r2, col, r2, c2));
				return lines;
			}

			col = CheckMoreLineR(r1, c1, r2, c2, -1);
			if (col != -1)
			{
				lines.Add(new LineConnect(r1, c1, r1, col));
				lines.Add(new LineConnect(r1, col, r2, col));
				lines.Add(new LineConnect(r2, col, r2, c2));
				return lines;
			}

			row = CheckMoreLineC(r1, c1, r2, c2, 1);
			if (row != -1)
			{
				lines.Add(new LineConnect(r1, c1, row, c1));
				lines.Add(new LineConnect(row, c1, row, c2));
				lines.Add(new LineConnect(row, c2, r2, c2));
				return lines;
			}

			row = CheckMoreLineC(r1, c1, r2, c2, -1);
			if (row != -1)
			{
				lines.Add(new LineConnect(r1, c1, row, c1));
				lines.Add(new LineConnect(row, c1, row, c2));
				lines.Add(new LineConnect(row, c2, r2, c2));
				return lines;
			}

			return lines;
		}

		/// <summary>Kiểm tra đường thẳng 1 hàng.</summary>
		/// <param name="c1">The c1.</param>
		/// <param name="c2">The c2.</param>
		/// <param name="r">The r.</param>
		/// <returns>
		///   <br />
		/// </returns>
		private bool CheckLineR(int c1, int c2, int r)
		{
			int min = c1, max = c2;
			if (min > max) { max = c1; min = c2; }

			for (int col = min; col <= max; col++)
				if (IsBarrier(r, col))
					return false;

			return true;
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

		private bool CheckLineC(int r1, int r2, int c)
		{
			int min = r1, max = r2;
			if (min > max) { max = r1; min = r2; }

			for (int row = min; row <= max; row++)
				if (IsBarrier(row, c))
					return false;

			return true;
		}

		private int CheckRectR(int r1, int c1, int r2, int c2)
		{
			int rpRMin = r1, cpRMin = c1, rpRMax = r2, cpRMax = c2;
			if (rpRMin > rpRMax)
			{
				cpRMax = c1; cpRMin = c2;
				rpRMax = r1; rpRMin = r2;
			}

			for (int row = rpRMin + 1; row < rpRMax; row++)
			{
				if (CheckLineC(rpRMin, row, cpRMin) &&
					CheckLineR(cpRMin, cpRMax, row) &&
					CheckLineC(row, rpRMax, cpRMax))
					return row;
			}

			return -1;
		}

		private int CheckRectC(int r1, int c1, int r2, int c2)
		{
			int rpCMin = r1, cpCMin = c1, rpCMax = r2, cpCMax = c2;
			if (cpCMin > cpCMax)
			{
				cpCMax = c1; cpCMin = c2;
				rpCMax = r1; rpCMin = r2;
			}

			for (int col = cpCMin + 1; col < cpCMax; col++)
			{
				if (CheckLineR(cpCMin, col, rpCMin) &&
					CheckLineC(rpCMin, rpCMax, col) &&
					CheckLineR(col, cpCMax, rpCMax))
					return col;
			}

			return -1;
		}

		private int CheckMoreLineC(int r1, int c1, int r2, int c2, int type)
		{
			int rpCMin = r1, cpCMin = c1, rpCMax = r2, cpCMax = c2;
			if (cpCMin > cpCMax)
			{
				cpCMax = c1; cpCMin = c2;
				rpCMax = r1; rpCMin = r2;
			}

			int row = cpCMax;
			int col = cpCMin;
			if (type == -1)
			{
				row = rpCMin;
				col = cpCMax;
			}
			if (CheckLineC(cpCMin, rpCMax, col))
			{
				while (!IsBarrier(cpCMin, row)
						&& !IsBarrier(cpCMax, row))
				{
					if (CheckLineR(cpCMin, cpCMax, row))
					{
						return row;
					}
					row += type;
				}
			}
			return -1;
		}

		private int CheckMoreLineR(int r1, int c1, int r2, int c2, int type)
		{
			int rpRMin = r1, cpRMin = c1, rpRMax = r2, cpRMax = c2;
			if (rpRMin > rpRMax)
			{
				cpRMax = c1; cpRMin = c2;
				rpRMax = r1; rpRMin = r2;
			}

			int col = cpRMax;
			int row = rpRMin;
			if (type == -1)
			{
				col = cpRMin;
				row = rpRMax;
			}
			if (CheckLineR(cpRMin, cpRMax, row))
			{
				while (!IsBarrier(col, rpRMin)
						&& !IsBarrier(col, rpRMax))
				{
					if (CheckLineC(rpRMin, rpRMax, col))
					{
						return col;
					}
					col += type;
				}
			}
			return -1;
		}
	}
}
