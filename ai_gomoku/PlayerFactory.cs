using System;

using ai_gomoku.Evaluation;
using ai_gomoku.Role;

namespace ai_gomoku
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(GameDef.PlayerType type, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType)
        {
            switch (type)
            {
                case GameDef.PlayerType.Human1:
                    Console.WriteLine($"Create a Human Player. ChessType is {chessType}");
                    return new HumanPlayer("Human1 " + chessType, view, model, roleMgr, chessType);
                    break;
                case GameDef.PlayerType.Human2:
                    Console.WriteLine($"Create a Human Player. ChessType is {chessType}");
                    return new HumanPlayer("Human2 " + chessType, view, model, roleMgr, chessType);
                    break;
                case GameDef.PlayerType.EasyAI:
                    Console.WriteLine($"Create a EasyAI Player. ChessType is {chessType}");
                    return new MinMAXComputerPlayer("EasyAI " + chessType, view, model, roleMgr, chessType, new OnePointEvaluation(), 0);
                    break;
                case GameDef.PlayerType.HardAI:
                    Console.WriteLine($"Create a HardAI Player. ChessType is {chessType}");
                    return new MinMAXComputerPlayer("HardAI " + chessType, view, model, roleMgr, chessType, new BoardEvaluation(), 1);
                    break;
                case GameDef.PlayerType.AI3X3:
                    Console.WriteLine($"Create a AI3X3 Player. ChessType is {chessType}");
                    return new AIComputer3X3Player("AI3X3 " + chessType, view, model, roleMgr, chessType);
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
