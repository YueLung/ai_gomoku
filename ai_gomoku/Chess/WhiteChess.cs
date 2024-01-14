namespace ai_gomoku
{
    class WhiteChess : ChessBase 
    {
        public WhiteChess() : base()
        {
            pictureBox.Image = Properties.Resources.white;
            label.BackColor = System.Drawing.Color.White;
        }
    }
}
