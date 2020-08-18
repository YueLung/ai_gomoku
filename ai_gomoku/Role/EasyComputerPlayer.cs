using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    public class EasyComputerPlayer : Player
    {
        public EasyComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        { 
        }

        public override void onMyTurn()
        {
            throw new NotImplementedException();
        }
    }
}
