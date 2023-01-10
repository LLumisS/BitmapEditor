using PictureEditor.Forms;
using PictureEditor.Classes;
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
    public partial class Main : Form
    {
        private readonly Brightness brightnessDialog = new Brightness();
        private readonly Contrast contrastDialog = new Contrast();
        private readonly RGB rgbDialog = new RGB();

        private readonly Files files = new Files();
        private readonly ToolBar toolBar;

        public Main()
        {
            InitializeComponent();
            toolBar = new ToolBar(this);
        }

        private void Reset()
        {
            brightnessDialog.Reset();
            contrastDialog.Reset();
            rgbDialog.Reset();
        }

        private void OpenButton(object sender, EventArgs e)
        {
            files.OnOpen(openFileDialog, pictureBox1);
            Editor.SetImage(pictureBox1);
            Reset();
        }

        private void SaveButton(object sender, EventArgs e)
        {
            files.OnSave(pictureBox1);
        }

        private void SaveAsButton(object sender, EventArgs e)
        {
            files.OnSaveAs(pictureBox1);
        }

        private void BrightnessToolButton(object sender, EventArgs e)
        {
            toolBar.Start(brightnessTool, pictureBox1, brightnessDialog);
        }

        private void ContrastToolButton(object sender, EventArgs e)
        {
            toolBar.Start(contrastTool, pictureBox1, contrastDialog);
        }

        private void RgbToolButton(object sender, EventArgs e)
        {
            toolBar.Start(rgbTool, pictureBox1, rgbDialog);
        }

        private void ExitButton(object sender, EventArgs e)
        {
            Close();
        }
    }
}
