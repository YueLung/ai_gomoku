using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        }
        public void PutChessOnView(Chess chess)
        {
            ChessList.Add(chess);

            this.Controls.Add(chess);
            chess.Refresh();

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
            MsgLabel.Refresh();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (RoleMgr != null)
            {
                ClickCommand clickCommand = new ClickCommand("ClickCommand", e.X, e.Y);
                RoleMgr.onCommand(clickCommand);
            }
        }
        private void ReNewBtn_Click(object sender, EventArgs e)
        {
            if (RoleMgr != null)
            {
                RenewCommand renewCommand = new RenewCommand("RenewCommand");
                RoleMgr.onCommand(renewCommand);
            }
        }
        private void ReturnHomeBtn_Click(object sender, EventArgs e)
        {
            if (RoleMgr != null)
            {
                ReturnHomeCommand returnHomeCommand = new ReturnHomeCommand("ReturnHomeCommand");
                RoleMgr.onCommand(returnHomeCommand);


                HomePanel.Visible = true;
                RoleMgr = null;
            }
        }
        private void HumanVSHuman_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.Human2);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }
        private void HumanVSAi1_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.AI1);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }

        private void HumanVSAi2_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.AI2);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }

        private void HumanVSAi3x3_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.AI3X3);
            HomePanel.Visible = false;

            GameDef.board_cell_length = 3;
            GameDef.win_count = 3;

            RoleMgr.Start();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }


}
