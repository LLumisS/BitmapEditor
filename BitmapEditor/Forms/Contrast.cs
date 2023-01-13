using BitmapEditor.Classes;
using System;
using System.Windows.Forms;

namespace BitmapEditor.Forms
{
    public partial class Contrast : Editor
    {
        private int Positive(byte channel, int percent) =>
            (channel * 100 - 128 * percent) / (100 - percent);

        private int Negative(byte channel, int percent) =>
            (channel * (100 - percent) + 128 * percent) / 100;

        public Contrast(ToolStripButton _tool, ToolStripMenuItem _menu)
        {
            InitializeComponent();
            tool = _tool;
            menu = _menu;
        }

        private void OKButton(object sender, EventArgs e)
        {
            int contrast = trackBar1.Value;

            if (contrast < 0) operation = Negative;
            else operation = Positive;

            changes.contrast = Math.Abs(contrast);

            ApplyChanges();
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

        public override void Reset()
        {
            Uncheck();
            Hide();

            trackBar1.Value = 0;
            textBox1.Text = "0";
        }

        private void ExitButton(object sender, EventArgs e)
        {
            Uncheck();
            Hide();
        }

        private void CloseButton(object sender, FormClosingEventArgs e)
        {
            Uncheck();
        }
    }
}
