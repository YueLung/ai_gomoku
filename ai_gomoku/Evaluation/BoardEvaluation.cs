using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        res -= GetOnePointScore(model, x, y, Utility.GetOppositeChessType(chessType));
                    }
                }
            }

            return res;
        }  
        
    }
}
