using ai_gomoku.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(GameDef.PlayerType type, String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType)
        {
            switch (type)
            {
                case GameDef.PlayerType.Human:
                    Console.WriteLine($"Create a Human Player. ChessType is {chessType}");
                    return new HumanPlayer(name, view, model, roleMgr, chessType);
                    break;
                case GameDef.PlayerType.AI1:
                    Console.WriteLine($"Create a AI1 Player. ChessType is {chessType}");
                    return new RandomComputerPlayer(name, view, model, roleMgr, chessType);
                    break;
                case GameDef.PlayerType.AI2:
                    Console.WriteLine($"Create a AI2 Player. ChessType is {chessType}");
                    return new AIComputerPlayer(name, view, model, roleMgr, chessType);
                    break;
                case GameDef.PlayerType.AI3X3:
                    Console.WriteLine($"Create a AI3X3 Player. ChessType is {chessType}");
                    return new AIComputer3X3Player(name, view, model, roleMgr, chessType);
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
