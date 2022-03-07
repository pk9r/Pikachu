using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng có thể xử lý sự kiện click.</summary>
	internal abstract class ButtonObject : ScreenObjectWithSize, IClickable
	{
		public bool Contains(int x, int y)
		{
			Rectangle rect = new(location, size);
			return rect.Contains(x, y);
		}

		public bool Contains(Point point)
		{
			return Contains(point.X, point.Y);
		}

		public abstract void OnClick(object? sender, EventArgs e);
	}
}
