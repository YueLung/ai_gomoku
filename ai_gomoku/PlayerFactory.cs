using System;

using ai_gomoku.Evaluation;
using ai_gomoku.Role;

namespace ai_gomoku
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(GameDef.PlayerType type, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType)
        {
            Console.WriteLine($"Create a {type.ToString()} Player. ChessType is {chessType}");

            switch (type)
            {
                case GameDef.PlayerType.Human1:
                    return new HumanPlayer("Human1 " + chessType, view, model, roleMgr, chessType);
                    break;
                case GameDef.PlayerType.Human2:
                    return new HumanPlayer("Human2 " + chessType, view, model, roleMgr, chessType);
                    break;
                case GameDef.PlayerType.EasyAI:
                    return new EasyComputerPlayer("EasyAI " + chessType, view, model, roleMgr, chessType, new OnePointEvaluation());
                    break;
                case GameDef.PlayerType.MediumAI:
                    return new MinMaxComputerPlayer("MediumAI " + chessType, view, model, roleMgr, chessType, 1);
                    break;
                case GameDef.PlayerType.HardAI:
                    return new MinMaxComputerPlayer("HardAI " + chessType, view, model, roleMgr, chessType, 3);
                    break;
                case GameDef.PlayerType.AI3X3:
                    return new AIComputer3X3Player("AI3X3 " + chessType, view, model, roleMgr, chessType);
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
