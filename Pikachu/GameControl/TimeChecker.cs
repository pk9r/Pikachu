using Pikachu.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameControl
{
	internal class TimeChecker
	{
		readonly DataGamePlay dataGamePlay;

		public event EventHandler? Timeout;

		public TimeChecker(DataGamePlay dataGamePlay)
		{
			this.dataGamePlay = dataGamePlay;
		}

		public void Update()
		{
			dataGamePlay.timeRemaining = 
				(int)(dataGamePlay.totalTime - 
				((DateTime.Now.Ticks - dataGamePlay.timeLastStarted) / 10000000));

			if (dataGamePlay.timeRemaining < 0)
			{
				dataGamePlay.timeRemaining = 0;
				OnTimeout();
			}
		}

		private void OnTimeout()
		{
			Timeout?.Invoke(this, new EventArgs());
		}
	}
}
