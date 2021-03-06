﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Registrator
{
    public enum WType { None, Clocks, Logo, Pole, Image, Text, Passport, Keyboard}

    internal class Widgets
    {
        public List<ScreenWidgets> B = new List<ScreenWidgets>();
        //public static int CurrentScreen = 1;

        public Widgets(XDocument doc, int CurrentScreen)
        {
            foreach (var e in doc.Descendants("Screens").Elements())
            {
                if (Convert.ToInt32(e.Attribute("Id").Value) == CurrentScreen)
                {
                    foreach (var el in e.Descendants("Cells").Elements())
                    {
                        int Pos = Convert.ToInt32(el.Attribute("P")?.Value);
                        int Span = Convert.ToInt32(el.Attribute("Span")?.Value ?? "0");
                        WType t;
                        object Par;
                        object Cont;
                        int Next = 0;

                        foreach (var el1 in el.Elements())
                        {
                            switch (el1.Name.LocalName)
                            {
                                case "Keyboard":
                                    t = WType.Keyboard;
                                    Par = null;
                                    Cont = null;
                                    Next = Convert.ToInt32(el1.Attribute("Next")?.Value??"0");
                                    break;
                                case "Passport":
                                    t = WType.Passport;
                                    Par = null;
                                    Cont = null;
                                    Next = Convert.ToInt32(el1.Attribute("Next")?.Value ?? "0");
                                    break;
                                case "Logo":
                                    t = WType.Logo;
                                    Par = new PictureBox
                                    {
                                        Dock = DockStyle.Fill,
                                        SizeMode = PictureBoxSizeMode.StretchImage
                                    };
                                    Cont = ((el1.Value != string.Empty) && (File.Exists(el1.Value.Trim()))) ? Image.FromFile(el1.Value.Trim()) : null;
                                    break;
                                case "Pole":
                                    t = WType.Pole;
                                    Par = null;
                                    Cont = null;
                                    Next = Convert.ToInt32(el1.Attribute("Next")?.Value ?? "0");
                                    break;
                                case "Clocks":
                                    t = WType.Clocks;
                                    Par = Par = new Label
                                    {
                                        Dock = DockStyle.Fill,
                                        TextAlign = ContentAlignment.MiddleCenter,
                                        Font = new Font(
                                            el1.Attribute("Font").Value.ToString(),
                                            Convert.ToSingle(el1.Attribute("Size")?.Value ?? "11"),
                                            ((el1.Attribute("Bold")?.Value == "1") ? FontStyle.Bold : FontStyle.Regular)
                                            | ((el1.Attribute("Italic")?.Value == "1") ? FontStyle.Italic : FontStyle.Regular)),
                                        ForeColor = (el1.Attribute("Color") != null) ? Color.FromName(el1.Attribute("Color").Value) : SystemColors.ControlText,
                                        BackColor = (el1.Attribute("BGColor") != null) ? Color.FromName(el1.Attribute("BGColor").Value) : SystemColors.Control
                                    };
                                    Cont = el1.Attribute("FMT")?.Value;
                                    break;
                                case "Text":
                                    t = WType.Text;
                                    Par = new Label
                                    {
                                        Dock = DockStyle.Fill,
                                        TextAlign=ContentAlignment.MiddleCenter,
                                        Font = new Font(
                                            el1.Attribute("Font").Value.ToString(),
                                            Convert.ToSingle(el1.Attribute("Size")?.Value ?? "11"),
                                            ((el1.Attribute("Bold")?.Value == "1") ? FontStyle.Bold : FontStyle.Regular)
                                            | ((el1.Attribute("Italic")?.Value == "1") ? FontStyle.Italic : FontStyle.Regular)),
                                        ForeColor = (el1.Attribute("Color") != null) ? Color.FromName(el1.Attribute("Color").Value) : SystemColors.ControlText,
                                        BackColor = (el1.Attribute("BGColor") != null) ? Color.FromName(el1.Attribute("BGColor").Value) : SystemColors.Control
                                    };
                                    Cont = el1?.Value;
                                    break;
                                case "Image":
                                    t = WType.Image;
                                    Par = new PictureBox
                                    {
                                        Dock = DockStyle.Fill,
                                        SizeMode = PictureBoxSizeMode.StretchImage
                                    };
                                    Cont = ((el1.Value != string.Empty) && File.Exists(el1.Value.Trim())) ? Image.FromFile(el1.Value.Trim()) : null;
                                    break;
                                default:
                                    t = WType.None;
                                    Par = null;
                                    Cont = null;
                                    Next = 0;
                                    break;
                            }
                            B.Add(new ScreenWidgets(Pos, Span, t, Par, Cont, Next));
                        }
                    }
                }
            }
        }
    }

    public class ScreenWidgets
    {
        public int Position;
        public int Span;
        public WType T;
        public object Param;
        public object Context;
        public int Next;

        public ScreenWidgets(int pos, int span, WType t, object par, object cont, int next)
        {
            Position = pos;
            Span = span;
            T = t;
            Param = par;
            Context = cont;
            Next = next;
        }
    }
}