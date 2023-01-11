using PictureEditor.Classes;
using System;
using System.Windows.Forms;

namespace PictureEditor.Forms
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
            rChange = trackBar1.Value;
            gChange = trackBar2.Value;
            bChange = trackBar3.Value;
            ApplyChanges();
        }

        private void ExitButton(object sender, EventArgs e)
        {
            tool.Checked = false;
            menu.Checked = false;
            Hide();
        }

        private void CloseButton(object sender, FormClosingEventArgs e)
        {
            tool.Checked = false;
            menu.Checked = false;
        }
    }
}
