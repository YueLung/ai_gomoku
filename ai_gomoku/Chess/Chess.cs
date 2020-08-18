using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_gomoku
{
    abstract public class Chess : PictureBox
    {
        public Chess()
        {
            Size = new System.Drawing.Size(50, 50);
            BackColor = System.Drawing.Color.Transparent;
        }

        public void SetPosition(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
        }
    }
}
