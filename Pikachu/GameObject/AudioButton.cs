using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class AudioButton : ImageButton
	{
		bool isSoundOn = true;
		readonly SoundPlayer soundPlayer = new(Properties.Resources.sunset);

		public AudioButton()
		{
			TogglePlay();
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			TogglePlay();
		}

		public void TogglePlay()
		{
			if (isSoundOn = !isSoundOn)
				soundPlayer.Stop();
			else
				soundPlayer.PlayLooping();

			if (isSoundOn)
				image = Properties.Resources.mute;
			else
				image = Properties.Resources.unmute;
		}
	}
}
