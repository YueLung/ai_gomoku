using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ai_gomoku.Command;

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

            ComputerNextBtn.Visible = false;
            ComputerNextBtn.Enabled = false;

            ChangeComputerPlayBtn.Visible = false;
            ChangeComputerPlayBtn.Enabled = false;
        }
        public void PutChessOnView(Chess chess)
        {
            ChessList.Add(chess);

            foreach (Control control in chess.ControlList) 
            {
                this.Controls.Add(control);
                control.Refresh();
            }
        }
        public void InitViewBoard()
        {
            foreach (Chess chess in ChessList)
            {
                foreach (Control control in chess.ControlList)
                {
                    this.Controls.Remove(control);
                }   
            }
        }
        public void RemoveLastChess()
        {
            if (ChessList.Count > 0)
            {
                Chess lastChess = ChessList[ChessList.Count - 1];

                foreach (Control control in lastChess.ControlList)
                {
                    this.Controls.Remove(control);
                }
                
                ChessList.RemoveAt(ChessList.Count - 1);
            }
            else
            {
                Console.WriteLine("Cannot RemoveLastChess because ChessList.Count <= 0");
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

                ComputerNextBtn.Visible = false;
                ComputerNextBtn.Enabled = false;

                ChangeComputerPlayBtn.Visible = false;
                ChangeComputerPlayBtn.Enabled = false;
            }
        }

        private void PreviousActionBtn_Click(object sender, EventArgs e)
        {
            if (RoleMgr != null)
            {
                PreviousActionCommand previousActionCommand = new PreviousActionCommand("PreviousActionCommand", RoleMgr.IsAnyPlayerAi());
                RoleMgr.onCommand(previousActionCommand);
            }
        }
        private void ComputerNextBtn_Click(object sender, EventArgs e)
        {
            if (RoleMgr != null)
            {
                ComputerNextCommand computerNextCommand = new ComputerNextCommand("ComputerNextCommand");
                RoleMgr.onCommand(computerNextCommand);
            }
        }
        private void ChangeComputerPlayBtn_Click(object sender, EventArgs e)
        {
            if (RoleMgr != null)
            {
                ChangeComputerPlayCommand changeComputerPlayCommand = new ChangeComputerPlayCommand("ChangeComputerPlayCommand");
                RoleMgr.onCommand(changeComputerPlayCommand);
            }
        }
        private void HumanVSHuman_Btn_Click(object sender, EventArgs e)
        {
            ChangeComputerPlayBtn.Visible = true;
            ChangeComputerPlayBtn.Enabled = true;

            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.Human2, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }
        private void HumanVSAi1_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.EasyAI, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }

        private void HumanVSAi2_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.HardAI, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }

        private void AIVSAI_Btn_Click(object sender, EventArgs e)
        {
            ComputerNextBtn.Visible = true;
            ComputerNextBtn.Enabled = true;

            RoleMgr = new RoleMgr(this, GameDef.PlayerType.HardAI, GameDef.PlayerType.MediumAI, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }
        private void HumanVSAi3x3_Btn_Click(object sender, EventArgs e)
        {
            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.AI3X3, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;

            GameDef.board_cell_length = 4;
            GameDef.win_count = 4;

            RoleMgr.Start();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region panelTop drag event
        private bool isDraggabel = false;
        private int mouseX;
        private int mouseY;

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggabel = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggabel)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggabel = false;
        }
        #endregion

 
    }


}
