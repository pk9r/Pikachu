using Pikachu.DataObject;
using Pikachu.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameControl
{
	internal class GamePlayChecker
	{
		DataGamePlay dataGamePlay;

		public GamePlayChecker(DataGamePlay dataGamePlay)
		{
			this.dataGamePlay = dataGamePlay;
		}

		public List<LineConnect> GetLines(int r1, int c1, int r2, int c2)
		{
			List<LineConnect> lines = new();

			if (dataGamePlay.data[r1, c1] != dataGamePlay.data[r2, c2])
				return lines; // Giá trị 2 ô khác nhau

			if (c1 == c2 && CheckLineC(r1, r2, c1))
			{
				lines.Add(new LineConnect(r1, c1, r2, c2));
			}
			else if (r1 == r2 && CheckLineR(c1, c2, r1))
			{
				lines.Add(new LineConnect(r1, c1, r2, c2));
			}

			return lines;
		}

		private bool CheckLineR(int c1, int c2, int r)
		{
			int min = Math.Min(c1, c2);
			int max = Math.Max(c1, c2);

			for (int col = min + 1; col < max; col++)
				if (dataGamePlay.data[r, col] != 0)
					return false;

			return true;
		}

		private bool CheckLineC(int r1, int r2, int c)
		{
			int min = Math.Min(r1, r2);
			int max = Math.Max(r1, r2);

			for (int row = min + 1; row < max; row++)
				if (dataGamePlay.data[row, c] != 0)
					return false;

			return true;
		}


	}
}
