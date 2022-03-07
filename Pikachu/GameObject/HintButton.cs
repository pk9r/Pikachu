using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Nút gợi ý.</summary>
	internal class HintButton : ImageButton
	{
		bool isShowHint = false;

		public HintButton()
		{
			// TODO: Thay cái hình xoá nền nhé, hình kia để hơi xấu
			image = Properties.Resources.hintchecker;
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			if (isShowHint = !isShowHint)
				GameObjectManagement.Instance.gamePlay.penHint = new(Color.Red, 3);
			else
				GameObjectManagement.Instance.gamePlay.penHint = new(Color.Black); // Ý tưởng thú vị đó :v
		}
	}
}
