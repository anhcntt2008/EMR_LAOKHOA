using System;
using System.Windows.Forms;

namespace Emr.SignPad
{
    public partial class KeypadNameWindow : Form
    {
        public string KeypadName { get; set; }

        public KeypadNameWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeypadName = TextBoxKeypadNameUser.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void KeypadNameWindow_Load(object sender, EventArgs e)
        {
            TextBoxKeypadNameUser.Select();
        }
    }
}
