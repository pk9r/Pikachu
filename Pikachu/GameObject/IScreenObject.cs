﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng có thể hiển thị trên màn hình.</summary>
	internal interface IScreenObject
	{
		/// <summary>Hiển thị đối tượng trên màn hình.</summary>
		/// <param name="g">The g.</param>
		public void Draw(Graphics g);
	}
}
