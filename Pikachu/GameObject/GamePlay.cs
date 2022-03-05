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
	internal class GamePlay : ScreenObject, IClickable, IUpdatable, IUpdateDataLevel
	{
		public readonly int width, height;

		#region Object Draw
		readonly Pen pen = new(Color.Brown);
		#endregion

		/// <summary>Mảng 2 chiều chứa các ô pokemon.</summary>
		public PokemonCell[,] pokemonCells;

		/// <summary>Danh sách các đường thẳng kết nối cặp ô pokemon khi nhận điểm.</summary>
		public List<LineConnect> lineConnects = new();

		/// <summary>Ô pokemon đang được rê chuột.</summary>
		public PokemonCell? cellFocus;

		/// <summary>Ô pokemon đã được lựa chọn 1.</summary>
		public PokemonCell? cellSelected1;

		/// <summary>Ô pokemon đã được lựa chọn 2.</summary>
		public PokemonCell? cellSelected2;

		/// <summary>Khởi tạo GamePlay theo toạ độ.</summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		public GamePlay(int x, int y)
		{
			width = GameControlManagement.TOTAL_COLUMNS * PokemonCell.width;
			height = GameControlManagement.TOTAL_ROWS * PokemonCell.height;

			int xBase = this.x = x;
			int yBase = this.y = y;

			pokemonCells = new PokemonCell[
				GameControlManagement.TOTAL_ROWS, 
				GameControlManagement.TOTAL_COLUMNS];

			for (int i = 0; i < GameControlManagement.TOTAL_ROWS; i++)
				for (int j = 0; j < GameControlManagement.TOTAL_COLUMNS; j++)
				{
					pokemonCells[i, j] = new PokemonCell
					{
						x = xBase + j * PokemonCell.width,
						y = yBase + i * PokemonCell.height,
						row = i,
						col = j,
					};
				}
		}

		public override void Draw(Graphics g)
		{
			DrawPokemonCells(g);
			DrawBorder(g);
			DrawLineConnects(g);
		}

		public void OnClick(object? sender, EventArgs e)
		{
			SelectCell(cellFocus);
		}

		public bool Contains(int x, int y)
		{
			cellFocus = GetPokemonCell(x, y);
			return cellFocus != null;
		}

		public bool Contains(Point point)
		{
			return Contains(point.X, point.Y);
		}

		public void Update()
		{
			UpdateCell();
			UpdateFocusCell();
			UpdateLines();
		}

		public void UpdateDataLevel()
		{
			UnselectAll();
		}

		/// <summary>Hiển thị các ô pokemon</summary>
		/// <param name="g">The g.</param>
		private void DrawPokemonCells(Graphics g)
		{
			foreach (var cell in pokemonCells)
				cell.Draw(g);
		}

		/// <summary>Hiển thị border của đối tượng.</summary>
		/// <param name="g">The g.</param>
		private void DrawBorder(Graphics g)
		{
			g.DrawRectangle(pen, x, y, width, height);
		}

		/// <summary>Vẽ các đường thẳng kết nối cặp pokemon.</summary>
		/// <param name="g">The g.</param>
		private void DrawLineConnects(Graphics g)
		{
			foreach (var line in lineConnects)
				line.Draw(g);
		}

		/// <summary>Lựa chọn một ô pokemon.</summary>
		/// <param name="pokemonCell">The pokemon cell.</param>
		public void SelectCell(PokemonCell? pokemonCell)
		{
			if (pokemonCell == null)
				return;

			if (cellSelected1 == null)
			{
				cellSelected1 = pokemonCell;
				cellSelected1.isSelected = true;
				return;
			}

			if (cellSelected1 == cellFocus)
			{
				cellSelected1.isSelected = false;
				return;
			}

			cellSelected2 = pokemonCell;
			cellSelected2.isSelected = true;

			lineConnects = GameControlManagement.Instance.SelectPair(
							cellSelected1.row, cellSelected1.col,
							cellSelected2.row, cellSelected2.col);

			UnselectAll();
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

		/// <summary>Lấy ô pokemon theo toạ độ.</summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		private PokemonCell? GetPokemonCell(int x, int y)
		{
			int row = (y - this.y) / PokemonCell.height;
			int col = (x - this.x) / PokemonCell.width;

			if (x >= this.x && y >= this.y &&
				row >= 0 && row < GameControlManagement.TOTAL_ROWS &&
				col >= 0 && col < GameControlManagement.TOTAL_COLUMNS &&
				pokemonCells[row, col].image != null)
				return pokemonCells[row, col];

			return null;
		}

		/// <summary>Cập nhập dữ liệu các ô pokemon.</summary>
		private void UpdateCell()
		{
			foreach (var cell in pokemonCells)
				cell.Update();
		}

		/// <summary>Cập nhập dữ liệu focus cho các ô pokemon.</summary>
		private void UpdateFocusCell()
		{
			foreach (var cell in pokemonCells)
				cell.isFocus = false;

			if (cellFocus != null)
				cellFocus.isFocus = true;
		}

		/// <summary>Cập nhập dữ liệu các đường thẳng kết nối cặp ô pokemon.</summary>
		private void UpdateLines()
		{
			foreach (var line in lineConnects)
				line.Update();
		}
	}
}
