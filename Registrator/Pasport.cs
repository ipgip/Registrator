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
        Control F;

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
            Form1.Send(
                 textBox1.Text
                + textBox2.Text
                + textBox3.Text
                + textBox4.Text
                + textBox5.Text
                + textBox6.Text
                + textBox7.Text
                + textBox8.Text
                + textBox9.Text
                + textBox10.Text);
            Clear();
            Visability(true);
        }

        private void Clear()
        {
            textBox1.Text =
            textBox2.Text =
            textBox3.Text =
            textBox4.Text =
            textBox5.Text =
            textBox6.Text =
            textBox7.Text =
            textBox8.Text =
            textBox9.Text =
            textBox10.Text = string.Empty;
        }

        /// <summary>
        /// Стирание последней цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BSBTN_Click(object sender, EventArgs e)
        {
            if (F.Parent.GetNextControl(F, false) != null)
            {
                if ((F as TextBox).TextLength > 0)
                {
                    F.Text = string.Empty;
                    //F = F.Parent.GetNextControl(F, false)??textBox1;
                    Visability(true);
                }
                else
                {
                    F = F.Parent.GetNextControl(F, false);
                    F.Text = string.Empty;
                    F = F.Parent.GetNextControl(F, false);
                    Visability(true);
                }
            }
            EnterBTN.Enabled = (textBox10.TextLength >= 1);
        }

        /// <summary>
        /// Нажатие на цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            (F as TextBox).Text = (sender as Button).Text;
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
                EnterBTN.Enabled = (textBox10.TextLength >= 1);
            }
            F = (sender as Control).Parent.GetNextControl(t, true);
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
                EnterBTN.Enabled = (textBox10.TextLength >= 1);
            }
            Visability(false);
            //tableLayoutPanel2.Enabled = false;
        }

        /// <summary>
        /// работоспособность кнопок ввода
        /// </summary>
        /// <param name="V"></param>
        private void Visability(bool V)
        {
            button1.Enabled =
            button2.Enabled =
            button3.Enabled =
            button4.Enabled =
            button5.Enabled =
            button6.Enabled =
            button7.Enabled =
            button8.Enabled =
            button9.Enabled =
            button10.Enabled = V;
        }

        private void Pasport_Load(object sender, EventArgs e)
        {
            F = textBox1;
        }
    }
}
