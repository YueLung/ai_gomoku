using System;
using System.Collections.Generic;

using ai_gomoku.Role;

namespace ai_gomoku
{
    public static class JudgeFactory
    {
        public static RoleBase CreateJudge(GameDef.JudgeType type, String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType)
        {
            Console.WriteLine($"Create a {type.ToString()} Judge. ChessType is {chessType}");

            switch (type)
            {
                case GameDef.JudgeType.Nomal:
                    return new Judge(name, view, model, roleMgr, chessType);
                    break;
                case GameDef.JudgeType.Debug:
                    return new DebugJudge(name, view, model, roleMgr, chessType);
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}