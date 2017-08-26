namespace EncryptionToolsGUI
{
    partial class EnigmaBreakerForm
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
            this.enterTextButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.findSolutionsButton = new System.Windows.Forms.Button();
            this.solutionsLabel = new System.Windows.Forms.Label();
            this.additionalSettingsBox = new System.Windows.Forms.GroupBox();
            this.invalidHoldLabel = new System.Windows.Forms.Label();
            this.initHoldSizeTB = new System.Windows.Forms.TextBox();
            this.initHoldSizeLabel = new System.Windows.Forms.Label();
            this.rotorCountLabel = new System.Windows.Forms.Label();
            this.rotorCountCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfPlugsLabel = new System.Windows.Forms.Label();
            this.plugNumberTB = new System.Windows.Forms.TextBox();
            this.invalidPlugNumberLabel = new System.Windows.Forms.Label();
            this.largePlugCountWarningLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.additionalSettingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterTextButton
            // 
            this.enterTextButton.Location = new System.Drawing.Point(13, 13);
            this.enterTextButton.Name = "enterTextButton";
            this.enterTextButton.Size = new System.Drawing.Size(82, 23);
            this.enterTextButton.TabIndex = 0;
            this.enterTextButton.Text = "Enter Text";
            this.enterTextButton.UseVisualStyleBackColor = true;
            this.enterTextButton.Click += new System.EventHandler(this.enterTextButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(687, 124);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // findSolutionsButton
            // 
            this.findSolutionsButton.Location = new System.Drawing.Point(101, 13);
            this.findSolutionsButton.Name = "findSolutionsButton";
            this.findSolutionsButton.Size = new System.Drawing.Size(82, 23);
            this.findSolutionsButton.TabIndex = 2;
            this.findSolutionsButton.Text = "Find solutions";
            this.findSolutionsButton.UseVisualStyleBackColor = true;
            this.findSolutionsButton.Click += new System.EventHandler(this.findSolutionsButton_Click);
            // 
            // solutionsLabel
            // 
            this.solutionsLabel.AutoSize = true;
            this.solutionsLabel.Location = new System.Drawing.Point(10, 171);
            this.solutionsLabel.Name = "solutionsLabel";
            this.solutionsLabel.Size = new System.Drawing.Size(50, 13);
            this.solutionsLabel.TabIndex = 3;
            this.solutionsLabel.Text = "Solutions";
            // 
            // additionalSettingsBox
            // 
            this.additionalSettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.additionalSettingsBox.Controls.Add(this.invalidHoldLabel);
            this.additionalSettingsBox.Controls.Add(this.initHoldSizeTB);
            this.additionalSettingsBox.Controls.Add(this.initHoldSizeLabel);
            this.additionalSettingsBox.Controls.Add(this.rotorCountLabel);
            this.additionalSettingsBox.Controls.Add(this.rotorCountCB);
            this.additionalSettingsBox.Controls.Add(this.label1);
            this.additionalSettingsBox.Location = new System.Drawing.Point(371, 13);
            this.additionalSettingsBox.Name = "additionalSettingsBox";
            this.additionalSettingsBox.Size = new System.Drawing.Size(329, 126);
            this.additionalSettingsBox.TabIndex = 4;
            this.additionalSettingsBox.TabStop = false;
            this.additionalSettingsBox.Text = "Additional Settings";
            // 
            // invalidHoldLabel
            // 
            this.invalidHoldLabel.AutoSize = true;
            this.invalidHoldLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidHoldLabel.Location = new System.Drawing.Point(49, 92);
            this.invalidHoldLabel.Name = "invalidHoldLabel";
            this.invalidHoldLabel.Size = new System.Drawing.Size(82, 13);
            this.invalidHoldLabel.TabIndex = 21;
            this.invalidHoldLabel.Text = "Invalid hold size";
            this.invalidHoldLabel.Visible = false;
            this.invalidHoldLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // initHoldSizeTB
            // 
            this.initHoldSizeTB.Location = new System.Drawing.Point(69, 68);
            this.initHoldSizeTB.Name = "initHoldSizeTB";
            this.initHoldSizeTB.Size = new System.Drawing.Size(49, 20);
            this.initHoldSizeTB.TabIndex = 18;
            this.initHoldSizeTB.Text = "100";
            this.initHoldSizeTB.TextChanged += new System.EventHandler(this.initHoldSizeTB_TextChanged);
            // 
            // initHoldSizeLabel
            // 
            this.initHoldSizeLabel.AutoSize = true;
            this.initHoldSizeLabel.Location = new System.Drawing.Point(13, 71);
            this.initHoldSizeLabel.Name = "initHoldSizeLabel";
            this.initHoldSizeLabel.Size = new System.Drawing.Size(50, 13);
            this.initHoldSizeLabel.TabIndex = 17;
            this.initHoldSizeLabel.Text = "Hold size";
            // 
            // rotorCountLabel
            // 
            this.rotorCountLabel.AutoSize = true;
            this.rotorCountLabel.Location = new System.Drawing.Point(10, 37);
            this.rotorCountLabel.Name = "rotorCountLabel";
            this.rotorCountLabel.Size = new System.Drawing.Size(85, 13);
            this.rotorCountLabel.TabIndex = 14;
            this.rotorCountLabel.Text = "Number of rotors";
            // 
            // rotorCountCB
            // 
            this.rotorCountCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotorCountCB.FormattingEnabled = true;
            this.rotorCountCB.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.rotorCountCB.Location = new System.Drawing.Point(101, 34);
            this.rotorCountCB.Name = "rotorCountCB";
            this.rotorCountCB.Size = new System.Drawing.Size(42, 21);
            this.rotorCountCB.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "These options may significantly slow down the solution finder";
            // 
            // numberOfPlugsLabel
            // 
            this.numberOfPlugsLabel.AutoSize = true;
            this.numberOfPlugsLabel.Location = new System.Drawing.Point(13, 43);
            this.numberOfPlugsLabel.Name = "numberOfPlugsLabel";
            this.numberOfPlugsLabel.Size = new System.Drawing.Size(85, 13);
            this.numberOfPlugsLabel.TabIndex = 5;
            this.numberOfPlugsLabel.Text = "Number of Plugs";
            // 
            // plugNumberTB
            // 
            this.plugNumberTB.Location = new System.Drawing.Point(104, 40);
            this.plugNumberTB.MaxLength = 2;
            this.plugNumberTB.Name = "plugNumberTB";
            this.plugNumberTB.Size = new System.Drawing.Size(25, 20);
            this.plugNumberTB.TabIndex = 6;
            this.plugNumberTB.Text = "5";
            this.plugNumberTB.TextChanged += new System.EventHandler(this.plugNumberTB_TextChanged);
            // 
            // invalidPlugNumberLabel
            // 
            this.invalidPlugNumberLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidPlugNumberLabel.Location = new System.Drawing.Point(16, 63);
            this.invalidPlugNumberLabel.Name = "invalidPlugNumberLabel";
            this.invalidPlugNumberLabel.Size = new System.Drawing.Size(167, 18);
            this.invalidPlugNumberLabel.TabIndex = 7;
            this.invalidPlugNumberLabel.Text = "Invalid Number of Plugs";
            this.invalidPlugNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.invalidPlugNumberLabel.Visible = false;
            // 
            // largePlugCountWarningLabel
            // 
            this.largePlugCountWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.largePlugCountWarningLabel.Location = new System.Drawing.Point(13, 81);
            this.largePlugCountWarningLabel.Name = "largePlugCountWarningLabel";
            this.largePlugCountWarningLabel.Size = new System.Drawing.Size(170, 41);
            this.largePlugCountWarningLabel.TabIndex = 8;
            this.largePlugCountWarningLabel.Text = "This program will have great difficulty finding good solutions due to the large n" +
    "umber of plugs";
            this.largePlugCountWarningLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.largePlugCountWarningLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(687, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // EnigmaBreakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 323);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.largePlugCountWarningLabel);
            this.Controls.Add(this.invalidPlugNumberLabel);
            this.Controls.Add(this.plugNumberTB);
            this.Controls.Add(this.numberOfPlugsLabel);
            this.Controls.Add(this.additionalSettingsBox);
            this.Controls.Add(this.solutionsLabel);
            this.Controls.Add(this.findSolutionsButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.enterTextButton);
            this.MinimumSize = new System.Drawing.Size(546, 362);
            this.Name = "EnigmaBreakerForm";
            this.Text = "Enigma Breaker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.additionalSettingsBox.ResumeLayout(false);
            this.additionalSettingsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterTextButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button findSolutionsButton;
        private System.Windows.Forms.Label solutionsLabel;
        private System.Windows.Forms.GroupBox additionalSettingsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox initHoldSizeTB;
        private System.Windows.Forms.Label initHoldSizeLabel;
        private System.Windows.Forms.Label rotorCountLabel;
        private System.Windows.Forms.ComboBox rotorCountCB;
        private System.Windows.Forms.Label invalidHoldLabel;
        private System.Windows.Forms.Label numberOfPlugsLabel;
        private System.Windows.Forms.TextBox plugNumberTB;
        private System.Windows.Forms.Label invalidPlugNumberLabel;
        private System.Windows.Forms.Label largePlugCountWarningLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}