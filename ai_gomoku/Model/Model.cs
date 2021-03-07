using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public enum ChessType { None, Black, White }

    public class Model: ICloneable
    {
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

            for (int i = 0; i < GameDef.board_cell_length; ++i)
            {
                List<ChessType> list = new List<ChessType>();
                
                for (int j = 0; j < GameDef.board_cell_length; ++j)
                {
                    list.Add(ChessType.None);
                }

                Board.Add(list);
            }    
        }
        public List<List<ChessType>> GetBoardByCopy()
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
            if (x >= GameDef.board_cell_length || x < 0 || y >= GameDef.board_cell_length || y < 0)
            {
                Console.WriteLine($"x:{x} y:{y}  PutChessToBoard pos exceed BOARD_CELL_LENGTH({GameDef.board_cell_length})");
                return false;
            }
                

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

        public void printBoard()
        {
            Console.WriteLine("=======================================");
            for (int i = 0; i < GameDef.board_cell_length; ++i)
            {
                for (int j = 0; j < GameDef.board_cell_length; ++j)
                {
                    Console.Write($" {Board[i][j]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("=======================================");
        }

        public object Clone()
        {
            Model clone = new Model();

            clone.Board = GetBoardByCopy();
            clone.LastPutType = LastPutType;
            clone.LastPutPOS_X = LastPutPOS_X;
            clone.LastPutPOS_Y = LastPutPOS_Y;

            return clone;
        }
    }
}
