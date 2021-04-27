﻿using System;
using System.Linq;

using ai_gomoku.Command;
using ai_gomoku.Evaluation;

namespace ai_gomoku.Role
{
    public class HumanPlayer : Player
    {
        IEvaluation DebugEvaluation;
        
        public HumanPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
            DebugEvaluation = new BoardEvaluation();

            addCommand("PreviousActionCommand", isAllowPreviousActionCommand, onPreviousActionCommand);
            addCommand("ChangeComputerPlayCommand", isAllowChangeComputerPlayCommand, onChangeComputerPlayCommand);
            addCommand("ClickCommand", isAllowClickCommand, onClickCommand);
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
                    if (Model.GetBoard().Any(x => x.Any(y => y == MyChessType)))
                    {
                        //todo hard code
                        TotalTurn -= 2;
                        Model.PreviousAction();
                        Model.PreviousAction();
                        View.RemoveLastChess();
                        View.RemoveLastChess();
                        onMyTurn();
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

        private bool isAllowChangeComputerPlayCommand()
        {
            return true;
        }
        private bool onChangeComputerPlayCommand(CommandBase command)
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

        private bool isAllowClickCommand()
        {
            return true;
        }
        private bool onClickCommand(CommandBase command)
        {
            if (command is ClickCommand)
            {
                ClickCommand clickCommand = command as ClickCommand;

                if (clickCommand.IsValid)
                {
                    bool isPutSuccessful = PutChess(clickCommand.Board_X, clickCommand.Board_Y);

                    Model.PrintBoard();

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

        public override void onMyTurn()
        {
            base.onMyTurn();
        }
    }
}
