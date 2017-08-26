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
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VigenereForm form = new VigenereForm();
            form.ShowDialog();
            form.Dispose();
        }

        private void caesarButton_Click(object sender, EventArgs e)
        {
            CaesarForm form = new CaesarForm();
            form.ShowDialog();
            form.Dispose();
        }

        private void enigmaButton_Click(object sender, EventArgs e)
        {
            EnigmaForm form = new EnigmaForm();
            form.ShowDialog();
            form.Dispose();
        }
    }
}
