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
            Console.WriteLine($"Board is {GameDef.board_cell_length} x {GameDef.board_cell_length}");

            View = view;

            Model = new Model();

            Random random = new Random();
            int order1 = (random.Next(0, 2)) * 2;
            int order2 = order1 == 2 ? 0 : 2;

            int num = random.Next(0, 2); //0、1
            GameDef.PlayerType blackPlayer = num == 0 ? player1 : player2;
            GameDef.PlayerType whitePlayer = num == 0 ? player2 : player1; 

            RoleOrderMap.Add(order1, PlayerFactory.CreatePlayer(blackPlayer, View, Model, this, ChessType.Black));
            RoleOrderMap.Add(order1 + 1, new Judge(GameDef.BLACK_CHESS_JUDGE, View, Model, this, ChessType.Black));
            RoleOrderMap.Add(order2, PlayerFactory.CreatePlayer(whitePlayer, View, Model, this, ChessType.White));
            RoleOrderMap.Add(order2 + 1, new Judge(GameDef.WHITE_CHESS_JUDGE, View, Model, this, ChessType.White));

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

            OrderNum = 0;
            CurrentTurnRole = RoleOrderMap[OrderNum];
            CurrentTurnRole.onMyTurn();
        }

        public void ReturnHome()
        {
            Model.init();

            View.InitViewBoard();
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
