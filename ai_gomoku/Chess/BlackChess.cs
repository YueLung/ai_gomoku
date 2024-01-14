namespace ai_gomoku
{
    class BlackChess : ChessBase
    {
        public BlackChess() : base()
        {
            pictureBox.Image = Properties.Resources.black;
            label.BackColor = System.Drawing.Color.Black;
        }
    }
}
