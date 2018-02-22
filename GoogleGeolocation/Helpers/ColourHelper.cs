﻿using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GoogleGeolocation
{
    class ColourHelper
    {
        public static Color HexStringToColor(string hexColor)
        {
            var hc = ExtractHexDigits(hexColor);

            if (hc.Length != 6)
                return Color.Empty;

            var r = hc.Substring(0, 2);
            var g = hc.Substring(2, 2);
            var b = hc.Substring(4, 2);

            var color = Color.Empty;

            var ri
                = int.Parse(r, NumberStyles.HexNumber);
            var gi
                = int.Parse(g, NumberStyles.HexNumber);
            var bi
                = int.Parse(b, NumberStyles.HexNumber);

            color = Color.FromArgb(ri, gi, bi);

            return color;
        }

        public static string ExtractHexDigits(string input)
        {
            // remove any characters that are not digits (like #)
            var isHexDigit
                = new Regex("[abcdefABCDEF\\d]+", RegexOptions.Compiled);

            var newnum = "";

            foreach (var c in input)
                if (isHexDigit.IsMatch(c.ToString()))
                    newnum += c.ToString();

            return newnum;
        }

        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = color.R;
            float green = color.G;
            float blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        public static string ColorOuputStringToHexString(string colorString)
        {
            var color = Color.White;

            if (!colorString.Any(char.IsDigit))
            {
                // string needs to be in the format: Color [Red]

                colorString = colorString.Replace("[", "").Replace("]", "");
                colorString = Regex.Replace(colorString, "Color ", "");

                color = Color.FromName(colorString);
            }
            else
            {
                // string needs to be in the format: Color [A=255, R=255, G=128, B=0]

                colorString = colorString.Replace("[", "").Replace("]", "").Replace(",", "");
                colorString = Regex.Replace(colorString, "Color ", "");
                colorString = Regex.Replace(colorString, "A", "");
                colorString = Regex.Replace(colorString, "R", "");
                colorString = Regex.Replace(colorString, "G", "");
                colorString = Regex.Replace(colorString, "B", "");

                var colourParts = Regex.Split(colorString, "=");

                color = Color.FromArgb(Convert.ToInt32(colourParts[1]), Convert.ToInt32(colourParts[2]),
                    Convert.ToInt32(colourParts[3]), Convert.ToInt32(colourParts[4]));
            }

            return ColorToHexString(color);
        }

        public static string ColorToHexString(Color color)
        {
            char[] hexDigits =
            {
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
            };

            var bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;

            var chars = new char[bytes.Length * 2];

            for (var i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }

            return new string(chars);
        }

        public static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            var index = siblings.IndexOf(control);

            Bitmap behind = null;

            for (var i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }

            if (behind == null
            ) return;

            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        public class ColourGenerator
        {
            private readonly IntensityGenerator intensityGenerator = new IntensityGenerator();
            private int index;

            public static Color GetRandomColour()
            {
                var r = new Random();
                var rInt = r.Next(0, 896); // the largest amount of colours this class will generate

                var colorGen = new ColourGenerator();
                var randomColourStr = "FFFFFF";

                for (var i = 0; i < rInt; i++)
                    randomColourStr = colorGen.NextColour();

                return HexStringToColor(randomColourStr);
            }

            public string NextColour()
            {
                var colour = string.Format(PatternGenerator.NextPattern(index),
                    intensityGenerator.NextIntensity(index));
                index++;
                return colour;
            }
        }

        public class PatternGenerator
        {
            public static string NextPattern(int index)
            {
                switch (index % 7)
                {
                    case 0: return "{0}0000";
                    case 1: return "00{0}00";
                    case 2: return "0000{0}";
                    case 3: return "{0}{0}00";
                    case 4: return "{0}00{0}";
                    case 5: return "00{0}{0}";
                    case 6: return "{0}{0}{0}";
                    default: throw new Exception("Math error");
                }
            }
        }

        public class IntensityGenerator
        {
            private int current;
            private IntensityValueWalker walker;

            public string NextIntensity(int index)
            {
                if (index == 0)
                {
                    current = 255;
                }
                else if (index % 7 == 0)
                {
                    if (walker == null)
                        walker = new IntensityValueWalker();
                    else
                        walker.MoveNext();
                    current = walker.Current.Value;
                }
                var currentText = current.ToString("X");
                if (currentText.Length == 1) currentText = "0" + currentText;
                return currentText;
            }
        }

        public class IntensityValue
        {
            private IntensityValue mChildA;
            private IntensityValue mChildB;

            public IntensityValue(IntensityValue parent, int value, int level)
            {
                if (level > 7) throw new Exception("There are no more colours left");
                Value = value;
                Parent = parent;
                Level = level;
            }

            public int Level { get; set; }
            public int Value { get; set; }
            public IntensityValue Parent { get; set; }

            public IntensityValue ChildA => mChildA ?? (mChildA =
                                                new IntensityValue(this, Value - (1 << (7 - Level)), Level + 1));

            public IntensityValue ChildB => mChildB ?? (mChildB =
                                                new IntensityValue(this, Value + (1 << (7 - Level)), Level + 1));
        }

        public class IntensityValueWalker
        {
            public IntensityValueWalker()
            {
                Current = new IntensityValue(null, 1 << 7, 1);
            }

            public IntensityValue Current { get; set; }

            public void MoveNext()
            {
                if (Current.Parent == null)
                {
                    Current = Current.ChildA;
                }
                else if (Current.Parent.ChildA == Current)
                {
                    Current = Current.Parent.ChildB;
                }
                else
                {
                    var levelsUp = 1;
                    Current = Current.Parent;
                    while (Current.Parent != null && Current == Current.Parent.ChildB)
                    {
                        Current = Current.Parent;
                        levelsUp++;
                    }
                    if (Current.Parent != null)
                        Current = Current.Parent.ChildB;
                    else
                        levelsUp++;
                    for (var i = 0; i < levelsUp; i++)
                        Current = Current.ChildA;
                }
            }
        }
    }
}
