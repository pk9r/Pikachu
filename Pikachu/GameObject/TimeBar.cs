using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class TimeBar : ScreenObjectWithSize, IUpdatable
	{
		readonly Pen pen = new(Color.Black);
		readonly Brush brushFill = new SolidBrush(Color.Green);
		readonly Brush brushText = new SolidBrush(Color.Black);
		readonly Font font = new("tahoma", 12, FontStyle.Italic | FontStyle.Bold);
		readonly StringFormat stringFormat = new()
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center,
		};
		readonly string text = "TIME: ";
		readonly StringFormat stringFormatLabel = new()
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Center,
		};

		public int totalTime;
		public int remaining;

		public override void Draw(Graphics g)
		{
			Rectangle rectangleLabel = new(x, y, 60, height);
			g.DrawString(text, font, brushText, rectangleLabel, stringFormatLabel);

			Rectangle rectangle = new(x + 60, y, width, height);
			g.DrawRectangle(pen, rectangle);

			int widthFill = width - 1;
			if (totalTime > 0)
				widthFill = remaining * widthFill / totalTime;

			g.FillRectangle(brushFill, x + 61, y + 1, widthFill, height - 1);
			g.DrawString($"{remaining}/{totalTime}", font, brushText, rectangle, stringFormat);
		}

		public void Update()
		{
			remaining = GameControlManagement.Instance.dataGamePlay.timeRemaining;
		}

		public void UpdateData()
		{
			totalTime = GameControlManagement.Instance.dataGamePlay.totalTime;
			remaining = GameControlManagement.Instance.dataGamePlay.timeRemaining;
		}
	}
}
