﻿using System;
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
                ReNewBtn.PerformClick();
                HomePanel.Visible = true;
                RoleMgr = null;
            }
        }
        private void HumanVSHuman_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human, GameDef.PlayerType.Human);
            HomePanel.Visible = false;
        }
        private void HumanVSAi1_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human, GameDef.PlayerType.AI1);
            HomePanel.Visible = false;
        }

        private void HumanVSAi2_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human, GameDef.PlayerType.AI2);
            HomePanel.Visible = false;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


}