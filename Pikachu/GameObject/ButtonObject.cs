using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal abstract class ButtonObject : ScreenObject, IClickable
	{
		public bool Contains(int x, int y)
		{
			Rectangle rect = new(this.x, this.y, width, height);
			return rect.Contains(x, y);
		}

		public bool Contains(Point point)
		{
			return Contains(point.X, point.Y);
		}

		public abstract void OnClick(object? sender, EventArgs e);
	}
}
