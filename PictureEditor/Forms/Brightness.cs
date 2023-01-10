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
    public partial class Brightness : Editor
    {
        public Brightness()
        {
            InitializeComponent();
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

        private void OKButton(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)sourceImg;
            Bitmap result = new Bitmap(source.Width, source.Height);

            int change = trackBar1.Value * 128 / 100;

            for (int y = 0; y < source.Height; y++)
                for(int x = 0; x < source.Width; x++)
                {
                    Color color = source.GetPixel(x, y);

                    int r = Math.Max(0, Math.Min(255, color.R + change));
                    int g = Math.Max(0, Math.Min(255, color.G + change));
                    int b = Math.Max(0, Math.Min(255, color.B + change));

                    Color resColor = Color.FromArgb(r, g, b);
                    result.SetPixel(x, y, resColor);
                }
            pictureBox.Image = result;
        }

        private void ExitButton(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
