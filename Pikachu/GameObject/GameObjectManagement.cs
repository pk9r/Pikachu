using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng quản lý và cài đặt các đối tượng.</summary>
	internal class GameObjectManagement : IUpdatable
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
			Init();
		}

		public static GameObjectManagement Instance => instance;
		#endregion

		#region View Objects
		public Background background = new()
		{
			width = 850,
			height = 600,
			x = 0,
			y = 0,
		};

		public ExitButton exitButton = new()
		{
			x = 750,
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

		public NewGameButton newGameButton = new()
		{
			height = 40,
			width = 100,
			x = 20,
			y = 100,
		};

		public GamePlay gamePlay = new(150, 100);
		#endregion

		#region List Objects
		public List<IScreenObject> Sens = new();
		public List<IClickable> Clickables = new();
		#endregion

		private void Init()
		{
			Sens.Add(background);
			Sens.Add(exitButton);
			Sens.Add(timeBar);
			Sens.Add(newGameButton);
			Sens.Add(gamePlay);

			Clickables.Add(exitButton);
			Clickables.Add(newGameButton);
			Clickables.Add(gamePlay);
		}

		public void Update()
		{
			timeBar.Update();
			gamePlay.Update();
		}
	}
}
