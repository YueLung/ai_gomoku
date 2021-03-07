﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public class ConnectStrategy
    {
        private Model Model;
        public ConnectStrategy(Model model)
        {
            Model = model;
        }

        public bool isWin(ChessType chessType)
        {
            //Model.printBoard();
            return IsWinHorizontal(chessType) || IsWinVertical(chessType) || IsWinRightOblique(chessType) || IsWinLeftOblique(chessType);
        }

        public bool isTie()
        {
            bool res = true;
            List < List < ChessType >> board = Model.GetBoardByCopy();

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
            return GetConnectCount(chessType, 1, 0) + GetConnectCount(chessType, -1, 0) - 1 == GameDef.win_count;
        }
        private bool IsWinVertical(ChessType chessType)
        {
            return GetConnectCount(chessType, 0, 1) + GetConnectCount(chessType, 0, -1) - 1 == GameDef.win_count;
        }
        private bool IsWinRightOblique(ChessType chessType)
        {
            return GetConnectCount(chessType, -1, 1) + GetConnectCount(chessType, 1, -1) - 1 == GameDef.win_count;
        }
        private bool IsWinLeftOblique(ChessType chessType)
        {
            return GetConnectCount(chessType, 1, 1) + GetConnectCount(chessType, -1, -1) - 1 == GameDef.win_count;
        }

        private int GetConnectCount(ChessType chessType, int volumeX, int volumeY)
        {
            int res = 0;

            var board = Model.GetBoardByCopy();

            int x = Model.LastPutPOS_X;
            int y = Model.LastPutPOS_Y;

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
