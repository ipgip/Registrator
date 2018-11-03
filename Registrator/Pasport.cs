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
    public partial class Pasport : UserControl
    {
        public Pasport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Завершение ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterBTN_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Стирание последней цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BSBTN_Click(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.TextLength > 0)
            {
                t.Text = string.Empty;
            }
            else
            {
                t.Parent.GetNextControl(t, false).Focus();
                t.Text = string.Empty;
            }
        }

        /// <summary>
        /// Нажатие на цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ввод цифр паспорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.TextLength >= 1)
            {
                t.Text = t.Text.Substring(0, 1);
            }
            (sender as Control).Parent.GetNextControl(t, true).Focus();
        }

        /// <summary>
        /// Ввод последней цифры паспорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox10_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.TextLength >= 1)
            {
                t.Text = t.Text.Substring(0, 1);
            }
            tableLayoutPanel2.Enabled = false;
        }
    }
}
