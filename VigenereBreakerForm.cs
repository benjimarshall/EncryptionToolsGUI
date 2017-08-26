using EPQProjectCMD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EncryptionToolsGUI
{
    public partial class VigenereBreakerForm : FormWithText
    {
        public VigenereBreakerForm(VigenereForm parent)
        {
            InitializeComponent();
            this.parent = parent;

            tabPages.Add(tabPage1);
            tabPages.Add(tabPage2);
            tabPages.Add(tabPage3);
            tabPages.Add(tabPage4);

            dataGrids.Add(dataGridView1);
            dataGrids.Add(dataGridView2);
            dataGrids.Add(dataGridView3);
            dataGrids.Add(dataGridView4);

            /*keyLettersTabPage.SelectTab(tabPage2);
            keyLettersTabPage.SelectTab(tabPage3);
            keyLettersTabPage.SelectTab(tabPage4);
            keyLettersTabPage.SelectTab(tabPage1)*/
        }

        private TabPage newTab()
        {
            TabPage tp = new TabPage("Letter " + (keyLettersTabPage.TabCount + 1));
            DataGridView dgv = new DataGridView();

            tp.Location = new Point(4, 22);
            tp.Name = "tabPage" + (keyLettersTabPage.TabCount + 1);
            tp.Size = new Size(397, 195);
            tp.TabIndex = 0;
            tp.UseVisualStyleBackColor = true;

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(3, 3);
            dgv.Name = "dataGridView" + (keyLettersTabPage.TabCount + 1);
            dgv.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Left) | AnchorStyles.Right)));
            
            dgv.ReadOnly = false;
            dgv.Size = new Size(391, 189);
            tp.Controls.Add(dgv);

            //Console.WriteLine(tp.Controls.Count);

            tabPages.Add(tp);
            dataGrids.Add(dgv);

            return tp;
        }

        private void keyLengthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (keyLengthTextBox.Text.Length == 0)
                invalidKeyLengthLabel.Visible = true;
            else if (Regex.IsMatch(keyLengthTextBox.Text, @"^[1-9][0-9]*$"))
                invalidKeyLengthLabel.Visible = false;
            else
                invalidKeyLengthLabel.Visible = true;

            if (!invalidKeyLengthLabel.Visible)
            {
                keyLengthChanged();
                findScores();
                solveForKeys();
            }
        }

        private void keyLengthChanged()
        {
            int tabDifference = keyLettersTabPage.TabCount - Int32.Parse(keyLengthTextBox.Text);

            if (tabDifference > 0)
            {
                for (int x = 0; x < tabDifference; x++)
                {
                    //if (keyLettersTabPage.TabCount != tabPages.Count)
                    //    Console.WriteLine("Whoops: " + keyLettersTabPage.TabCount + " " + tabPages.Count);

                    keyLettersTabPage.TabPages.Remove(tabPages[keyLettersTabPage.TabCount - 1]);
                    tabPages.RemoveAt(tabPages.Count - 1);
                    dataGrids.RemoveAt(dataGrids.Count - 1);
                }
            }
            else if (tabDifference < 0)
            {
                for (int x = 0; x < -tabDifference; x++)
                {
                    keyLettersTabPage.TabPages.Add(newTab());
                }
            }

            keyLengthTextBox.Focus();
        }

        public void changeKeyLength(int keyLength)
        {
            keyLengthTextBox.Text = keyLength.ToString();
            /*keyLengthChanged();
            findScores();
            solveForKeys();*/
        }

        private void findLetterScoresButton_Click(object sender, EventArgs e)
        {
            findScores();
        }

        private void findScores()
        {
            int keyLength = Int32.Parse(keyLengthTextBox.Text);
            //List<double[]> keyLetters = new List<double[]>();
            string[] textColumns = CaesarAndVigenere.vigenereColumnSeparator(parent.ciphertext, keyLength);

            for (int x = 0; x < keyLength; x++)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Letter", typeof(char));
                dt.Columns.Add("Chi-squared score", typeof(double));
                dt.Columns[0].ReadOnly = true;
                dt.Columns[1].ReadOnly = true;


                for (int i = 0; i < 26; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = (char)(i + 65);
                    dr[1] = CaesarAndVigenere.chiSquaredScore(CaesarAndVigenere.caesarText(textColumns[x], CaesarAndVigenere.ALPHABET[i], false));
                    dt.Rows.Add(dr);
                }

                dataGrids[x].DataSource = null;
                dataGrids[x].Columns.Clear();
                dataGrids[x].DataSource = dt;
                dataGrids[x].Sort(dataGrids[x].Columns[1], ListSortDirection.Ascending);

                DataGridViewCheckBoxColumn cbc = new DataGridViewCheckBoxColumn();
                dataGrids[x].Columns.Add(cbc);
                cbc.HeaderText = "Check letter";
                cbc.Name = "checkBoxes";
                cbc.Width = 75;
                cbc.ReadOnly = false;
            }
            checkTopWithin20();
            //solveForKeys();
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

        private void clearCheckboxesButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridView dgv in dataGrids)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)(row.Cells["checkBoxes"]);
                    cell.Value = false;
                }
            }
        }

        private void top3boxesButton_Click(object sender, EventArgs e)
        {
            TabPage selectedPage = keyLettersTabPage.SelectedTab;
            for (int gridNo = 0; gridNo < dataGrids.Count; gridNo++)
            {
                keyLettersTabPage.SelectedTab = keyLettersTabPage.TabPages[gridNo];
                DataGridView dgv = dataGrids[gridNo];
                //foreach (DataGridViewRow row in dgv.Rows)
                for (int x = 0; x < 3; x++)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)(dgv.Rows[x].Cells["checkBoxes"]);
                    //DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)(row.Cells["checkBoxes"]);
                    cell.Value = true;
                }
            }

            keyLettersTabPage.SelectedTab = selectedPage;
        }

        private void checkTopWithin20Button_Click(object sender, EventArgs e)
        {
            checkTopWithin20();
        }

        private void checkTopWithin20()
        {
            TabPage selectedPage = keyLettersTabPage.SelectedTab;
            for (int gridNo = 0; gridNo < dataGrids.Count; gridNo++)
            {
                keyLettersTabPage.SelectedTab = keyLettersTabPage.TabPages[gridNo];
                DataGridView dgv = dataGrids[gridNo];
                //foreach (DataGridViewRow row in dgv.Rows)

                double biggerScore = (double)(dgv.Rows[0].Cells["Chi-squared score"].Value) * 1.2;
                for (int x = 0; x < 26; x++)
                {
                    if ((double)(dgv.Rows[x].Cells["Chi-squared score"].Value) > biggerScore)
                        break;
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)(dgv.Rows[x].Cells["checkBoxes"]);
                    //DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)(row.Cells["checkBoxes"]);
                    cell.Value = true;
                }
            }

            keyLettersTabPage.SelectedTab = selectedPage;
        }

        private void makeKeysButton_Click(object sender, EventArgs e)
        {
            solveForKeys();
        }

        private void solveForKeys()
        {
            progressBar1.Maximum = 1000;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get array of checked letters
            List<char[]> checkedLetterLists = new List<char[]>();

            foreach (DataGridView dgv in dataGrids)
            {
                List<char> checkedLetters = new List<char>();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)(row.Cells["checkBoxes"]);

                    if (Convert.ToBoolean(cell.Value))
                    {
                        checkedLetters.Add((char)(row.Cells["Letter"].Value));
                    }
                }

                checkedLetterLists.Add(checkedLetters.ToArray());
            }

            // Get array of keys
            string[] keys = CaesarAndVigenere.joinPossibleKeys(checkedLetterLists.ToArray());

            // Make DataTable for the final output DataGridView
            resultsTable = new DataTable();
            resultsTable.Columns.Add("Key", typeof(string));
            resultsTable.Columns.Add("Chi-squared score", typeof(double));
            resultsTable.Columns.Add("Decrypted text", typeof(string));



            for (int i = 0; i < keys.Length; i++)
            {
                string key = keys[i];
                DataRow newRow = resultsTable.NewRow();
                string decryptedText = CaesarAndVigenere.vigenereText(parent.ciphertext, key, false);
                //Console.WriteLine(decryptedText.Length);

                newRow[0] = key;
                newRow[1] = CaesarAndVigenere.chiSquaredScore(decryptedText);
                newRow[2] = decryptedText;

                resultsTable.Rows.Add(newRow);

                ((BackgroundWorker)sender).ReportProgress((i * 1000) / keys.Length);
            }

            // Push to the DGV
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finalKeysResultsDGV.DataSource = null;
            finalKeysResultsDGV.DataSource = resultsTable;
            finalKeysResultsDGV.Sort(finalKeysResultsDGV.Columns[1], ListSortDirection.Ascending);
            finalKeysResultsDGV.Columns[2].Width = 200;

            progressBar1.Value = 0;
        }

        private void finalKeysResultsDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != 2)
            //    return;
            string key = finalKeysResultsDGV.Rows[e.RowIndex].Cells["Key"].Value as string;

            parent.runEncrypt(key, false);
            parent.Focus();
        }

        private void findKeyLengthButton_Click(object sender, EventArgs e)
        {
            if (keyLengthFinder == null || keyLengthFinder.IsDisposed)
            {
                keyLengthFinder = new VigenereKeyLength(this);
                keyLengthFinder.Show();
            }
            else
                keyLengthFinder.Select();
        }
        private void VigenereBreakerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (keyLengthFinder != null)
                keyLengthFinder.Dispose();
        }

        List<TabPage> tabPages = new List<TabPage>();
        List<DataGridView> dataGrids = new List<DataGridView>();
        public VigenereForm parent;
        private VigenereKeyLength keyLengthFinder;
        DataTable resultsTable;

        private void breakVigenereButton_Click(object sender, EventArgs e)
        {
            const int numberOfLengths = 16;

            // Scores start at 1
            List<double> scores = new List<double>(
                CaesarAndVigenere.vigenereKeyLengthScores(parent.ciphertext, numberOfLengths));

            scores.RemoveAt(0);

            List<double> scoresInOrder = new List<double>(scores);

            //scores.Sort();
            //scores.Reverse();
            //int roundedUpQuarterLength = (int)Math.Ceiling(scores.Count / 4.0);
            //scores.RemoveRange(roundedUpQuarterLength, scores.Count - roundedUpQuarterLength);
            double maxTwenty = scores.Max() * 0.8;
            Console.WriteLine("Max: " + maxTwenty);
            scores = scores.Where(x => x > maxTwenty).ToList();

            List<int> bestIndicies = scores.Select(x => scoresInOrder.IndexOf(x)).ToList();
            bestIndicies.Sort();

            if (bestIndicies[0] + 1 != 4)
                changeKeyLength(bestIndicies[0] + 1);
            else
            {
                //keyLengthChanged();
                findScores();
                checkTopWithin20();
                solveForKeys();
            }
        }
    }
}
