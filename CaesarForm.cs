using EPQProjectCMD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionToolsGUI
{
    public partial class CaesarForm : FormWithText
    {
        public CaesarForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void enterTextButton_Click(object sender, EventArgs e)
        {
            // Launch textbox form
            //inputForm = Application.OpenForms.OfType<TextInputForm>().FirstOrDefault();
            enterTextButton();
        }

        private void caesarShiftLetterBox_TextChanged(object sender, EventArgs e)
        {
            if (caesarShiftLetterBox.Text.Length == 0)
            {
                invalidKeyLabel.Visible = true;
                return;
            }
            if (Char.IsLetter(caesarShiftLetterBox.Text[0]))
            {
                invalidKeyLabel.Visible = false;
                return;
            }
            else
            {
                invalidKeyLabel.Visible = true;
                return;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            ciphertext = CaesarAndVigenere.stripText(ciphertext);
            runEncrypt(caesarShiftLetterBox.Text[0], encryptRB.Checked);
        }

        public void runEncrypt(char key, bool encrypt)
        {
            outputTextBox.Text = CaesarAndVigenere.caesarText(ciphertext, key, encrypt);
            caesarShiftLetterBox.Text = key.ToString();
            decryptRB.Checked = !encrypt;
            encryptRB.Checked = encrypt;
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

        /*private void encryptionModePanel_Paint(object sender, PaintEventArgs e)
        {

        }*/

        private void freqAnalButton_Click(object sender, EventArgs e)
        {
            if (freqAnalyser == null || freqAnalyser.IsDisposed)
            {
                freqAnalyser = new FreqencyAnalyserForm(this);
                freqAnalyser.Show();
            }
            else
                freqAnalyser.Select();
        }

        private void CaesarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (inputForm != null)
                inputForm.Dispose();
            if (freqAnalyser != null)
                freqAnalyser.Dispose();
        }

        private FreqencyAnalyserForm freqAnalyser;

        private void caesarShiftLetterBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!(Char.IsLetter(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;*/
        }
    }
}
