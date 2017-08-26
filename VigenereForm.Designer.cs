namespace EncryptionToolsGUI
{
    partial class VigenereForm
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
            this.decryptRB = new System.Windows.Forms.RadioButton();
            this.encryptRB = new System.Windows.Forms.RadioButton();
            this.encryptionModePanel = new System.Windows.Forms.Panel();
            this.outputTextLabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.invalidKeyLabel = new System.Windows.Forms.Label();
            this.encryptButton = new System.Windows.Forms.Button();
            this.vigenereBreakerButton = new System.Windows.Forms.Button();
            this.encryptionModePanel.SuspendLayout();
            this.SuspendLayout();
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
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Location = new System.Drawing.Point(13, 87);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(457, 162);
            this.outputTextBox.TabIndex = 1;
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
            // encryptionModePanel
            // 
            this.encryptionModePanel.Controls.Add(this.decryptRB);
            this.encryptionModePanel.Controls.Add(this.encryptRB);
            this.encryptionModePanel.Location = new System.Drawing.Point(105, 13);
            this.encryptionModePanel.Name = "encryptionModePanel";
            this.encryptionModePanel.Size = new System.Drawing.Size(147, 23);
            this.encryptionModePanel.TabIndex = 2;
            // 
            // outputTextLabel
            // 
            this.outputTextLabel.AutoSize = true;
            this.outputTextLabel.Location = new System.Drawing.Point(13, 68);
            this.outputTextLabel.Name = "outputTextLabel";
            this.outputTextLabel.Size = new System.Drawing.Size(63, 13);
            this.outputTextLabel.TabIndex = 3;
            this.outputTextLabel.Text = "Output Text";
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(13, 48);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(25, 13);
            this.keyLabel.TabIndex = 4;
            this.keyLabel.Text = "Key";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(44, 45);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(107, 20);
            this.keyTextBox.TabIndex = 5;
            this.keyTextBox.Text = "WORD";
            this.keyTextBox.TextChanged += new System.EventHandler(this.keyTextBox_TextChanged);
            this.keyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyTextBox_KeyPress);
            // 
            // invalidKeyLabel
            // 
            this.invalidKeyLabel.AutoSize = true;
            this.invalidKeyLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidKeyLabel.Location = new System.Drawing.Point(158, 48);
            this.invalidKeyLabel.Name = "invalidKeyLabel";
            this.invalidKeyLabel.Size = new System.Drawing.Size(59, 13);
            this.invalidKeyLabel.TabIndex = 6;
            this.invalidKeyLabel.Text = "Invalid Key";
            this.invalidKeyLabel.Visible = false;
            this.invalidKeyLabel.VisibleChanged += new System.EventHandler(this.invalidKeyLabel_VisibleChanged);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(273, 13);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 7;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // vigenereBreakerButton
            // 
            this.vigenereBreakerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vigenereBreakerButton.Location = new System.Drawing.Point(398, 12);
            this.vigenereBreakerButton.Name = "vigenereBreakerButton";
            this.vigenereBreakerButton.Size = new System.Drawing.Size(75, 37);
            this.vigenereBreakerButton.TabIndex = 8;
            this.vigenereBreakerButton.Text = "Vigenere Breaker";
            this.vigenereBreakerButton.UseVisualStyleBackColor = true;
            this.vigenereBreakerButton.Click += new System.EventHandler(this.vigenereBreakerButton_Click);
            // 
            // VigenereForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 261);
            this.Controls.Add(this.vigenereBreakerButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.invalidKeyLabel);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.outputTextLabel);
            this.Controls.Add(this.encryptionModePanel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.enterTextButton);
            this.Name = "VigenereForm";
            this.Text = "Vigenere Cipher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VigenereForm_FormClosed);
            this.encryptionModePanel.ResumeLayout(false);
            this.encryptionModePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterTextButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.RadioButton decryptRB;
        private System.Windows.Forms.RadioButton encryptRB;
        private System.Windows.Forms.Panel encryptionModePanel;
        private System.Windows.Forms.Label outputTextLabel;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label invalidKeyLabel;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button vigenereBreakerButton;
    }
}