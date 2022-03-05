using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class LabelShuffle : ScreenObject
	{
		string Text => GameControl.GameControlManagement.Instance.dataGamePlay.countShuffle.ToString();

		readonly Font font = new("Tahoma", 24, FontStyle.Regular);

		readonly Brush brush = new SolidBrush(Color.Black);

		public override void Draw(Graphics g)
		{
			g.DrawString(Text, font, brush, x, y);
		}
	}
}
