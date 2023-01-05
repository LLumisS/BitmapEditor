using PictureEditor.Forms;
using PictureEditor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor
{
    internal class ToolBar
    {
        private Brightness brightnessDialog = new Brightness();
        private Contrast contrastDialog = new Contrast();
        private RGB rgbDialog = new RGB();

        private Form previous;

        private void Start(ToolStripButton tool, PictureBox pictureBox, Editor dialog)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show(
                    "Please select a picture firstly.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            tool.Checked = false;

            if (previous != null) previous.Hide();
            dialog.Show();
            dialog.Activate();
            previous = dialog;
            dialog.SetImage(pictureBox.Image);
        }

        public void OnBrightness(ToolStripButton tool, PictureBox pictureBox)
        {
            Start(tool, pictureBox, brightnessDialog);
        }

        public void OnContrast(ToolStripButton tool, PictureBox pictureBox)
        {
            Start(tool, pictureBox, contrastDialog);
        }

        public void OnRGB(ToolStripButton tool, PictureBox pictureBox)
        {
            Start(tool, pictureBox, rgbDialog);
        }
        
    }
}
