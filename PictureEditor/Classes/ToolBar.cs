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
        private Editor previous;

        public void Start(ToolStripButton tool, PictureBox pictureBox, Editor dialog)
        {
            if (pictureBox.Image == null)
            {
                tool.Checked = false;
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
    }
}
