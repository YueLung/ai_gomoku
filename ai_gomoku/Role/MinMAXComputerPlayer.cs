﻿using ai_gomoku.Evaluation;
using ai_gomoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ai_gomoku.Role
{
    public class MinMaxComputerPlayer : Player
    {
        private int _minMaxSearchDepth;

        private int _minMaxSearchCount = 0;

        private int _searchHasResultCount = 0;

        private BoardEvaluation _boardEvaluation = new BoardEvaluation();

        private OnePointEvaluation _onePointEvaluation = new OnePointEvaluation();

        /// <summary>
        /// param searchDepth should odd ex:1,3,5..  
        /// </summary>
        /// <param name="name"></param>
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <param name="roleMgr"></param>
        /// <param name="chessType"></param>
        /// <param name="searchDepth"></param>
        public MinMaxComputerPlayer(String name, Form1 view, GameModel model, RoleMgr roleMgr, ChessType chessType, int searchDepth)
            : base(name, view, model, roleMgr, chessType)
        {
            _minMaxSearchDepth = searchDepth;
        }
        public override void OnMyTurn()
        {
            base.OnMyTurn();

            if (TotalTurn == 0)
            {
                Console.WriteLine($"AI Turn 1");
                bool isPutSuccessful = PutChess(GameDef.board_cell_length / 2, GameDef.board_cell_length / 2);

                RoleMgr.ChangeNextRole();
            }
            else
            {
                _minMaxSearchCount = 0;
                MinMaxSearchInfo bestPosInfo = MinMaxSearch(Model, MyChessType, true, 0, int.MinValue, int.MaxValue);

                Console.WriteLine($"MinMaxSearchCount = {_minMaxSearchCount.ToString()}");
                Console.WriteLine($"SearchHasResultCount = {_searchHasResultCount.ToString()}");
                Console.WriteLine($"Turn: {(TotalTurn + 1).ToString()}  {Name} Y = {bestPosInfo.Y.ToString()} X = {bestPosInfo.X.ToString() } Score = {bestPosInfo.Score.ToString()}");
                bestPosInfo.Model.PrintBoard();

                bool isPutSuccessful = PutChess(bestPosInfo.X, bestPosInfo.Y);
                RoleMgr.ChangeNextRole();
            }
        }

        private MinMaxSearchInfo MinMaxSearch(GameModel pModel, ChessType chessType, bool isMaxLayer, int depth, int alpha, int beta)
        {
            _minMaxSearchCount++;
            int bestScore = isMaxLayer ? int.MinValue : int.MaxValue;
            MinMaxSearchInfo bestPosInfo = new MinMaxSearchInfo(-1, -1, bestScore);
            //Console.WriteLine($"depth: {depth} isMaxLayer: {isMaxLayer} MinMaxSearchCount: {MinMaxSearchCount.ToString()} alpha: {alpha.ToString()} beta: {beta}");

            //          y,   x,  score
            List<Tuple<int, int, int>> OrderPosScoreList = GetPossibleBestPosOrderList(pModel, chessType);

            foreach (Tuple<int, int, int> PosScoreTuple in OrderPosScoreList)
            {
                int y = PosScoreTuple.Item1;
                int x = PosScoreTuple.Item2;

                GameModel cloneModel = pModel.Clone() as GameModel;
                cloneModel.PutChessToBoard(x, y, chessType);

                bool isWin = false;
                bool isTie = false;

                int tmpScore = 0;
                GameModel tmpModel;

                //when anyone win or tie, stop search
                ConnectStrategy connectStrategy = new ConnectStrategy(cloneModel);
                isWin = connectStrategy.IsWin(chessType);
                isTie = connectStrategy.IsTie();

                if (isWin)
                {
                    Console.WriteLine($"win happen");
                    _searchHasResultCount++;

                    MinMaxSearchInfo Info = new MinMaxSearchInfo(x, y, isMaxLayer ? int.MaxValue - 1 : int.MinValue + 1);
                    Info.Model = cloneModel;

                    return Info;
                }

                if (depth == _minMaxSearchDepth || isTie)
                {
                    _searchHasResultCount++;
                    tmpScore = _boardEvaluation.GetScore(cloneModel, MyChessType);

                    tmpModel = cloneModel;

                    //cloneModel.PrintBoard();
                    //Console.WriteLine($"y: {y}  x: {x} score: {score}");
                }
                else
                {
                    ChessType nextChessType = Utility.GetOppositeChessType(chessType);
                    MinMaxSearchInfo info = MinMaxSearch(cloneModel, nextChessType, !isMaxLayer, depth + 1, alpha, beta);

                    //===== alpha beta pruning ===== 
                    if (isMaxLayer)
                        alpha = Math.Max(alpha, info.Score);
                    else
                        beta = Math.Min(beta, info.Score);

                    if (alpha >= beta)
                        return info;
                    //=============================== 

                    tmpScore = info.Score;
                    tmpModel = info.Model;
                }

                if (isMaxLayer)
                {
                    if (tmpScore > bestPosInfo.Score)
                    {
                        bestPosInfo.Score = tmpScore;
                        bestPosInfo.X = x;
                        bestPosInfo.Y = y;
                        bestPosInfo.Model = tmpModel;
                    }
                }
                else
                {
                    if (tmpScore < bestPosInfo.Score)
                    {
                        bestPosInfo.Score = tmpScore;
                        bestPosInfo.X = x;
                        bestPosInfo.Y = y;
                        bestPosInfo.Model = tmpModel;
                    }
                }


                if (depth == 0)
                {
                    Console.WriteLine($"y: {y}  x: {x} score: {tmpScore} depth: {depth}  MinMaxSearchCount = {_minMaxSearchCount.ToString()}");
                    //bestModel.PrintBoard();
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

        private List<Tuple<int, int, int>> GetPossibleBestPosOrderList(GameModel pModel, ChessType chessType)
        {
            const int FIND_COUNT = 10;

            List<Tuple<int, int, int>> posScoreList = new List<Tuple<int, int, int>>();

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    var board = pModel.GetBoardByCopy();
                    if (board[y][x] == ChessType.None)
                    {
                        GameModel cloneModel = pModel.Clone() as GameModel;

                        int score = _onePointEvaluation.GetScore(cloneModel, y, x, chessType);

                        posScoreList.Add(new Tuple<int, int, int>(y, x, score));
                    }
                }
            }
            //         y,   x,  score                                   order score by Descending   
            List<Tuple<int, int, int>> OrderPosScoreList = posScoreList.OrderByDescending(x => x.Item3).ToList();

            if (OrderPosScoreList.Count > FIND_COUNT)
                OrderPosScoreList = OrderPosScoreList.GetRange(0, FIND_COUNT);

            return OrderPosScoreList;
        }

        //only find 2 cell range.  ex: (0,0)  find max range = (2,2) , so (2-0)^2 + (2-0)^2 = 8
        //private const int SEACH_RANGE_SQUARE = 8;
        //private bool IsPosNeedSearch(List<List<ChessType>> board, int CenterX, int CenterY) 
        //{
        //    bool res = false;

        //    for (int y = 0; y < GameDef.board_cell_length; y++)
        //    {
        //        for (int x = 0; x < GameDef.board_cell_length; x++)
        //        {
        //            int r = (int)(Math.Pow((CenterX - x), 2) + Math.Pow((CenterY - y), 2));

        //            if (r != 0 && r <= SEACH_RANGE_SQUARE)
        //            {
        //                if (board[y][x] != ChessType.None)
        //                {
        //                    res = true;
        //                }
        //            }        
        //        }
        //    }

        //    return res;
        //}

    }
}
