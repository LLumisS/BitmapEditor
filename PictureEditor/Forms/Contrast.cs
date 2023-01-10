using PictureEditor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor.Forms
{
    public partial class Contrast : Editor
    {
        private delegate int Operation(byte a, int b);
        private Operation operation;

        private int Positive(byte channel, int percent) =>
            (channel * 100 - 128 * percent) / (100 - percent);
        
        private int Negative(byte channel, int percent) =>
            (channel * (100 - percent) + 128 * percent) / 100;

        public Contrast()
        {
            InitializeComponent();
        }

        private void OKButton(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)sourceImg;
            Bitmap result = new Bitmap(source.Width, source.Height);

            int perc = trackBar1.Value;
            if (perc < 0) operation = Negative;
            else operation = Positive;

            perc = Math.Abs(perc);

            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                {
                    Color color = source.GetPixel(x, y);

                    byte r = GetByte(operation(color.R, perc));
                    byte g = GetByte(operation(color.G, perc));
                    byte b = GetByte(operation(color.B, perc));

                    Color resColor = Color.FromArgb(r, g, b);
                    result.SetPixel(x, y, resColor);
                }
            pictureBox.Image = result;
        }

        private void TextInput(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Value = Int32.Parse(textBox1.Text);
            }
            catch
            {
                ScrollChaged(sender, e);
            }
        }

        private void ScrollChaged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void ExitButton(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
