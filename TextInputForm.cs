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
    public partial class TextInputForm : Form
    {
        public TextInputForm(FormWithText parent, string startText)
        {
            parentForm = parent;
            InitializeComponent();
            textBox1.Text = startText;
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            parentForm.ciphertext = textBox1.Text;
        }

        private void TextInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.ciphertext = textBox1.Text;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FormWithText parentForm;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void TextInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
