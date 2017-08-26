namespace EncryptionToolsGUI
{
    partial class FreqencyAnalyserForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.enterTextButton = new System.Windows.Forms.Button();
            this.findFreqsButton = new System.Windows.Forms.Button();
            this.freqsListView = new System.Windows.Forms.ListView();
            this.Letter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.caesarShiftLabel = new System.Windows.Forms.Label();
            this.caesarShiftLetterBox = new System.Windows.Forms.TextBox();
            this.minusButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.invalidKeyLabel = new System.Windows.Forms.Label();
            this.expectedFreqsCheckBox = new System.Windows.Forms.CheckBox();
            this.userCaesarShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.decryptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // enterTextButton
            // 
            this.enterTextButton.Location = new System.Drawing.Point(12, 12);
            this.enterTextButton.Name = "enterTextButton";
            this.enterTextButton.Size = new System.Drawing.Size(75, 23);
            this.enterTextButton.TabIndex = 1;
            this.enterTextButton.Text = "Enter Text";
            this.enterTextButton.UseVisualStyleBackColor = true;
            this.enterTextButton.Click += new System.EventHandler(this.enterTextButton_Click);
            // 
            // findFreqsButton
            // 
            this.findFreqsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findFreqsButton.Location = new System.Drawing.Point(476, 12);
            this.findFreqsButton.Name = "findFreqsButton";
            this.findFreqsButton.Size = new System.Drawing.Size(105, 23);
            this.findFreqsButton.TabIndex = 2;
            this.findFreqsButton.Text = "Find Frequencies";
            this.findFreqsButton.UseVisualStyleBackColor = true;
            this.findFreqsButton.Click += new System.EventHandler(this.findFreqsButton_Click);
            // 
            // freqsListView
            // 
            this.freqsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.freqsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Letter,
            this.Frequency});
            this.freqsListView.GridLines = true;
            this.freqsListView.Location = new System.Drawing.Point(12, 41);
            this.freqsListView.Name = "freqsListView";
            this.freqsListView.Size = new System.Drawing.Size(144, 323);
            this.freqsListView.TabIndex = 3;
            this.freqsListView.UseCompatibleStateImageBehavior = false;
            this.freqsListView.View = System.Windows.Forms.View.Details;
            // 
            // Letter
            // 
            this.Letter.Text = "Letter";
            this.Letter.Width = 40;
            // 
            // Frequency
            // 
            this.Frequency.Text = "Frequency";
            this.Frequency.Width = 66;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Title = "Letter Number";
            chartArea1.AxisY.Title = "Percentage Frequency";
            chartArea1.BorderWidth = 3;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(169, 87);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.EmptyPointStyle.IsVisibleInLegend = false;
            series1.Enabled = false;
            series1.Legend = "Legend1";
            series1.Name = "English Frequencies";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.EmptyPointStyle.IsVisibleInLegend = false;
            series2.Enabled = false;
            series2.Legend = "Legend1";
            series2.Name = "Frequencies of Caesar Decryption";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.EmptyPointStyle.IsVisibleInLegend = false;
            series3.Enabled = false;
            series3.Legend = "Legend1";
            series3.Name = "Actual Frequencies";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(412, 277);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // caesarShiftLabel
            // 
            this.caesarShiftLabel.AutoSize = true;
            this.caesarShiftLabel.Location = new System.Drawing.Point(169, 64);
            this.caesarShiftLabel.Name = "caesarShiftLabel";
            this.caesarShiftLabel.Size = new System.Drawing.Size(64, 13);
            this.caesarShiftLabel.TabIndex = 6;
            this.caesarShiftLabel.Text = "Caesar Shift";
            // 
            // caesarShiftLetterBox
            // 
            this.caesarShiftLetterBox.Location = new System.Drawing.Point(265, 61);
            this.caesarShiftLetterBox.MaxLength = 1;
            this.caesarShiftLetterBox.Name = "caesarShiftLetterBox";
            this.caesarShiftLetterBox.Size = new System.Drawing.Size(18, 20);
            this.caesarShiftLetterBox.TabIndex = 7;
            this.caesarShiftLetterBox.Text = "A";
            this.caesarShiftLetterBox.TextChanged += new System.EventHandler(this.caesarShiftLetterBox_TextChanged);
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(289, 61);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(20, 20);
            this.minusButton.TabIndex = 8;
            this.minusButton.Text = "-";
            this.minusButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(239, 61);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(20, 20);
            this.plusButton.TabIndex = 9;
            this.plusButton.Text = "+";
            this.plusButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // invalidKeyLabel
            // 
            this.invalidKeyLabel.AutoSize = true;
            this.invalidKeyLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidKeyLabel.Location = new System.Drawing.Point(315, 65);
            this.invalidKeyLabel.Name = "invalidKeyLabel";
            this.invalidKeyLabel.Size = new System.Drawing.Size(89, 13);
            this.invalidKeyLabel.TabIndex = 10;
            this.invalidKeyLabel.Text = "Invalid Key Letter";
            this.invalidKeyLabel.Visible = false;
            // 
            // expectedFreqsCheckBox
            // 
            this.expectedFreqsCheckBox.AutoSize = true;
            this.expectedFreqsCheckBox.Checked = true;
            this.expectedFreqsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.expectedFreqsCheckBox.Location = new System.Drawing.Point(169, 15);
            this.expectedFreqsCheckBox.Name = "expectedFreqsCheckBox";
            this.expectedFreqsCheckBox.Size = new System.Drawing.Size(171, 17);
            this.expectedFreqsCheckBox.TabIndex = 11;
            this.expectedFreqsCheckBox.Text = "Overlay Expected Frequencies";
            this.expectedFreqsCheckBox.UseVisualStyleBackColor = true;
            this.expectedFreqsCheckBox.CheckedChanged += new System.EventHandler(this.expectedFreqsCheckBox_CheckedChanged);
            // 
            // userCaesarShiftCheckBox
            // 
            this.userCaesarShiftCheckBox.AutoSize = true;
            this.userCaesarShiftCheckBox.Checked = true;
            this.userCaesarShiftCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.userCaesarShiftCheckBox.Location = new System.Drawing.Point(169, 34);
            this.userCaesarShiftCheckBox.Name = "userCaesarShiftCheckBox";
            this.userCaesarShiftCheckBox.Size = new System.Drawing.Size(293, 17);
            this.userCaesarShiftCheckBox.TabIndex = 12;
            this.userCaesarShiftCheckBox.Text = "Use frequencies of text decrypted with the Caesar cipher";
            this.userCaesarShiftCheckBox.UseVisualStyleBackColor = true;
            this.userCaesarShiftCheckBox.CheckedChanged += new System.EventHandler(this.userCaesarShiftCheckBox_CheckedChanged);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(410, 58);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(62, 23);
            this.decryptButton.TabIndex = 13;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // FreqencyAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 376);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.userCaesarShiftCheckBox);
            this.Controls.Add(this.expectedFreqsCheckBox);
            this.Controls.Add(this.invalidKeyLabel);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.caesarShiftLetterBox);
            this.Controls.Add(this.caesarShiftLabel);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.freqsListView);
            this.Controls.Add(this.findFreqsButton);
            this.Controls.Add(this.enterTextButton);
            this.MinimumSize = new System.Drawing.Size(500, 375);
            this.Name = "FreqencyAnalyserForm";
            this.Text = "Freqency Analysis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FreqencyAnalyserForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterTextButton;
        private System.Windows.Forms.Button findFreqsButton;
        private System.Windows.Forms.ListView freqsListView;
        private System.Windows.Forms.ColumnHeader Letter;
        private System.Windows.Forms.ColumnHeader Frequency;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label caesarShiftLabel;
        private System.Windows.Forms.TextBox caesarShiftLetterBox;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Label invalidKeyLabel;
        private System.Windows.Forms.CheckBox expectedFreqsCheckBox;
        private System.Windows.Forms.CheckBox userCaesarShiftCheckBox;
        private System.Windows.Forms.Button decryptButton;
    }
}