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

        public ClickCommand(String name, int x, int y) : base(name)
        {
            int Cell_Length = Form1.CELL_LENGTH;

            if ((x % Cell_Length < 20 || x % Cell_Length > 54) &&
                 (y % Cell_Length < 20 || y % Cell_Length > 54))
            {
                IsValid = true;

                int posx, posy;

                if (x % Cell_Length < 20)
                    posx = (x / Cell_Length) * Cell_Length;
                else
                    posx = (x / Cell_Length) * Cell_Length + Cell_Length;

                if (y % Cell_Length < 20)
                    posy = (y / Cell_Length) * Cell_Length;
                else
                    posy = (y / Cell_Length) * Cell_Length + Cell_Length;

                View_X = posx - 20;
                View_Y = posy - 20;

                Board_X = (posx / Cell_Length) - 1;
                Board_Y = (posy / Cell_Length) - 1;

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
