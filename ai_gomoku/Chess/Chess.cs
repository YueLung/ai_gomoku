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

        public Chess()
        {
            ControlList = new List<Control>();

            pictureBox = new PictureBox();
            pictureBox.Size = new System.Drawing.Size(50, 50);
            pictureBox.BackColor = System.Drawing.Color.Transparent;

            label = new Label();
            label.Location = new System.Drawing.Point(10, 10);
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            label.ForeColor = System.Drawing.Color.Red;

            ControlList.Add(label);
            ControlList.Add(pictureBox);  
        }

        public void SetPositionPixel(int x, int y)
        {
            pictureBox.Location = new System.Drawing.Point(x, y);

            label.Text = Player.TotalTurn.ToString();
            label.Location = new System.Drawing.Point(x + 18, y + 18);
        }

        public void SetPositionByCoordinate(int x, int y)
        {
            int Cell_Length = Form1.CELL_LENGTH;

            SetPositionPixel((x + 1) * Cell_Length - 20, (y + 1) * Cell_Length - 20);
        }
    }
}
