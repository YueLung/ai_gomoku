using ai_gomoku.Models;

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
