using ai_gomoku.Factory;
using ai_gomoku.Models;
using System;

namespace ai_gomoku.Role
{
    public abstract class Player : RoleBase
    {
        public static int TotalTurn = 0;
        public Player(String name, Form1 view, GameModel model, RoleMgr roleMgr, ChessType chessType) 
            : base(name, view, model, roleMgr, chessType)
        {
            //TotalTurn = 0;
        }

        public override void OnMyTurn()
        {
            base.OnMyTurn();
            View.ShowMsg($"Turn : {Name}      TotalTurn = {TotalTurn}");         
        }

        public bool PutChess(int x, int y)
        {
            bool isSuccessful = Model.PutChessToBoard(x, y, MyChessType);

            if (isSuccessful)
            {
                TotalTurn++;
                ChessBase myChess = ChessFactory.CreateChess(MyChessType);
                myChess.SetPositionByCoordinate(x, y);

                View.PutChessOnView(myChess);
            }

            return isSuccessful;
        }

        public static void InitTotalTurn()
        {
            TotalTurn = 0;
        }
    }
}
