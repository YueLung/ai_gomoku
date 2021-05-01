using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ai_gomoku.Command;

namespace ai_gomoku
{
    public partial class Form1 : Form
    {
        //public const int CELL_LENGTH = 74;
        public const int CELL_LENGTH = 44;

        public const int FIRST_CELL_X = 27;

        public const int FIRST_CELL_Y = 61;

        private List<Chess> ChessList = new List<Chess>();

        private RoleMgr RoleMgr;

        public Form1()
        {
            InitializeComponent();
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
            //MessageBox.Show($"X = {e.X.ToString()}   Y = {e.Y.ToString()} ");

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

                DisableComputerNextBtn();
                DisableChangeComputerPlayBtn();
            }
        }
        //悔棋
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
        private void LoadBoardBtn_Click(object sender, EventArgs e)
        {
            if (RoleMgr != null)
            {
                LoadBoardCommand loadBoardCommand = new LoadBoardCommand("LoadBoardCommand");
                RoleMgr.onCommand(loadBoardCommand);
            }
        }

        private void HumanVSHuman_Btn_Click(object sender, EventArgs e)
        {
            DisableChangeComputerPlayBtn();
            DisableComputerNextBtn();
            EnableChangeComputerPlayBtn();
            EnableLoadBoardBtn();

            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.Human2, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }
        private void HumanVSEasyAi_Btn_Click(object sender, EventArgs e)
        {
            DisableComputerNextBtn();
            EnableChangeComputerPlayBtn();
            DisableLoadBoardBtn();

            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.EasyAI, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }
        private void HumanVSMediumAi_Btn_Click(object sender, EventArgs e)
        {
            DisableComputerNextBtn();
            EnableChangeComputerPlayBtn();
            DisableLoadBoardBtn();

            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.MediumAI, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }
        private void HumanVSHardAi_Btn_Click(object sender, EventArgs e)
        {
            DisableComputerNextBtn();
            EnableChangeComputerPlayBtn();
            DisableLoadBoardBtn();

            RoleMgr = new RoleMgr(this, GameDef.PlayerType.Human1, GameDef.PlayerType.HardAI, GameDef.JudgeType.Nomal);
            HomePanel.Visible = false;
            RoleMgr.Start();
        }
        private void AIVSAI_Btn_Click(object sender, EventArgs e)
        {
            DisablePreviousActionBtn();
            DisableChangeComputerPlayBtn();
            DisableLoadBoardBtn();

            GameDef.JudgeType judgeType = GameDef.JudgeType.Nomal;

            if (judgeType == GameDef.JudgeType.Debug)
                EnableComputerNextBtn();
            else
                DisableComputerNextBtn();

            RoleMgr = new RoleMgr(this, GameDef.PlayerType.HardAI, GameDef.PlayerType.HardAI, judgeType);
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
        
        private void EnableChangeComputerPlayBtn()
        {
            ChangeComputerPlayBtn.Visible = true;
            ChangeComputerPlayBtn.Enabled = true;
        }
        private void DisableChangeComputerPlayBtn()
        {
            ChangeComputerPlayBtn.Visible = false;
            ChangeComputerPlayBtn.Enabled = false;
        }
        private void EnableComputerNextBtn()
        {
            ComputerNextBtn.Visible = true;
            ComputerNextBtn.Enabled = true;
        }
        private void DisableComputerNextBtn()
        {
            ComputerNextBtn.Visible = false;
            ComputerNextBtn.Enabled = false;
        }
        private void EnablePreviousActionBtn()
        {
            PreviousActionBtn.Visible = true;
            PreviousActionBtn.Enabled = true;
        }
        private void DisablePreviousActionBtn()
        {
            PreviousActionBtn.Visible = false;
            PreviousActionBtn.Enabled = false;
        }
        private void EnableLoadBoardBtn()
        {
            LoadBoardBtn.Visible = true;
            LoadBoardBtn.Enabled = true;
            
        }
        private void DisableLoadBoardBtn()
        {
            LoadBoardBtn.Visible = false;
            LoadBoardBtn.Enabled = false;

        }
        #region panelTop drag event
        private bool isDraggabel = false;
        private int mouseX;
        private int mouseY;

        private void TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggabel = true;
            mouseX = Cursor.Position.X - this.Left;
            mouseY = Cursor.Position.Y - this.Top;
        }

        private void TopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggabel)
            {
                this.Left = Cursor.Position.X - mouseX;
                this.Top = Cursor.Position.Y - mouseY;
            }
        }

        private void TopBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggabel = false;
        }


        #endregion

     
    }


}
