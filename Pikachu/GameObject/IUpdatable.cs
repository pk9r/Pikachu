using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng có thể cập nhập dữ liệu.</summary>
	internal interface IUpdatable
	{
		/// <summary>Cập nhập dữ liệu cho đối tượng.</summary>
		public void Update();
	}
}
