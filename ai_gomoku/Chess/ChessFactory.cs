using System;

namespace ai_gomoku
{
    public static class ChessFactory
    {
        public static Chess CreateChess(ChessType chessType)
        {
            
            switch (chessType)
            {
                case ChessType.Black:
                    return new BlackChess();
                    break;
                case ChessType.White:
                    return new WhiteChess();
                    break;
                default:
                    Console.WriteLine("Default case");
                    return null;
                    break;
            }
        }
    }
}
