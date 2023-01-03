using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PictureEditor
{
    internal class FileManip
    {
        private string filePath;

        public void OnOpen(OpenFileDialog openDialog, PictureBox pictureBox)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                //pictureBox.Image = Image.FromFile(openDialog.FileName);
                filePath = openDialog.FileName;
                
                try
                {
                    Bitmap img_temp = new Bitmap(filePath);
                    Bitmap img = new Bitmap(img_temp);
                    img_temp.Dispose();
                    pictureBox.Image = img; 
                }
                catch { MessageBox.Show("This picture is too big.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        public void OnSave(PictureBox pictureBox)
        {
            if (pictureBox.Image != null) pictureBox.Image.Save(filePath);
            else MessageBox.Show("Please select a picture firstly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void OnSaveAs(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Images|*.jpg;*.bmp;*.png";
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image.Save(save.FileName);//, System.Drawing.Imaging.ImageFormat.Png
                }
            }
            else MessageBox.Show("Please select a picture firstly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
