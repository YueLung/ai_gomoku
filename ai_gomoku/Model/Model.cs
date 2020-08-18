using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public enum ChessType { None, Black, White }

    public class Model
    {
        public const int BOARD_CELL_LENGTH = 9;

        private List<List<ChessType>> Board;

        public ChessType LastPutType { get; private set; }
        public int LastPutPOS_X { get; private set; }
        public int LastPutPOS_Y { get; private set; }

        public Model()
        {
            init();
        }

        public void init()
        {
            Board = new List<List<ChessType>>();

            for (int i = 0; i < BOARD_CELL_LENGTH; ++i)
            {
                List<ChessType> list = new List<ChessType>();
                
                for (int j = 0; j < BOARD_CELL_LENGTH; ++j)
                {
                    list.Add(ChessType.None);
                }

                Board.Add(list);
            }    
        }
        public List<List<ChessType>> GetBoard()
        {
            List<List<ChessType>> copyBoard = new List<List<ChessType>>();
            for (int i = 0; i < Board.Count(); i++)
            {
                List<ChessType> rowList = new List<ChessType>(Board[i]);
                copyBoard.Add(rowList);
            }

            return copyBoard;
        }
        public bool PutChessToBoard(int x, int y, ChessType chessType)
        {
            if (x >= BOARD_CELL_LENGTH || x < 0 || y >= BOARD_CELL_LENGTH || y < 0)
                return false;

            if (Board[y][x] == ChessType.None)
            {
                Board[y][x] = chessType;

                LastPutType = chessType;
                LastPutPOS_X = x;
                LastPutPOS_Y = y;

                return true;
            }
        
            return false;
        }
    }
}
