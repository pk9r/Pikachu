using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal abstract class TextButton : ButtonObject
	{
		protected string text = "";

		#region Object Draw
		protected Font font = new("tahoma", 12, FontStyle.Bold);
		protected Brush brushText = new SolidBrush(Color.Black);
		protected Brush brushRect = new SolidBrush(Color.Yellow);
		protected StringFormat stringFormat = new() 
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center,
		};
		#endregion

		public override void Draw(Graphics g)
		{
			Rectangle rectangle = new(location, size);
			g.FillRectangle(brushRect, rectangle);
			g.DrawString(text, font, brushText, rectangle, stringFormat);
		}
	}
}
