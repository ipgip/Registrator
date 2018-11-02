using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Registrator
{
    internal class ScreenTable
    {
        public List<Rows> R = new List<Rows>();
        public List<Cols> C = new List<Cols>();

        public ScreenTable(XDocument doc)
        {
            foreach (var el in doc.Descendants("Rows").Elements())
            {
                R.Add(new Rows(Convert.ToInt32(el.Attribute("Height").Value)));
            }
            foreach (var el in doc.Descendants("Cols").Elements())
            {
                C.Add(new Cols(Convert.ToInt32(el.Attribute("Width").Value)));
            }
        }
    }

    public class Cols
    {
        public int Width;
        public Cols(int v) => this.Width = v;
    }

    public class Rows
    {
        public int Height;

        public Rows(int v) => this.Height = v;
    }
}