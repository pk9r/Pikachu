using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class ExitButton : ButtonObject
	{
		public Image image = Properties.Resources.exit;

		public override void Draw(Graphics g)
		{
			g.DrawImage(image, x, y, width, height);
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			(sender as Form)?.Close();
		}
	}
}
