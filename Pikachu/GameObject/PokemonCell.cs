using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class PokemonCell : ScreenObject
	{
		public static List<Bitmap?> images = LoadImages();

		private static List<Bitmap?> LoadImages()
		{
			List<Bitmap?> images = new();
			int length = 36;
			for (int i = 1; i <= length; i++)
			{
				images.Add(Properties.Resources.ResourceManager.GetObject($"pieces{i}") as Bitmap);
			}
			return images;
		}

		/* Đây là kích thước ảnh không nên thay đổi để tránh vỡ ảnh */
		public static readonly int width = 40;
		public static readonly int height = 50;

		public static Bitmap? GetImage(int index)
		{
			return images[index];
		}

		readonly Pen penWithoutFocus = new(Color.Green);
		readonly Pen penWithFocus = new(Color.Red);

		public Image? image;
		public bool isFocus;

		public override void Draw(Graphics g)
		{
			if (image != null)
			{
				g.DrawImage(image, x, y, width, height);
				if (isFocus)
					g.DrawRectangle(penWithFocus, x, y, width, height);
				else
					g.DrawRectangle(penWithoutFocus, x, y, width, height);
			}
		}
	}
}
