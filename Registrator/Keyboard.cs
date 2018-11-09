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
    public partial class Keyboard : UserControl
    {
        private event EventHandler<KeyArgs> _Click;
        private EventHandler<KeyArgs> _BSP;
        private EventHandler<KeyArgs> _Ent;

        char[][] kbd = new char[][]{ new char[] { '1','2','3','4','5','6','7','8','9','0','Ё','Й','Ц','У','К','Е','Н','Г','Ш','Щ','З','Х','Ф','Ы','В','А','П','Р','О','Л','Д','Ж','Э','Я','Ч','С','М','И','Т','Ь','Б','Ю','.','-' },
                                     new char[] { '1','2','3','4','5','6','7','8','9','0','_','Q','W','E','R','T','Y','U','I','O','P','*','A','S','D','F','G','H','J','K','L','#','%','Z','X','C','V','B','N','M','[',']','.','@' } };
        bool LanguageSelector = false; // Латинский

        #region События
        [Category("IGP"), Description("Нажата клавиша")]
        public event EventHandler<KeyArgs> ClickChar
        {
            add { _Click += value; }
            remove { _Click -= value; }
        }

        [Category("IGP"), Description("Нажат Backspece")]
        public event EventHandler<KeyArgs> BSPChar
        {
            add { _BSP += value; }
            remove { _BSP -= value; }
        }
        [Category("IGP"), Description("Нажат ВВОД")]
        public event EventHandler<KeyArgs> ENTChar
        {
            add { _Ent += value; }
            remove { _Ent -= value; }
        }
        #endregion

        public Keyboard()
        {
            InitializeComponent();
            //button36.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }

        private void button_Click(object sender, EventArgs e)
        {
            _Click?.Invoke(this, new KeyArgs((sender as Button).Text[0]));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _BSP?.Invoke(this, new KeyArgs(' '));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            _Ent?.Invoke(this, new KeyArgs(' '));
        }

        // переключение языков клавиатуры
        private void LanguageSelector_Click(object sender, EventArgs e)
        {
            LanguageSelector = !LanguageSelector;
            LoadKeys();
        }

        private void Keyboard_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < kbd[LanguageSelector ? 0 : 1].Length; i++)
            {
                Button b = new Button
                {
                    Font=new Font(DefaultFont.FontFamily, 8, FontStyle.Bold),
                    Text = kbd[LanguageSelector ? 0 : 1][i].ToString(),
                    Dock = DockStyle.Fill
                };
                b.Click += button_Click;
                tableLayoutPanel1.Controls.Add(b, i % 11, i / 11);
            }
            Lang.Text = LanguageSelector ? "RUS" : "LAT";
        }

        // загрузка клавиш
        private void LoadKeys()
        {
            for (int i = 0; i < kbd[LanguageSelector ? 0 : 1].Length; i++)
            {
                Button b = tableLayoutPanel1.GetControlFromPosition(i % 11, i / 11) as Button;

                b.Text = kbd[LanguageSelector ? 0 : 1][i].ToString();
            }
            Lang.Text = LanguageSelector ? "RUS" : "LAT";
        }
    }

    public class KeyArgs : EventArgs
    {
        public char Key;

        public KeyArgs(char p)
        {
            Key = p;
        }
    }

}
