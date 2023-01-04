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
    public partial class Brightness : Form
    {
        private Image image;

        public Brightness()
        {
            InitializeComponent();
        }

        public void SetImage(Image _image)
        {
            image = _image;
        }

        private void TextInput(object sender, EventArgs e)
        {

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
