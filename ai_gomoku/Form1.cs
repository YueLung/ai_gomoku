using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_gomoku
{
    public partial class Form1 : Form
    {
        public const int CELL_LENGTH = 74;

        private List<Chess> ChessList = new List<Chess>();

        private RoleMgr RoleMgr;

        public Form1()
        {
            InitializeComponent();

            RoleMgr = new RoleMgr(this);
        }

        public void PutChessOnView(Chess chess)
        {
            ChessList.Add(chess);

            this.Controls.Add(chess);
        }

        public void InitViewBoard()
        {
            foreach (Chess chess in ChessList)
            {
                this.Controls.Remove(chess);
            }
        }

        public void ShowMsg(String msg)
        {
            MsgLabel.Text = msg;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ClickCommand clickCommand = new ClickCommand("ClickCommand", e.X, e.Y);
            RoleMgr.onCommand(clickCommand);
        }

        private void ReNewBtn_Click(object sender, EventArgs e)
        {
            RenewCommand renewCommand = new RenewCommand("RenewCommand");
            RoleMgr.onCommand(renewCommand);
        }
    }


}
