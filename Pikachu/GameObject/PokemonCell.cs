using Pikachu.DataObject;
using Pikachu.Extensions;
using Pikachu.GameControl;
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
			int length = DataGamePlay.numOfType;
			for (int i = 1; i <= length; i++)
			{
				images.Add(Properties.Resources.ResourceManager.GetObject($"pieces{i}") as Bitmap);
			}
			return images;
		}

		/* Đây là kích thước ảnh không nên thay đổi để tránh vỡ ảnh */
		public static readonly int width = 40;
		public static readonly int height = 50;

		/// <summary>Lấy ảnh đối tượng từ value.</summary>
		/// <param name="value">The value.</param>
		/// <returns>Hình ảnh tương ứng với value.<br /></returns>
		public static Bitmap? GetImage(int value)
		{
			if (value <= 0 || value > images.Count)
				return null;

			return images[value - 1];
		}

		#region Object Draw
		readonly Pen penWithoutFocus = new(Color.Green);
		readonly Pen penWithFocus = new(Color.Red, 2);
		#endregion

		public Image? image;
		public bool isFocus;
		public bool isSelected;
		public int row;
		public int col;

		public int Value => GameControlManagement.Instance.dataGamePlay.data[row, col];

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

		public void Update()
		{
			image = GetImage(Value);
			if (isSelected)
			{
				image = image?.Opacity(0.5f);
			}
		}
	}
}
