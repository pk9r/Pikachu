using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.Extensions
{
	internal static class ImageExtensions
	{
		public static Image Opacity(this Image image, float opacityvalue)
		{
			Bitmap bmp = new(image.Width, image.Height);
			Graphics graphics = Graphics.FromImage(bmp);
			ColorMatrix colormatrix = new();
			colormatrix.Matrix33 = opacityvalue;
			ImageAttributes imgAttribute = new();
			imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			graphics.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttribute);
			graphics.Dispose();
			return bmp;
		}
	}
}
