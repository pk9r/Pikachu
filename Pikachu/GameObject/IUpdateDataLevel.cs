using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng cần cập nhập dữ liệu khi thay đổi level.</summary>
	internal interface IUpdateDataLevel
	{
		/// <summary>Cập nhập dữ liệu khi chuyển level.</summary>
		public void UpdateDataLevel();
	}
}
