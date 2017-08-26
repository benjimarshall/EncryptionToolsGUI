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
    public partial class EnigmaForm : Form
    {
        public EnigmaForm()
        {
            InitializeComponent();

            leftRotorNumberCBox.SelectedIndex = 0;
            midRotorNumberCBox.SelectedIndex = 1;
            rightRotorNumberCBox.SelectedIndex = 2;
            reflectorCB.SelectedIndex = 1;

            // Initialise plugBoardDGV
            foreach (char c in CaesarAndVigenere.ALPHABET)
            {
                plugBoardDGV.Rows.Add(c, "");
            }
            plugBoardDGV.Columns[1].ValueType = typeof(string);
        }

        private void checkRotorNumbers()
        {
            if (leftRotorNumberCBox.SelectedIndex == midRotorNumberCBox.SelectedIndex
                || leftRotorNumberCBox.SelectedIndex == rightRotorNumberCBox.SelectedIndex
                || midRotorNumberCBox.SelectedIndex == rightRotorNumberCBox.SelectedIndex)
            {
                rotorReusedLabel.Visible = true;
            }
            else
            {
                rotorReusedLabel.Visible = false;
            }

        }

        private void leftRotorNumberCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkRotorNumbers();
            runEncrypt();
            leftRotorNumberCBox.Focus();
        }

        private void midRotorNumberCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkRotorNumbers();
            runEncrypt();
            leftRotorNumberCBox.Focus();
        }

        private void rightRotorNumberCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkRotorNumbers();
            runEncrypt();
            leftRotorNumberCBox.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void refocusTextBox(TextBox tb)
        {
            tb.Focus();
            tb.Select(tb.TextLength, 0);
        }

        private void leftTextBoxesChanged()
        {
            if (leftPositionTB.Text.Length == 0 || !Char.IsLetter(leftPositionTB.Text[0]))
            {
                if (leftRingTB.Text.Length == 0 || !Char.IsLetter(leftRingTB.Text[0]))
                {
                    leftInvalidSettingLabel.Text = "Invalid rotor and ring positions";
                }
                else
                {
                    leftInvalidSettingLabel.Text = "Invalid rotor position";
                }

                leftInvalidSettingLabel.Visible = true;
            }
            else
            {
                if (leftRingTB.Text.Length == 0 || !Char.IsLetter(leftRingTB.Text[0]))
                {
                    leftInvalidSettingLabel.Text = "Invalid ring position";
                    leftInvalidSettingLabel.Visible = true;
                }
                else
                {
                    leftInvalidSettingLabel.Visible = false;
                }
            }
        }

        private void leftPositionTB_TextChanged(object sender, EventArgs e)
        {
            leftTextBoxesChanged();
            runEncrypt();
            refocusTextBox(leftPositionTB);
        }

        private void leftRingTB_TextChanged(object sender, EventArgs e)
        {
            leftTextBoxesChanged();
            runEncrypt();
            refocusTextBox(leftRingTB);
        }

        private void midTextBoxesChanged()
        {
            if (midPositionTB.Text.Length == 0 || !Char.IsLetter(midPositionTB.Text[0]))
            {
                if (midRingTB.Text.Length == 0 || !Char.IsLetter(midRingTB.Text[0]))
                {
                    midInvalidSettingLabel.Text = "Invalid rotor and ring positions";
                }
                else
                {
                    midInvalidSettingLabel.Text = "Invalid rotor position";
                }

                midInvalidSettingLabel.Visible = true;
            }
            else
            {
                if (midRingTB.Text.Length == 0 || !Char.IsLetter(midRingTB.Text[0]))
                {
                    midInvalidSettingLabel.Text = "Invalid ring position";
                    midInvalidSettingLabel.Visible = true;
                }
                else
                {
                    midInvalidSettingLabel.Visible = false;
                }
            }
        }

        private void midPositionTB_TextChanged(object sender, EventArgs e)
        {
            midTextBoxesChanged();
            runEncrypt();
            refocusTextBox(midPositionTB);
        }

        private void midRingTB_TextChanged(object sender, EventArgs e)
        {
            midTextBoxesChanged();
            runEncrypt();
            refocusTextBox(midRingTB);
        }

        private void rightTextBoxesChanged()
        {
            if (rightPositionTB.Text.Length == 0 || !Char.IsLetter(rightPositionTB.Text[0]))
            {
                if (rightRingTB.Text.Length == 0 || !Char.IsLetter(rightRingTB.Text[0]))
                {
                    rightInvalidSettingLabel.Text = "Invalid rotor and ring positions";
                }
                else
                {
                    rightInvalidSettingLabel.Text = "Invalid rotor position";
                }

                rightInvalidSettingLabel.Visible = true;
            }
            else
            {
                if (rightRingTB.Text.Length == 0 || !Char.IsLetter(rightRingTB.Text[0]))
                {
                    rightInvalidSettingLabel.Text = "Invalid ring position";
                    rightInvalidSettingLabel.Visible = true;
                }
                else
                {
                    rightInvalidSettingLabel.Visible = false;
                }
            }
        }

        private void rightPositionTB_TextChanged(object sender, EventArgs e)
        {
            rightTextBoxesChanged();
            runEncrypt();
            refocusTextBox(rightPositionTB);
        }

        private void rightRingTB_TextChanged(object sender, EventArgs e)
        {
            rightTextBoxesChanged();
            runEncrypt();
            refocusTextBox(rightRingTB);
        }

        private void plugBoardDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void plugBoardDGV_CurrentCellChanged(object sender, EventArgs e)
        {
            // plugBoardDGV.BeginEdit(false);
        }

        private void plugBoardDGV_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            //Keys keyChar = e.KeyCode;
            plugBoardDGV.CommitEdit(DataGridViewDataErrorContexts.Commit);
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)plugBoardDGV.EditingControl;

            if (plugBoardDGV.CurrentCell.ColumnIndex == 1 && tb != null && (plugBoardDGV.CurrentCell.Value == null ||
                ((string)(plugBoardDGV.CurrentCell.Value)).Length == 0) || tb.SelectionLength == 1)
            {
                //if (e.KeyCode < Keys.A || e.KeyCode > Keys.Z)
                if (!Char.IsLetter(e.KeyChar))
                {
                    plugBoardDGV.CurrentCell.Value = "";
                    cellLeaveCleanup();
                }

                else
                {
                    //char newChar = Char.ToUpper((new KeysConverter()).ConvertToString(e.KeyCode)[0]);
                    char newChar = Char.ToUpper(e.KeyChar);

                    if (plugBoardDGV.CurrentCell.RowIndex == (int)newChar - 65)
                    {
                        plugBoardDGV.CurrentCell.Value = "";
                    }
                    else
                    {
                        int newCharIndex = (int)newChar - 65;
                        // Delete all other instances of the row letter
                        string currentRowString = ((char)(plugBoardDGV.CurrentCell.RowIndex + 65)).ToString();
                        foreach (DataGridViewRow row in plugBoardDGV.Rows)
                        {
                            if (currentRowString.Equals((string)(row.Cells[1].Value)))
                            {
                                row.Cells[1].Value = "";
                            }
                        }

                        // Add it into the correct place
                        plugBoardDGV.CurrentCell.Value = newChar.ToString();

                        // Find the inputted letter and give it its pair
                        if (plugBoardDGV.Rows[newCharIndex].Cells[1].Value == null || ((string)(plugBoardDGV.Rows[newCharIndex].Cells[1].Value)).Equals(""))
                        {
                            plugBoardDGV.Rows[newCharIndex].Cells[1].Value = ((char)(plugBoardDGV.CurrentCell.RowIndex + 65)).ToString();
                        }
                        else
                        {
                            plugBoardDGV.Rows[(int)((string)(plugBoardDGV.Rows[newCharIndex].Cells[1].Value))[0] - 65].Cells[1].Value = "";
                            plugBoardDGV.Rows[newCharIndex].Cells[1].Value = ((char)(plugBoardDGV.CurrentCell.RowIndex + 65)).ToString();
                        }
                        // Replacing that inputted pairs old letter if necessary
                    }
                }
            }

            runEncrypt();
            cellLeaveCleanup();
            int rowIndex = plugBoardDGV.CurrentCell.RowIndex;
            plugBoardDGV.CurrentCell = plugBoardDGV.Rows[0].Cells[1];
            plugBoardDGV.CurrentCell = plugBoardDGV.Rows[rowIndex].Cells[1];
        }

        private void plugBoardDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            currentKPEventH = new KeyPressEventHandler(keyPress);
            tb.KeyPress += currentKPEventH;

            //e.Control.KeyPress += new KeyPressEventHandler(plugBoardDGV_KeyPress);
        }

        private void cellLeaveCleanup()
        {
            plugBoardDGV.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow row in plugBoardDGV.Rows)
            {
                if (row.Cells[1].Value == null)
                    continue;
                else if (row.Cells[1].Value.GetType() == typeof(char))
                {
                    row.Cells[1].Value = Char.ToUpper((char)row.Cells[1].Value);
                }
                else if (row.Cells[1].Value.GetType() == typeof(string))
                {
                    string text = (string)(row.Cells[1].Value);

                    if (text.Length != 0)
                    {
                        if ((char)text[0] != row.Index + 65 && (char)text[0] != row.Index + 97)
                        {
                            if (Char.IsLetter(text[0]))
                                row.Cells[1].Value = Char.ToUpper(text[0]).ToString();
                            else
                                row.Cells[1].Value = "";
                        }
                        else
                            row.Cells[1].Value = "";
                    }

                }
                else
                    Console.WriteLine("Well Whoops: " + row.Cells[1].Value.GetType());
            }

            List<char> listOfValues = new List<char>();
            foreach (DataGridViewRow dr in plugBoardDGV.Rows)
            {
                if (dr.Cells[1].Value == null || ((string)(dr.Cells[1].Value)).Length == 0)
                    continue;
                listOfValues.Add((char)((string)(dr.Cells[1].Value))[0]);
            }

            foreach (DataGridViewRow row in plugBoardDGV.Rows)
            {
                if (row.Cells[1].Value == null)
                    continue;

                string text = (string)(row.Cells[1].Value);
                if (text.Length == 0)
                    continue;

                object pluggedValue = plugBoardDGV.Rows[(int)((char)(text[0])) - 65].Cells[1].Value;
                if (pluggedValue == null || ((string)pluggedValue).Length == 0 || !listOfValues.Contains((char)((string)(pluggedValue))[0]))
                    row.Cells[1].Value = "";
            }

            runEncrypt();
        }

        private void plugBoardDGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)plugBoardDGV.EditingControl;
            if (currentKPEventH != null && tb != null)
                tb.KeyPress -= currentKPEventH;

            cellLeaveCleanup();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            runEncrypt();
            inputTextBox.Focus();   
            inputTextBox.Select(inputTextBox.TextLength, 0);
        }

        private Enigma makeEnigma()
        { 
            int[] rotors = new int[] { leftRotorNumberCBox.SelectedIndex + 1,
            midRotorNumberCBox.SelectedIndex + 1, rightRotorNumberCBox.SelectedIndex + 1};
            int reflector = reflectorCB.SelectedIndex + 1;
            string rotorPositions = (leftPositionTB.Text + midPositionTB.Text + rightPositionTB.Text).ToUpper();
            string rotorRings = (leftRingTB.Text + midRingTB.Text + rightRingTB.Text).ToUpper();

            if (reflector == 0 || rotors.Contains(0) || rotorPositions.Length != 3 ||
                rotorRings.Length != 3 || rotorReusedLabel.Visible || leftInvalidSettingLabel.Visible ||
                midInvalidSettingLabel.Visible || rightInvalidSettingLabel.Visible)
            {
                return null;
            }

            Console.WriteLine(leftRingTB.Text);

            List<char[]> plugboardList = new List<char[]>();
            List<char> registeredLetters = new List<char>();
            int count = 0;

            foreach (DataGridViewRow row in plugBoardDGV.Rows)
            {
                object cellValue = row.Cells[1].Value;
                if (cellValue != null && ((string)cellValue).Length != 0)
                {
                    count++;
                    char letter1 = ((string)cellValue)[0];
                    if (!registeredLetters.Contains(letter1))
                    {
                        char letter2 = (char)(row.Index + 65);
                        plugboardList.Add(new char[] { letter1, letter2 });
                        registeredLetters.Add(letter1);
                        registeredLetters.Add(letter2);
                    }
                }
            }

            if (count % 2 == 0)
                return new Enigma(rotors, reflector, rotorPositions, plugboardList.ToArray(), rotorRings);
            else
                return null;
        }

        private void runEncrypt()
        {
            Enigma enigma = makeEnigma();

            if (enigma != null)
            {
                inputTextBox.Text = CaesarAndVigenere.stripText(inputTextBox.Text).ToUpper();
                outputTextBox.Text = enigma.encrypt(inputTextBox.Text);
            }
            else
                outputTextBox.Text = "";
        }

        private void plugBoardDGV_KeyDown(object sender, KeyEventArgs e)
        {
            /*Console.WriteLine("Key Down");
            keyPress(sender, e);*/
        }

        private void plugBoardDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        KeyPressEventHandler currentKPEventH;

        private void clearTextButton_Click(object sender, EventArgs e)
        {
            oldInputLetterBox.Text = "";
            outputtedLettersBox.Text = "";
            letterInputBox.Text = "";
        }

        private void clearSettingsButton_Click(object sender, EventArgs e)
        {
            leftRotorNumberCBox.SelectedIndex = 0;
            midRotorNumberCBox.SelectedIndex = 1;
            rightRotorNumberCBox.SelectedIndex = 2;
            reflectorCB.SelectedIndex = 1;

            leftPositionTB.Text = "A";
            leftRingTB.Text = "A";
            midPositionTB.Text = "A";
            midRingTB.Text = "A";
            rightPositionTB.Text = "A";
            rightRingTB.Text = "A";

            lockCheckBox.Checked = false;

            foreach (DataGridViewRow row in plugBoardDGV.Rows)
            {
                row.Cells[1].Value = "";
            }
        }

        private void letterInputBox_TextChanged(object sender, EventArgs e)
        {
            if (letterInputBox.Text == null)
                letterInputBox.Text = "";
            if (letterInputBox.Text.Length != 0)
            {
                if (Char.IsLetter(letterInputBox.Text[0]))
                {
                    string input = letterInputBox.Text.ToUpper();
                    oldInputLetterBox.Text += input;

                    if (lockCheckBox.Checked)
                    {
                        Enigma enigma = makeEnigma();
                        if (enigma != null)
                            outputtedLettersBox.Text += enigma.encrypt(input);
                    }
                    else
                    {
                        Enigma enigma = makeEnigma();
                        if (enigma != null)
                        {
                            outputtedLettersBox.Text += enigma.encrypt(input);
                            int[] newRotorPositions = enigma.stepRotors();
                            string[] newRotorStrings = newRotorPositions.Select(x => (char)(x + 65)).Select(Char.ToString).ToArray();

                            leftPositionTB.Text = newRotorStrings[0];
                            midPositionTB.Text = newRotorStrings[1];
                            rightPositionTB.Text = newRotorStrings[2];
                        }
                    }
                }

                letterInputBox.Text = "";
            }

            letterInputBox.Focus();
        }

        public void launchEncrypt(DataGridViewRow row, string text)
        {
            /*finalResultsDT.Columns.Add("Score", typeof(double));
            finalResultsDT.Columns.Add("Positions", typeof(string));
            finalResultsDT.Columns.Add("Rotors", typeof(string));
            finalResultsDT.Columns.Add("Rings", typeof(string));
            finalResultsDT.Columns.Add("Plugboard", typeof(string));*/
            tabControl1.SelectTab(1);
            inputTextBox.Text = "";

            // Positions
            leftPositionTB.Text = ((string)row.Cells[1].Value)[0].ToString();
            midPositionTB.Text = ((string)row.Cells[1].Value)[1].ToString();
            rightPositionTB.Text = ((string)row.Cells[1].Value)[2].ToString();

            // Rings
            leftRingTB.Text = ((string)row.Cells[3].Value)[0].ToString();
            midRingTB.Text = ((string)row.Cells[3].Value)[1].ToString();
            rightRingTB.Text = ((string)row.Cells[3].Value)[2].ToString();

            // Rotors
            leftRotorNumberCBox.SelectedIndex = (int)((string)row.Cells[2].Value)[0] - 49;
            midRotorNumberCBox.SelectedIndex = (int)((string)row.Cells[2].Value)[1] - 49;
            rightRotorNumberCBox.SelectedIndex = (int)((string)row.Cells[2].Value)[2] - 49;

            // Plugboard
            string plugs = CaesarAndVigenere.stripText((string)row.Cells[4].Value);

            for (int i = 0; i < plugs.Length / 2; i++)
            {
                plugBoardDGV.Rows[(int)plugs[2 * i] - 65].Cells[1].Value = plugs[2 * i + 1].ToString();
                plugBoardDGV.Rows[(int)plugs[2 * i + 1] - 65].Cells[1].Value = plugs[2 * i].ToString();
            }

            // Reflector
            reflectorCB.SelectedIndex = 1;

            inputTextBox.Text = text;
            runEncrypt();
            this.Focus();
        }

        private void enigmaBreakerButton_Click(object sender, EventArgs e)
        {
            if (enigmaBreaker == null || enigmaBreaker.IsDisposed)
            {
                enigmaBreaker = new EnigmaBreakerForm(this);
                enigmaBreaker.Show();
            }
            else
                enigmaBreaker.Select();
        }

        EnigmaBreakerForm enigmaBreaker;
    }
}
