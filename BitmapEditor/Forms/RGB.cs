using BitmapEditor.Classes;
using System;
using System.Windows.Forms;

namespace BitmapEditor.Forms
{
    public partial class RGB : Editor
    {
        public RGB(ToolStripButton _tool, ToolStripMenuItem _menu)
        {
            InitializeComponent();
            tool = _tool;
            menu = _menu;
        }

        private void TextInputButton(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TrackBar trackBar;

            if (Equals(textBox, textBox1)) trackBar = trackBar1;
            else if (Equals(textBox, textBox2)) trackBar = trackBar2;
            else trackBar = trackBar3;

            try
            {
                trackBar.Value = Int32.Parse(textBox.Text);
            }
            catch
            {
                ScrollChaged(trackBar, textBox);
            }
        }

        private void ScrollChagedButton(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            TextBox textBox;

            if (Equals(trackBar, trackBar1)) textBox = textBox1;
            else if (Equals(trackBar, trackBar2)) textBox = textBox2;
            else textBox = textBox3;

            textBox.Text = trackBar.Value.ToString();
        }

        private void ScrollChaged(TrackBar trackBar, TextBox textBox)
        {
            textBox.Text = trackBar.Value.ToString();
        }

        private void OKButton(object sender, EventArgs e)
        {
            changes.r = trackBar1.Value;
            changes.g = trackBar2.Value;
            changes.b = trackBar3.Value;
            ApplyChanges();
        }

        public override void Reset()
        {
            Uncheck();
            Hide();

            trackBar1.Value = 0;
            textBox1.Text = "0";

            trackBar2.Value = 0;
            textBox2.Text = "0";

            trackBar3.Value = 0;
            textBox3.Text = "0";
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
