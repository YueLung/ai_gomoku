using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    public class AIComputerPlayer : Player
    {
        public AIComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        { 
        }

        private void GetScore(List<List<ChessType>> board, int x, int y)
        {
            
        }

        public override void onMyTurn()
        {
            for (int i = 0; i < Model.BOARD_CELL_LENGTH; i++) 
            {
                for (int j = 0; j < Model.BOARD_CELL_LENGTH; j++)
                {
                    var board = Model.GetBoard();

                    if (board[i][j] == ChessType.None)
                    {
                        
                    }
                }
            }
        }
    }
}
