using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    public abstract class Player : RoleBase
    {
        protected static int TotalTurn;
        public Player(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
            TotalTurn = 0;
        }

        public override void onMyTurn()
        {
            base.onMyTurn();
            View.ShowMsg($"Turn : {Name}      TotalTurn = {TotalTurn}");
            TotalTurn++;
        }

        public bool putChess(int x, int y)
        {
            bool isSuccessful = Model.PutChessToBoard(x, y, MyChessType);

            if (isSuccessful)
            {
                Chess myChess = ChessFactory.CreateChess(MyChessType);
                myChess.SetPositionByCoordinate(x, y);

                View.PutChessOnView(myChess);
                RoleMgr.ChangeNextRole();
            }

            return isSuccessful;
        }

        public static void InitTotalTurn()
        {
            TotalTurn = 0;
        }
    }
}
