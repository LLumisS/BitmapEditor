using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor.Forms
{
    public partial class RGB : Form
    {
        private Image image;

        public RGB()
        {
            InitializeComponent();
        }

        public void SetImage(Image _image)
        {
            image = _image;
        }

        private void TextInputButton(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TrackBar trackBar = null;

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
            TextBox textBox = null;

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

        }

        private void ExitButton(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
