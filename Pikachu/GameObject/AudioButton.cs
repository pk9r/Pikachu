using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Nút Bật/Tắt nhạc nền.</summary>
	internal class AudioButton : ImageButton
	{
		readonly SoundPlayer soundPlayer = new(Properties.Resources.sunset);
		
		/// <summary>Trạng thái phát audio.</summary>
		bool isPlaying = true;

		public AudioButton()
		{
			TogglePlay();
		}

		public override void OnClick(object? sender, EventArgs e)
		{
			TogglePlay();
		}

		/// <summary>Bật/Tắt nhạc nền.</summary>
		public void TogglePlay()
		{
			if (isPlaying = !isPlaying)
				soundPlayer.Stop();
			else
				soundPlayer.PlayLooping();

			if (isPlaying)
				image = Properties.Resources.mute;
			else
				image = Properties.Resources.unmute;
		}
	}
}
