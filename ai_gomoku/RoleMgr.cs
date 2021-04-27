using System;
using System.Collections.Generic;

using ai_gomoku.Role;
using ai_gomoku.Command;
using System.Threading;

namespace ai_gomoku
{
  
    public class RoleMgr
    {
        private Dictionary<int, RoleBase> RoleOrderMap = new Dictionary<int, RoleBase>();
        
        private RoleBase CurrentTurnRole;

        private Model Model;

        private Form1 View;

        private GameDef.PlayerType P1;

        private GameDef.PlayerType P2;

        private int OrderNum;

        public RoleMgr(Form1 view, GameDef.PlayerType player1, GameDef.PlayerType player2, GameDef.JudgeType judgeType)
        {
            Console.WriteLine($"Board is {GameDef.board_cell_length} x {GameDef.board_cell_length}");

            Model = new Model();
            View = view;

            P1 = player1;
            P2 = player2;

            Random random = new Random();

            int num = random.Next(0, 2); //0、1
            GameDef.PlayerType blackPlayer = num == 0 ? P1 : P2;
            GameDef.PlayerType whitePlayer = num == 0 ? P2 : P1;

            //assume black chess order is first 
            RoleOrderMap.Add(0, PlayerFactory.CreatePlayer(blackPlayer, View, Model, this, ChessType.Black));
            RoleOrderMap.Add(1, JudgeFactory.CreateJudge(judgeType, GameDef.BLACK_CHESS_JUDGE + "_" + blackPlayer.ToString(), View, Model, this, ChessType.Black));
            RoleOrderMap.Add(2, PlayerFactory.CreatePlayer(whitePlayer, View, Model, this, ChessType.White));
            RoleOrderMap.Add(3, JudgeFactory.CreateJudge(judgeType, GameDef.WHITE_CHESS_JUDGE + "_" + whitePlayer.ToString(), View, Model, this, ChessType.White));

            OrderNum = 0;
            CurrentTurnRole = RoleOrderMap[OrderNum];
        }
        public void Start()
        {
            CurrentTurnRole.onMyTurn();
        }
        public void RenewGame()
        {
            Model.init();

            View.InitViewBoard();

            Player.InitTotalTurn();

            OrderNum = 0;
            CurrentTurnRole = RoleOrderMap[OrderNum];
            CurrentTurnRole.onMyTurn();
        }
        public void ReturnHome()
        {
            Model.init();

            View.InitViewBoard();

            Player.InitTotalTurn();
        }
        public void ChangeNextRole()
        {
            OrderNum++;

            if (OrderNum >= RoleOrderMap.Count)
            {
                OrderNum = 0;
            }

            CurrentTurnRole = RoleOrderMap[OrderNum];
            //Thread.Sleep(200);
            CurrentTurnRole.onMyTurn();
        }
        public void ChangeComputerToPlay()
        {
            GameDef.PlayerType changeAIType = GameDef.PlayerType.HardAI;

            RoleOrderMap[OrderNum] = PlayerFactory.CreatePlayer(changeAIType, View, Model, this, CurrentTurnRole.GetChessType());

            int judgeOeder = OrderNum + 1;
            RoleOrderMap[judgeOeder].AppendName($" + {changeAIType.ToString()}");

            CurrentTurnRole = RoleOrderMap[OrderNum];
            CurrentTurnRole.onMyTurn();

        }
        public void PreviousPlayer()
        {
            OrderNum -= 2;
            if (OrderNum < 0)
            {
                OrderNum = RoleOrderMap.Count - 2;
            }

            CurrentTurnRole = RoleOrderMap[OrderNum];
            CurrentTurnRole.onMyTurn();
        }
        public bool IsAnyPlayerAi()
        {
            if (P1.ToString().Contains("Human") && P2.ToString().Contains("Human"))
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        public void onCommand(CommandBase command)
        {
            CurrentTurnRole.onCommand(command);
        }
    }
}
