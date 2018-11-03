using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Registrator
{
    public partial class Form1 : Form
    {
        string Path = @"C:\Users\ipigp\Desktop\Registrator.xml";
        string FMT = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(Path);
            ScreenTable ST = new ScreenTable(doc);
            ButtonsPole BP = new ButtonsPole(doc);
            Widgets WW = new Widgets(doc);

            TableLayoutPanel tp = LoadTPFromFile(ST);
            TableLayoutPanel Pole = LoadPole(doc, BP);
            LoadWidgets(WW, tp, Pole);
            //tp.Controls.Add(Pole, 1, 1);
            Controls.Add(tp);
        }

        private void LoadWidgets(Widgets w, TableLayoutPanel tp, TableLayoutPanel Pole)
        {
            foreach (var ww in w.B)
            {
                int X = ww.Position % tp.ColumnCount;
                int Y = ww.Position / tp.ColumnCount;
                Control L = null;
                switch (ww.T)
                {
                    case WType.Clocks:
                        L = ww.Param as Label;
                        L.Text = DateTime.Now.ToString((ww.Context as string));
                        FMT = ww.Context as string;
                        L.Name = "CLC";
                        // перечитывать значение
                        timer1.Interval = 1000;
                        timer1.Tick += Timer1_Tick;
                        timer1.Start();
                        break;
                    case WType.Pole:
                        L = Pole;
                        break;
                    case WType.Logo:
                    case WType.Image:
                        L = ww.Param as PictureBox;
                        (L as PictureBox).Image = ww.Context as Image;
                        break;
                    case WType.Text:
                        L = ww.Param as Label;
                        L.Text = ww.Context as string;
                        break;
                    case WType.Pasport:
                        L = new Panel
                        {
                            Dock=DockStyle.Fill
                        };
                        //L.Controls.Add(new Pasport());
                        break;
                    case WType.None:
                    default:
                        break;
                }
                if (ww.T != WType.None)
                {
                    tp.Controls.Add(L, X, Y);
                    if (ww.Span != 0)
                        tp.SetColumnSpan(L, ww.Span);
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Label L = (Label)Controls.Find("CLC", true)[0];
            L.Text = DateTime.Now.ToString(FMT);
        }

        private TableLayoutPanel LoadPole(XDocument doc, ButtonsPole bP)
        {
            var a = doc.Descendants("ButtonsPole").First();
            int r = Convert.ToInt32(a.Attribute("Rows")?.Value ?? "1");
            int c = Convert.ToInt32(a.Attribute("Cols")?.Value ?? "1");
            TableLayoutPanel P = new TableLayoutPanel
            {
#if DEBUG
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
#endif
                Dock = DockStyle.Fill,
                RowCount = (int)Math.Ceiling(((decimal)bP.B.Count()) / c),
                ColumnCount = c
            };
            foreach (var b in bP.B)
            {
                Button BB = new Button
                {
                    Dock = DockStyle.Fill,
                    Text = b.Text,
                    Tag = b.Id,
                    Font = b.F,
                    ForeColor = b.FC,
                    BackColor = b.BC,
                    Image = b.I
                };

                BB.Click += BB_Click;

                P.Controls.Add(BB);
            }
            P.RowStyles.Clear();
            P.ColumnStyles.Clear();
            for (int i = 0; i < (int)Math.Ceiling((decimal)bP.B.Count() / c); i++)
            {
                P.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / r));
            }

            for (int i = 0; i < c; i++)
            {
                P.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / c));
            }

            return P;
        }

        /// <summary>
        /// Обработка выбора услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BB_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{(sender as Button).Tag}");
        }

        private static TableLayoutPanel LoadTPFromFile(ScreenTable ST)
        {
            TableLayoutPanel tp = new TableLayoutPanel
            {
#if DEBUG
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
#endif
                Dock = DockStyle.Fill,
                ColumnCount = ST.C.Count(),
                RowCount = ST.R.Count()
            };
            tp.ColumnStyles.Clear();
            tp.RowStyles.Clear();
            foreach (var cc in ST.C)
            {
                tp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, cc.Width));
            }
            foreach (var rr in ST.R)
            {
                tp.RowStyles.Add(new RowStyle(SizeType.Percent, rr.Height));
            }
            return tp;
        }
    }
}
