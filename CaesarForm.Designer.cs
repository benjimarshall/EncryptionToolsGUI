namespace EncryptionToolsGUI
{
    partial class CaesarForm
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
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextLabel = new System.Windows.Forms.Label();
            this.caesarLetterLabel = new System.Windows.Forms.Label();
            this.caesarShiftLetterBox = new System.Windows.Forms.TextBox();
            this.invalidKeyLabel = new System.Windows.Forms.Label();
            this.encryptButton = new System.Windows.Forms.Button();
            this.freqAnalButton = new System.Windows.Forms.Button();
            this.encryptionModePanel = new System.Windows.Forms.Panel();
            this.decryptRB = new System.Windows.Forms.RadioButton();
            this.encryptRB = new System.Windows.Forms.RadioButton();
            this.encryptionModePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterTextButton
            // 
            this.enterTextButton.Location = new System.Drawing.Point(12, 12);
            this.enterTextButton.Name = "enterTextButton";
            this.enterTextButton.Size = new System.Drawing.Size(75, 23);
            this.enterTextButton.TabIndex = 0;
            this.enterTextButton.Text = "Enter Text";
            this.enterTextButton.UseVisualStyleBackColor = true;
            this.enterTextButton.Click += new System.EventHandler(this.enterTextButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Location = new System.Drawing.Point(13, 88);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(484, 227);
            this.outputTextBox.TabIndex = 2;
            // 
            // outputTextLabel
            // 
            this.outputTextLabel.AutoSize = true;
            this.outputTextLabel.Location = new System.Drawing.Point(12, 72);
            this.outputTextLabel.Name = "outputTextLabel";
            this.outputTextLabel.Size = new System.Drawing.Size(63, 13);
            this.outputTextLabel.TabIndex = 3;
            this.outputTextLabel.Text = "Output Text";
            // 
            // caesarLetterLabel
            // 
            this.caesarLetterLabel.AutoSize = true;
            this.caesarLetterLabel.Location = new System.Drawing.Point(12, 47);
            this.caesarLetterLabel.Name = "caesarLetterLabel";
            this.caesarLetterLabel.Size = new System.Drawing.Size(94, 13);
            this.caesarLetterLabel.TabIndex = 4;
            this.caesarLetterLabel.Text = "Caesar Shift Letter";
            // 
            // caesarShiftLetterBox
            // 
            this.caesarShiftLetterBox.Location = new System.Drawing.Point(112, 44);
            this.caesarShiftLetterBox.MaxLength = 1;
            this.caesarShiftLetterBox.Name = "caesarShiftLetterBox";
            this.caesarShiftLetterBox.Size = new System.Drawing.Size(31, 20);
            this.caesarShiftLetterBox.TabIndex = 5;
            this.caesarShiftLetterBox.Text = "A";
            this.caesarShiftLetterBox.TextChanged += new System.EventHandler(this.caesarShiftLetterBox_TextChanged);
            this.caesarShiftLetterBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.caesarShiftLetterBox_KeyPress);
            // 
            // invalidKeyLabel
            // 
            this.invalidKeyLabel.AutoSize = true;
            this.invalidKeyLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidKeyLabel.Location = new System.Drawing.Point(149, 47);
            this.invalidKeyLabel.Name = "invalidKeyLabel";
            this.invalidKeyLabel.Size = new System.Drawing.Size(89, 13);
            this.invalidKeyLabel.TabIndex = 6;
            this.invalidKeyLabel.Text = "Invalid Key Letter";
            this.invalidKeyLabel.Visible = false;
            this.invalidKeyLabel.VisibleChanged += new System.EventHandler(this.invalidKeyLabel_VisibleChanged);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(268, 12);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 7;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // freqAnalButton
            // 
            this.freqAnalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.freqAnalButton.Location = new System.Drawing.Point(383, 12);
            this.freqAnalButton.Name = "freqAnalButton";
            this.freqAnalButton.Size = new System.Drawing.Size(114, 23);
            this.freqAnalButton.TabIndex = 8;
            this.freqAnalButton.Text = "Frequency Analysis";
            this.freqAnalButton.UseVisualStyleBackColor = true;
            this.freqAnalButton.Click += new System.EventHandler(this.freqAnalButton_Click);
            // 
            // encryptionModePanel
            // 
            this.encryptionModePanel.Controls.Add(this.decryptRB);
            this.encryptionModePanel.Controls.Add(this.encryptRB);
            this.encryptionModePanel.Location = new System.Drawing.Point(93, 12);
            this.encryptionModePanel.Name = "encryptionModePanel";
            this.encryptionModePanel.Size = new System.Drawing.Size(147, 23);
            this.encryptionModePanel.TabIndex = 9;
            // 
            // decryptRB
            // 
            this.decryptRB.AutoSize = true;
            this.decryptRB.Location = new System.Drawing.Point(74, 3);
            this.decryptRB.Name = "decryptRB";
            this.decryptRB.Size = new System.Drawing.Size(62, 17);
            this.decryptRB.TabIndex = 1;
            this.decryptRB.Text = "Decrypt";
            this.decryptRB.UseVisualStyleBackColor = true;
            // 
            // encryptRB
            // 
            this.encryptRB.AutoSize = true;
            this.encryptRB.Checked = true;
            this.encryptRB.Location = new System.Drawing.Point(1, 3);
            this.encryptRB.Name = "encryptRB";
            this.encryptRB.Size = new System.Drawing.Size(61, 17);
            this.encryptRB.TabIndex = 0;
            this.encryptRB.TabStop = true;
            this.encryptRB.Text = "Encrypt";
            this.encryptRB.UseVisualStyleBackColor = true;
            this.encryptRB.CheckedChanged += new System.EventHandler(this.encryptRB_CheckedChanged);
            // 
            // CaesarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 327);
            this.Controls.Add(this.encryptionModePanel);
            this.Controls.Add(this.freqAnalButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.invalidKeyLabel);
            this.Controls.Add(this.caesarShiftLetterBox);
            this.Controls.Add(this.caesarLetterLabel);
            this.Controls.Add(this.outputTextLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.enterTextButton);
            this.MinimumSize = new System.Drawing.Size(525, 200);
            this.Name = "CaesarForm";
            this.Text = "Caesar Cipher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaesarForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.encryptionModePanel.ResumeLayout(false);
            this.encryptionModePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterTextButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label outputTextLabel;
        private System.Windows.Forms.Label caesarLetterLabel;
        private System.Windows.Forms.TextBox caesarShiftLetterBox;
        private System.Windows.Forms.Label invalidKeyLabel;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button freqAnalButton;
        private System.Windows.Forms.Panel encryptionModePanel;
        private System.Windows.Forms.RadioButton decryptRB;
        private System.Windows.Forms.RadioButton encryptRB;
    }
}

