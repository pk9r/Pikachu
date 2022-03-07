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
		public readonly Size size;

		#region Object Draw
		readonly Pen penBorder = new(Color.Brown);
		public Pen penHint = new(Color.Black);
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

		///// <summary>Ô pokemon đã được lựa chọn 1.</summary>
		public PokemonCell? cellHint1;

		///// <summary>Ô pokemon đã được lựa chọn 2.</summary>
		public PokemonCell? cellHint2;

		/// <summary>Khởi tạo GamePlay theo toạ độ.</summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		public GamePlay(Point location)
		{
			size = new(PokemonCell.size.Width * GameControlManagement.TOTAL_COLUMNS,
				PokemonCell.size.Height * GameControlManagement.TOTAL_ROWS);

			this.location = location;

			int xBase = location.X;
			int yBase = location.Y;

			pokemonCells = new PokemonCell[
				GameControlManagement.TOTAL_ROWS,
				GameControlManagement.TOTAL_COLUMNS];

			int x, y;
			for (int i = 0; i < GameControlManagement.TOTAL_ROWS; i++)
				for (int j = 0; j < GameControlManagement.TOTAL_COLUMNS; j++)
				{
					x = xBase + j * PokemonCell.size.Width;
					y = yBase + i * PokemonCell.size.Height;

					pokemonCells[i, j] = new PokemonCell
					{
						location = new(x, y),
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
			DrawHint(g);
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
			UpdateHint();
		}

		public void UpdateDataLevel()
		{
			UnselectAll();
		}

		/// <summary>Lựa chọn ô pokemon.</summary>
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
				cellSelected1 = null;
				return;
			}

			cellSelected2 = pokemonCell;
			cellSelected2.isSelected = true;

			lineConnects = GameControlManagement.Instance.SelectPair(
							cellSelected1.row, cellSelected1.col,
							cellSelected2.row, cellSelected2.col);

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
			g.DrawRectangle(penBorder, new(location, size));
		}

		/// <summary>Vẽ các đường thẳng kết nối cặp pokemon.</summary>
		/// <param name="g">The g.</param>
		private void DrawLineConnects(Graphics g)
		{
			foreach (var line in lineConnects)
				line.Draw(g);
		}

		/// <summary>Vẽ gợi ý.</summary>
		/// <param name="g">The g.</param>
		private void DrawHint(Graphics g)
		{
			if (cellHint1 != null && cellHint2 != null)
			{
				g.DrawRectangle(penHint, new(cellHint1.location, PokemonCell.size));
				g.DrawRectangle(penHint, new(cellHint2.location, PokemonCell.size));
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

		/// <summary>Lấy ô pokemon theo toạ độ.</summary>
		private PokemonCell? GetPokemonCell(int x, int y)
		{
			int row = (y - location.Y) / PokemonCell.size.Height;
			int col = (x - location.X) / PokemonCell.size.Width;

			if (x >= location.X && y >= location.Y &&
				row >= 0 && row < GameControlManagement.Instance.dataGamePlay.numOfRows &&
				col >= 0 && col < GameControlManagement.Instance.dataGamePlay.numOfCols &&
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

		private void UpdateHint()
		{
			if (GameControlManagement.Instance.hintChecker.indexHint1 == int.MaxValue ||
				GameControlManagement.Instance.hintChecker.indexHint2 == int.MaxValue)
			{
				cellHint1 = cellHint2 = null;
				return;
			}

			int row1 = GameControlManagement.Instance.hintChecker.indexHint1 /
				GameControlManagement.Instance.dataGamePlay.numOfCols;
			int col1 = GameControlManagement.Instance.hintChecker.indexHint1 %
				GameControlManagement.Instance.dataGamePlay.numOfCols;
			int row2 = GameControlManagement.Instance.hintChecker.indexHint2 /
				GameControlManagement.Instance.dataGamePlay.numOfCols;
			int col2 = GameControlManagement.Instance.hintChecker.indexHint2 %
				GameControlManagement.Instance.dataGamePlay.numOfCols;

			cellHint1 = pokemonCells[row1, col1];
			cellHint2 = pokemonCells[row2, col2];
		}
	}
}
