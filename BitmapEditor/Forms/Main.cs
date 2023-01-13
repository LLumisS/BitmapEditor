using BitmapEditor.Forms;
using BitmapEditor.Classes;
using System;
using System.Windows.Forms;

namespace BitmapEditor
{
    public partial class Main : Form
    {
        private readonly Files files = new Files();
        private readonly ToolBar toolBar;

        private readonly Brightness brightnessDialog;
        private readonly Contrast contrastDialog;
        private readonly RGB rgbDialog;

        public Main()
        {
            InitializeComponent();

            toolBar = new ToolBar(this);

            brightnessDialog = new Brightness(brightnessTool, brightnessToolStripMenuItem);
            contrastDialog = new Contrast(contrastTool, contrastToolStripMenuItem);
            rgbDialog = new RGB(rgbTool, RGBToolStripMenuItem);
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
            toolBar.Start(
                brightnessTool, 
                brightnessToolStripMenuItem, 
                pictureBox1, 
                brightnessDialog);
        }

        private void ContrastToolButton(object sender, EventArgs e)
        {
            toolBar.Start(
                contrastTool, 
                contrastToolStripMenuItem, 
                pictureBox1, 
                contrastDialog);
        }

        private void RgbToolButton(object sender, EventArgs e)
        {
            toolBar.Start(
                rgbTool, 
                RGBToolStripMenuItem, 
                pictureBox1, 
                rgbDialog);
        }

        private void ExitButton(object sender, EventArgs e)
        {
            Close();
        }
    }
}
