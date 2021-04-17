using System;
using System.Collections.Generic;

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
            }
            else
            {
                MinMaxSearchCount = 0;
                MinMaxSearchInfo bestPosInfo = MinMaxSearch(Model, MyChessType, true, 0, int.MinValue, int.MaxValue);

                System.Console.WriteLine($"MinMaxSearchCount = {MinMaxSearchCount.ToString()}");
                System.Console.WriteLine($"SearchHasResultCount = {SearchHasResultCount.ToString()}");
                System.Console.WriteLine($"X = {bestPosInfo.X.ToString()} Y = {bestPosInfo.Y.ToString()} Score = {bestPosInfo.Score.ToString()}");

                bool isPutSuccessful = PutChess(bestPosInfo.X, bestPosInfo.Y);
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
                    var board = pModel.GetBoardByCopy();
                    if (board[y][x] == ChessType.None)
                    {
                        Model cloneModel = pModel.Clone() as Model;
                        cloneModel.PutChessToBoard(x, y, chessType);

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
                            ChessType nextChessType = Utility.GetOppositeChessType(chessType);
                            MinMaxSearchInfo info = MinMaxSearch(cloneModel, nextChessType, !isMaxLayer, depth + 1, alpha, beta);
  
                            //if (isMaxLayer)
                            //    alpha = Math.Max(alpha, info.Score);
                            //else
                            //    beta = Math.Min(beta, info.Score);

                            //if (alpha >= beta)
                            //    return info;

                            score = info.Score;
                        }

                        if (depth == 0)
                        {
                            Console.WriteLine($"y: {y}  x: {x} score: {score} depth: {depth}");
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

    }
}
