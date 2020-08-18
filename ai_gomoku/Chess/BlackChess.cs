using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_gomoku
{
    class BlackChess : Chess
    {
        public BlackChess() : base()
        {
            Image = Properties.Resources.black;
        }
    }
}
