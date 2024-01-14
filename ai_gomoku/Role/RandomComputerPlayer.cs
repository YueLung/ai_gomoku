using ai_gomoku.Models;
using System;

namespace ai_gomoku.Role
{
    class RandomComputerPlayer : Player
    {
        public RandomComputerPlayer(String name, Form1 view, GameModel model, RoleMgr roleMgr, ChessType chessType)
            : base(name, view, model, roleMgr, chessType)
        {

        }

        public override void OnMyTurn()
        {
            Random random = new Random();

            int x, y;

            do
            {
                x = random.Next(GameDef.board_cell_length);
                y = random.Next(GameDef.board_cell_length);

            } while (Model.GetBoardByCopy()[y][x] != ChessType.None);

            bool isPutSuccessful = PutChess(x, y);
            RoleMgr.ChangeNextRole();
        }
    }
}
