using ai_gomoku.Models;
using System;

namespace ai_gomoku.Role
{
    class MinMaxSearchInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Score { get; set; }
        public GameModel Model { get; set; }
        public MinMaxSearchInfo(int x, int y, int score)
        {
            this.X = x;
            this.Y = y;
            this.Score = score;
        }
    }

    class AIComputer3X3Player : Player
    {
        enum BoradStatus { Winlose, Tie, Nothing}

        private int MinMaxSearchCount = 0;

        private int SearchHasResultCount = 0;

        public AIComputer3X3Player(String name, Form1 view, GameModel model, RoleMgr roleMgr, ChessType chessType) 
            : base(name, view, model, roleMgr, chessType)
        {
        }

        public override void OnMyTurn()
        {
            base.OnMyTurn();

            if (TotalTurn == 1)
            {
                System.Console.WriteLine($"AI Turn 1");
                bool isPutSuccessful = PutChess(GameDef.board_cell_length/2, GameDef.board_cell_length/2);
            }
            else
            {
                MinMaxSearchCount = 0;
                MinMaxSearchInfo bestPosInfo = MinMaxSearch(Model, MyChessType, true, 0, int.MinValue, int.MaxValue);

                System.Console.WriteLine($"MinMaxSearchCount = {MinMaxSearchCount.ToString()}");
                System.Console.WriteLine($"SearchHasResultCount = {SearchHasResultCount.ToString()}");

                bool isPutSuccessful = PutChess(bestPosInfo.X, bestPosInfo.Y);
            }
           
        }

        private MinMaxSearchInfo MinMaxSearch(GameModel pModel, ChessType chessType, bool isMaxLayer, int depth, int alpha, int beta)
        {
            MinMaxSearchCount++;
            int bestScore = isMaxLayer ? -999 : 999;
            MinMaxSearchInfo bestPosInfo = new MinMaxSearchInfo(-1, -1, bestScore);
            Console.WriteLine($"depth: {depth} isMaxLayer: {isMaxLayer} MinMaxSearchCount: {MinMaxSearchCount.ToString()} alpha: {alpha.ToString()} beta: {beta}");
            
            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    var board = pModel.GetBoardByCopy();
                    if (board[y][x] == ChessType.None)
                    {
                        GameModel cloneModel = pModel.Clone() as GameModel;
                        cloneModel.PutChessToBoard(x, y, chessType);

                        int score = 0;
                        BoradStatus boradStatus = GetBoardStatus(cloneModel, chessType);

                        if (boradStatus == BoradStatus.Nothing) //沒有勝負 繼續往下找
                        {
                            ChessType nextChessType = Utility.GetOppositeChessType(chessType);
                            MinMaxSearchInfo info = MinMaxSearch(cloneModel, nextChessType, !isMaxLayer, depth + 1, alpha, beta);

                            //--------- alpha-beta pruning ---------
                            if (isMaxLayer)
                                alpha = Math.Max(alpha, info.Score);
                            else
                                beta = Math.Min(beta, info.Score);

                            if (alpha >= beta)
                                return info;
                            //--------------------------------------

                            score = info.Score;
                        }
                        else if (boradStatus == BoradStatus.Winlose)
                        {
                            SearchHasResultCount++;
                            score = MyChessType == chessType  ? 1 : -1;//If chess is mychessType get 1 point else get -1 point 
                        }
                        else if (boradStatus == BoradStatus.Tie)
                        {
                            SearchHasResultCount++;
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

        private BoradStatus GetBoardStatus(GameModel model, ChessType chessType)
        {
            BoradStatus status = BoradStatus.Nothing;
            ConnectStrategy connectStrategy = new ConnectStrategy(model);

            if (connectStrategy.IsWin(chessType))
                status = BoradStatus.Winlose;
            else if (connectStrategy.IsTie())
                status = BoradStatus.Tie;

            return status;
        }

    }
   
}
