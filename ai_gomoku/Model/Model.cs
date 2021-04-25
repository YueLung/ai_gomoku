using System;
using System.Collections.Generic;
using System.Linq;

namespace ai_gomoku
{
    public enum ChessType { None, Black, White }
    public class ChessPos
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ChessPos(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Model: ICloneable
    {
        private List<List<ChessType>> Board;

        private List<ChessPos> ChessOrderList;

        public ChessType PrepareCheckedChessType { get; set; }
        public int PrepareCheckedPOS_X { get; set; }
        public int PrepareCheckedPOS_Y { get; set; }

        public Model()
        {
            init();
        }
        public void init()
        {
            if (Board != null) Board = null;
            if (ChessOrderList != null) ChessOrderList = null;

            Board = new List<List<ChessType>>();
            ChessOrderList = new List<ChessPos>();

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
        public List<List<ChessType>> GetBoard()
        {
            return Board;
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
        public int GetChessTotalCount()
        {
            return ChessOrderList.Count;
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

                ChessOrderList.Add(new ChessPos(x, y));

                PrepareCheckedChessType = chessType;
                PrepareCheckedPOS_X = x;
                PrepareCheckedPOS_Y = y;

                return true;
            }
        
            return false;
        }
        public void PreviousAction()
        {
            if (ChessOrderList.Count > 0)
            {
                Board[ChessOrderList.Last().Y][ChessOrderList.Last().X] = ChessType.None;
                ChessOrderList.RemoveAt(ChessOrderList.Count - 1);
            }
            else
            {
                Console.WriteLine("Cannot PreviousAction becuse ChessOrderList.Count <= 0");
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine("=======================================");
            Console.Write("   ");
            for (int i = 0; i < GameDef.board_cell_length; ++i)
                Console.Write($"{i.ToString(),-7}");

            Console.WriteLine();

            for (int i = 0; i < GameDef.board_cell_length; ++i)
            {
                Console.Write($"{i.ToString(), -3}");
                for (int j = 0; j < GameDef.board_cell_length; ++j)
                {
                    Console.Write($"{Board[i][j], -7}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("=======================================");
        }
        public object Clone()
        {
            Model clone = new Model();

            clone.Board = GetBoardByCopy();
            clone.PrepareCheckedChessType = PrepareCheckedChessType;
            clone.PrepareCheckedPOS_X = PrepareCheckedPOS_X;
            clone.PrepareCheckedPOS_Y = PrepareCheckedPOS_Y;

            return clone;
        }
    }
}
