using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor
{
    internal class FileManip
    {
        public void OnOpen(OpenFileDialog openDialog, PictureBox pictureBox)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                //pictureBox.Image = Image.FromFile(openDialog.FileName);
                pictureBox.Image = new Bitmap(openDialog.FileName);
            }
        }

        public void OnSave()
        {

        }

        public void OnSaveAs()
        {

        }
    }
}
