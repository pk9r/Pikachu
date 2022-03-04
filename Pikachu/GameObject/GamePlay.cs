using Pikachu.DataObject;
using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng hiển thị và nhận tương tác với các ô pokemon.</summary>
	internal class GamePlay : ScreenObject, IClickable
	{
		/* Đây là bàn chơi tiêu chuẩn của pikachu classic
		 * Đã phù hợp với kích thước form không nên thay đổi nếu không đổi kích thước form */
		public static readonly int totalRows = 9;
		public static readonly int totalColumns = 16;

		#region Object Draw
		readonly Pen pen = new(Color.Brown);
		#endregion

		public int width;
		public int height;

		public PokemonCell[,] pokemonCells;
		public List<LineConnect> lineConnects;

		public PokemonCell? cellFocus;
		public PokemonCell? cellSelected1;
		public PokemonCell? cellSelected2;

		public GamePlay(int x, int y)
		{
			this.x = x;
			this.y = y;
			width = totalColumns * PokemonCell.width;
			height = totalRows * PokemonCell.height;

			pokemonCells = new PokemonCell[totalRows, totalColumns];

			for (int i = 0; i < totalRows; i++)
				for (int j = 0; j < totalColumns; j++)
				{
					pokemonCells[i, j] = new PokemonCell
					{
						x = this.x + j * PokemonCell.width,
						y = this.y + i * PokemonCell.height,
						row = i,
						col = j,
					};
				}
		}

		public override void Draw(Graphics g)
		{
			DrawPokemonCells(g);
			DrawBorder(g);

			if (lineConnects != null)
				foreach (var line in lineConnects)
				{
					line.Draw(g);
				}
		}

		public void OnClick(object? sender, EventArgs e)
		{
			SelectCell(cellFocus);
		}

		public bool Contains(int x, int y)
		{
			int row = (y - this.y) / PokemonCell.height;
			int col = (x - this.x) / PokemonCell.width;

			if (x >= this.x && y >= this.y &&
				row >= 0 && row < totalRows &&
				col >= 0 && col < totalColumns)
			{
				if (pokemonCells[row, col].image != null)
				{
					cellFocus = pokemonCells[row, col];
					return true;
				}
			}

			cellFocus = null;
			return false;
		}

		public bool Contains(Point point)
		{
			return Contains(point.X, point.Y);
		}

		/// <summary>Hiển thị các ô pokemon</summary>
		/// <param name="g">The g.</param>
		private void DrawPokemonCells(Graphics g)
		{
			foreach (var cell in pokemonCells)
			{
				cell.Draw(g);
			}
		}

		/// <summary>Hiển thị border của đối tượng.</summary>
		/// <param name="g">The g.</param>
		private void DrawBorder(Graphics g)
		{
			g.DrawRectangle(pen, x, y, width, height);
		}

		/// <summary>Lựa chọn một ô pokemon.</summary>
		/// <param name="pokemonCell">The pokemon cell.</param>
		public void SelectCell(PokemonCell? pokemonCell)
		{
			if (pokemonCell != null)
			{
				if (cellSelected1 == null)
				{
					cellSelected1 = pokemonCell;
					cellSelected1.isSelected = true;
				}
				else if (cellSelected1 == cellFocus)
				{
					cellSelected1.isSelected = false;
				}
				else
				{
					cellSelected2 = pokemonCell;
					cellSelected2.isSelected = true;

					lineConnects = GameControlManagement.Instance.SelectPair(
									cellSelected1.row, cellSelected1.col,
									cellSelected2.row, cellSelected2.col);

					UnselectAll();
				}
			}
		}

		/// <summary>Bỏ lựa chọn tất cả các ô pokemon.</summary>
		public void UnselectAll()
		{
			if (cellSelected1 != null)
			{
				cellSelected1.isSelected = false;
				cellSelected1 = null;
			}
			if (cellSelected2 != null)
			{
				cellSelected2.isSelected = false;
				cellSelected2 = null;
			}
		}

		/// <summary>Cập nhập dữ liệu cho đối tượng.</summary>
		public void Update()
		{
			UpdateCell();
			UpdateFocusCell();
			UpdateLines();
		}

		private void UpdateLines()
		{
			if (lineConnects == null)
				return;

			foreach (var line in lineConnects)
			{
				line.Update();
			}
		}

		/// <summary>Cập nhập dữ liệu các ô pokemon.</summary>
		private void UpdateCell()
		{
			foreach (var cell in pokemonCells)
			{
				cell.Update();
			}
		}

		/// <summary>Cập nhập dữ liệu focus cho các ô pokemon.</summary>
		private void UpdateFocusCell()
		{
			foreach (var cell in pokemonCells)
			{
				cell.isFocus = false;
			}

			if (cellFocus != null)
				cellFocus.isFocus = true;
		}
	}
}
