using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pikachu
{
	public partial class CustomForm : Form
	{
		public CustomForm()
		{
			InitializeComponent();

			numOfType.Value = DataLevel.customLevel.numOfType;
			numOfRows.Value = DataLevel.customLevel.numOfRows;
			numOfCols.Value = DataLevel.customLevel.numOfCols;
			totalTime.Value = DataLevel.customLevel.totalTime;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DataLevel.customLevel.numOfType = (int)numOfType.Value;
			DataLevel.customLevel.numOfRows = (int)numOfRows.Value;
			DataLevel.customLevel.numOfCols = (int)numOfCols.Value;
			DataLevel.customLevel.totalTime = (int)totalTime.Value;

			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
