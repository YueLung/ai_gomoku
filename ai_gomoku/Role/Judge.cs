using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    public class Judge : RoleBase
    {
        private ConnectStrategy ConnectStrategy;
        public Judge(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
            ConnectStrategy = new ConnectStrategy(model);
        }
        public override void onMyTurn()
        {
            base.onMyTurn();

            if (Model.LastPutType == ChessType)
            {                                             
                if (ConnectStrategy.IsWinHorizontal(ChessType)   || ConnectStrategy.IsWinVertical(ChessType) ||
                    ConnectStrategy.IsWinRightOblique(ChessType) || ConnectStrategy.IsWinLeftOblique(ChessType)
                    )
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
