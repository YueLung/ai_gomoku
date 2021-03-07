﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    class minMaxSearchInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Score { get; set; }
        public minMaxSearchInfo(int x, int y, int score)
        {
            this.X = x;
            this.Y = y;
            this.Score = score;
        }
    }

    class AIComputer3X3Player : Player
    {
        enum BoradStatus { Winlose, Tie, Nothing}

        public AIComputer3X3Player(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
        }

        public override void onMyTurn()
        {
            base.onMyTurn();
            View.ShowMsg($"Turn : {Name}");

            minMaxSearchInfo bestPosInfo = MinMaxSearch(Model, MyChessType, true, 0);

            bool isPutSuccessful = putChess(bestPosInfo.X, bestPosInfo.Y);

            if (isPutSuccessful)
            {
                Chess myChess = ChessFactory.CreateChess(MyChessType);
                myChess.SetPositionByCoordinate(bestPosInfo.X, bestPosInfo.Y);

                View.PutChessOnView(myChess);

                RoleMgr.ChangeNextRole();
            }
        }

        private minMaxSearchInfo MinMaxSearch(Model pModel, ChessType chessType, bool isMaxLayer, int depth)
        {
            int bestScore = isMaxLayer ? -999 : 999;
            minMaxSearchInfo bestPosInfo = new minMaxSearchInfo(-1, -1, bestScore);
            Console.WriteLine($"depth: {depth} isMaxLayer: {isMaxLayer} bestScore(Default): {bestPosInfo.Score}");

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    var board = pModel.GetBoardByCopy();
                    if (board[y][x] == ChessType.None)
                    {
                        Model cloneModel = pModel.Clone() as Model;
                        cloneModel.PutChessToBoard(x, y, chessType);

                        //int score = getBoardScore(cloneModel, chessType);
                        int score = 0;

                        BoradStatus boradStatus = getBoardStatus(cloneModel, chessType);

                        if (boradStatus == BoradStatus.Nothing) //沒有勝負 繼續往下找
                        {
                            ChessType nextChessType = getOppositeChessType(chessType);
                            minMaxSearchInfo info = MinMaxSearch(cloneModel, nextChessType, !isMaxLayer, depth + 1);
                            score = info.Score;
                        }
                        else if (boradStatus == BoradStatus.Winlose)
                        {
                            score = isMaxLayer ? 1 : -1;
                        }
                        else if (boradStatus == BoradStatus.Tie)
                        {
                            score = 0;
                        }

                        if (isMaxLayer)
                        {
                            if (score > bestPosInfo.Score)
                            {
                                bestPosInfo.Score = score;
                                bestPosInfo.X = x;
                                bestPosInfo.Y = y;
                            }
                        }
                        else 
                        {
                            if (score < bestPosInfo.Score)
                            {
                                bestPosInfo.Score = score;
                                bestPosInfo.X = x;
                                bestPosInfo.Y = y;
                            }
                        }
                    }
                }
            }

            return bestPosInfo;
        }

        private BoradStatus getBoardStatus(Model model, ChessType chessType)
        {
            BoradStatus status = BoradStatus.Nothing;
            ConnectStrategy connectStrategy = new ConnectStrategy(model);

            if (connectStrategy.isWin(chessType))
                status = BoradStatus.Winlose;
            else if (connectStrategy.isTie())
                status = BoradStatus.Tie;

            return status;
        }

        private ChessType getOppositeChessType(ChessType chessType)
        {
            ChessType retChess = chessType == ChessType.Black ? ChessType.White : ChessType.Black;

            return retChess;
        }
    }
   
}
