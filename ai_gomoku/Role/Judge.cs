using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    public class Judge : RoleBase
    {
        public Judge(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
        }

        private int GetConnectCount(int volumeX, int volumeY)
        {
            int res = 0;

            var board = Model.GetBoard();

            int x = Model.LastPutPOS_X;
            int y = Model.LastPutPOS_Y;
            
            while (board[y][x] == ChessType)
            {
                res++;
                x += volumeX;
                y += volumeY;

                if ((y < 0 || y >= Model.BOARD_CELL_LENGTH) ||
                    (x < 0 || x >= Model.BOARD_CELL_LENGTH))
                {
                    break;
                }
            }

            return res;
        }

        public override void onMyTurn()
        {
            base.onMyTurn();

            if (Model.LastPutType == ChessType)
            {
                //                                                 - 1 => repeated count 1,so minus 1
                if (GetConnectCount(1, 0) + GetConnectCount(-1, 0) - 1 == GameDef.WIN_COUNT  ||
                    GetConnectCount(0, 1) + GetConnectCount(0, -1) - 1 == GameDef.WIN_COUNT  ||
                    GetConnectCount(1, 1) + GetConnectCount(-1, -1) - 1 == GameDef.WIN_COUNT ||
                    GetConnectCount(-1, 1) + GetConnectCount(1, -1) - 1 == GameDef.WIN_COUNT)
                {
                    View.ShowMsg($"{Name.Split('_')[0]} WIN !!!");
                }

                else
                {
                    RoleMgr.ChangeNextRole();
                }
            }
            else
            {
                System.Console.WriteLine($"{Name} judge error type");
            }
        }
    }
}
