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
        private ToolStripButton previousTool;
        private Editor previousDialog;
        private readonly Form parent;

        private ToolBar() { }

        public ToolBar (Form _parent)
        {
            parent = _parent;
        }

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
            if (previousTool != null) previousTool.Checked = false;
            previousTool = tool;
            tool.Checked = true;
            
            SetSubWindowPos(dialog, pictureBox);
        }

        private void SetSubWindowPos(Editor dialog, PictureBox pictureBox)
        {
            if (previousDialog != null) previousDialog.Hide();
            previousDialog = dialog;

            dialog.Show();
            dialog.Activate();

            const int indent = 5;
            dialog.Left = parent.Left + parent.Width + indent;
            dialog.Top = parent.Top;
        }
    }
}
