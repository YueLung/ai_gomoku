using ai_gomoku.Command;
using ai_gomoku.Evaluation;
using ai_gomoku.Models;
using System;
using System.Linq;

namespace ai_gomoku.Role
{
    public class HumanPlayer : Player
    {
        BoardEvaluation DebugEvaluation = new BoardEvaluation();
        
        public HumanPlayer(String name, Form1 view, GameModel model, RoleMgr roleMgr, ChessType chessType) 
            : base(name, view, model, roleMgr, chessType)
        {
            AddCommand("PreviousActionCommand", IsAllowPreviousActionCommand, OnPreviousActionCommand);
            AddCommand("ChangeComputerPlayCommand", IsAllowChangeComputerPlayCommand, OnChangeComputerPlayCommand);
            AddCommand("LoadBoardCommand", IsAllowLoadBoardCommand, OnLoadBoardCommand);
            AddCommand("ClickCommand", IsAllowClickCommand, OnClickCommand);
        }

        private bool IsAllowPreviousActionCommand()
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
        private bool OnPreviousActionCommand(CommandBase command)
        {
            Console.WriteLine("onPreviousActionCommand");

            if (command is PreviousActionCommand)
            {
                PreviousActionCommand previousActionCommand = command as PreviousActionCommand;

                if (previousActionCommand.IsEnemyAi)
                {
                    if (Model.GetBoard().Any(x => x.Any(y => y == MyChessType)))
                    {
                        //todo hard code
                        TotalTurn -= 2;
                        Model.PreviousAction();
                        Model.PreviousAction();
                        View.RemoveLastChess();
                        View.RemoveLastChess();
                        OnMyTurn();
                    }
                    else
                    {
                        Console.WriteLine("Not exit my chess,cant regret");
                    }

                }
                else
                {
                    TotalTurn--;
                    Model.PreviousAction();
                    View.RemoveLastChess();
                    RoleMgr.PreviousPlayer();
                }
                
                return true;
            }
            else
            {
                Console.WriteLine("command is not PreviousActionCommand");
                return false;
            }   
        }

        private bool IsAllowChangeComputerPlayCommand()
        {
            return true;
        }
        private bool OnChangeComputerPlayCommand(CommandBase command)
        {
            if (command is ChangeComputerPlayCommand)
            {
                RoleMgr.ChangeComputerToPlay();
                return true;
            }
            else
            { 
                Console.WriteLine("command is not ChangeComputerPlayCommand");
                return false;
            }
        }

        private bool IsAllowLoadBoardCommand()
        {
            //only 0 turn can load board
            if (TotalTurn == 0)
                return true;
            else
                return false;
        }
        private bool OnLoadBoardCommand(CommandBase command)
        {
            Console.WriteLine("onLoadBoardCommand");
            RoleMgr.LoadBorad();
            return true;
        }

        private bool IsAllowClickCommand()
        {
            return true;
        }
        private bool OnClickCommand(CommandBase command)
        {
            if (command is ClickCommand)
            {
                ClickCommand clickCommand = command as ClickCommand;

                if (clickCommand.IsValid)
                {
                    bool isPutSuccessful = PutChess(clickCommand.Board_X, clickCommand.Board_Y);

                    //Model.PrintBoard();

                    RoleMgr.ChangeNextRole();

                    int boardScore = DebugEvaluation.GetScore(Model, MyChessType);
                    Console.WriteLine($"ChessType = {MyChessType.ToString()}   Board Score = {boardScore.ToString()}");
                    
                    return true;
                }
                else
                {
                    Console.WriteLine($"Not valid position");

                    return false;
                }
            }
            else
            {
                Console.WriteLine("command is not ClickCommand");

                return false;
            } 
        }

        public override void OnMyTurn()
        {
            base.OnMyTurn();
        }
    }
}
