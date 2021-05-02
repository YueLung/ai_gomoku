using System;
using System.Collections.Generic;
using System.Linq;


using ai_gomoku.Command;

namespace ai_gomoku.Role
{
    public class Judge : RoleBase
    {
        protected ConnectStrategy ConnectStrategy;
        public Judge(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
            ConnectStrategy = new ConnectStrategy(model);

            addCommand("PreviousActionCommand", isAllowPreviousActionCommand, onPreviousActionCommand);
        }
        public override void AppendName(string appendName)
        {
            Name = Name + appendName;
        }

        private bool isAllowPreviousActionCommand()
        {
            if (Model.GetChessTotalCount() > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("ChessTotalCount <= 0");
                return false;
            }
        }
        private bool onPreviousActionCommand(CommandBase command)
        {
            Console.WriteLine("onPreviousActionCommand");

            if (command is PreviousActionCommand)
            {
                PreviousActionCommand previousActionCommand = command as PreviousActionCommand;

                if (previousActionCommand.IsEnemyAi)
                {
                    //judge has my chessType
                    if (Model.GetBoard().Any(x => x.Any(y => y == MyChessType)))
                    {
                        //todo hard code
                        Player.TotalTurn -= 2;
                        Model.PreviousAction();
                        Model.PreviousAction();
                        View.RemoveLastChess();
                        View.RemoveLastChess();
                        RoleMgr.PreviousPlayerByJudgeContainAI();
                    }
                    else
                    {
                        Console.WriteLine("Not exit my chess,cant regret");
                    }
                }
                else
                {
                    Player.TotalTurn--;
                    Model.PreviousAction();
                    View.RemoveLastChess();
                    RoleMgr.PreviousPlayerByJudge();
                }
                
                return true;
            }
            else
            {
                Console.WriteLine("command is not PreviousActionCommand");
                return false;
            }
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
