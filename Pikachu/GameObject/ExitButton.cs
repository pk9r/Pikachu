using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Nút thoát trò chơi.</summary>
	internal class ExitButton : ImageButton
	{
		public ExitButton()
		{
			image = Properties.Resources.exit;
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			(sender as Form)?.Close();
		}
	}
}
