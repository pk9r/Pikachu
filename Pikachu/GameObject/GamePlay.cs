using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class GamePlay : ScreenObject, IClickable
	{

		/* Đây là bàn chơi tiêu chuẩn của pikachu classic
		 * Đã phù hợp với kích thước form không nên thay đổi nếu không đổi kích thước form */
		public static readonly int row = 9;
		public static readonly int col = 16;

		public int width;
		public int height;

		public PokemonCell[,] pokemonCells;

		public GamePlay(int x, int y)
		{
			this.x = x;
			this.y = y;
			width = col * PokemonCell.width;
			height = row * PokemonCell.height;

			pokemonCells = new PokemonCell[row, col];

			for (int i = 0; i < row; i++)
				for (int j = 0; j < col; j++)
				{
					pokemonCells[i, j] = new PokemonCell
					{
						x = this.x + j * 40,
						y = this.y + i * 50,
					};
				}
		}

		public void LoadData(int[,] data)
		{
			for (int i = 0; i < row; i++)
				for (int j = 0; j < col; j++)
				{
					pokemonCells[i, j].image = PokemonCell.GetImage(data[i, j]);
				}
		}

		public override void Draw(Graphics g)
		{
			for (int i = 0; i < row; i++)
				for (int j = 0; j < col; j++)
				{
					pokemonCells[i, j].Draw(g);
				}
		}

		public void OnClick(object? sender, EventArgs e)
		{
			MouseEventArgs? mouseEvent = e as MouseEventArgs;
			if (mouseEvent != null)
			{
				int row = (mouseEvent.Y - y) / PokemonCell.height;
				int col = (mouseEvent.X - x) / PokemonCell.width;

				pokemonCells[row, col].image = null;
			}


		}

		public bool Contains(int x, int y)
		{
			Rectangle rectangle = new Rectangle(this.x, this.y, width, height);
			if (!rectangle.Contains(x, y))
				return false;

			int row = (y - this.y) / PokemonCell.height;
			int col = (x - this.x) / PokemonCell.width;

			if (pokemonCells[row, col].image != null)
				return true;
			return false;
		}

		public bool Contains(Point point)
		{
			return Contains(point.X, point.Y);
		}
	}
}
