using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionToolsGUI
{
    public class FormWithText : Form
    {
        protected void enterTextButton()
        {
            if (inputForm == null || inputForm.IsDisposed)
            {
                inputForm = new TextInputForm(this, ciphertext);
                inputForm.Show();
            }
            else
                inputForm.Select();
        }

        /*private string _text = "";
        public string text
        {
            get { Console.WriteLine("HI"); return _text; }
            set
            {
                _text = value;
                Console.WriteLine(_text);
            }
        }*/

        public string ciphertext { get; set; } = "";

        public TextInputForm inputForm { get; set; }
    }
}
