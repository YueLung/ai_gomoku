namespace ai_gomoku
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MsgLabel = new System.Windows.Forms.Label();
            this.ReNewBtn = new System.Windows.Forms.Button();
            this.HomePanel = new System.Windows.Forms.Panel();
            this.AIVSAI_Btn = new System.Windows.Forms.Button();
            this.HumanVSAi3x3_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HumanVSAi2_Btn = new System.Windows.Forms.Button();
            this.HumanVSAi1_Btn = new System.Windows.Forms.Button();
            this.HumanVSHuman_Btn = new System.Windows.Forms.Button();
            this.ReturnHomeBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.PreviousActionBtn = new System.Windows.Forms.Button();
            this.ComputerNextBtn = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.ChangeComputerPlayBtn = new System.Windows.Forms.Button();
            this.HomePanel.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MsgLabel.Location = new System.Drawing.Point(402, 21);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(0, 20);
            this.MsgLabel.TabIndex = 0;
            // 
            // ReNewBtn
            // 
            this.ReNewBtn.BackColor = System.Drawing.Color.Gold;
            this.ReNewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReNewBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReNewBtn.Location = new System.Drawing.Point(705, 139);
            this.ReNewBtn.Name = "ReNewBtn";
            this.ReNewBtn.Size = new System.Drawing.Size(137, 37);
            this.ReNewBtn.TabIndex = 1;
            this.ReNewBtn.Text = "重        來";
            this.ReNewBtn.UseVisualStyleBackColor = false;
            this.ReNewBtn.Click += new System.EventHandler(this.ReNewBtn_Click);
            // 
            // HomePanel
            // 
            this.HomePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.HomePanel.Controls.Add(this.AIVSAI_Btn);
            this.HomePanel.Controls.Add(this.HumanVSAi3x3_Btn);
            this.HomePanel.Controls.Add(this.label1);
            this.HomePanel.Controls.Add(this.HumanVSAi2_Btn);
            this.HomePanel.Controls.Add(this.HumanVSAi1_Btn);
            this.HomePanel.Controls.Add(this.HumanVSHuman_Btn);
            this.HomePanel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HomePanel.Location = new System.Drawing.Point(125, 108);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Size = new System.Drawing.Size(569, 537);
            this.HomePanel.TabIndex = 1;
            // 
            // AIVSAI_Btn
            // 
            this.AIVSAI_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.AIVSAI_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AIVSAI_Btn.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AIVSAI_Btn.Location = new System.Drawing.Point(170, 375);
            this.AIVSAI_Btn.Name = "AIVSAI_Btn";
            this.AIVSAI_Btn.Size = new System.Drawing.Size(248, 54);
            this.AIVSAI_Btn.TabIndex = 5;
            this.AIVSAI_Btn.Text = "電腦 vs 電腦";
            this.AIVSAI_Btn.UseVisualStyleBackColor = false;
            this.AIVSAI_Btn.Click += new System.EventHandler(this.AIVSAI_Btn_Click);
            // 
            // HumanVSAi3x3_Btn
            // 
            this.HumanVSAi3x3_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.HumanVSAi3x3_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HumanVSAi3x3_Btn.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HumanVSAi3x3_Btn.Location = new System.Drawing.Point(170, 454);
            this.HumanVSAi3x3_Btn.Name = "HumanVSAi3x3_Btn";
            this.HumanVSAi3x3_Btn.Size = new System.Drawing.Size(248, 54);
            this.HumanVSAi3x3_Btn.TabIndex = 4;
            this.HumanVSAi3x3_Btn.Text = "玩家 vs 電腦(3X3)";
            this.HumanVSAi3x3_Btn.UseVisualStyleBackColor = false;
            this.HumanVSAi3x3_Btn.Click += new System.EventHandler(this.HumanVSAi3x3_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(192, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "選擇玩法 :";
            // 
            // HumanVSAi2_Btn
            // 
            this.HumanVSAi2_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.HumanVSAi2_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HumanVSAi2_Btn.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HumanVSAi2_Btn.Location = new System.Drawing.Point(170, 297);
            this.HumanVSAi2_Btn.Name = "HumanVSAi2_Btn";
            this.HumanVSAi2_Btn.Size = new System.Drawing.Size(248, 54);
            this.HumanVSAi2_Btn.TabIndex = 2;
            this.HumanVSAi2_Btn.Text = "玩家 vs 困難電腦";
            this.HumanVSAi2_Btn.UseVisualStyleBackColor = false;
            this.HumanVSAi2_Btn.Click += new System.EventHandler(this.HumanVSAi2_Btn_Click);
            // 
            // HumanVSAi1_Btn
            // 
            this.HumanVSAi1_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.HumanVSAi1_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HumanVSAi1_Btn.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HumanVSAi1_Btn.Location = new System.Drawing.Point(170, 217);
            this.HumanVSAi1_Btn.Name = "HumanVSAi1_Btn";
            this.HumanVSAi1_Btn.Size = new System.Drawing.Size(248, 54);
            this.HumanVSAi1_Btn.TabIndex = 1;
            this.HumanVSAi1_Btn.Text = "玩家 vs 簡單電腦";
            this.HumanVSAi1_Btn.UseVisualStyleBackColor = false;
            this.HumanVSAi1_Btn.Click += new System.EventHandler(this.HumanVSAi1_Btn_Click);
            // 
            // HumanVSHuman_Btn
            // 
            this.HumanVSHuman_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.HumanVSHuman_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HumanVSHuman_Btn.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HumanVSHuman_Btn.Location = new System.Drawing.Point(170, 139);
            this.HumanVSHuman_Btn.Name = "HumanVSHuman_Btn";
            this.HumanVSHuman_Btn.Size = new System.Drawing.Size(248, 54);
            this.HumanVSHuman_Btn.TabIndex = 2;
            this.HumanVSHuman_Btn.Text = "玩家 vs 玩家";
            this.HumanVSHuman_Btn.UseVisualStyleBackColor = false;
            this.HumanVSHuman_Btn.Click += new System.EventHandler(this.HumanVSHuman_Btn_Click);
            // 
            // ReturnHomeBtn
            // 
            this.ReturnHomeBtn.BackColor = System.Drawing.Color.Gold;
            this.ReturnHomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnHomeBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReturnHomeBtn.Location = new System.Drawing.Point(704, 196);
            this.ReturnHomeBtn.Name = "ReturnHomeBtn";
            this.ReturnHomeBtn.Size = new System.Drawing.Size(137, 37);
            this.ReturnHomeBtn.TabIndex = 1;
            this.ReturnHomeBtn.Text = "重選玩法";
            this.ReturnHomeBtn.UseVisualStyleBackColor = false;
            this.ReturnHomeBtn.Click += new System.EventHandler(this.ReturnHomeBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.BackgroundImage = global::ai_gomoku.Properties.Resources.board;
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CloseBtn.Location = new System.Drawing.Point(801, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(47, 44);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // PreviousActionBtn
            // 
            this.PreviousActionBtn.BackColor = System.Drawing.Color.Gold;
            this.PreviousActionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousActionBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PreviousActionBtn.Location = new System.Drawing.Point(705, 345);
            this.PreviousActionBtn.Name = "PreviousActionBtn";
            this.PreviousActionBtn.Size = new System.Drawing.Size(137, 37);
            this.PreviousActionBtn.TabIndex = 4;
            this.PreviousActionBtn.Text = "悔       棋";
            this.PreviousActionBtn.UseVisualStyleBackColor = false;
            this.PreviousActionBtn.Click += new System.EventHandler(this.PreviousActionBtn_Click);
            // 
            // ComputerNextBtn
            // 
            this.ComputerNextBtn.BackColor = System.Drawing.Color.Gold;
            this.ComputerNextBtn.Enabled = false;
            this.ComputerNextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComputerNextBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComputerNextBtn.Location = new System.Drawing.Point(705, 443);
            this.ComputerNextBtn.Name = "ComputerNextBtn";
            this.ComputerNextBtn.Size = new System.Drawing.Size(136, 73);
            this.ComputerNextBtn.TabIndex = 5;
            this.ComputerNextBtn.Text = "電腦下一步";
            this.ComputerNextBtn.UseVisualStyleBackColor = false;
            this.ComputerNextBtn.Visible = false;
            this.ComputerNextBtn.Click += new System.EventHandler(this.ComputerNextBtn_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.CloseBtn);
            this.panelTop.Location = new System.Drawing.Point(1, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(848, 41);
            this.panelTop.TabIndex = 6;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // ChangeComputerPlayBtn
            // 
            this.ChangeComputerPlayBtn.BackColor = System.Drawing.Color.Gold;
            this.ChangeComputerPlayBtn.Enabled = false;
            this.ChangeComputerPlayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeComputerPlayBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ChangeComputerPlayBtn.Location = new System.Drawing.Point(705, 551);
            this.ChangeComputerPlayBtn.Name = "ChangeComputerPlayBtn";
            this.ChangeComputerPlayBtn.Size = new System.Drawing.Size(136, 65);
            this.ChangeComputerPlayBtn.TabIndex = 7;
            this.ChangeComputerPlayBtn.Text = "換電腦下";
            this.ChangeComputerPlayBtn.UseVisualStyleBackColor = false;
            this.ChangeComputerPlayBtn.Visible = false;
            this.ChangeComputerPlayBtn.Click += new System.EventHandler(this.ChangeComputerPlayBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::ai_gomoku.Properties.Resources.board;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(847, 700);
            this.Controls.Add(this.ChangeComputerPlayBtn);
            this.Controls.Add(this.ComputerNextBtn);
            this.Controls.Add(this.PreviousActionBtn);
            this.Controls.Add(this.HomePanel);
            this.Controls.Add(this.ReturnHomeBtn);
            this.Controls.Add(this.ReNewBtn);
            this.Controls.Add(this.MsgLabel);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.HomePanel.ResumeLayout(false);
            this.HomePanel.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label MsgLabel;
        private System.Windows.Forms.Button ReNewBtn;
        private System.Windows.Forms.Panel HomePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button HumanVSAi2_Btn;
        private System.Windows.Forms.Button HumanVSAi1_Btn;
        private System.Windows.Forms.Button HumanVSHuman_Btn;
        private System.Windows.Forms.Button ReturnHomeBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button HumanVSAi3x3_Btn;
        private System.Windows.Forms.Button AIVSAI_Btn;
        private System.Windows.Forms.Button PreviousActionBtn;
        private System.Windows.Forms.Button ComputerNextBtn;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button ChangeComputerPlayBtn;
    }
}

