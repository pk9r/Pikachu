using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng button sử dụng image.</summary>
	internal abstract class ImageButton : ButtonObject
	{
		public Image? image;

		public override void Draw(Graphics g)
		{
			if (image != null)
				g.DrawImage(image, x, y, width, height);
		}
	}
}
