using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public static class Utility
    {
        public static ChessType GetOppositeChessType(ChessType chessType)
        {
            ChessType retChess = chessType == ChessType.Black ? ChessType.White : ChessType.Black;

            return retChess;
        }
      
    }
}
