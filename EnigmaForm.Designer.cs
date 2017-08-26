namespace EncryptionToolsGUI
{
    partial class EnigmaForm
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
            this.leftRotorGroupBox = new System.Windows.Forms.GroupBox();
            this.leftInvalidSettingLabel = new System.Windows.Forms.Label();
            this.leftRingTB = new System.Windows.Forms.TextBox();
            this.leftPositionTB = new System.Windows.Forms.TextBox();
            this.leftRotorNumberCBox = new System.Windows.Forms.ComboBox();
            this.leftRingLabel = new System.Windows.Forms.Label();
            this.leftPositionLabel = new System.Windows.Forms.Label();
            this.leftRotorNumLabel = new System.Windows.Forms.Label();
            this.midRotorGroupBox = new System.Windows.Forms.GroupBox();
            this.midInvalidSettingLabel = new System.Windows.Forms.Label();
            this.midRingTB = new System.Windows.Forms.TextBox();
            this.midPositionTB = new System.Windows.Forms.TextBox();
            this.midRotorNumberCBox = new System.Windows.Forms.ComboBox();
            this.midRingLabel = new System.Windows.Forms.Label();
            this.midPositionLabel = new System.Windows.Forms.Label();
            this.midRotorNumLabel = new System.Windows.Forms.Label();
            this.rightRotorGroupBox = new System.Windows.Forms.GroupBox();
            this.rightInvalidSettingLabel = new System.Windows.Forms.Label();
            this.rightRingTB = new System.Windows.Forms.TextBox();
            this.rightPositionTB = new System.Windows.Forms.TextBox();
            this.rightRotorNumberCBox = new System.Windows.Forms.ComboBox();
            this.rightRingLabel = new System.Windows.Forms.Label();
            this.rightPositionLabel = new System.Windows.Forms.Label();
            this.rightRotorNumLabel = new System.Windows.Forms.Label();
            this.rotorReusedLabel = new System.Windows.Forms.Label();
            this.plugBoardLabel = new System.Windows.Forms.Label();
            this.plugBoardDGV = new System.Windows.Forms.DataGridView();
            this.keyLetterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pluggedLetterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.letterTab = new System.Windows.Forms.TabPage();
            this.clearTextButton = new System.Windows.Forms.Button();
            this.lockCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.letterInputBox = new System.Windows.Forms.TextBox();
            this.encryptedLettersLabel = new System.Windows.Forms.Label();
            this.enteredLettersLabel = new System.Windows.Forms.Label();
            this.outputtedLettersBox = new System.Windows.Forms.TextBox();
            this.oldInputLetterBox = new System.Windows.Forms.TextBox();
            this.textTab = new System.Windows.Forms.TabPage();
            this.outputTextLabel = new System.Windows.Forms.Label();
            this.inputTextLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.reflectorCB = new System.Windows.Forms.ComboBox();
            this.clearSettingsButton = new System.Windows.Forms.Button();
            this.enigmaBreakerButton = new System.Windows.Forms.Button();
            this.leftRotorGroupBox.SuspendLayout();
            this.midRotorGroupBox.SuspendLayout();
            this.rightRotorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plugBoardDGV)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.letterTab.SuspendLayout();
            this.textTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftRotorGroupBox
            // 
            this.leftRotorGroupBox.Controls.Add(this.leftInvalidSettingLabel);
            this.leftRotorGroupBox.Controls.Add(this.leftRingTB);
            this.leftRotorGroupBox.Controls.Add(this.leftPositionTB);
            this.leftRotorGroupBox.Controls.Add(this.leftRotorNumberCBox);
            this.leftRotorGroupBox.Controls.Add(this.leftRingLabel);
            this.leftRotorGroupBox.Controls.Add(this.leftPositionLabel);
            this.leftRotorGroupBox.Controls.Add(this.leftRotorNumLabel);
            this.leftRotorGroupBox.Location = new System.Drawing.Point(12, 12);
            this.leftRotorGroupBox.Name = "leftRotorGroupBox";
            this.leftRotorGroupBox.Size = new System.Drawing.Size(163, 114);
            this.leftRotorGroupBox.TabIndex = 0;
            this.leftRotorGroupBox.TabStop = false;
            this.leftRotorGroupBox.Text = "Left Rotor";
            // 
            // leftInvalidSettingLabel
            // 
            this.leftInvalidSettingLabel.AutoSize = true;
            this.leftInvalidSettingLabel.ForeColor = System.Drawing.Color.Red;
            this.leftInvalidSettingLabel.Location = new System.Drawing.Point(7, 93);
            this.leftInvalidSettingLabel.Name = "leftInvalidSettingLabel";
            this.leftInvalidSettingLabel.Size = new System.Drawing.Size(147, 13);
            this.leftInvalidSettingLabel.TabIndex = 9;
            this.leftInvalidSettingLabel.Text = "Invalid rotor and ring positions";
            this.leftInvalidSettingLabel.Visible = false;
            // 
            // leftRingTB
            // 
            this.leftRingTB.Location = new System.Drawing.Point(86, 70);
            this.leftRingTB.MaxLength = 1;
            this.leftRingTB.Name = "leftRingTB";
            this.leftRingTB.Size = new System.Drawing.Size(21, 20);
            this.leftRingTB.TabIndex = 2;
            this.leftRingTB.Text = "A";
            this.leftRingTB.TextChanged += new System.EventHandler(this.leftRingTB_TextChanged);
            // 
            // leftPositionTB
            // 
            this.leftPositionTB.Location = new System.Drawing.Point(86, 44);
            this.leftPositionTB.MaxLength = 1;
            this.leftPositionTB.Name = "leftPositionTB";
            this.leftPositionTB.Size = new System.Drawing.Size(21, 20);
            this.leftPositionTB.TabIndex = 1;
            this.leftPositionTB.Text = "A";
            this.leftPositionTB.TextChanged += new System.EventHandler(this.leftPositionTB_TextChanged);
            // 
            // leftRotorNumberCBox
            // 
            this.leftRotorNumberCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftRotorNumberCBox.FormattingEnabled = true;
            this.leftRotorNumberCBox.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V"});
            this.leftRotorNumberCBox.Location = new System.Drawing.Point(86, 17);
            this.leftRotorNumberCBox.Name = "leftRotorNumberCBox";
            this.leftRotorNumberCBox.Size = new System.Drawing.Size(63, 21);
            this.leftRotorNumberCBox.TabIndex = 0;
            this.leftRotorNumberCBox.SelectedIndexChanged += new System.EventHandler(this.leftRotorNumberCBox_SelectedIndexChanged);
            // 
            // leftRingLabel
            // 
            this.leftRingLabel.AutoSize = true;
            this.leftRingLabel.Location = new System.Drawing.Point(6, 73);
            this.leftRingLabel.Name = "leftRingLabel";
            this.leftRingLabel.Size = new System.Drawing.Size(69, 13);
            this.leftRingLabel.TabIndex = 2;
            this.leftRingLabel.Text = "Ring Position";
            // 
            // leftPositionLabel
            // 
            this.leftPositionLabel.AutoSize = true;
            this.leftPositionLabel.Location = new System.Drawing.Point(7, 47);
            this.leftPositionLabel.Name = "leftPositionLabel";
            this.leftPositionLabel.Size = new System.Drawing.Size(73, 13);
            this.leftPositionLabel.TabIndex = 1;
            this.leftPositionLabel.Text = "Rotor Position";
            // 
            // leftRotorNumLabel
            // 
            this.leftRotorNumLabel.AutoSize = true;
            this.leftRotorNumLabel.Location = new System.Drawing.Point(7, 21);
            this.leftRotorNumLabel.Name = "leftRotorNumLabel";
            this.leftRotorNumLabel.Size = new System.Drawing.Size(73, 13);
            this.leftRotorNumLabel.TabIndex = 0;
            this.leftRotorNumLabel.Text = "Rotor Number";
            // 
            // midRotorGroupBox
            // 
            this.midRotorGroupBox.Controls.Add(this.midInvalidSettingLabel);
            this.midRotorGroupBox.Controls.Add(this.midRingTB);
            this.midRotorGroupBox.Controls.Add(this.midPositionTB);
            this.midRotorGroupBox.Controls.Add(this.midRotorNumberCBox);
            this.midRotorGroupBox.Controls.Add(this.midRingLabel);
            this.midRotorGroupBox.Controls.Add(this.midPositionLabel);
            this.midRotorGroupBox.Controls.Add(this.midRotorNumLabel);
            this.midRotorGroupBox.Location = new System.Drawing.Point(181, 12);
            this.midRotorGroupBox.Name = "midRotorGroupBox";
            this.midRotorGroupBox.Size = new System.Drawing.Size(163, 114);
            this.midRotorGroupBox.TabIndex = 5;
            this.midRotorGroupBox.TabStop = false;
            this.midRotorGroupBox.Text = "Middle Rotor";
            // 
            // midInvalidSettingLabel
            // 
            this.midInvalidSettingLabel.AutoSize = true;
            this.midInvalidSettingLabel.ForeColor = System.Drawing.Color.Red;
            this.midInvalidSettingLabel.Location = new System.Drawing.Point(7, 93);
            this.midInvalidSettingLabel.Name = "midInvalidSettingLabel";
            this.midInvalidSettingLabel.Size = new System.Drawing.Size(147, 13);
            this.midInvalidSettingLabel.TabIndex = 10;
            this.midInvalidSettingLabel.Text = "Invalid rotor and ring positions";
            this.midInvalidSettingLabel.Visible = false;
            // 
            // midRingTB
            // 
            this.midRingTB.Location = new System.Drawing.Point(86, 70);
            this.midRingTB.MaxLength = 1;
            this.midRingTB.Name = "midRingTB";
            this.midRingTB.Size = new System.Drawing.Size(21, 20);
            this.midRingTB.TabIndex = 5;
            this.midRingTB.Text = "A";
            this.midRingTB.TextChanged += new System.EventHandler(this.midRingTB_TextChanged);
            // 
            // midPositionTB
            // 
            this.midPositionTB.Location = new System.Drawing.Point(86, 44);
            this.midPositionTB.MaxLength = 1;
            this.midPositionTB.Name = "midPositionTB";
            this.midPositionTB.Size = new System.Drawing.Size(21, 20);
            this.midPositionTB.TabIndex = 4;
            this.midPositionTB.Text = "A";
            this.midPositionTB.TextChanged += new System.EventHandler(this.midPositionTB_TextChanged);
            // 
            // midRotorNumberCBox
            // 
            this.midRotorNumberCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midRotorNumberCBox.FormattingEnabled = true;
            this.midRotorNumberCBox.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V"});
            this.midRotorNumberCBox.Location = new System.Drawing.Point(86, 17);
            this.midRotorNumberCBox.Name = "midRotorNumberCBox";
            this.midRotorNumberCBox.Size = new System.Drawing.Size(63, 21);
            this.midRotorNumberCBox.TabIndex = 3;
            this.midRotorNumberCBox.SelectedIndexChanged += new System.EventHandler(this.midRotorNumberCBox_SelectedIndexChanged);
            // 
            // midRingLabel
            // 
            this.midRingLabel.AutoSize = true;
            this.midRingLabel.Location = new System.Drawing.Point(6, 73);
            this.midRingLabel.Name = "midRingLabel";
            this.midRingLabel.Size = new System.Drawing.Size(69, 13);
            this.midRingLabel.TabIndex = 2;
            this.midRingLabel.Text = "Ring Position";
            // 
            // midPositionLabel
            // 
            this.midPositionLabel.AutoSize = true;
            this.midPositionLabel.Location = new System.Drawing.Point(7, 47);
            this.midPositionLabel.Name = "midPositionLabel";
            this.midPositionLabel.Size = new System.Drawing.Size(73, 13);
            this.midPositionLabel.TabIndex = 1;
            this.midPositionLabel.Text = "Rotor Position";
            // 
            // midRotorNumLabel
            // 
            this.midRotorNumLabel.AutoSize = true;
            this.midRotorNumLabel.Location = new System.Drawing.Point(7, 21);
            this.midRotorNumLabel.Name = "midRotorNumLabel";
            this.midRotorNumLabel.Size = new System.Drawing.Size(73, 13);
            this.midRotorNumLabel.TabIndex = 0;
            this.midRotorNumLabel.Text = "Rotor Number";
            // 
            // rightRotorGroupBox
            // 
            this.rightRotorGroupBox.Controls.Add(this.rightInvalidSettingLabel);
            this.rightRotorGroupBox.Controls.Add(this.rightRingTB);
            this.rightRotorGroupBox.Controls.Add(this.rightPositionTB);
            this.rightRotorGroupBox.Controls.Add(this.rightRotorNumberCBox);
            this.rightRotorGroupBox.Controls.Add(this.rightRingLabel);
            this.rightRotorGroupBox.Controls.Add(this.rightPositionLabel);
            this.rightRotorGroupBox.Controls.Add(this.rightRotorNumLabel);
            this.rightRotorGroupBox.Location = new System.Drawing.Point(350, 12);
            this.rightRotorGroupBox.Name = "rightRotorGroupBox";
            this.rightRotorGroupBox.Size = new System.Drawing.Size(163, 114);
            this.rightRotorGroupBox.TabIndex = 6;
            this.rightRotorGroupBox.TabStop = false;
            this.rightRotorGroupBox.Text = "Right Rotor";
            // 
            // rightInvalidSettingLabel
            // 
            this.rightInvalidSettingLabel.AutoSize = true;
            this.rightInvalidSettingLabel.ForeColor = System.Drawing.Color.Red;
            this.rightInvalidSettingLabel.Location = new System.Drawing.Point(7, 93);
            this.rightInvalidSettingLabel.Name = "rightInvalidSettingLabel";
            this.rightInvalidSettingLabel.Size = new System.Drawing.Size(147, 13);
            this.rightInvalidSettingLabel.TabIndex = 10;
            this.rightInvalidSettingLabel.Text = "Invalid rotor and ring positions";
            this.rightInvalidSettingLabel.Visible = false;
            this.rightInvalidSettingLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // rightRingTB
            // 
            this.rightRingTB.Location = new System.Drawing.Point(86, 70);
            this.rightRingTB.MaxLength = 1;
            this.rightRingTB.Name = "rightRingTB";
            this.rightRingTB.Size = new System.Drawing.Size(21, 20);
            this.rightRingTB.TabIndex = 8;
            this.rightRingTB.Text = "A";
            this.rightRingTB.TextChanged += new System.EventHandler(this.rightRingTB_TextChanged);
            // 
            // rightPositionTB
            // 
            this.rightPositionTB.Location = new System.Drawing.Point(86, 44);
            this.rightPositionTB.MaxLength = 1;
            this.rightPositionTB.Name = "rightPositionTB";
            this.rightPositionTB.Size = new System.Drawing.Size(21, 20);
            this.rightPositionTB.TabIndex = 7;
            this.rightPositionTB.Text = "A";
            this.rightPositionTB.TextChanged += new System.EventHandler(this.rightPositionTB_TextChanged);
            // 
            // rightRotorNumberCBox
            // 
            this.rightRotorNumberCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rightRotorNumberCBox.FormattingEnabled = true;
            this.rightRotorNumberCBox.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V"});
            this.rightRotorNumberCBox.Location = new System.Drawing.Point(86, 17);
            this.rightRotorNumberCBox.Name = "rightRotorNumberCBox";
            this.rightRotorNumberCBox.Size = new System.Drawing.Size(63, 21);
            this.rightRotorNumberCBox.TabIndex = 6;
            this.rightRotorNumberCBox.SelectedIndexChanged += new System.EventHandler(this.rightRotorNumberCBox_SelectedIndexChanged);
            // 
            // rightRingLabel
            // 
            this.rightRingLabel.AutoSize = true;
            this.rightRingLabel.Location = new System.Drawing.Point(6, 73);
            this.rightRingLabel.Name = "rightRingLabel";
            this.rightRingLabel.Size = new System.Drawing.Size(69, 13);
            this.rightRingLabel.TabIndex = 2;
            this.rightRingLabel.Text = "Ring Position";
            // 
            // rightPositionLabel
            // 
            this.rightPositionLabel.AutoSize = true;
            this.rightPositionLabel.Location = new System.Drawing.Point(7, 47);
            this.rightPositionLabel.Name = "rightPositionLabel";
            this.rightPositionLabel.Size = new System.Drawing.Size(73, 13);
            this.rightPositionLabel.TabIndex = 1;
            this.rightPositionLabel.Text = "Rotor Position";
            // 
            // rightRotorNumLabel
            // 
            this.rightRotorNumLabel.AutoSize = true;
            this.rightRotorNumLabel.Location = new System.Drawing.Point(7, 21);
            this.rightRotorNumLabel.Name = "rightRotorNumLabel";
            this.rightRotorNumLabel.Size = new System.Drawing.Size(73, 13);
            this.rightRotorNumLabel.TabIndex = 0;
            this.rightRotorNumLabel.Text = "Rotor Number";
            // 
            // rotorReusedLabel
            // 
            this.rotorReusedLabel.AutoSize = true;
            this.rotorReusedLabel.ForeColor = System.Drawing.Color.Red;
            this.rotorReusedLabel.Location = new System.Drawing.Point(171, 129);
            this.rotorReusedLabel.Name = "rotorReusedLabel";
            this.rotorReusedLabel.Size = new System.Drawing.Size(183, 13);
            this.rotorReusedLabel.TabIndex = 7;
            this.rotorReusedLabel.Text = "The same rotor cannot be used twice";
            this.rotorReusedLabel.Visible = false;
            // 
            // plugBoardLabel
            // 
            this.plugBoardLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plugBoardLabel.AutoSize = true;
            this.plugBoardLabel.Location = new System.Drawing.Point(519, 9);
            this.plugBoardLabel.Name = "plugBoardLabel";
            this.plugBoardLabel.Size = new System.Drawing.Size(55, 13);
            this.plugBoardLabel.TabIndex = 8;
            this.plugBoardLabel.Text = "Plugboard";
            // 
            // plugBoardDGV
            // 
            this.plugBoardDGV.AllowUserToAddRows = false;
            this.plugBoardDGV.AllowUserToDeleteRows = false;
            this.plugBoardDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugBoardDGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.plugBoardDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.plugBoardDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyLetterColumn,
            this.pluggedLetterColumn});
            this.plugBoardDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.plugBoardDGV.Location = new System.Drawing.Point(520, 26);
            this.plugBoardDGV.Name = "plugBoardDGV";
            this.plugBoardDGV.RowHeadersVisible = false;
            this.plugBoardDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.plugBoardDGV.Size = new System.Drawing.Size(172, 375);
            this.plugBoardDGV.TabIndex = 9;
            this.plugBoardDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.plugBoardDGV_CellContentClick);
            this.plugBoardDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.plugBoardDGV_CellEndEdit);
            this.plugBoardDGV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.plugBoardDGV_CellLeave);
            this.plugBoardDGV.CurrentCellChanged += new System.EventHandler(this.plugBoardDGV_CurrentCellChanged);
            this.plugBoardDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.plugBoardDGV_EditingControlShowing);
            this.plugBoardDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.plugBoardDGV_KeyDown);
            this.plugBoardDGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.plugBoardDGV_KeyPress);
            // 
            // keyLetterColumn
            // 
            this.keyLetterColumn.HeaderText = "Letter";
            this.keyLetterColumn.MaxInputLength = 1;
            this.keyLetterColumn.Name = "keyLetterColumn";
            this.keyLetterColumn.ReadOnly = true;
            this.keyLetterColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.keyLetterColumn.Width = 50;
            // 
            // pluggedLetterColumn
            // 
            this.pluggedLetterColumn.HeaderText = "Plugged Letter";
            this.pluggedLetterColumn.MaxInputLength = 1;
            this.pluggedLetterColumn.Name = "pluggedLetterColumn";
            this.pluggedLetterColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.letterTab);
            this.tabControl1.Controls.Add(this.textTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 170);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 231);
            this.tabControl1.TabIndex = 10;
            // 
            // letterTab
            // 
            this.letterTab.Controls.Add(this.clearTextButton);
            this.letterTab.Controls.Add(this.lockCheckBox);
            this.letterTab.Controls.Add(this.label1);
            this.letterTab.Controls.Add(this.letterInputBox);
            this.letterTab.Controls.Add(this.encryptedLettersLabel);
            this.letterTab.Controls.Add(this.enteredLettersLabel);
            this.letterTab.Controls.Add(this.outputtedLettersBox);
            this.letterTab.Controls.Add(this.oldInputLetterBox);
            this.letterTab.Location = new System.Drawing.Point(4, 22);
            this.letterTab.Name = "letterTab";
            this.letterTab.Padding = new System.Windows.Forms.Padding(3);
            this.letterTab.Size = new System.Drawing.Size(493, 205);
            this.letterTab.TabIndex = 0;
            this.letterTab.Text = "Encrypt letter by letter";
            this.letterTab.UseVisualStyleBackColor = true;
            // 
            // clearTextButton
            // 
            this.clearTextButton.Location = new System.Drawing.Point(407, 32);
            this.clearTextButton.Name = "clearTextButton";
            this.clearTextButton.Size = new System.Drawing.Size(75, 23);
            this.clearTextButton.TabIndex = 7;
            this.clearTextButton.Text = "Clear text";
            this.clearTextButton.UseVisualStyleBackColor = true;
            this.clearTextButton.Click += new System.EventHandler(this.clearTextButton_Click);
            // 
            // lockCheckBox
            // 
            this.lockCheckBox.AutoSize = true;
            this.lockCheckBox.Location = new System.Drawing.Point(368, 9);
            this.lockCheckBox.Name = "lockCheckBox";
            this.lockCheckBox.Size = new System.Drawing.Size(119, 17);
            this.lockCheckBox.TabIndex = 6;
            this.lockCheckBox.Text = "Lock Rotor Position";
            this.lockCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter letter here:";
            // 
            // letterInputBox
            // 
            this.letterInputBox.Location = new System.Drawing.Point(235, 6);
            this.letterInputBox.MaxLength = 1;
            this.letterInputBox.Name = "letterInputBox";
            this.letterInputBox.Size = new System.Drawing.Size(21, 20);
            this.letterInputBox.TabIndex = 4;
            this.letterInputBox.TextChanged += new System.EventHandler(this.letterInputBox_TextChanged);
            // 
            // encryptedLettersLabel
            // 
            this.encryptedLettersLabel.AutoSize = true;
            this.encryptedLettersLabel.Location = new System.Drawing.Point(246, 49);
            this.encryptedLettersLabel.Name = "encryptedLettersLabel";
            this.encryptedLettersLabel.Size = new System.Drawing.Size(86, 13);
            this.encryptedLettersLabel.TabIndex = 3;
            this.encryptedLettersLabel.Text = "Encrypted letters";
            // 
            // enteredLettersLabel
            // 
            this.enteredLettersLabel.AutoSize = true;
            this.enteredLettersLabel.Location = new System.Drawing.Point(3, 49);
            this.enteredLettersLabel.Name = "enteredLettersLabel";
            this.enteredLettersLabel.Size = new System.Drawing.Size(75, 13);
            this.enteredLettersLabel.TabIndex = 2;
            this.enteredLettersLabel.Text = "Entered letters";
            // 
            // outputtedLettersBox
            // 
            this.outputtedLettersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.outputtedLettersBox.Location = new System.Drawing.Point(249, 65);
            this.outputtedLettersBox.Multiline = true;
            this.outputtedLettersBox.Name = "outputtedLettersBox";
            this.outputtedLettersBox.ReadOnly = true;
            this.outputtedLettersBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputtedLettersBox.Size = new System.Drawing.Size(235, 134);
            this.outputtedLettersBox.TabIndex = 1;
            // 
            // oldInputLetterBox
            // 
            this.oldInputLetterBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.oldInputLetterBox.Location = new System.Drawing.Point(6, 65);
            this.oldInputLetterBox.Multiline = true;
            this.oldInputLetterBox.Name = "oldInputLetterBox";
            this.oldInputLetterBox.ReadOnly = true;
            this.oldInputLetterBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.oldInputLetterBox.Size = new System.Drawing.Size(235, 134);
            this.oldInputLetterBox.TabIndex = 0;
            // 
            // textTab
            // 
            this.textTab.Controls.Add(this.outputTextLabel);
            this.textTab.Controls.Add(this.inputTextLabel);
            this.textTab.Controls.Add(this.outputTextBox);
            this.textTab.Controls.Add(this.inputTextBox);
            this.textTab.Location = new System.Drawing.Point(4, 22);
            this.textTab.Name = "textTab";
            this.textTab.Padding = new System.Windows.Forms.Padding(3);
            this.textTab.Size = new System.Drawing.Size(493, 205);
            this.textTab.TabIndex = 1;
            this.textTab.Text = "Encrypt blocks of text";
            this.textTab.UseVisualStyleBackColor = true;
            // 
            // outputTextLabel
            // 
            this.outputTextLabel.AutoSize = true;
            this.outputTextLabel.Location = new System.Drawing.Point(249, 4);
            this.outputTextLabel.Name = "outputTextLabel";
            this.outputTextLabel.Size = new System.Drawing.Size(59, 13);
            this.outputTextLabel.TabIndex = 4;
            this.outputTextLabel.Text = "Output text";
            // 
            // inputTextLabel
            // 
            this.inputTextLabel.AutoSize = true;
            this.inputTextLabel.Location = new System.Drawing.Point(7, 4);
            this.inputTextLabel.Name = "inputTextLabel";
            this.inputTextLabel.Size = new System.Drawing.Size(55, 13);
            this.inputTextLabel.TabIndex = 3;
            this.inputTextLabel.Text = "Input Text";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.outputTextBox.Location = new System.Drawing.Point(250, 23);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(235, 179);
            this.outputTextBox.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.inputTextBox.Location = new System.Drawing.Point(6, 23);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(235, 179);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // reflectorCB
            // 
            this.reflectorCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reflectorCB.FormattingEnabled = true;
            this.reflectorCB.Items.AddRange(new object[] {
            "Reflector A",
            "Reflector B",
            "Reflector C"});
            this.reflectorCB.Location = new System.Drawing.Point(425, 132);
            this.reflectorCB.Name = "reflectorCB";
            this.reflectorCB.Size = new System.Drawing.Size(88, 21);
            this.reflectorCB.TabIndex = 12;
            // 
            // clearSettingsButton
            // 
            this.clearSettingsButton.Location = new System.Drawing.Point(425, 159);
            this.clearSettingsButton.Name = "clearSettingsButton";
            this.clearSettingsButton.Size = new System.Drawing.Size(88, 23);
            this.clearSettingsButton.TabIndex = 13;
            this.clearSettingsButton.Text = "Clear Settings";
            this.clearSettingsButton.UseVisualStyleBackColor = true;
            this.clearSettingsButton.Click += new System.EventHandler(this.clearSettingsButton_Click);
            // 
            // enigmaBreakerButton
            // 
            this.enigmaBreakerButton.Location = new System.Drawing.Point(12, 132);
            this.enigmaBreakerButton.Name = "enigmaBreakerButton";
            this.enigmaBreakerButton.Size = new System.Drawing.Size(106, 23);
            this.enigmaBreakerButton.TabIndex = 14;
            this.enigmaBreakerButton.Text = "Enigma Breaker";
            this.enigmaBreakerButton.UseVisualStyleBackColor = true;
            this.enigmaBreakerButton.Click += new System.EventHandler(this.enigmaBreakerButton_Click);
            // 
            // EnigmaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 413);
            this.Controls.Add(this.enigmaBreakerButton);
            this.Controls.Add(this.clearSettingsButton);
            this.Controls.Add(this.reflectorCB);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.plugBoardDGV);
            this.Controls.Add(this.plugBoardLabel);
            this.Controls.Add(this.rotorReusedLabel);
            this.Controls.Add(this.rightRotorGroupBox);
            this.Controls.Add(this.midRotorGroupBox);
            this.Controls.Add(this.leftRotorGroupBox);
            this.MinimumSize = new System.Drawing.Size(720, 300);
            this.Name = "EnigmaForm";
            this.Text = "Enigma Cipher";
            this.leftRotorGroupBox.ResumeLayout(false);
            this.leftRotorGroupBox.PerformLayout();
            this.midRotorGroupBox.ResumeLayout(false);
            this.midRotorGroupBox.PerformLayout();
            this.rightRotorGroupBox.ResumeLayout(false);
            this.rightRotorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plugBoardDGV)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.letterTab.ResumeLayout(false);
            this.letterTab.PerformLayout();
            this.textTab.ResumeLayout(false);
            this.textTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox leftRotorGroupBox;
        private System.Windows.Forms.ComboBox leftRotorNumberCBox;
        private System.Windows.Forms.Label leftRingLabel;
        private System.Windows.Forms.Label leftPositionLabel;
        private System.Windows.Forms.Label leftRotorNumLabel;
        private System.Windows.Forms.TextBox leftRingTB;
        private System.Windows.Forms.TextBox leftPositionTB;
        private System.Windows.Forms.GroupBox midRotorGroupBox;
        private System.Windows.Forms.TextBox midRingTB;
        private System.Windows.Forms.TextBox midPositionTB;
        private System.Windows.Forms.ComboBox midRotorNumberCBox;
        private System.Windows.Forms.Label midRingLabel;
        private System.Windows.Forms.Label midPositionLabel;
        private System.Windows.Forms.Label midRotorNumLabel;
        private System.Windows.Forms.GroupBox rightRotorGroupBox;
        private System.Windows.Forms.TextBox rightRingTB;
        private System.Windows.Forms.TextBox rightPositionTB;
        private System.Windows.Forms.ComboBox rightRotorNumberCBox;
        private System.Windows.Forms.Label rightRingLabel;
        private System.Windows.Forms.Label rightPositionLabel;
        private System.Windows.Forms.Label rightRotorNumLabel;
        private System.Windows.Forms.Label rotorReusedLabel;
        private System.Windows.Forms.Label plugBoardLabel;
        private System.Windows.Forms.Label leftInvalidSettingLabel;
        private System.Windows.Forms.Label midInvalidSettingLabel;
        private System.Windows.Forms.Label rightInvalidSettingLabel;
        private System.Windows.Forms.DataGridView plugBoardDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyLetterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pluggedLetterColumn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage letterTab;
        private System.Windows.Forms.TabPage textTab;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label outputTextLabel;
        private System.Windows.Forms.Label inputTextLabel;
        private System.Windows.Forms.ComboBox reflectorCB;
        private System.Windows.Forms.Button clearSettingsButton;
        private System.Windows.Forms.Button clearTextButton;
        private System.Windows.Forms.CheckBox lockCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox letterInputBox;
        private System.Windows.Forms.Label encryptedLettersLabel;
        private System.Windows.Forms.Label enteredLettersLabel;
        private System.Windows.Forms.TextBox outputtedLettersBox;
        private System.Windows.Forms.TextBox oldInputLetterBox;
        private System.Windows.Forms.Button enigmaBreakerButton;
    }
}