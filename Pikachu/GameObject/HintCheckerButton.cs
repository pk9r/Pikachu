using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class HintCheckerButton : ImageButton
	{
		bool isClick = false;
		public HintCheckerButton()
		{
			image = Properties.Resources.hintchecker;
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			if (isClick = !isClick)
			{
				GameObjectManagement.Instance.gamePlay.penHint = new(Color.Red, 3);
			}
			else
				GameObjectManagement.Instance.gamePlay.penHint = new(Color.Black);
		}
	}
}
