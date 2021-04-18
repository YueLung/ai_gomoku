using System;
using System.Collections.Generic;

using ai_gomoku.Command;
using ai_gomoku.Evaluation;

namespace ai_gomoku.Role
{
    public class MinMaxComputerPlayer : Player
    {
        private int MinMaxSearchDepth { get; }

        private int MinMaxSearchCount = 0;

        private int SearchHasResultCount = 0;

        private IEvaluation MyEvaluation;

        public MinMaxComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType, IEvaluation evaluation, int searchDepth) : base(name, view, model, roleMgr, chessType)
        {
            MyEvaluation = evaluation;
            MinMaxSearchDepth = searchDepth;
        }
        public override void onMyTurn()
        {
            base.onMyTurn();

            if (TotalTurn == 0)
            {
                System.Console.WriteLine($"AI Turn 1");
                bool isPutSuccessful = PutChess(GameDef.board_cell_length / 2, GameDef.board_cell_length / 2);
                RoleMgr.ChangeNextRole();
            }
            else
            {
                MinMaxSearchCount = 0;
                MinMaxSearchInfo bestPosInfo = MinMaxSearch(Model, MyChessType, true, 0, int.MinValue, int.MaxValue);

                System.Console.WriteLine($"MinMaxSearchCount = {MinMaxSearchCount.ToString()}");
                System.Console.WriteLine($"SearchHasResultCount = {SearchHasResultCount.ToString()}");
                System.Console.WriteLine($"Turn: {(TotalTurn + 1).ToString()}  {Name} Y = {bestPosInfo.Y.ToString()} X = {bestPosInfo.X.ToString() } Score = {bestPosInfo.Score.ToString()}");

                bool isPutSuccessful = PutChess(bestPosInfo.X, bestPosInfo.Y);
                RoleMgr.ChangeNextRole();
            }
        }
        private MinMaxSearchInfo MinMaxSearch(Model pModel, ChessType chessType, bool isMaxLayer, int depth, int alpha, int beta)
        {
            MinMaxSearchCount++;
            int bestScore = isMaxLayer ? int.MinValue : int.MaxValue;
            MinMaxSearchInfo bestPosInfo = new MinMaxSearchInfo(-1, -1, bestScore);
            //Console.WriteLine($"depth: {depth} isMaxLayer: {isMaxLayer} MinMaxSearchCount: {MinMaxSearchCount.ToString()} alpha: {alpha.ToString()} beta: {beta}");

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    List<List<ChessType>> board = pModel.GetBoardByCopy();
                    if (board[y][x] == ChessType.None && IsPosNeedSearch(board, x, y)) 
                    {
                        Model cloneModel = pModel.Clone() as Model;
                        cloneModel.PutChessToBoard(x, y, chessType);

                        bool isWin = false;

                        int score = 0;

                        if (depth == MinMaxSearchDepth)
                        {
                            SearchHasResultCount++;
                            score = MyEvaluation.GetScore(cloneModel, MyChessType);

                            //cloneModel.PrintBoard();
                            //Console.WriteLine($"y: {y}  x: {x} score: {score}");
                        }
                        else
                        {
                            ConnectStrategy connectStrategy = new ConnectStrategy(cloneModel);
                            isWin = connectStrategy.IsWin(chessType);

                            if (isWin)
                            {
                                score = MyEvaluation.GetScore(cloneModel, MyChessType);
                            }
                            else
                            {
                                ChessType nextChessType = Utility.GetOppositeChessType(chessType);
                                MinMaxSearchInfo info = MinMaxSearch(cloneModel, nextChessType, !isMaxLayer, depth + 1, alpha, beta);

                                if (isMaxLayer)
                                    alpha = Math.Max(alpha, info.Score);
                                else
                                    beta = Math.Min(beta, info.Score);

                                if (alpha >= beta)
                                    return info;

                                score = info.Score;
                            }

                        }

                        if (depth == 0)
                        {
                            Console.WriteLine($"y: {y}  x: {x} score: {score} depth: {depth}");
                        }

                        if (isWin)
                        {
                            Console.WriteLine($"Win happen y: {y}  x: {x} score: {score} depth: {depth}");
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

        //only find 2 cell range.  ex: (0,0)  find max range = (2,2) , so (2-0)^2 + (2-0)^2 = 8
        private const int SEACH_RANGE_SQUARE = 2;
        private bool IsPosNeedSearch(List<List<ChessType>> board, int CenterX, int CenterY) 
        {
            bool res = false;

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    int r = (int)(Math.Pow((CenterX - x), 2) + Math.Pow((CenterY - y), 2));
                    
                    if (r != 0 && r <= SEACH_RANGE_SQUARE)
                    {
                        if (board[y][x] != ChessType.None)
                        {
                            res = true;
                        }
                    }        
                }
            }

            return res;
        }
  
    }
}
