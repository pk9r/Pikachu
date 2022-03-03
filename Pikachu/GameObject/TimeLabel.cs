using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class TimeLabel : ScreenObject
	{
		readonly string text = "TIME: ";
		readonly Font font = new("tahoma", 12, FontStyle.Bold);
		readonly Brush brush = new SolidBrush(Color.Red);
		readonly StringFormat stringFormat = new()
		{
			Alignment = StringAlignment.Far,
			LineAlignment = StringAlignment.Center,
		};

		public override void Draw(Graphics g)
		{
			Rectangle rectangle = new(x, y, width, height);
			g.DrawString(text, font, brush, rectangle, stringFormat);
		}
	}
}
