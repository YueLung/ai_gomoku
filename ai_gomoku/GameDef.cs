﻿using System;

namespace ai_gomoku
{
    public class GameDef
    {
        public const String BLACK_CHESS_PLAYER = "Black_Chess_Player";

        public const String WHITE_CHESS_PLAYER = "White_Chess_Player";

        public const String BLACK_CHESS_JUDGE = "Black_Chess_Judge";

        public const String WHITE_CHESS_JUDGE = "White_Chess_Judge";

        public static int win_count = 5;

        public static int board_cell_length = 15;

        public enum PlayerType { Human1, Human2,  EasyAI, MediumAI, HardAI, AI3X3, RandomAI }

        public enum JudgeType { Nomal, Debug }

    }
}
