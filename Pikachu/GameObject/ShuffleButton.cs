using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class ShuffleButton : ImageButton
	{
		public ShuffleButton()
		{
			image = Properties.Resources.shuffle;
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			GameControlManagement.Instance.Shuffle();
		}
	}
}
