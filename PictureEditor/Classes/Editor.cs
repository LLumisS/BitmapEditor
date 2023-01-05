using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PictureEditor.Classes
{
    public class Editor : Form
    {
        private Image image;

        public void SetImage(Image _image)
        {
            image = _image;
        }
    }
}
