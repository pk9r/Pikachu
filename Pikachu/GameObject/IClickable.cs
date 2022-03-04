using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal interface IClickable
	{
		/// <summary>Kiểm tra một toạ độ nằm trong đối tượng.</summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns>
		///   <c>true</c> if [contains] [the specified x]; otherwise, <c>false</c>.</returns>
		public bool Contains(int x, int y);
		/// <summary>Kiểm tra một toạ độ nằm trong đối tượng.</summary>
		/// <param name="point">The point.</param>
		/// <returns>
		///   <c>true</c> if [contains] [the specified point]; otherwise, <c>false</c>.</returns>
		public bool Contains(Point point);
		/// <summary>Được gọi khi [click] vào đối tượng.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		public void OnClick(object? sender, EventArgs e);
	}
}
