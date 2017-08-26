using EPQProjectCMD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionToolsGUI
{
    public partial class VigenereForm : FormWithText
    {
        public VigenereForm()
        {
            InitializeComponent();
        }

        private void enterTextButton_Click(object sender, EventArgs e)
        {
            enterTextButton();
        }

        private void encryptRB_CheckedChanged(object sender, EventArgs e)
        {
            if (encryptRB.Checked)
            {
                encryptButton.Text = "Encrypt";
            }
            else
            {
                encryptButton.Text = "Decrypt";
            }
        }

        private void invalidKeyLabel_VisibleChanged(object sender, EventArgs e)
        {
            if (invalidKeyLabel.Visible)
            {
                encryptButton.Enabled = false;
            }
            else
            {
                encryptButton.Enabled = true;
            }
        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (keyTextBox.Text.Length == 0)
                invalidKeyLabel.Visible = true;
            else if (Regex.IsMatch(keyTextBox.Text, @"^[a-zA-Z]+$"))
                invalidKeyLabel.Visible = false;
            else
                invalidKeyLabel.Visible = true;
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            ciphertext = CaesarAndVigenere.stripText(ciphertext);
            runEncrypt(CaesarAndVigenere.stripText(keyTextBox.Text).ToUpper(), 
                encryptRB.Checked);
        }

        public void runEncrypt(string key, bool encrypt)
        {
            outputTextBox.Text = CaesarAndVigenere.vigenereText(ciphertext, key, encrypt);
            keyTextBox.Text = key.ToString();
            decryptRB.Checked = !encrypt;
            encryptRB.Checked = encrypt;
        }

        private void VigenereForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (inputForm != null)
                inputForm.Dispose();
            if (breakerForm != null)
                breakerForm.Dispose();
        }

        private void vigenereBreakerButton_Click(object sender, EventArgs e)
        {
            if (breakerForm == null || breakerForm.IsDisposed)
            {
                breakerForm = new VigenereBreakerForm(this);
                breakerForm.Show();
            }
            else
                breakerForm.Select();
        }

        private void keyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private VigenereBreakerForm breakerForm;
    }
}
