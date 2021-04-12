using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Evaluation
{
    public enum AttackDirection { Horizontal, Vertical, RightOblique, LeftOblique };
    public enum DefenseDirection { Left,UpperLeft,Up, UpperRight, Right,LowerRight, Down, LowerLeft};
    public class AttackDirectionInfo
    {
        public int ConnectCount { get; set; }

        public bool IsLive { get; set; }
    }
    public class OnePointEvaluation : IEvaluation
    {
        public OnePointEvaluation(){}
        public virtual int GetScore(Model model, ChessType myChessType)
        {
            int posX = model.PrepareCheckedPOS_X;
            int posY = model.PrepareCheckedPOS_Y;
            ChessType posChessType = model.PrepareCheckedChessType;

            int score = GetOnePointScore(model, posX, posY, posChessType);

            //if (model.PrepareCheckedChessType != myChessType)
            //    score = -1 * score;

            return score;
            #region before
            //int boardScore = 0;
            //int[] scoreTable = new int[] { 0, 2, 30, 150, 800, 9999, 9999, 9999, 9999 };

            //Model copyModel = model.Clone() as Model;
            //ConnectStrategy connectStrategy = new ConnectStrategy(copyModel);

            //List<List<ChessType>> board = copyModel.GetBoard();

            //for (int y = 0; y < GameDef.board_cell_length; y++)
            //{
            //    for (int x = 0; x < GameDef.board_cell_length; x++)
            //    {
            //        if (board[y][x] != ChessType.None)
            //        {
            //            ChessType curChessType = board[y][x];

            //            copyModel.PrepareCheckedChessType = curChessType;
            //            copyModel.PrepareCheckedPOS_X = x;
            //            copyModel.PrepareCheckedPOS_Y = y;

            //            int connectCount = 0;
            //            int onePosScore = 0;

            //            connectCount = connectStrategy.GetConnectCount(curChessType, 1, 0);
            //            //Console.WriteLine($"connectCount = {connectCount}");
            //            onePosScore += scoreTable[connectCount];

            //            connectCount = connectStrategy.GetConnectCount(curChessType, 0, 1);
            //            onePosScore += scoreTable[connectCount];

            //            connectCount = connectStrategy.GetConnectCount(curChessType, -1, 1);
            //            onePosScore += scoreTable[connectCount];

            //            connectCount = connectStrategy.GetConnectCount(curChessType, 1, 1);
            //            onePosScore += scoreTable[connectCount];

            //            if (curChessType == myChessType)
            //                boardScore += onePosScore;
            //            else
            //                boardScore -= onePosScore;
            //        }
            //    }
            //}

            //return boardScore;
            #endregion
        }

        protected int GetOnePointScore(Model model, int posX, int posY, ChessType posChessType)
        {
            int score = GetAttackLineScore(AttackDirection.Horizontal, model, posX, posY, posChessType) +
                           GetAttackLineScore(AttackDirection.Vertical, model, posX, posY, posChessType) +
                           GetAttackLineScore(AttackDirection.RightOblique, model, posX, posY, posChessType) +
                           GetAttackLineScore(AttackDirection.LeftOblique, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.Left, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.UpperLeft, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.Up, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.UpperRight, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.Right, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.LowerRight, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.Down, model, posX, posY, posChessType) +
                           GetDefenseLineScore(DefenseDirection.LowerLeft, model, posX, posY, posChessType);
            return score;
        }

        private int GetAttackLineScore(AttackDirection attackDirection, Model model, int posX, int posY, ChessType posChessType)
        {
            int res = 0;

            AttackDirectionInfo directionInfoRight;
            AttackDirectionInfo directionInfoLeft;

            switch (attackDirection)
            {
                case AttackDirection.Horizontal:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, 1, 0);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, -1, 0);

                    res = CalculateAttackScore(directionInfoRight, directionInfoLeft);
                    break;
                case AttackDirection.Vertical:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, 0, 1);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, 0, -1);

                    res = CalculateAttackScore(directionInfoRight, directionInfoLeft);
                    break;
                case AttackDirection.RightOblique:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, -1, 1);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, 1, -1);

                    res = CalculateAttackScore(directionInfoRight, directionInfoLeft);
                    break;
                case AttackDirection.LeftOblique:
                    directionInfoRight = GetAttackConnectInfo(model, posX, posY, posChessType, 1, 1);
                    directionInfoLeft = GetAttackConnectInfo(model, posX, posY, posChessType, -1, -1);

                    res = CalculateAttackScore(directionInfoRight, directionInfoLeft);
                    break;
            }

            return res;
        }
        private int GetDefenseLineScore(DefenseDirection defenseDirection, Model model, int posX, int posY, ChessType posChessType)
        {
            int res = 0;
            int connentCount;

            switch (defenseDirection)
            {
                case DefenseDirection.Left:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, -1, 0);
                    res = CalculateDefenseScore(connentCount);
                    break;
                case DefenseDirection.UpperLeft:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, -1, -1);
                    res = CalculateDefenseScore(connentCount);
                    break;
                case DefenseDirection.Up:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, 0, -1);
                    res = CalculateDefenseScore(connentCount);
                    break;
                case DefenseDirection.UpperRight:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, 1, -1);
                    res = CalculateDefenseScore(connentCount);
                    break;
                case DefenseDirection.Right:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, 1, 0);
                    res = CalculateDefenseScore(connentCount);
                    break;
                case DefenseDirection.LowerRight:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, 1, 1);
                    res = CalculateDefenseScore(connentCount);
                    break;
                case DefenseDirection.Down:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, 0, 1);
                    res = CalculateDefenseScore(connentCount);
                    break;
                case DefenseDirection.LowerLeft:
                    connentCount = GetDefenseConnectCount(model, posX, posY, posChessType, -1, 1);
                    res = CalculateDefenseScore(connentCount);
                    break;
            }

            return res;
        }
        private AttackDirectionInfo GetAttackConnectInfo(Model model, int posX, int posY, ChessType posChessType, int volumeX, int volumeY)
        {
            AttackDirectionInfo res = new AttackDirectionInfo();
            int connectCount = 0;

            var board = model.GetBoardByCopy();

            while (board[posY][posX] == posChessType)
            {
                connectCount++;
                posX += volumeX;
                posY += volumeY;

                if ((posY < 0 || posY >= GameDef.board_cell_length) ||
                    (posX < 0 || posX >= GameDef.board_cell_length))
                {
                    break;
                }
            }

            res.ConnectCount = connectCount;

            if ((posY < 0 || posY >= GameDef.board_cell_length) ||
                (posX < 0 || posX >= GameDef.board_cell_length))
            {
                res.IsLive = false;
            }
            else
            {
                if (board[posY][posX] == ChessType.None)
                {
                    res.IsLive = true;
                }
                else if (board[posY][posX] == posChessType)
                {
                    Console.WriteLine("Error impossible...");
                }
                else
                {
                    res.IsLive = false;
                }
            }

            return res;
        }
        private int CalculateAttackScore(AttackDirectionInfo directionInfo_1, AttackDirectionInfo directionInfo_2)
        {
            int res = 0;

            int totalConnectCount = directionInfo_1.ConnectCount + directionInfo_2.ConnectCount - 1;
            int liveCount = 0;

            if (directionInfo_1.IsLive) liveCount += 1;
            if (directionInfo_2.IsLive) liveCount += 1;

            if (totalConnectCount >= 5)
            {
                res = 999999;
            }
            else if (totalConnectCount == 4)
            {
                if (liveCount == 2)
                    res = 999999;
                else if (liveCount == 1)
                    res = 6000;
                else if (liveCount == 0)
                    res = 0;
            }
            else if (totalConnectCount == 3)
            {
                if (liveCount == 2)
                    res = 1200;
                else if (liveCount == 1)
                    res = 800;
                else if (liveCount == 0)
                    res = 0;
            }
            else if (totalConnectCount == 2)
            {
                if (liveCount == 2)
                    res = 500;
                else if (liveCount == 1)
                    res = 300;
                else if (liveCount == 0)
                    res = 0;
            }
            else if (totalConnectCount == 1)
            {
                if (liveCount == 2)
                    res = 125;
                else if (liveCount == 1)
                    res = 70;
                else if (liveCount == 0)
                    res = 0;
            }

            return res;
        }
        private int GetDefenseConnectCount(Model model, int posX, int posY, ChessType posChessType,int volumeX, int volumeY)
        {
            int res = 0;

            var board = model.GetBoardByCopy();

            int x = posX + volumeX;
            int y = posY + volumeY;

            ChessType chessType = Utility.GetOppositeChessType(posChessType);

            if ((y < 0 || y >= GameDef.board_cell_length) ||
                (x < 0 || x >= GameDef.board_cell_length))
            {
                return res;
            }

            while (board[y][x] == chessType )
            {
                res++;
                x += volumeX;
                y += volumeY;

                if ((y < 0 || y >= GameDef.board_cell_length) ||
                    (x < 0 || x >= GameDef.board_cell_length))
                {
                    break;
                }
            }

            return res;
        }
        private int CalculateDefenseScore(int connect)
        {
            int res = 0;

            if (connect >= 4)
            {
                res = 15000;
            }
            else if (connect == 3)
            {
                res = 1500;
            }
            else if (connect == 2)
            {
                res = 400;
            }
            else if (connect == 1)
            {
                res = 120;
            }

            return res;
        }
    }
}