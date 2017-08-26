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
    public partial class FreqencyAnalyserForm : Form
    {
        public FreqencyAnalyserForm(CaesarForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            /*freqsListView.Columns.Add("Letter");
            freqsListView.Columns.Add("Count");*/
        }

        private void FreqencyAnalyserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //parent.Text = text;
        }

        private void enterTextButton_Click(object sender, EventArgs e)
        {
            if (parent.inputForm == null || parent.inputForm.IsDisposed)
            {
                parent.inputForm = new TextInputForm(parent, parent.ciphertext);
                parent.inputForm.Show();
            }
            else
                parent.inputForm.Select();
        }

        CaesarForm parent;

        private void findFreqsButton_Click(object sender, EventArgs e)
        {
            int[] scores = CaesarAndVigenere.letterFrequencyAnalyser(parent.ciphertext);
            freqsListView.Items.Clear();

            for (int x = 0; x < 26; x++)
            {
                string[] rowStrings = new string[] { CaesarAndVigenere.ALPHABET[x].ToString(), scores[x].ToString() };
                ListViewItem item = new ListViewItem(rowStrings);
                freqsListView.Items.Add(item);
            }

            updateChart();
        }

        private void updateChart()
        { 
            //chart1.Series["Actual Frequencies"].Points.DataBindY(CaesarAndVigenere.ALPHABET.ToArray());

            chart1.Series["English Frequencies"].Enabled = false;
            chart1.Series["Actual Frequencies"].Enabled = false;
            chart1.Series["Frequencies of Caesar Decryption"].Enabled = false;

            string text = CaesarAndVigenere.stripText(parent.ciphertext);

            if (text.Length == 0)
                return;

            if (expectedFreqsCheckBox.Checked)
            {
                chart1.Series["English Frequencies"].Enabled = true;
                double[] percentageScores = CaesarAndVigenere.ENGLISH_FREQUENCIES.Select(x => 100.0 * x).ToArray();
                chart1.Series["English Frequencies"].Points.DataBindY(percentageScores);
            }

            if (userCaesarShiftCheckBox.Checked)
            {
                if (!invalidKeyLabel.Visible)
                {
                    chart1.Series["Frequencies of Caesar Decryption"].Enabled = true;
                    double textLength = text.Length;
                    int[] scores = CaesarAndVigenere.letterFrequencyAnalyser(CaesarAndVigenere.caesarText(text, caesarShiftLetterBox.Text[0], false));
                    double[] percentageScores = scores.Select(x => 100.0 * x / textLength).ToArray();
                    chart1.Series["Frequencies of Caesar Decryption"].Points.DataBindY(percentageScores);
                }
            }
            else
            {
                chart1.Series["Actual Frequencies"].Enabled = true;
                double textLength = text.Length;
                int[] scores = CaesarAndVigenere.letterFrequencyAnalyser(text);
                double[] percentageScores = scores.Select(x => 100.0 * x / textLength).ToArray();
                chart1.Series["Actual Frequencies"].Points.DataBindY(percentageScores);
            }
        }

        private void caesarShiftLetterBox_TextChanged(object sender, EventArgs e)
        {
            if (caesarShiftLetterBox.Text.Length == 0)
            {
                invalidKeyLabel.Visible = true;
            }
            else if (Char.IsLetter(caesarShiftLetterBox.Text[0]))
            {
                invalidKeyLabel.Visible = false;
            }
            else
            {
                invalidKeyLabel.Visible = true;
            }
            updateChart();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            if (!invalidKeyLabel.Visible)
            {
                caesarShiftLetterBox.Text = CaesarAndVigenere.ALPHABET[(CaesarAndVigenere.ALPHABET.IndexOf(caesarShiftLetterBox.Text[0]) + 1) % 26].ToString();
                updateChart();
            }
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            if (!invalidKeyLabel.Visible)
            {
                caesarShiftLetterBox.Text = CaesarAndVigenere.ALPHABET[(CaesarAndVigenere.ALPHABET.IndexOf(caesarShiftLetterBox.Text[0]) + 25) % 26].ToString();
                updateChart();
            }
        }

        private void expectedFreqsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            updateChart();
        }

        private void userCaesarShiftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            updateChart();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (!invalidKeyLabel.Visible)
            {
                parent.runEncrypt(caesarShiftLetterBox.Text[0], false);
                parent.Focus();
            }
        }
    }
}
