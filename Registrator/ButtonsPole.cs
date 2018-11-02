using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Linq;

namespace Registrator
{
    internal class ButtonsPole
    {
        public List<ScreenButton> B = new List<ScreenButton>();

        public ButtonsPole(XDocument doc)
        {
            foreach (var el in doc.Descendants("Buttons").Elements())
            {
                string Id=el.Attribute("Id").Value;
                string Text = el.Value;
                string fontName = el.Attribute("Font").Value;
                float fontSize = Convert.ToSingle(el.Attribute("Size")?.Value??"11");
                bool Bold = el.Attribute("Bold").Value == "1";
                bool Italic = el.Attribute("Italic").Value == "1";
                string fC = el.Attribute("Color").Value;
                string bC = el.Attribute("BGColor").Value;
                string imagepath = el.Attribute("Image").Value;
                B.Add(new ScreenButton(Id, Text, fontName,fontSize, Bold, Italic, fC, bC, imagepath));
            }
        }
    }

    public class ScreenButton
    {
        public string Id;
        public string Text;
        public Font F;
        public Color FC;
        public Color BC;
        public Image I;

        public ScreenButton(string id, string text, string fontName, float fontSize, bool bold, bool italic, string fC, string bC, string imagepath)
        {
            Id = id;
            Text = text;
            F = new Font(fontName, fontSize, (bold ? FontStyle.Bold : FontStyle.Regular)
                                    | (italic ? FontStyle.Italic : FontStyle.Regular));
            FC = (fC != string.Empty) ? Color.FromName(fC) : SystemColors.ControlText;
            BC = (bC != string.Empty) ? Color.FromName(bC) : SystemColors.Control;
            I = ((imagepath != string.Empty) && (File.Exists(imagepath))) ? Image.FromFile(imagepath) : null;
        }
    }
}