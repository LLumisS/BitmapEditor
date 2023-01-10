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
        public Contrast()
        {
            InitializeComponent();
        }

        private void OKButton(object sender, EventArgs e)
        {
            contrastChange = trackBar1.Value;
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

        private void ExitButton(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
