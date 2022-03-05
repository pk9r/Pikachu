using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đường thẳng kết nối các ô pokemon.</summary>
	internal class LineConnect : IScreenObject, IUpdatable
	{
		readonly Pen pen = new(Color.Red, 5);
		readonly int timeShow = 500;
		readonly long timeStart;

		public int r1, c1, r2, c2;
		public bool isShow = true;

		public LineConnect(int r1, int c1, int r2, int c2)
		{
			this.r1 = r1;
			this.c1 = c1;
			this.r2 = r2;
			this.c2 = c2;

			timeStart = DateTime.Now.Ticks;
		}

		public void Draw(Graphics g)
		{
			if (!isShow)
				return;

			int xBase = GameObjectManagement.Instance.gamePlay.x;
			int yBase = GameObjectManagement.Instance.gamePlay.y;

			int x1 = c1 * PokemonCell.width + PokemonCell.width / 2 + xBase;
			int y1 = r1 * PokemonCell.height + PokemonCell.height / 2 + yBase;
			int x2 = c2 * PokemonCell.width + PokemonCell.width / 2 + xBase;
			int y2 = r2 * PokemonCell.height + PokemonCell.height / 2 + yBase;
			g.DrawLine(pen, x1, y1, x2, y2);
		}

		/// <summary>Cập nhập dữ liệu cho đối tượng</summary>
		public void Update()
		{
			if ((DateTime.Now.Ticks - timeStart) / 10000 > timeShow)
			{
				isShow = false;
			}
		}
	}
}
