using System;

namespace ai_gomoku.Command
{
    public class ClickCommand : CommandBase
    {
        public bool IsValid { get; }
        public int Board_X { get; }
        public int Board_Y { get; }

        public int View_X { get; }
        public int View_Y { get; }

        public ClickCommand(String name, int cursor_x, int cursor_y) : base(name)
        {
            const int Cell_Length = Form1.CELL_LENGTH;

            int x = cursor_x - Form1.FIRST_CELL_X;
            int y = cursor_y - Form1.FIRST_CELL_Y;

            const int ACCEPT_CLICK_WIDTH = Cell_Length / 3;


            if ((x % Cell_Length < ACCEPT_CLICK_WIDTH || x % Cell_Length > 2 * ACCEPT_CLICK_WIDTH) &&
                 (y % Cell_Length < ACCEPT_CLICK_WIDTH || y % Cell_Length > 2 * ACCEPT_CLICK_WIDTH))
            {
                IsValid = true;

                int posx, posy;

                if (x % Cell_Length < ACCEPT_CLICK_WIDTH)
                    posx = (x / Cell_Length) * Cell_Length;
                else
                    posx = (x / Cell_Length) * Cell_Length + Cell_Length;

                if (y % Cell_Length < ACCEPT_CLICK_WIDTH)
                    posy = (y / Cell_Length) * Cell_Length;
                else
                    posy = (y / Cell_Length) * Cell_Length + Cell_Length;

                View_X = posx + Form1.FIRST_CELL_X;
                View_Y = posy + Form1.FIRST_CELL_Y;

                Board_X = (posx / Cell_Length);
                Board_Y = (posy / Cell_Length);

                if (Board_X < 0 || Board_X >= GameDef.board_cell_length ||
                    Board_Y < 0 || Board_Y >= GameDef.board_cell_length)
                {
                    IsValid = false;
                }
            }
            else
            {
                IsValid = false;
            }
        }
    }
}
