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
			size = new(850, 600),
			location = new(0, 0),
		};

		public ExitButton exitButton = new()
		{
			size = new(75, 75),
			location = new(750, 0),
		};

		public TimeBar timeBar = new()
		{
			size = new(500, 30),
			location = new(150, 40),
		};

		public NewGameButton newGameButton = new()
		{
			size = new(100, 40),
			location = new(20, 100),
		};

		public ShuffleButton shuffleButton = new()
		{
			size = new(75, 75),
			location = new(20, 200),
		};

		public LabelShuffle labelShuffle = new()
		{
			location = new(100, 215),
		};

		public CustomButton customButton = new()
		{
			size = new(100, 40),
			location = new(20, 300),
		};

		public AudioButton audioButton = new()
		{
			size = new(48, 48),
			location = new(20, 20),
		};

		public HintButton hintButton = new()
		{
			size = new(48, 48),
			location = new(20, 350),
		};

		public GamePlay gamePlay = new(new(150, 100));
		#endregion

		#region List Objects
		public List<IScreenObject> Sens = new();
		public List<IClickable> Clickables = new();
		#endregion

		private void Init()
		{
			Clickables.Add(exitButton);
			Clickables.Add(newGameButton);
			Clickables.Add(shuffleButton);
			Clickables.Add(gamePlay);
			Clickables.Add(customButton);
			Clickables.Add(audioButton);
			Clickables.Add(hintButton);

			Sens.Add(background);
			Sens.Add(timeBar);
			Sens.Add(labelShuffle);
			Sens.Add(hintButton);

			Sens.AddRange(Clickables);
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
