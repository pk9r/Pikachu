using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Nút tuỳ chỉnh màn chơi.</summary>
	internal class CustomButton : TextButton
	{
		public CustomButton()
		{
			text = "Tuỳ chỉnh";
		}
	
		public override void OnClick(object? sender, EventArgs e)
		{
			CustomForm customForm = new();
			var r = customForm.ShowDialog();
			if (r == DialogResult.OK)
			{
				GameControlManagement.Instance.NewGame(isLevelCustom: true);
			}
		}
	}
}
