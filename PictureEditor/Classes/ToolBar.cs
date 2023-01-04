using PictureEditor.Forms;
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

        private bool Check(ToolStripButton tool, PictureBox pictureBox, Form dialog)
        {
            if (pictureBox.Image == null)
            {
                tool.Checked = false;
                MessageBox.Show(
                    "Please select a picture firstly.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            tool.Checked = false;

            if (previous != null) previous.Hide();
            dialog.Show();
            dialog.Activate();
            previous = dialog;

            return true;
        }

        public void OnBrightness(ToolStripButton tool, PictureBox pictureBox)
        {
            if (Check(tool, pictureBox, brightnessDialog))
                brightnessDialog.SetImage(pictureBox.Image);
        }

        public void OnContrast(ToolStripButton tool, PictureBox pictureBox)
        {
            if (Check(tool, pictureBox, contrastDialog))
                contrastDialog.SetImage(pictureBox.Image);
        }

        public void OnRGB(ToolStripButton tool, PictureBox pictureBox)
        {
            if (Check(tool, pictureBox, rgbDialog))
                rgbDialog.SetImage(pictureBox.Image);
        }
        
    }
}
