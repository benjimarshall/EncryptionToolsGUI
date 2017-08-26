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
using System.Windows.Forms.DataVisualization.Charting;

namespace EncryptionToolsGUI
{
    public partial class VigenereKeyLength : FormWithText
    {
        public VigenereKeyLength(VigenereBreakerForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.grandparent = parent.parent;
            makeGraph();
        }

        private void enterTextButton_Click(object sender, EventArgs e)
        {
            if (grandparent.inputForm == null || grandparent.inputForm.IsDisposed)
            {
                grandparent.inputForm = new TextInputForm(grandparent, grandparent.ciphertext);
                grandparent.inputForm.Show();
            }
            else
                grandparent.inputForm.Select();

            makeGraph();
        }

        private void VigenereKeyLength_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void findScoresButton_Click(object sender, EventArgs e)
        {
            makeGraph();
        }

        private void makeGraph()
        {
            if (!invalidNumberLabel.Visible)
            {
                int numberOfLengths = Int32.Parse(numberOfLengthsTextBox.Text);

                DataTable dt = new DataTable();
                dt.Columns.Add("Key Length", typeof(int));
                dt.Columns.Add("IC Score", typeof(double));

                double[] scores = CaesarAndVigenere.vigenereKeyLengthScores(grandparent.ciphertext, numberOfLengths);

                for (int length = 1; length <= numberOfLengths; length++)
                {
                    DataRow newRow = dt.NewRow();

                    newRow[0] = length;
                    newRow[1] = scores[length];

                    dt.Rows.Add(newRow);
                }

                keyLengthScoresDGV.DataSource = null;
                keyLengthScoresDGV.DataSource = dt;
                //keyLengthScoresDGV.Sort(keyLengthScoresDGV.Columns[1], ListSortDirection.Ascending);
                keyLengthScoresDGV.Columns[0].Width = 85;

                //chart1.ChartAreas[0].AxisX.Minimum = 1;
                chart1.Series["Letter Scores"].Points.DataBindY(scores.Skip(1).ToArray());

                // Crop y axis scale
                double smallest = scores.Skip(1).Min();
                Console.WriteLine(smallest);
                chart1.ChartAreas[0].AxisY.Minimum = Math.Round(0.8 * smallest, 2);
            }
        }

        private void numberOfLengthsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (numberOfLengthsTextBox.Text.Length == 0)
                invalidNumberLabel.Visible = true;
            else if (Regex.IsMatch(numberOfLengthsTextBox.Text, @"^[1-9][0-9]*$"))
                invalidNumberLabel.Visible = false;
            else
                invalidNumberLabel.Visible = true;
            makeGraph();
        }

        private void keyLengthScoresDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            parent.changeKeyLength(e.RowIndex + 1);
            parent.Focus();
        }

        private VigenereForm grandparent;
        private VigenereBreakerForm parent;

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint point = chart1.Series[0].Points[result.PointIndex];

                parent.changeKeyLength(chart1.Series["Letter Scores"].Points.IndexOf(point) + 1);
                parent.Focus();
            }
        }
    }
}
