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
	/// <summary>Ô pokemon.</summary>
	internal class PokemonCell : ScreenObject
	{
		public const int MAX_NUM_OF_TYPE = 36;

		public static List<Bitmap?> images = LoadImages();

		private static List<Bitmap?> LoadImages()
		{
			List<Bitmap?> images = new();
			int length = MAX_NUM_OF_TYPE;
			for (int i = 1; i <= length; i++)
			{
				images.Add(Properties.Resources.ResourceManager.GetObject($"pieces{i}") as Bitmap);
			}
			return images;
		}

		/* Đây là kích thước ảnh không nên thay đổi để tránh vỡ ảnh */
		/// <summary>Kích thước ô pokemon.</summary>
		public static readonly Size size = new(40, 50);

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
			Rectangle rectangle = new(location, size);

			if (image != null)
			{
				g.DrawImage(image, rectangle);

				if (isFocus)
					g.DrawRectangle(penWithFocus, rectangle);
				else
					g.DrawRectangle(penWithoutFocus, rectangle);
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
