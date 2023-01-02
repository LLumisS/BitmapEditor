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
        private ToolStripButton previous;

        private void Check(ToolStripButton tool, PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                tool.Checked = false;
                MessageBox.Show("Please select a picture firstly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (previous != null) previous.Checked = false;
            tool.Checked = true;
            previous = tool;
        }

        public void OnBrightness(ToolStripButton tool, PictureBox pictureBox)
        {
            Check(tool, pictureBox);
        }

        public void OnContrast(ToolStripButton tool, PictureBox pictureBox)
        {
            Check(tool, pictureBox);
        }

        public void OnRGB(ToolStripButton tool, PictureBox pictureBox)
        {
            Check(tool, pictureBox);
        }
    }
}
