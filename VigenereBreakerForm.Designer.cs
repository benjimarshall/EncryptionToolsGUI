namespace EncryptionToolsGUI
{
    partial class VigenereBreakerForm
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
            this.keyLengthLabel = new System.Windows.Forms.Label();
            this.keyLengthTextBox = new System.Windows.Forms.TextBox();
            this.findKeyLengthButton = new System.Windows.Forms.Button();
            this.keyLettersTabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.invalidKeyLengthLabel = new System.Windows.Forms.Label();
            this.findLetterScoresButton = new System.Windows.Forms.Button();
            this.enterTextButton = new System.Windows.Forms.Button();
            this.top3boxesButton = new System.Windows.Forms.Button();
            this.checkTopWithin20Button = new System.Windows.Forms.Button();
            this.clearCheckboxesButton = new System.Windows.Forms.Button();
            this.finalKeysResultsDGV = new System.Windows.Forms.DataGridView();
            this.makeKeysButton = new System.Windows.Forms.Button();
            this.keysAndDecryptionsLabel = new System.Windows.Forms.Label();
            this.breakVigenereButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.keyLettersTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalKeysResultsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // keyLengthLabel
            // 
            this.keyLengthLabel.AutoSize = true;
            this.keyLengthLabel.Location = new System.Drawing.Point(13, 113);
            this.keyLengthLabel.Name = "keyLengthLabel";
            this.keyLengthLabel.Size = new System.Drawing.Size(61, 13);
            this.keyLengthLabel.TabIndex = 0;
            this.keyLengthLabel.Text = "Key Length";
            // 
            // keyLengthTextBox
            // 
            this.keyLengthTextBox.Location = new System.Drawing.Point(80, 110);
            this.keyLengthTextBox.Name = "keyLengthTextBox";
            this.keyLengthTextBox.Size = new System.Drawing.Size(27, 20);
            this.keyLengthTextBox.TabIndex = 1;
            this.keyLengthTextBox.Text = "4";
            this.keyLengthTextBox.TextChanged += new System.EventHandler(this.keyLengthTextBox_TextChanged);
            // 
            // findKeyLengthButton
            // 
            this.findKeyLengthButton.Location = new System.Drawing.Point(127, 108);
            this.findKeyLengthButton.Name = "findKeyLengthButton";
            this.findKeyLengthButton.Size = new System.Drawing.Size(104, 23);
            this.findKeyLengthButton.TabIndex = 2;
            this.findKeyLengthButton.Text = "Find Key Length";
            this.findKeyLengthButton.UseVisualStyleBackColor = true;
            this.findKeyLengthButton.Click += new System.EventHandler(this.findKeyLengthButton_Click);
            // 
            // keyLettersTabPage
            // 
            this.keyLettersTabPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyLettersTabPage.Controls.Add(this.tabPage1);
            this.keyLettersTabPage.Controls.Add(this.tabPage2);
            this.keyLettersTabPage.Controls.Add(this.tabPage3);
            this.keyLettersTabPage.Controls.Add(this.tabPage4);
            this.keyLettersTabPage.Location = new System.Drawing.Point(237, 10);
            this.keyLettersTabPage.Name = "keyLettersTabPage";
            this.keyLettersTabPage.SelectedIndex = 0;
            this.keyLettersTabPage.Size = new System.Drawing.Size(405, 221);
            this.keyLettersTabPage.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(397, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Letter 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(391, 189);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(397, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Letter 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(391, 189);
            this.dataGridView2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(397, 195);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Letter 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(391, 189);
            this.dataGridView3.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(397, 195);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Letter 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(3, 3);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.Size = new System.Drawing.Size(391, 189);
            this.dataGridView4.TabIndex = 1;
            // 
            // invalidKeyLengthLabel
            // 
            this.invalidKeyLengthLabel.AutoSize = true;
            this.invalidKeyLengthLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidKeyLengthLabel.Location = new System.Drawing.Point(13, 133);
            this.invalidKeyLengthLabel.Name = "invalidKeyLengthLabel";
            this.invalidKeyLengthLabel.Size = new System.Drawing.Size(95, 13);
            this.invalidKeyLengthLabel.TabIndex = 4;
            this.invalidKeyLengthLabel.Text = "Invalid Key Length";
            this.invalidKeyLengthLabel.Visible = false;
            // 
            // findLetterScoresButton
            // 
            this.findLetterScoresButton.Location = new System.Drawing.Point(12, 149);
            this.findLetterScoresButton.Name = "findLetterScoresButton";
            this.findLetterScoresButton.Size = new System.Drawing.Size(122, 23);
            this.findLetterScoresButton.TabIndex = 5;
            this.findLetterScoresButton.Text = "Find Key Letter Scores";
            this.findLetterScoresButton.UseVisualStyleBackColor = true;
            this.findLetterScoresButton.Click += new System.EventHandler(this.findLetterScoresButton_Click);
            // 
            // enterTextButton
            // 
            this.enterTextButton.Location = new System.Drawing.Point(12, 8);
            this.enterTextButton.Name = "enterTextButton";
            this.enterTextButton.Size = new System.Drawing.Size(75, 23);
            this.enterTextButton.TabIndex = 6;
            this.enterTextButton.Text = "Enter Text";
            this.enterTextButton.UseVisualStyleBackColor = true;
            this.enterTextButton.Click += new System.EventHandler(this.enterTextButton_Click);
            // 
            // top3boxesButton
            // 
            this.top3boxesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.top3boxesButton.Location = new System.Drawing.Point(241, 242);
            this.top3boxesButton.Name = "top3boxesButton";
            this.top3boxesButton.Size = new System.Drawing.Size(107, 23);
            this.top3boxesButton.TabIndex = 7;
            this.top3boxesButton.Text = "Check top 3 boxes";
            this.top3boxesButton.UseVisualStyleBackColor = true;
            this.top3boxesButton.Click += new System.EventHandler(this.top3boxesButton_Click);
            // 
            // checkTopWithin20Button
            // 
            this.checkTopWithin20Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTopWithin20Button.Location = new System.Drawing.Point(382, 237);
            this.checkTopWithin20Button.Name = "checkTopWithin20Button";
            this.checkTopWithin20Button.Size = new System.Drawing.Size(108, 37);
            this.checkTopWithin20Button.TabIndex = 8;
            this.checkTopWithin20Button.Text = "Check boxes within 20% of top score";
            this.checkTopWithin20Button.UseVisualStyleBackColor = true;
            this.checkTopWithin20Button.Click += new System.EventHandler(this.checkTopWithin20Button_Click);
            // 
            // clearCheckboxesButton
            // 
            this.clearCheckboxesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearCheckboxesButton.Location = new System.Drawing.Point(528, 244);
            this.clearCheckboxesButton.Name = "clearCheckboxesButton";
            this.clearCheckboxesButton.Size = new System.Drawing.Size(107, 23);
            this.clearCheckboxesButton.TabIndex = 9;
            this.clearCheckboxesButton.Text = "Clear Checkboxes";
            this.clearCheckboxesButton.UseVisualStyleBackColor = true;
            this.clearCheckboxesButton.Click += new System.EventHandler(this.clearCheckboxesButton_Click);
            // 
            // finalKeysResultsDGV
            // 
            this.finalKeysResultsDGV.AllowUserToAddRows = false;
            this.finalKeysResultsDGV.AllowUserToDeleteRows = false;
            this.finalKeysResultsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finalKeysResultsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finalKeysResultsDGV.Location = new System.Drawing.Point(12, 320);
            this.finalKeysResultsDGV.Name = "finalKeysResultsDGV";
            this.finalKeysResultsDGV.ReadOnly = true;
            this.finalKeysResultsDGV.RowHeadersVisible = false;
            this.finalKeysResultsDGV.Size = new System.Drawing.Size(630, 129);
            this.finalKeysResultsDGV.TabIndex = 10;
            this.finalKeysResultsDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.finalKeysResultsDGV_CellDoubleClick);
            // 
            // makeKeysButton
            // 
            this.makeKeysButton.Location = new System.Drawing.Point(11, 235);
            this.makeKeysButton.Name = "makeKeysButton";
            this.makeKeysButton.Size = new System.Drawing.Size(121, 37);
            this.makeKeysButton.TabIndex = 11;
            this.makeKeysButton.Text = "Make keys and show decryptions";
            this.makeKeysButton.UseVisualStyleBackColor = true;
            this.makeKeysButton.Click += new System.EventHandler(this.makeKeysButton_Click);
            // 
            // keysAndDecryptionsLabel
            // 
            this.keysAndDecryptionsLabel.AutoSize = true;
            this.keysAndDecryptionsLabel.Location = new System.Drawing.Point(12, 304);
            this.keysAndDecryptionsLabel.Name = "keysAndDecryptionsLabel";
            this.keysAndDecryptionsLabel.Size = new System.Drawing.Size(131, 13);
            this.keysAndDecryptionsLabel.TabIndex = 12;
            this.keysAndDecryptionsLabel.Text = "Keys and their decryptions";
            // 
            // breakVigenereButton
            // 
            this.breakVigenereButton.Location = new System.Drawing.Point(140, 8);
            this.breakVigenereButton.Name = "breakVigenereButton";
            this.breakVigenereButton.Size = new System.Drawing.Size(91, 23);
            this.breakVigenereButton.TabIndex = 13;
            this.breakVigenereButton.Text = "Break Vigenere";
            this.breakVigenereButton.UseVisualStyleBackColor = true;
            this.breakVigenereButton.Click += new System.EventHandler(this.breakVigenereButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(11, 278);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(631, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // VigenereBreakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 461);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.breakVigenereButton);
            this.Controls.Add(this.keysAndDecryptionsLabel);
            this.Controls.Add(this.makeKeysButton);
            this.Controls.Add(this.finalKeysResultsDGV);
            this.Controls.Add(this.clearCheckboxesButton);
            this.Controls.Add(this.checkTopWithin20Button);
            this.Controls.Add(this.top3boxesButton);
            this.Controls.Add(this.enterTextButton);
            this.Controls.Add(this.findLetterScoresButton);
            this.Controls.Add(this.invalidKeyLengthLabel);
            this.Controls.Add(this.keyLettersTabPage);
            this.Controls.Add(this.findKeyLengthButton);
            this.Controls.Add(this.keyLengthTextBox);
            this.Controls.Add(this.keyLengthLabel);
            this.MinimumSize = new System.Drawing.Size(670, 500);
            this.Name = "VigenereBreakerForm";
            this.Text = "Vigenere Breaker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VigenereBreakerForm_FormClosed);
            this.keyLettersTabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalKeysResultsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keyLengthLabel;
        private System.Windows.Forms.TextBox keyLengthTextBox;
        private System.Windows.Forms.Button findKeyLengthButton;
        private System.Windows.Forms.TabControl keyLettersTabPage;
        private System.Windows.Forms.Label invalidKeyLengthLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button findLetterScoresButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button enterTextButton;
        private System.Windows.Forms.Button top3boxesButton;
        private System.Windows.Forms.Button checkTopWithin20Button;
        private System.Windows.Forms.Button clearCheckboxesButton;
        private System.Windows.Forms.DataGridView finalKeysResultsDGV;
        private System.Windows.Forms.Button makeKeysButton;
        private System.Windows.Forms.Label keysAndDecryptionsLabel;
        private System.Windows.Forms.Button breakVigenereButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}