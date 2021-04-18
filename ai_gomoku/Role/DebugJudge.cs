using System;
using System.Collections.Generic;

using ai_gomoku.Command;

namespace ai_gomoku.Role
{
    class DebugJudge : RoleBase
    {
        protected ConnectStrategy ConnectStrategy;

        public DebugJudge(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
            ConnectStrategy = new ConnectStrategy(model);

            addCommand("ComputerNextCommand", isAllowComputerNextCommand, onComputerNextCommand);
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
                }
            }
            else
            {
                System.Console.WriteLine($"{Name} judge error type");
            }
        }

        private bool isAllowComputerNextCommand()
        {
            return true;
        }
        private bool onComputerNextCommand(CommandBase command)
        {
            if (command is ComputerNextCommand)
            {
                RoleMgr.ChangeNextRole();
                return true;
            }
            else
            {
                Console.WriteLine("command is not ComputerNextCommand");
                return false;
            }
        }
    }
}
