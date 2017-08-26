namespace EncryptionToolsGUI
{
    partial class Launcher
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
            this.caesarButton = new System.Windows.Forms.Button();
            this.vigenereButton = new System.Windows.Forms.Button();
            this.enigmaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // caesarButton
            // 
            this.caesarButton.Location = new System.Drawing.Point(110, 12);
            this.caesarButton.Name = "caesarButton";
            this.caesarButton.Size = new System.Drawing.Size(75, 23);
            this.caesarButton.TabIndex = 0;
            this.caesarButton.Text = "Caesar";
            this.caesarButton.UseVisualStyleBackColor = true;
            this.caesarButton.Click += new System.EventHandler(this.caesarButton_Click);
            // 
            // vigenereButton
            // 
            this.vigenereButton.Location = new System.Drawing.Point(110, 44);
            this.vigenereButton.Name = "vigenereButton";
            this.vigenereButton.Size = new System.Drawing.Size(75, 23);
            this.vigenereButton.TabIndex = 1;
            this.vigenereButton.Text = "Vigenere";
            this.vigenereButton.UseVisualStyleBackColor = true;
            this.vigenereButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // enigmaButton
            // 
            this.enigmaButton.Location = new System.Drawing.Point(110, 77);
            this.enigmaButton.Name = "enigmaButton";
            this.enigmaButton.Size = new System.Drawing.Size(75, 23);
            this.enigmaButton.TabIndex = 2;
            this.enigmaButton.Text = "Enigma";
            this.enigmaButton.UseVisualStyleBackColor = true;
            this.enigmaButton.Click += new System.EventHandler(this.enigmaButton_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 112);
            this.Controls.Add(this.enigmaButton);
            this.Controls.Add(this.vigenereButton);
            this.Controls.Add(this.caesarButton);
            this.Name = "Launcher";
            this.Text = "Encryption Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button caesarButton;
        private System.Windows.Forms.Button vigenereButton;
        private System.Windows.Forms.Button enigmaButton;
    }
}