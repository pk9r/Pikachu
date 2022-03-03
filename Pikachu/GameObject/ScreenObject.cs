using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal abstract class ScreenObject : IScreenObject
	{
		public int x;
		public int y;

		public abstract void Draw(Graphics g);
	}
}
