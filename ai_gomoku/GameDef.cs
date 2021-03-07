using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public class GameDef
    {
        public const String BLACK_CHESS_PLAYER = "Black_Chess_Player";

        public const String WHITE_CHESS_PLAYER = "White_Chess_Player";

        public const String BLACK_CHESS_JUDGE = "Black_Chess_Judge";

        public const String WHITE_CHESS_JUDGE = "White_Chess_Judge";

        public static int win_count = 5;

        public static int board_cell_length = 9;

        public enum PlayerType { Human, AI1, AI2, AI3X3 }


    }
}
