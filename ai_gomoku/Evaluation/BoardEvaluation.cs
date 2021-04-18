using System;
using System.Collections.Generic;
using System.Linq;


namespace ai_gomoku.Evaluation
{
    class BoardEvaluation : OnePointEvaluation
    {
        public BoardEvaluation() {}
        public override int GetScore(Model model, ChessType chessType)
        {
            int res = 0;

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    var board = model.GetBoardByCopy();

                    if (board[y][x] == chessType)
                    {
                        res += GetOnePointScore(model, x, y, chessType);
                    }
                    else if (board[y][x] == Utility.GetOppositeChessType(chessType))
                    {
                        ChessType enemyChessType = Utility.GetOppositeChessType(chessType);
                        res -= GetOnePointScore(model, x, y, enemyChessType);
                    }
                }
            }

            return res;
        }
        protected override int GetOnePointScore(Model model, int posX, int posY, ChessType posChessType)
        {
            int score = GetAttackLineScore(AttackDirection.Horizontal, model, posX, posY, posChessType) +
                        GetAttackLineScore(AttackDirection.Vertical, model, posX, posY, posChessType) +
                        GetAttackLineScore(AttackDirection.RightOblique, model, posX, posY, posChessType) +
                        GetAttackLineScore(AttackDirection.LeftOblique, model, posX, posY, posChessType);

            if (posChessType == ChessType.Black)
                score = (int)(score * 1.0);

            return score;
        }
        protected override int CalculateAttackScore(AttackDirectionInfo directionInfo_1, AttackDirectionInfo directionInfo_2)
        {
            int res = 0;

            int totalConnectCount = directionInfo_1.ConnectCount + directionInfo_2.ConnectCount - 1;
            int liveCount = 0;

            if (directionInfo_1.IsLive) liveCount += 1;
            if (directionInfo_2.IsLive) liveCount += 1;

            if (totalConnectCount >= 5)
            {
                res = 100000;
            }
            else if (totalConnectCount == 4)
            {
                if (liveCount == 2)
                    res = 100000;  
                else if (liveCount == 1)
                    res = 250;    
                else if (liveCount == 0)
                    res = 0;
            }
            else if (totalConnectCount == 3)
            {
                if (liveCount == 2)
                    res = 333;
                else if (liveCount == 1)
                    res = 33;
                else if (liveCount == 0)
                    res = 0;
            }
            else if (totalConnectCount == 2)
            {
                if (liveCount == 2)
                    res = 50;
                else if (liveCount == 1)
                    res = 5;
                else if (liveCount == 0)
                    res = 0;
            }
            else if (totalConnectCount == 1)
            {
                if (liveCount == 2)
                    res = 10;
                else if (liveCount == 1)
                    res = 1;
                else if (liveCount == 0)
                    res = 0;
            }

            return res;
        }
    }
}
