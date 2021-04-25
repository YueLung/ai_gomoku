using System.Collections.Generic;
using System.Windows.Forms;

using ai_gomoku.Role;

namespace ai_gomoku
{
    abstract public class Chess
    {
        public List<Control> ControlList;

        protected Label label;

        protected PictureBox pictureBox;

        private const int PICTURE_WIDTH = 35;

        private const int PICTURE_HEIGHT = 35;

        public Chess()
        {
            ControlList = new List<Control>();

            pictureBox = new PictureBox();
            pictureBox.Size = new System.Drawing.Size(PICTURE_WIDTH, PICTURE_HEIGHT);
            pictureBox.BackColor = System.Drawing.Color.Transparent;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            label = new Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            label.ForeColor = System.Drawing.Color.Red;

            ControlList.Add(label);
            ControlList.Add(pictureBox);  
        }

        public void SetPositionPixel(int x, int y)
        {
            pictureBox.Location = new System.Drawing.Point(x, y);

            string txtOnChess = Player.TotalTurn.ToString();

            label.Text = txtOnChess;

            if (txtOnChess.Length > 1)
                label.Location = new System.Drawing.Point(x + 8, y + 8);
            else
                label.Location = new System.Drawing.Point(x + 10, y + 10);
        }

        public void SetPositionByCoordinate(int x, int y)
        {
            int Cell_Length = Form1.CELL_LENGTH;

            SetPositionPixel(Form1.FIRST_CELL_X - (PICTURE_WIDTH / 2) + (x * Cell_Length), 
                             Form1.FIRST_CELL_Y - (PICTURE_HEIGHT / 2) + (y * Cell_Length) );
        }
    }
}
