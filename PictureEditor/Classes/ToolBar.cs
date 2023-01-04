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

        private ToolStripButton previous;

        private bool Check(ToolStripButton tool, PictureBox pictureBox)
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
            //if (previous != null) previous.Checked = false;
            tool.Checked = false;
            //previous = tool;
            return true;
        }

        public void OnBrightness(ToolStripButton tool, PictureBox pictureBox)
        {
            if (Check(tool, pictureBox))
            {
                brightnessDialog.Show();
                brightnessDialog.SetImage(pictureBox.Image);
            }
        }

        public void OnContrast(ToolStripButton tool, PictureBox pictureBox)
        {
            if (Check(tool, pictureBox))
            {
                contrastDialog.Show();
                contrastDialog.SetImage(pictureBox.Image);
            }
        }

        public void OnRGB(ToolStripButton tool, PictureBox pictureBox)
        {
            if (Check(tool, pictureBox))
            {
                rgbDialog.Show();
                rgbDialog.SetImage(pictureBox.Image);
            }
        }
    }
}
