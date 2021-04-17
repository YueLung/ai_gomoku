namespace ai_gomoku
{
    class BlackChess : Chess
    {
        public BlackChess() : base()
        {
            pictureBox.Image = Properties.Resources.black;
            label.BackColor = System.Drawing.Color.Black;

        }
    }
}
