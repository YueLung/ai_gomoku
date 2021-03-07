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
                x = random.Next(GameDef.board_cell_length);
                y = random.Next(GameDef.board_cell_length);

            } while (Model.GetBoardByCopy()[y][x] != ChessType.None);

            Chess myChess = ChessFactory.CreateChess(MyChessType);
            myChess.SetPositionByCoordinate(x, y);

            putChess(x, y);

            View.PutChessOnView(myChess);

            RoleMgr.ChangeNextRole();           
        }
    }
}
