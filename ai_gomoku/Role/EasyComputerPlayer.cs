﻿using System;

using ai_gomoku.Evaluation;

namespace ai_gomoku.Role
{
    class EasyComputerPlayer : Player
    {
        private IEvaluation MyEvaluation;
        public EasyComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType, IEvaluation evaluation) : base(name, view, model, roleMgr, chessType)
        {
            MyEvaluation = evaluation;
        }
        public override void onMyTurn()
        {
            base.onMyTurn();
            int bestScore = int.MinValue;
            int bestX = -1;
            int bestY = -1;

            if (TotalTurn == 0)
            {
                System.Console.WriteLine($"AI Turn 1");
                bool isPutSuccessful = PutChess(GameDef.board_cell_length / 2, GameDef.board_cell_length / 2);
            }
            else
            {

                for (int y = 0; y < GameDef.board_cell_length; y++)
                {
                    for (int x = 0; x < GameDef.board_cell_length; x++)
                    {
                        var board = Model.GetBoardByCopy();
                        if (board[y][x] == ChessType.None)
                        {
                            Model cloneModel = Model.Clone() as Model;
                            cloneModel.PutChessToBoard(x, y, MyChessType);

                            int score = 0;
                            score = MyEvaluation.GetScore(cloneModel, MyChessType);

                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestX = x;
                                bestY = y;
                            }
                        }
                    }
                }

                bool isPutSuccessful = PutChess(bestX, bestY);
            }
        }
    }
}