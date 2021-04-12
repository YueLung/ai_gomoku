using System;

namespace ai_gomoku.Role
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(String name, Form1 view, Model model, RoleMgr roleMgr, ChessType chessType) : base(name, view, model, roleMgr, chessType)
        {
            addCommand("ClickCommand", isAllowClickCommand, onClickCommand);
        }

        private bool isAllowClickCommand()
        {
            return true;
        }
        private bool onClickCommand(Command command)
        {
            if (command is ClickCommand)
            {
                ClickCommand clickCommand = command as ClickCommand;

                if (clickCommand.isValid)
                {
                    bool isPutSuccessful = putChess(clickCommand.Board_X, clickCommand.Board_Y);
                       
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            } 
        }

        public override void onMyTurn()
        {
            base.onMyTurn();
        }
    }
}
