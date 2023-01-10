﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PictureEditor.Classes
{
    public class Editor : Form
    {
        static private int def(byte a, int b) => a;

        protected delegate int Operation(byte a, int b);
        static protected Operation operation = def;

        static protected PictureBox pictureBox;
        static protected Bitmap source;

        static protected int brightChange = 0;
        static protected int contrastChange = 0;

        static protected int rChange = 0;
        static protected int gChange = 0;
        static protected int bChange = 0;

        static public void SetImage(PictureBox _pictureBox)
        {
            pictureBox = _pictureBox;
            source = (Bitmap)_pictureBox.Image;
        }

        protected byte GetByte(int value)
        {
            return (byte)Math.Max(0, Math.Min(255, value));
        }

        protected void ApplyChanges()
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                {
                    Color color = source.GetPixel(x, y);

                    byte r = GetByte(operation(color.R, contrastChange) + brightChange + rChange);
                    byte g = GetByte(operation(color.G, contrastChange) + brightChange + gChange);
                    byte b = GetByte(operation(color.B, contrastChange) + brightChange + bChange);

                    Color resColor = Color.FromArgb(r, g, b);
                    result.SetPixel(x, y, resColor);
                }
            pictureBox.Image = result;
        }

        public virtual void Reset() { }
    }
}
