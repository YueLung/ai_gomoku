using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    class RandomComputerPlayer : Player
    {
        public RandomComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {

        }

        public override void onMyTurn()
        {
            Random random = new Random();

            int x, y;

            do
            {
                x = random.Next(9);
                y = random.Next(9);

            } while (Model.GetBoard()[y][x] != ChessType.None);

            int Cell_Length = Form1.CELL_LENGTH;

            Chess myChess = ChessFactory.CreateChess(ChessType);
            myChess.SetPosition((x + 1) * Cell_Length - 20, (y + 1) * Cell_Length - 20);

            putChess(x, y);

            View.PutChessOnView(myChess);

            RoleMgr.ChangeNextRole();           
        }
    }
}
