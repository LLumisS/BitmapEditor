using System;
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
        static protected Image sourceImg;

        static protected int brightChange = 0;
        static protected int contrastChange = 0;

        static public void SetImage(PictureBox _pictureBox)
        {
            pictureBox = _pictureBox;
            sourceImg = _pictureBox.Image;
        }

        protected byte GetByte(int value)
        {
            return (byte)Math.Max(0, Math.Min(255, value));
        }

        protected void ApplyChanges()
        {
            Bitmap source = (Bitmap)sourceImg;
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                {
                    Color color = source.GetPixel(x, y);

                    byte r = GetByte(operation(color.R, contrastChange) + brightChange);
                    byte g = GetByte(operation(color.G, contrastChange) + brightChange);
                    byte b = GetByte(operation(color.B, contrastChange) + brightChange);

                    Color resColor = Color.FromArgb(r, g, b);
                    result.SetPixel(x, y, resColor);
                }
            pictureBox.Image = result;
        }
    }
}
