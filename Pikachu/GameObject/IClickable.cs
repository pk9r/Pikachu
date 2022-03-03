using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal interface IClickable
	{
		public bool Contains(int x, int y);
		public bool Contains(Point point);
		public void OnClick(object? sender, EventArgs e);
	}
}
