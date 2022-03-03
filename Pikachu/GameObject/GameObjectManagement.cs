using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	internal class GameObjectManagement
	{
		#region Singleton
		private static readonly GameObjectManagement instance = new();

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static GameObjectManagement()
		{
		}

		private GameObjectManagement()
		{
			Sens.Add(exitButton);
			Sens.Add(timeBar);
			Sens.Add(timeLabel);
			Sens.Add(newGameButton);

			Clickables.Add(exitButton);
			Clickables.Add(newGameButton);

			timeBar.Timeout += TimeBar_Timeout;
		}

		private void TimeBar_Timeout(object? sender, EventArgs e)
		{
			GameControlManagement.Instance.GameOver();
		}

		public static GameObjectManagement Instance => instance;
		#endregion

		public ExitButton exitButton = new()
		{
			x = 700,
			y = 0,
			height = 75,
			width = 75,
		};

		public TimeBar timeBar = new()
		{
			x = 150,
			y = 40,
			height = 30,
			width = 500,
		};

		public TimeLabel timeLabel = new()
		{
			height = 30,
			width = 100,
			x = 50,
			y = 40,
		};

		public NewGameButton newGameButton = new()
		{
			height = 40,
			width = 100,
			x = 20,
			y = 100,
		};

		public List<IScreenObject> Sens = new();
		public List<IClickable> Clickables = new();
	}
}
