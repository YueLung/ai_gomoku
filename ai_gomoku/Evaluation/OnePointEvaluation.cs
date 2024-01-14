using ai_gomoku.Models;
using System;

namespace ai_gomoku.Evaluation
{
    public enum AttackDirection { Horizontal, Vertical, RightOblique, LeftOblique };
    public enum DefenseDirection { Left,UpperLeft,Up, UpperRight, Right,LowerRight, Down, LowerLeft};

    public class AttackDirectionInfo
    {
        public int ConnectCount { get; set; }
        public bool IsLive { get; set; }
    }
    public class DefenseDirectionInfo
    {
        public int EnemyConnectCount { get; set; }
        public bool IsEnemyLive { get; set; }
    }

    public class OnePointEvaluation
    {
        public OnePointEvaluation(){}
        public int GetScore(GameModel model, int y, int x, ChessType chessType)
        {
            GameModel attackCloneModel = model.Clone() as GameModel;
            GameModel defenseCloneModel = model.Clone() as GameModel;

            ChessType enemyChessType = Utility.GetOppositeChessType(chessType);

            attackCloneModel.PutChessToBoard(x, y, chessType);
            defenseCloneModel.PutChessToBoard(x, y, enemyChessType);


            //int posX = model.PrepareCheckedPOS_X;
            //int posY = model.PrepareCheckedPOS_Y;
            //ChessType posChessType = model.PrepareCheckedChessType;

            int attackScore  = GetOnePointScore(attackCloneModel, x, y, chessType);
            int defenseScore = GetOnePointScore(defenseCloneModel, x, y, enemyChessType);

            int totalScore = (int)(1.05 * attackScore) + defenseScore;

            return totalScore;
        }
        protected virtual int GetOnePointScore(GameModel model, int posX, int posY, ChessType posChessType)
        {
            int score = GetAttackLineScore(AttackDirection.Horizontal, model, posX, posY, posChessType) +
                        GetAttackLineScore(AttackDirection.Vertical, model, posX, posY, posChessType) +
                        GetAttackLineScore(AttackDirection.RightOblique, model, posX, posY, posChessType) +
                        GetAttackLineScore(AttackDirection.LeftOblique, model, posX, posY, posChessType);

                        //GetDefenseLineScore(DefenseDirection.Left, model, posX, posY, posChessType) +
                        //GetDefenseLineScore(DefenseDirection.UpperLeft, model, posX, posY, posChessType) +
                        //GetDefenseLineScore(DefenseDirection.Up, model, posX, posY, posChessType) +
                        //GetDefenseLineScore(DefenseDirection.UpperRight, model, posX, posY, posChessType) +
                        //GetDefenseLineScore(DefenseDirection.Right, model, posX, posY, posChessType) +
                        //GetDefenseLineScore(DefenseDirection.LowerRight, model, posX, posY, posChessType) +
                        //GetDefenseLineScore(DefenseDirection.Down, model, posX, posY, posChessType) +
                        //GetDefenseLineScore(DefenseDirection.LowerLeft, model, posX, posY, posChessType);

            return score;
        }
        protected int GetAttackLineScore(AttackDirection attackDirection, GameModel model, int posX, int posY, ChessType posChessType)
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
        protected int GetDefenseLineScore(DefenseDirection defenseDirection, GameModel model, int posX, int posY, ChessType posChessType)
        {
            int res = 0;

            DefenseDirectionInfo defenseDirectionInfo;

            switch (defenseDirection)
            {
                case DefenseDirection.Left:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, -1, 0);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
                case DefenseDirection.UpperLeft:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, -1, -1);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
                case DefenseDirection.Up:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, 0, -1);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
                case DefenseDirection.UpperRight:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, 1, -1);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
                case DefenseDirection.Right:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, 1, 0);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
                case DefenseDirection.LowerRight:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, 1, 1);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
                case DefenseDirection.Down:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, 0, 1);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
                case DefenseDirection.LowerLeft:
                    defenseDirectionInfo = GetDefenseConnectCount(model, posX, posY, posChessType, -1, 1);
                    res = CalculateDefenseScore(defenseDirectionInfo);
                    break;
            }

            return res;
        }
        protected AttackDirectionInfo GetAttackConnectInfo(GameModel model, int posX, int posY, ChessType posChessType, int volumeX, int volumeY)
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
        protected virtual int CalculateAttackScore(AttackDirectionInfo directionInfo_1, AttackDirectionInfo directionInfo_2)
        {
            int res = 0;

            int totalConnectCount = directionInfo_1.ConnectCount + directionInfo_2.ConnectCount - 1;
            int liveCount = 0;

            if (directionInfo_1.IsLive) liveCount += 1;
            if (directionInfo_2.IsLive) liveCount += 1;

            if (totalConnectCount >= 5)
            {
                res = 2000000;
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
                    res = 1800;
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
                    res = 250;
                else if (liveCount == 0)
                    res = 0;
            }
            else if (totalConnectCount == 1)
            {
                if (liveCount == 2)
                    res = 125;
                else if (liveCount == 1)
                    res = 50;
                else if (liveCount == 0)
                    res = 0;
            }

            return res;
        }
        protected DefenseDirectionInfo GetDefenseConnectCount(GameModel model, int posX, int posY, ChessType posChessType,int volumeX, int volumeY)
        {
            DefenseDirectionInfo defenseDirectionInfo = new DefenseDirectionInfo();

            defenseDirectionInfo.EnemyConnectCount = 0;
            defenseDirectionInfo.IsEnemyLive = false;

            var board = model.GetBoardByCopy();

            int x = posX + volumeX;
            int y = posY + volumeY;

            ChessType enemyChessType = Utility.GetOppositeChessType(posChessType);

            if ((y < 0 || y >= GameDef.board_cell_length) ||
                (x < 0 || x >= GameDef.board_cell_length))
            {
                return defenseDirectionInfo;
            }

            while (board[y][x] == enemyChessType)
            {
                defenseDirectionInfo.EnemyConnectCount++;

                x += volumeX;
                y += volumeY;

                if ((y < 0 || y >= GameDef.board_cell_length) ||
                    (x < 0 || x >= GameDef.board_cell_length))
                {
                    break;
                }
            }

            if ((y < 0 || y >= GameDef.board_cell_length) ||
                (x < 0 || x >= GameDef.board_cell_length))
            {
                defenseDirectionInfo.IsEnemyLive = false;
            }
            else
            {
                if (board[y][x] == ChessType.None)
                {
                    defenseDirectionInfo.IsEnemyLive = true;
                }
            }

            return defenseDirectionInfo;
        }
        protected int CalculateDefenseScore(DefenseDirectionInfo defenseDirectionInfo)
        {
            int res = 0;
            int connect = defenseDirectionInfo.EnemyConnectCount;
            bool isLive = defenseDirectionInfo.IsEnemyLive;

            if (connect >= 4)
            {
                res = 1000000;
            }
            else if (connect == 3)
            {
                if (isLive)
                {
                    res = 4000;
                }
                else
                {
                    res = 2000;
                }             
            }
            else if (connect == 2)
            {
                if (isLive)
                {
                    res = 400;
                }
                else
                {
                    res = 200;
                }
            }
            else if (connect == 1)
            {
                if (isLive)
                {
                    res = 150;
                }
                else
                {
                    res = 75;
                }    
            }

            return res;
        }
    }
}