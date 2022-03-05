using Pikachu.GameControl;
using Pikachu.GameObject;

namespace Pikachu
{
	/// <summary>
	/// Refer: <a href="https://stackoverflow.com/questions/7834775/simple-game-in-c-sharp-with-only-native-libraries">https://stackoverflow.com/questions/7834775/simple-game-in-c-sharp-with-only-native-libraries</a></summary>
	public partial class MainForm : Form
	{
		Bitmap? Backbuffer = null;

		public MainForm()
		{
			InitializeComponent();

			SetStyle(
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.DoubleBuffer, true);

			System.Windows.Forms.Timer GameTimer = new();
			GameTimer.Interval = 60;
			GameTimer.Tick += GameTimer_Tick;
			GameTimer.Start();

			Load += MainForm_Load;
			Paint += MainForm_Paint;
			MouseMove += MainForm_MouseMove;
			Click += MainForm_Click;
		}

		private void MainForm_Load(object? sender, EventArgs e)
		{
			if (Backbuffer != null)
				Backbuffer.Dispose();

			Backbuffer = new Bitmap(ClientSize.Width, ClientSize.Height);
			GameControlManagement.Instance.NewGame();
		}

		private void MainForm_MouseMove(object? sender, MouseEventArgs e)
		{
			foreach (var obj in GameObjectManagement.Instance.Clickables)
			{
				if (obj.Contains(e.Location))
				{
					Cursor.Current = Cursors.Hand;
				}
			}
		}

		private void MainForm_Click(object? sender, EventArgs e)
		{
			MouseEventArgs? mouseEvent = e as MouseEventArgs;
			if (mouseEvent?.Button == MouseButtons.Left)
			{
				foreach (var obj in GameObjectManagement.Instance.Clickables)
				{
					if (obj.Contains(mouseEvent.Location))
						obj.OnClick(sender, e);
				}
			}
		}

		void MainForm_Paint(object? sender, PaintEventArgs e)
		{
			if (Backbuffer != null)
			{
				e.Graphics.DrawImageUnscaled(Backbuffer, Point.Empty);
			}
		}

		void GameTimer_Tick(object? sender, EventArgs e)
		{
			GameControlManagement.Instance.Update();

			if (Backbuffer != null)
			{
				using (var g = Graphics.FromImage(Backbuffer))
				{
					Draw(g);
				}
				Invalidate();
			}
		}

		private static void Draw(Graphics g)
		{
			g.Clear(Color.White);

			foreach (var obj in GameObjectManagement.Instance.Sens)
			{
				obj.Draw(g);
			}
		}
	}
}