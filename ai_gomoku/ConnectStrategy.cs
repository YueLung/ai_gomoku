﻿using ai_gomoku.Models;


namespace ai_gomoku
{
    public class ConnectStrategy
    {
        private GameModel _model;
        public ConnectStrategy(GameModel model)
        {
            _model = model;
        }

        public bool IsWin(ChessType chessType)
        {
            //Model.printBoard();
            return IsWinHorizontal(chessType) || IsWinVertical(chessType) || IsWinRightOblique(chessType) || IsWinLeftOblique(chessType);
        }

        public bool IsTie()
        {
            bool res = true;
            var board = _model.GetBoardByCopy();

            for (int y = 0; y < GameDef.board_cell_length; y++)
            {
                for (int x = 0; x < GameDef.board_cell_length; x++)
                {
                    if (board[y][x] == ChessType.None)
                    {
                        res = false;
                        break;
                    }
                }
            }
            return res;
        }

        private bool IsWinHorizontal(ChessType chessType)
        {
            return GetConnectCount(chessType, 1, 0) + GetConnectCount(chessType, -1, 0) - 1 >= GameDef.win_count;
        }
        private bool IsWinVertical(ChessType chessType)
        {
            return GetConnectCount(chessType, 0, 1) + GetConnectCount(chessType, 0, -1) - 1 >= GameDef.win_count;
        }
        private bool IsWinRightOblique(ChessType chessType)
        {
            return GetConnectCount(chessType, -1, 1) + GetConnectCount(chessType, 1, -1) - 1 >= GameDef.win_count;
        }
        private bool IsWinLeftOblique(ChessType chessType)
        {
            return GetConnectCount(chessType, 1, 1) + GetConnectCount(chessType, -1, -1) - 1 >= GameDef.win_count;
        }

        public int GetConnectCount(ChessType chessType, int volumeX, int volumeY)
        {
            int res = 0;

            var board = _model.GetBoardByCopy();

            int x = _model.PrepareCheckedPOS_X;
            int y = _model.PrepareCheckedPOS_Y;

            while (board[y][x] == chessType)
            {
                res++;
                x += volumeX;
                y += volumeY;

                if ((y < 0 || y >= GameDef.board_cell_length) ||
                    (x < 0 || x >= GameDef.board_cell_length))
                {
                    break;
                }
            }

            return res;
        }
    }
}
