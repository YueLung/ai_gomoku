using System;

using ai_gomoku.Evaluation;

namespace ai_gomoku.Role
{
    /// <summary>
    /// Jsut find max score on empty cell 
    /// </summary>
    class EasyComputerPlayer : Player
    {
        private OnePointEvaluation MyEvaluation = new OnePointEvaluation();
        public EasyComputerPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
        }
        public override void onMyTurn()
        {
            base.onMyTurn();

            int bestScore = int.MinValue;
            int bestX = -1;
            int bestY = -1;

            if (TotalTurn == 0)
            {
                System.Console.WriteLine($"AI Turn 1");
                bool isPutSuccessful = PutChess(GameDef.board_cell_length / 2, GameDef.board_cell_length / 2);
                RoleMgr.ChangeNextRole();
            }
            else
            {

                for (int y = 0; y < GameDef.board_cell_length; y++)
                {
                    for (int x = 0; x < GameDef.board_cell_length; x++)
                    {
                        var board = Model.GetBoardByCopy();
                        if (board[y][x] == ChessType.None)
                        {
                            Model cloneModel = Model.Clone() as Model;

                            int score = MyEvaluation.GetScore(cloneModel, y, x, MyChessType);

                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestX = x;
                                bestY = y;
                            }
                        }
                    }
                }

                bool isPutSuccessful = PutChess(bestX, bestY);
                RoleMgr.ChangeNextRole();
            }
        }
    }
}
