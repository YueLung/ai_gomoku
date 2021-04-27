using System;
using System.Linq;
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

        private BoardEvaluation MyEvaluation = new BoardEvaluation();

        /// <summary>
        /// param searchDepth should odd ex:1,3,5..  
        /// </summary>
        /// <param name="name"></param>
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <param name="roleMgr"></param>
        /// <param name="chessType"></param>
        /// <param name="searchDepth"></param>
        public MinMaxComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType, int searchDepth) : base(name, view, model, roleMgr, chessType)
        {
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

                bestPosInfo.Model.PrintBoard();

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
                     
            //          y,   x,  score
            List<Tuple<int, int, int>> OrderPosScoreList =  GetPossibleBestPosOrderList(pModel, chessType);
   
            foreach (Tuple<int, int, int> PosScoreTuple in OrderPosScoreList)
            {
                
                int y = PosScoreTuple.Item1;
                int x = PosScoreTuple.Item2;

                //int score = PosScoreTuple.Item3;
                Model cloneModel = pModel.Clone() as Model;
                cloneModel.PutChessToBoard(x, y, chessType);

                bool isWin = false;

                int score = 0;
                Model bestModel;

                //when anyone win, stop search
                //isWin = MyEvaluation.IsEndSearch(cloneModel, chessType);
                ConnectStrategy connectStrategy = new ConnectStrategy(cloneModel);
                isWin = connectStrategy.IsWin(chessType) || connectStrategy.IsTie();

                if (depth == MinMaxSearchDepth || isWin)
                {
                    SearchHasResultCount++;
                    score = MyEvaluation.GetScore(cloneModel, MyChessType);

                    bestModel = cloneModel;

                    //cloneModel.PrintBoard();
                    //Console.WriteLine($"y: {y}  x: {x} score: {score}");
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
                    bestModel = info.Model;
                }

                if (depth == 0)
                {
                    Console.WriteLine($"y: {y}  x: {x} score: {score} depth: {depth}");
                    //bestModel.PrintBoard();
                }
                if (isWin)
                {
                    //Console.WriteLine($"Win happen y: {y}  x: {x} score: {score} depth: {depth}");
                    //bestModel.PrintBoard();
                }

                if (isMaxLayer)
                {
                    if (score > bestPosInfo.Score)
                    {
                        bestPosInfo.Score = score;
                        bestPosInfo.X = x;
                        bestPosInfo.Y = y;
                        bestPosInfo.Model = bestModel;
                    }
                }
                else
                {
                    if (score < bestPosInfo.Score)
                    {
                        bestPosInfo.Score = score;
                        bestPosInfo.X = x;
                        bestPosInfo.Y = y;
                        bestPosInfo.Model = bestModel;
                    }
                }
            }

            #region Not use find order list
            /*
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
                            isWin = connectStrategy.IsWin(chessType) || connectStrategy.IsTie();

                            //when anyone win, stop search
                            //isWin = MyEvaluation.IsEndSearch(cloneModel, chessType);

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
            */
            #endregion

            return bestPosInfo;
        }

        private List<Tuple<int, int, int>> GetPossibleBestPosOrderList(Model pModel, ChessType chessType)
        {
            List<Tuple<int, int, int>> posScoreList = new List<Tuple<int, int, int>>();

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    var board = pModel.GetBoardByCopy();
                    if (board[y][x] == ChessType.None)
                    {
                        Model cloneModel = pModel.Clone() as Model;
                        cloneModel.PutChessToBoard(x, y, chessType);

                        OnePointEvaluation onePointEvaluation = new OnePointEvaluation();

                        int score = onePointEvaluation.GetScore(cloneModel, chessType);

                        posScoreList.Add(new Tuple<int, int, int>(y, x, score));
                    }
                }
            }
            //          y,   x,  score
            List<Tuple<int, int, int>> OrderPosScoreList = posScoreList.OrderByDescending(x => x.Item3).ToList();

            OrderPosScoreList = OrderPosScoreList.GetRange(0, 10);


            return OrderPosScoreList;
        }

        //only find 2 cell range.  ex: (0,0)  find max range = (2,2) , so (2-0)^2 + (2-0)^2 = 8
        private const int SEACH_RANGE_SQUARE = 8;
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
