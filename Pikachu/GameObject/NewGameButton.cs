using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class NewGameButton : ButtonObject
	{
		readonly string text = "New Game";

		readonly Font font = new("tahoma", 12, FontStyle.Bold);
		readonly Brush brushText = new SolidBrush(Color.Black);
		readonly Brush brushRect = new SolidBrush(Color.Yellow);
		readonly StringFormat stringFormat = new()
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center,
		};

		public override void Draw(Graphics g)
		{
			Rectangle rectangle = new(x, y, width, height);
			g.FillRectangle(brushRect, rectangle);
			g.DrawString(text, font, brushText, rectangle, stringFormat);
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			GameControlManagement.Instance.NewGame();
		}
	}
}
