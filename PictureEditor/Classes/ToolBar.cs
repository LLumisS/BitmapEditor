using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor
{
    internal class ToolBar
    {
        private ToolStripButton previous;

        public void OnLightning(ToolStripButton tool)
        {
            if (previous != null) previous.Checked = false;
            previous = tool;
        }

        public void OnContrast(ToolStripButton tool)
        {
            if (previous != null) previous.Checked = false;
            previous = tool;
        }

        public void OnRGB(ToolStripButton tool)
        {
            if (previous != null) previous.Checked = false;
            previous = tool;
        }
    }
}
