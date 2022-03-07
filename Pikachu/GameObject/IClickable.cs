using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng có thể click.</summary>
	internal interface IClickable : IScreenObject
	{
		/// <summary>Kiểm tra một toạ độ nằm trong đối tượng.</summary>
		public bool Contains(int x, int y);

		/// <summary>Kiểm tra một toạ độ nằm trong đối tượng.</summary>
		public bool Contains(Point point);

		/// <summary>Hành động thực hiện khi click đối tượng.</summary>
		public void OnClick(object? sender, EventArgs e);
	}
}
