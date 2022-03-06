namespace Pikachu
{
	partial class CustomForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.numOfRows = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numOfType = new System.Windows.Forms.NumericUpDown();
			this.numOfCols = new System.Windows.Forms.NumericUpDown();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.totalTime = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numOfRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numOfType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numOfCols)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.totalTime)).BeginInit();
			this.SuspendLayout();
			// 
			// numOfRows
			// 
			this.numOfRows.Location = new System.Drawing.Point(128, 98);
			this.numOfRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.numOfRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numOfRows.Name = "numOfRows";
			this.numOfRows.Size = new System.Drawing.Size(164, 23);
			this.numOfRows.TabIndex = 0;
			this.numOfRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numOfRows.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tuỳ chỉnh cấp độ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Số cột: ";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Số loại pokemon: ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "Số hàng: ";
			// 
			// numOfType
			// 
			this.numOfType.Location = new System.Drawing.Point(128, 58);
			this.numOfType.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
			this.numOfType.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numOfType.Name = "numOfType";
			this.numOfType.Size = new System.Drawing.Size(164, 23);
			this.numOfType.TabIndex = 5;
			this.numOfType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numOfType.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// numOfCols
			// 
			this.numOfCols.Location = new System.Drawing.Point(128, 138);
			this.numOfCols.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numOfCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numOfCols.Name = "numOfCols";
			this.numOfCols.Size = new System.Drawing.Size(164, 23);
			this.numOfCols.TabIndex = 6;
			this.numOfCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numOfCols.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(12, 220);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(125, 23);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(167, 220);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(125, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Huỷ";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 180);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 15);
			this.label5.TabIndex = 9;
			this.label5.Text = "Thời gian: ";
			// 
			// totalTime
			// 
			this.totalTime.Location = new System.Drawing.Point(128, 178);
			this.totalTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.totalTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.totalTime.Name = "totalTime";
			this.totalTime.Size = new System.Drawing.Size(164, 23);
			this.totalTime.TabIndex = 10;
			this.totalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.totalTime.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
			// 
			// CustomForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 271);
			this.Controls.Add(this.totalTime);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.numOfCols);
			this.Controls.Add(this.numOfType);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numOfRows);
			this.Name = "CustomForm";
			this.Text = "CustomForm";
			((System.ComponentModel.ISupportInitialize)(this.numOfRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numOfType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numOfCols)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.totalTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private NumericUpDown numOfRows;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private NumericUpDown numOfType;
		private NumericUpDown numOfCols;
		private Button btnOK;
		private Button btnCancel;
		private Label label5;
		private NumericUpDown totalTime;
	}
}