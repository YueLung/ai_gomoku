﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_gomoku.Role
{
    public abstract class Player : RoleBase
    {
        public Player(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
        }

        public bool putChess(int x, int y)
        {
            bool isSuccessful = Model.PutChessToBoard(x, y, MyChessType);

            return isSuccessful;
        }
    }
}
