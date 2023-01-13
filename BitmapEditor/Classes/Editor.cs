using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace BitmapEditor.Classes
{
    public abstract class Editor : Form
    {
        static private int def(byte a, int b) => a;

        protected delegate int Operation(byte a, int b);
        static protected Operation operation = def;

        static protected PictureBox pictureBox;
        static protected Bitmap source;

        static protected Change change = new Change();

        protected ToolStripButton tool;
        protected ToolStripMenuItem menu;

        static public void SetImage(PictureBox _pictureBox)
        {
            pictureBox = _pictureBox;
            source = (Bitmap)_pictureBox.Image;
        }

        protected byte GetByte(byte srcchan, int br, int cont, int destchan)
        {
            int value = operation(srcchan, cont) + br + destchan;
            return (byte)Math.Max(0, Math.Min(255, value));
        }

        protected async void ApplyChanges()
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            int bright = change.bright;
            int contrast = change.contrast;
            int _r = change.r;
            int _g = change.g;
            int _b = change.b;

            await Task.Run( () =>
            {
                for (int y = 0; y < source.Height; y++)
                    for (int x = 0; x < source.Width; x++)
                    {
                        Color color = source.GetPixel(x, y);

                        byte r = GetByte(color.R, bright, contrast, _r);
                        byte g = GetByte(color.G, bright, contrast, _g);
                        byte b = GetByte(color.B, bright, contrast, _b);

                        Color resColor = Color.FromArgb(r, g, b);
                        result.SetPixel(x, y, resColor);
                    }
            });

            pictureBox.Image = result;
        }

        public abstract void Reset();
    }
}
