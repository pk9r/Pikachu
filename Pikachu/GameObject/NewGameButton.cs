using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class NewGameButton : TextButton
	{
		public NewGameButton()
		{
			text = "Chơi mới";
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			GameControlManagement.Instance.NewGame();
		}
	}
}
