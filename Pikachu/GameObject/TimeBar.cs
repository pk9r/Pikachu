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
		readonly int offsetLabel = 60;

		public int totalTime;
		public int remaining;

		public override void Draw(Graphics g)
		{
			Rectangle rectangleLabel = new(location, new(offsetLabel, size.Height));
			g.DrawString(text, font, brushText, rectangleLabel, stringFormatLabel);

			Rectangle rectangle = new(location.X + offsetLabel, location.Y, size.Width - offsetLabel, size.Height);
			g.DrawRectangle(pen, rectangle);

			int widthFill = size.Width - offsetLabel - 1;
			if (totalTime > 0)
				widthFill = remaining * widthFill / totalTime;

			g.FillRectangle(brushFill, location.X + 61, location.Y + 1, widthFill, size.Height - 1);
			g.DrawString($"{remaining}/{totalTime}", font, brushText, rectangle, stringFormat);
		}

		public void Update()
		{
			remaining = GameControlManagement.Instance.dataGamePlay.timeRemaining;
		}

		public void UpdateDataLevel()
		{
			totalTime = GameControlManagement.Instance.dataGamePlay.totalTime;
			remaining = GameControlManagement.Instance.dataGamePlay.timeRemaining;
		}
	}
}
