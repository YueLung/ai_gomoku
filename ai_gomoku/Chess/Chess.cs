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

        public void SetPositionPixel(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
        }

        public void SetPositionByCoordinate(int x, int y)
        {
            int Cell_Length = Form1.CELL_LENGTH;

            SetPositionPixel((x + 1) * Cell_Length - 20, (y + 1) * Cell_Length - 20);
        }
    }
}
