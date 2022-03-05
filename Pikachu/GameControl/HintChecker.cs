using Pikachu.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameControl
{
	internal class HintChecker
	{
		DataGamePlay dataGamePlay;

		SelectChecker selectChecker;

		public int indexHint1, indexHint2;

		public HintChecker(DataGamePlay dataGamePlay, SelectChecker selectChecker)
		{
			this.dataGamePlay = dataGamePlay;
			this.selectChecker = selectChecker;
		}

		public void LoadHint()
		{
			for (int i = 0; i < dataGamePlay.setCells.Count; i++)
			{
				int index1 = dataGamePlay.setCells.ElementAt(i);
				int value1 = dataGamePlay.GetValue(index1);
				for (int j = i + 1; j < dataGamePlay.setCells.Count; j++)
				{
					int index2 = dataGamePlay.setCells.ElementAt(j);
					int value2 = dataGamePlay.GetValue(index2);
					if (value1 == value2)
					{
						var lines = selectChecker.GetLines(index1, index2);
						if (lines.Count > 0)
						{
							indexHint1 = index1;
							indexHint2 = index2;
							return;
						}
					}
				}
			}

			indexHint1 = int.MaxValue;
			indexHint2 = int.MaxValue;
		}
	}
}
