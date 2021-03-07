using ai_gomoku.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
  
    public class RoleMgr
    {
        private Dictionary<int, RoleBase> RoleOrderMap = new Dictionary<int, RoleBase>();
        
        private RoleBase CurrentTurnRole;

        private Model Model;

        private Form1 View;

        private int OrderNum;

        public RoleMgr(Form1 view, GameDef.PlayerType player1, GameDef.PlayerType player2)
        {
            View = view;

            Model = new Model();

            RoleOrderMap.Add(0, PlayerFactory.CreatePlayer(player1, GameDef.BLACK_CHESS_PLAYER, View, Model, this, ChessType.Black));
            RoleOrderMap.Add(1, new Judge(GameDef.BLACK_CHESS_JUDGE, View, Model, this, ChessType.Black));
            RoleOrderMap.Add(2, PlayerFactory.CreatePlayer(player2, GameDef.WHITE_CHESS_PLAYER, View, Model, this, ChessType.White));
            RoleOrderMap.Add(3, new Judge(GameDef.WHITE_CHESS_JUDGE, View, Model, this, ChessType.White));

            OrderNum = 0;
            CurrentTurnRole = RoleOrderMap[OrderNum];
            CurrentTurnRole.onMyTurn();

            Console.WriteLine($"Board is {GameDef.board_cell_length} x {GameDef.board_cell_length}");
        }

        public void RenewGame()
        {
            Model.init();

            View.InitViewBoard();

            OrderNum = 0;
            CurrentTurnRole = RoleOrderMap[OrderNum];
            CurrentTurnRole.onMyTurn();
        }
        public void ChangeNextRole()
        {
            OrderNum++;

            if (OrderNum >= RoleOrderMap.Count)
            {
                OrderNum = 0;
            }

            CurrentTurnRole = RoleOrderMap[OrderNum];
            CurrentTurnRole.onMyTurn();
        }
        public void onCommand(Command command)
        {
            CurrentTurnRole.onCommand(command);
        }
    }
}
