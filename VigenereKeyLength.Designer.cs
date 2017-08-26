namespace EncryptionToolsGUI
{
    partial class VigenereKeyLength
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.findScoresButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.keyLengthScoresLabel = new System.Windows.Forms.Label();
            this.keyLengthScoresDGV = new System.Windows.Forms.DataGridView();
            this.enterTextButton = new System.Windows.Forms.Button();
            this.numOfLengthsLabel = new System.Windows.Forms.Label();
            this.numberOfLengthsTextBox = new System.Windows.Forms.TextBox();
            this.invalidNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyLengthScoresDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // findScoresButton
            // 
            this.findScoresButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findScoresButton.Location = new System.Drawing.Point(605, 13);
            this.findScoresButton.Name = "findScoresButton";
            this.findScoresButton.Size = new System.Drawing.Size(75, 23);
            this.findScoresButton.TabIndex = 4;
            this.findScoresButton.Text = "Find scores";
            this.findScoresButton.UseVisualStyleBackColor = true;
            this.findScoresButton.Click += new System.EventHandler(this.findScoresButton_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Title = "Key Length";
            chartArea1.AxisY.Title = "Score";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(224, 59);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Letter Scores";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(457, 325);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            this.chart1.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // keyLengthScoresLabel
            // 
            this.keyLengthScoresLabel.AutoSize = true;
            this.keyLengthScoresLabel.Location = new System.Drawing.Point(13, 43);
            this.keyLengthScoresLabel.Name = "keyLengthScoresLabel";
            this.keyLengthScoresLabel.Size = new System.Drawing.Size(97, 13);
            this.keyLengthScoresLabel.TabIndex = 2;
            this.keyLengthScoresLabel.Text = "Key Length Scores";
            // 
            // keyLengthScoresDGV
            // 
            this.keyLengthScoresDGV.AllowUserToAddRows = false;
            this.keyLengthScoresDGV.AllowUserToDeleteRows = false;
            this.keyLengthScoresDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.keyLengthScoresDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keyLengthScoresDGV.Location = new System.Drawing.Point(13, 59);
            this.keyLengthScoresDGV.Name = "keyLengthScoresDGV";
            this.keyLengthScoresDGV.ReadOnly = true;
            this.keyLengthScoresDGV.RowHeadersVisible = false;
            this.keyLengthScoresDGV.Size = new System.Drawing.Size(205, 325);
            this.keyLengthScoresDGV.TabIndex = 1;
            this.keyLengthScoresDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.keyLengthScoresDGV_CellDoubleClick);
            // 
            // enterTextButton
            // 
            this.enterTextButton.Location = new System.Drawing.Point(13, 13);
            this.enterTextButton.Name = "enterTextButton";
            this.enterTextButton.Size = new System.Drawing.Size(75, 23);
            this.enterTextButton.TabIndex = 0;
            this.enterTextButton.Text = "Enter Text";
            this.enterTextButton.UseVisualStyleBackColor = true;
            this.enterTextButton.Click += new System.EventHandler(this.enterTextButton_Click);
            // 
            // numOfLengthsLabel
            // 
            this.numOfLengthsLabel.AutoSize = true;
            this.numOfLengthsLabel.Location = new System.Drawing.Point(130, 17);
            this.numOfLengthsLabel.Name = "numOfLengthsLabel";
            this.numOfLengthsLabel.Size = new System.Drawing.Size(133, 13);
            this.numOfLengthsLabel.TabIndex = 5;
            this.numOfLengthsLabel.Text = "Number of Lengths Tested";
            // 
            // numberOfLengthsTextBox
            // 
            this.numberOfLengthsTextBox.Location = new System.Drawing.Point(269, 14);
            this.numberOfLengthsTextBox.Name = "numberOfLengthsTextBox";
            this.numberOfLengthsTextBox.Size = new System.Drawing.Size(36, 20);
            this.numberOfLengthsTextBox.TabIndex = 6;
            this.numberOfLengthsTextBox.Text = "15";
            this.numberOfLengthsTextBox.TextChanged += new System.EventHandler(this.numberOfLengthsTextBox_TextChanged);
            // 
            // invalidNumberLabel
            // 
            this.invalidNumberLabel.AutoSize = true;
            this.invalidNumberLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidNumberLabel.Location = new System.Drawing.Point(251, 35);
            this.invalidNumberLabel.Name = "invalidNumberLabel";
            this.invalidNumberLabel.Size = new System.Drawing.Size(78, 13);
            this.invalidNumberLabel.TabIndex = 7;
            this.invalidNumberLabel.Text = "Invalid Number";
            this.invalidNumberLabel.Visible = false;
            // 
            // VigenereKeyLength
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 396);
            this.Controls.Add(this.invalidNumberLabel);
            this.Controls.Add(this.numberOfLengthsTextBox);
            this.Controls.Add(this.numOfLengthsLabel);
            this.Controls.Add(this.findScoresButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.keyLengthScoresLabel);
            this.Controls.Add(this.keyLengthScoresDGV);
            this.Controls.Add(this.enterTextButton);
            this.MinimumSize = new System.Drawing.Size(436, 321);
            this.Name = "VigenereKeyLength";
            this.Text = "Vigenere Key Length Finder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VigenereKeyLength_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyLengthScoresDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterTextButton;
        private System.Windows.Forms.DataGridView keyLengthScoresDGV;
        private System.Windows.Forms.Label keyLengthScoresLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button findScoresButton;
        private System.Windows.Forms.Label numOfLengthsLabel;
        private System.Windows.Forms.TextBox numberOfLengthsTextBox;
        private System.Windows.Forms.Label invalidNumberLabel;
    }
}