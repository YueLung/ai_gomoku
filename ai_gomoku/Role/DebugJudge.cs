using ai_gomoku.Command;
using ai_gomoku.Models;
using System;

namespace ai_gomoku.Role
{
    class DebugJudge : RoleBase
    {
        protected ConnectStrategy ConnectStrategy;

        public DebugJudge(String name, Form1 view, GameModel model, RoleMgr roleMgr, ChessType chessType)
            : base(name, view, model, roleMgr, chessType)
        {
            ConnectStrategy = new ConnectStrategy(model);

            AddCommand("ComputerNextCommand", isAllowComputerNextCommand, onComputerNextCommand);
        }

        public override void OnMyTurn()
        {
            base.OnMyTurn();

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
