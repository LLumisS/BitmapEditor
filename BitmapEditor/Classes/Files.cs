using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PictureEditor
{
    internal class Files
    {
        private string filePath;

        public void OnOpen(OpenFileDialog openDialog, PictureBox pictureBox)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openDialog.FileName;
                
                try
                {
                    Bitmap img_temp = new Bitmap(filePath);
                    Bitmap img = new Bitmap(img_temp);
                    img_temp.Dispose();
                    pictureBox.Image = img;
                    openDialog.FileName = Path.GetFileName(filePath);
                }
                catch
                {
                    MessageBox.Show(
                        "This picture is too big.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        public void OnSave(PictureBox pictureBox)
        {
            if (pictureBox.Image != null) pictureBox.Image.Save(filePath);
            else MessageBox.Show(
                "Please select a picture firstly.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public void OnSaveAs(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Images|*.jpg;*.bmp;*.png";
                save.RestoreDirectory = true;
                save.FileName = Path.GetFileName(filePath);
                if (save.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image.Save(save.FileName);
                }
            }
            else MessageBox.Show(
                "Please select a picture firstly.", 
                "Error", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
}
