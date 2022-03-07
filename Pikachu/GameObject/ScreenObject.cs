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
		/// <summary>Vị trí đối tượng.</summary>
		public Point location;

		public abstract void Draw(Graphics g);
	}
}
