using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor
{
    public partial class Form1 : Form
    {
        FileManip fileManip = new FileManip();
        Editor editor = new Editor();
        ToolStripButton previous;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenButton(object sender, EventArgs e)
        {
            fileManip.OnOpen(openFileDialog, pictureBox1);
        }

        private void SaveButton(object sender, EventArgs e)
        {
            fileManip.OnSave();
        }

        private void SaveAsButton(object sender, EventArgs e)
        {
            fileManip.OnSaveAs();
        }

        private void LightningToolButton(object sender, EventArgs e)
        {
            editor.OnLightning();
            if (previous != null) previous.Checked = false;
            previous = lightningTool;
        }

        private void ContrastToolButton(object sender, EventArgs e)
        {
            editor.OnContrast();
            if (previous != null) previous.Checked = false;
            previous = contrastTool;
        }

        private void RgbToolButton(object sender, EventArgs e)
        {
            editor.OnRGB();
            if (previous != null) previous.Checked = false;
            previous = rgbTool;
        }

        private void ExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
