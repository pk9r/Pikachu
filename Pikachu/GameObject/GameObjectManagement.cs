using Pikachu.GameControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikachu.GameObject
{
	/// <summary>Đối tượng quản lý và cài đặt các đối tượng.</summary>
	internal class GameObjectManagement : IUpdatable, IUpdateDataLevel
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

		public ShuffleButton shuffleButton = new()
		{
			height = 75,
			width = 75,
			x = 20,
			y = 200,
		};

		public LabelShuffle labelShuffle = new()
		{
			x = 100,
			y = 215,
		};

		public CustomButton customButton = new()
		{
			height = 40,
			width = 100,
			x = 20,
			y = 300,
		};

		public AudioButton audioButton = new()
		{
			width = 48,
			height = 48,
			x = 20,
			y = 20,
		};

		public HintCheckerButton hintCheckerButton = new()
		{
			width = 48,
			height = 48,
			x = 20,
			y = 350,
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
			Sens.Add(shuffleButton);
			Sens.Add(labelShuffle);
			Sens.Add(gamePlay);
			Sens.Add(customButton);
			Sens.Add(audioButton);
			Sens.Add(hintCheckerButton);

			Clickables.Add(exitButton);
			Clickables.Add(newGameButton);
			Clickables.Add(shuffleButton);
			Clickables.Add(gamePlay);
			Clickables.Add(customButton);
			Clickables.Add(audioButton);
			Clickables.Add(hintCheckerButton);
		}

		public void Update()
		{
			timeBar.Update();
			gamePlay.Update();
		}

		public void UpdateDataLevel()
		{
			timeBar.UpdateDataLevel();
			gamePlay.UpdateDataLevel();
		}
	}
}
