using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng hiển thị trên màn hình với toạ độ.</summary>
	internal abstract class ScreenObject : IScreenObject
	{
		/// <summary>The x</summary>
		public int x;
		/// <summary>The y</summary>
		public int y;

		public abstract void Draw(Graphics g);
	}
}
