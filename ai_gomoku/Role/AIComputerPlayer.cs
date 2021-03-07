using System;
using System.Collections.Generic;

namespace ai_gomoku.Role
{
    struct Pos { public int x; public int y; }

    public class AIComputerPlayer : Player
    {
        public AIComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        { 
        }

        public override void onMyTurn()
        {
            base.onMyTurn();
            View.ShowMsg($"Turn : {Name}");

            var board = Model.GetBoardByCopy();

            int bestScore = -1;

            Pos bestPos;
            bestPos.x = -1;
            bestPos.y = -1;

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    if (board[y][x] == ChessType.None)
                    {
                        board[y][x] = MyChessType;
                        ChessType nextchessType = MyChessType == ChessType.Black ? ChessType.White : ChessType.Black;

                        int score = MinMaxSearch(board, 0, nextchessType, false);

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestPos.x = x;
                            bestPos.y = y;
                        }
                    }
                }
            }


            bool isPutSuccessful = putChess(bestPos.x, bestPos.y);

            if (isPutSuccessful)
            {
                Chess myChess = ChessFactory.CreateChess(MyChessType);
                myChess.SetPositionByCoordinate(bestPos.x, bestPos.y);

                View.PutChessOnView(myChess);

                RoleMgr.ChangeNextRole();
            }
  
        }

        private int MinMaxSearch(List<List<ChessType>> board, int depth, ChessType chessType, bool isMaxLayer)
        {
            int bestScore = isMaxLayer ? -1 : 9999999;

            if (depth == 0) 
            {
                int score = getBoardScore(board);
                return score;
            }
                
            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    if (board[y][x] == ChessType.None)
                    {
                        board[y][x] = chessType;
                        ChessType nextchessType = chessType == ChessType.Black ? ChessType.White : ChessType.Black;

                        int score = MinMaxSearch(board, depth - 1, nextchessType, !isMaxLayer);

                        bestScore = isMaxLayer ? Math.Max(score, bestScore) : Math.Min(score, bestScore);

                        //Console.WriteLine($"x:{i} y:{j}  depth:{depth} score:{getBoardScore(board)}");

                        board[y][x] = ChessType.None;
                    }
                }
            }

            return bestScore;
        }

        public int c = 0;
        private int getBoardScore(List<List<ChessType>> board)
        {
            //Random rnd = new Random((int)DateTime.Now.Millisecond);
            //int num = rnd.Next(0, 5);

            int[] ary = new int[] { 1, 999, 30, 30, 19 };
            int ret = ary[c];
            //Console.WriteLine($"score:{ary[c]}");
            c = (c + 1) % 5;
            
            return ret;
        }

    }
}
