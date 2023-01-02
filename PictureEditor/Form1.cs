using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor
{
    public partial class Form1 : Form
    {
        FileManip fileManip = new FileManip();

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

        private void ExitButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
