using System;
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

        public bool IsWinHorizontal(ChessType chessType)
        {
            return GetConnectCount(chessType, 1, 0) + GetConnectCount(chessType, -1, 0) - 1 == GameDef.WIN_COUNT;
        }
        public bool IsWinVertical(ChessType chessType)
        {
            return GetConnectCount(chessType, 0, 1) + GetConnectCount(chessType, 0, -1) - 1 == GameDef.WIN_COUNT;
        }
        public bool IsWinRightOblique(ChessType chessType)
        {
            return GetConnectCount(chessType, -1, 1) + GetConnectCount(chessType, -1, -1) - 1 == GameDef.WIN_COUNT;
        }
        public bool IsWinLeftOblique(ChessType chessType)
        {
            return GetConnectCount(chessType, 1, 1) + GetConnectCount(chessType, -1, -1) - 1 == GameDef.WIN_COUNT;
        }

        public int GetConnectCount(ChessType chessType, int volumeX, int volumeY)
        {
            int res = 0;

            var board = Model.GetBoard();

            int x = Model.LastPutPOS_X;
            int y = Model.LastPutPOS_Y;

            while (board[y][x] == chessType)
            {
                res++;
                x += volumeX;
                y += volumeY;

                if ((y < 0 || y >= Model.BOARD_CELL_LENGTH) ||
                    (x < 0 || x >= Model.BOARD_CELL_LENGTH))
                {
                    break;
                }
            }

            return res;
        }
    }
}
