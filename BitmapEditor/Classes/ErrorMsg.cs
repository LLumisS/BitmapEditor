using System.Windows.Forms;

namespace BitmapEditor.Classes
{
    public class ErrorMsg
    {
        protected void Error(string msg)
        {
            MessageBox.Show(msg, "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
