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
        protected PictureBox pictureBox;
        protected Image sourceImg;

        public void SetImage(PictureBox _pictureBox)
        {
            pictureBox = _pictureBox;
            sourceImg = _pictureBox.Image;
        }

        protected byte GetByte(int value)
        {
            return (byte)Math.Max(0, Math.Min(255, value));
        }
    }
}
