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
    public partial class EnigmaBreakerForm : FormWithText
    {
        public EnigmaBreakerForm(EnigmaForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            rotorCountCB.SelectedIndex = 0;
            //reflectorCB.SelectedIndex = 1;
        }

        private void enterTextButton_Click(object sender, EventArgs e)
        {
            enterTextButton();
        }

        EnigmaForm parent;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void holdSizeChanged()
        {
            if (initHoldSizeTB.Text.Length == 0 || !initHoldSizeTB.Text.All(Char.IsDigit) 
                || initHoldSizeTB.Text.All(x => x == '0'))
            {
                invalidHoldLabel.Visible = true;
            }
            else
            {
                invalidHoldLabel.Visible = false;
            }
        }

        private void initHoldSizeTB_TextChanged(object sender, EventArgs e)
        {
            holdSizeChanged();
        }

        private void finalHoldSizeTB_TextChanged(object sender, EventArgs e)
        {
            holdSizeChanged();
        }

        /*private void fixedReflectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fixedReflectorCheckBox.Checked)
                reflectorCB.Enabled = true;
            else
                reflectorCB.Enabled = false;
        }*/

        private void findSolutionsButton_Click(object sender, EventArgs e)
        {
            rotorCount = rotorCountCB.SelectedIndex;
            holdSize = Int32.Parse(initHoldSizeTB.Text);
            plugCount = Int32.Parse(plugNumberTB.Text);
            finalSize = holdSize / 2;
            if (finalSize == 0)
                finalSize = 1;

            numOfEncryptions = Enigma.numOfEncryptionsToBreak(rotorCount + 3, holdSize, plugCount, finalSize);

            if (!invalidHoldLabel.Visible && !invalidPlugNumberLabel.Visible)
            {
                progressBar1.Maximum = numOfEncryptions;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            string text = CaesarAndVigenere.stripText(ciphertext).ToUpper();

            int finalSize = holdSize / 2;
            if (finalSize == 0)
                finalSize = 1;

            numOfEncryptions = Enigma.numOfEncryptionsToBreak(rotorCountCB.SelectedIndex + 3, Int32.Parse(initHoldSizeTB.Text),
                Int32.Parse(plugNumberTB.Text), finalSize);

            //System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

                
            //watch.Stop();
            //long elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine((double)elapsedMs/1000.0);


            /* dt.Columns.Add("Score", typeof(double));
                * dt.Columns.Add("Positions", typeof(int[]));
                * dt.Columns.Add("Rotors", typeof(int[]));
                * dt.Columns.Add("Rings", typeof(int[]));
                * dt.Columns.Add("Plugboard", typeof(char[][]));
                */

            DataTable finalResultsDT = new DataTable();
            finalResultsDT.Columns.Add("Score", typeof(double));
            finalResultsDT.Columns.Add("Positions", typeof(string));
            finalResultsDT.Columns.Add("Rotors", typeof(string));
            finalResultsDT.Columns.Add("Rings", typeof(string));
            finalResultsDT.Columns.Add("Plugboard", typeof(string));
            finalResultsDT.Columns.Add("Text", typeof(string));

            foreach (DataRow row in results.Rows)
            {
                DataRow newRow = finalResultsDT.NewRow();

                newRow[0] = row[0];
                newRow[1] = new string(((int[])row[1]).Select(x => (char)(x + 65)).ToArray());
                newRow[2] = new string(((int[])row[2]).Select(x => (char)(x + 48)).ToArray());
                newRow[3] = new string(((int[])row[3]).Select(x => (char)(x + 65)).ToArray());

                StringBuilder plugBoard = new StringBuilder();
                foreach (char[] plug in (char[][])row[4])
                {
                    plugBoard.Append('[').Append(plug[0]).Append(", ").Append(plug[1]).Append("] ");
                }
                newRow[4] = plugBoard.ToString();
                newRow[5] = (new Enigma((string)newRow[2], 'B', (string)newRow[1], (char[][])((char[][])row[4]).Clone(), (string)newRow[3])).encrypt(text);

                finalResultsDT.Rows.Add(newRow);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = finalResultsDT;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

            dataGridView1.Columns["Text"].Width = 250;
        }
        

        private void plugNumberTB_TextChanged(object sender, EventArgs e)
        {
            if (plugNumberTB.Text.Length != 0 && plugNumberTB.Text.All(Char.IsDigit))
            {
                int plugNumber = Int32.Parse(plugNumberTB.Text);
                if (plugNumber > 13)
                {
                    invalidPlugNumberLabel.Visible = true;
                    largePlugCountWarningLabel.Visible = false;
                }
                else
                {
                    invalidPlugNumberLabel.Visible = false;
                    if (plugNumber > 10)
                        largePlugCountWarningLabel.Visible = true;
                    else
                        largePlugCountWarningLabel.Visible = false;
                }
            }
            else
            {
                invalidPlugNumberLabel.Visible = true;
                largePlugCountWarningLabel.Visible = false;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != 5)
            //    return;

            parent.launchEncrypt(dataGridView1.Rows[e.RowIndex], ciphertext);
            parent.Focus();

        }

        public void Update(int i, string threadName)
        {
            Console.WriteLine("Called! ");
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int, string>(Update), new object[] { i, threadName });
                return;
            }
            //label1.Text = threadName;
            Console.WriteLine(+progressBar1.Value + ", " + (progressBar1.Value + i) + "; " + numOfEncryptions);
            progressBar1.Value = Math.Min(progressBar1.Value + i, numOfEncryptions);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string text = CaesarAndVigenere.stripText(ciphertext).ToUpper();
            results = Enigma.finalEnigma(text, rotorCount + 3, holdSize, plugCount,
                finalSize, this);
            Console.WriteLine("Done: " + results == null);
        }

        int rotorCount;
        int holdSize;
        int plugCount;
        int finalSize;
        int numOfEncryptions;
        DataTable results;
    }
}
