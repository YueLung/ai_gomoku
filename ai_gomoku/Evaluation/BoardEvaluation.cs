using System;
using System.Collections.Generic;
using System.Linq;


namespace ai_gomoku.Evaluation
{
    public class BoardEvaluation : OnePointEvaluation
    {
        public BoardEvaluation() {}

        public bool IsEndSearch(Model model, ChessType chessType)
        {
            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    var board = model.GetBoardByCopy();

                    if (board[y][x] == chessType)
                    {
                        bool isAbsoluteWin;
                        isAbsoluteWin = IsLineWin(AttackDirection.Horizontal, model, x, y, chessType) ||
                                        IsLineWin(AttackDirection.Vertical, model, x, y, chessType) ||
                                        IsLineWin(AttackDirection.RightOblique, model, x, y, chessType) ||
                                        IsLineWin(AttackDirection.LeftOblique, model, x, y, chessType);

                        if (isAbsoluteWin)
                            return true;
                    }
                }
            }

            return false;
        }
        private bool IsLineWin(AttackDirection attackDirection, Model model, int posX, int posY, ChessType posChessType)
        {
            bool res = false;

            AttackDirectionInfo directionInfoRight;
            AttackDirectionInfo directionInfoLeft;

            switch (attackDirection)
            {
                case AttackDirection.Horizontal:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, 1, 0);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, -1, 0);

                    res = JudgeWin(directionInfoRight, directionInfoLeft);
                    break;
                case AttackDirection.Vertical:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, 0, 1);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, 0, -1);

                    res = JudgeWin(directionInfoRight, directionInfoLeft);
                    break;
                case AttackDirection.RightOblique:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, -1, 1);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, 1, -1);

                    res = JudgeWin(directionInfoRight, directionInfoLeft);
                    break;
                case AttackDirection.LeftOblique:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, 1, 1);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, -1, -1);

                    res = JudgeWin(directionInfoRight, directionInfoLeft);
                    break;
            }

            return res;
        }
        private bool JudgeWin(AttackDirectionInfo directionInfo_1, AttackDirectionInfo directionInfo_2)
        {
            bool res = false;

            int totalConnectCount = directionInfo_1.ConnectCount + directionInfo_2.ConnectCount - 1;
            int liveCount = 0;

            if (directionInfo_1.IsLive) liveCount += 1;
            if (directionInfo_2.IsLive) liveCount += 1;

            if (totalConnectCount >= 5)
            {
                res = true;
            }
            else if (totalConnectCount == 4)
            {
                if (liveCount == 2)
                    res = true;
            }

            return res;
        }


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
                res = 200000;
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
