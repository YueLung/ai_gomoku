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

            if (Model.PrepareCheckedChessType == MyChessType)
            {
                if (ConnectStrategy.IsWin(MyChessType))
                {
                    View.ShowMsg($"{Name.Split('_')[0]} ({Name.Split('_')[3]}) WIN !!!");
                    System.Console.WriteLine($"{Name.Split('_')[0]} ({Name.Split('_')[3]}) WIN !!!");
                }
                else if (ConnectStrategy.IsTie())
                {
                    System.Console.WriteLine($"It's tie !!!");
                    View.ShowMsg($"It's tie !!!");
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
