using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.Classes
{
    public struct Change
    {
        public int bright;
        public int contrast;
        public int r;
        public int g;
        public int b;

        public Change(int val = 0)
        {
            bright = val;
            contrast = val;
            r = val;
            g = val;
            b = val;
        }
    }
}
