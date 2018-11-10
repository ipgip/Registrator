using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registrator
{
    public partial class KBD : UserControl
    {
        private StringBuilder s = new StringBuilder();

        public new string Text { get; set; }
        public event EventHandler<string> Kbd_Enter;

        public KBD()
        {
            InitializeComponent();
            label1.Text = string.Empty;
        }

        private void Keyboard1_BSPChar(object sender, KeyArgs e)
        {

        }

        private void Keyboard1_ClickChar(object sender, KeyArgs e)
        {
            s.Append(e.Key);
            label1.Text += e.Key;
        }

        private void Keyboard1_ENTChar(object sender, KeyArgs e)
        {
            Text = s.ToString();
            Kbd_Enter?.Invoke(this, Text);
        }
    }
}
