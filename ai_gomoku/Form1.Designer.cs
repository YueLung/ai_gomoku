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
            this.label1 = new System.Windows.Forms.Label();
            this.HumanVSAi2_Btn = new System.Windows.Forms.Button();
            this.HumanVSAi1_Btn = new System.Windows.Forms.Button();
            this.HumanVSHuman_Btn = new System.Windows.Forms.Button();
            this.ReturnHomeBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.HomePanel.SuspendLayout();
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
            this.ReNewBtn.Text = "重來";
            this.ReNewBtn.UseVisualStyleBackColor = false;
            this.ReNewBtn.Click += new System.EventHandler(this.ReNewBtn_Click);
            // 
            // HomePanel
            // 
            this.HomePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.HomePanel.Controls.Add(this.label1);
            this.HomePanel.Controls.Add(this.HumanVSAi2_Btn);
            this.HomePanel.Controls.Add(this.HumanVSAi1_Btn);
            this.HomePanel.Controls.Add(this.HumanVSHuman_Btn);
            this.HomePanel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HomePanel.Location = new System.Drawing.Point(125, 108);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Size = new System.Drawing.Size(569, 456);
            this.HomePanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(192, 81);
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
            this.HumanVSAi2_Btn.Location = new System.Drawing.Point(198, 342);
            this.HumanVSAi2_Btn.Name = "HumanVSAi2_Btn";
            this.HumanVSAi2_Btn.Size = new System.Drawing.Size(180, 54);
            this.HumanVSAi2_Btn.TabIndex = 2;
            this.HumanVSAi2_Btn.Text = "玩家 vs 電腦2";
            this.HumanVSAi2_Btn.UseVisualStyleBackColor = false;
            this.HumanVSAi2_Btn.Click += new System.EventHandler(this.HumanVSAi2_Btn_Click);
            // 
            // HumanVSAi1_Btn
            // 
            this.HumanVSAi1_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.HumanVSAi1_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HumanVSAi1_Btn.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HumanVSAi1_Btn.Location = new System.Drawing.Point(198, 260);
            this.HumanVSAi1_Btn.Name = "HumanVSAi1_Btn";
            this.HumanVSAi1_Btn.Size = new System.Drawing.Size(180, 54);
            this.HumanVSAi1_Btn.TabIndex = 1;
            this.HumanVSAi1_Btn.Text = "玩家 vs 電腦1";
            this.HumanVSAi1_Btn.UseVisualStyleBackColor = false;
            this.HumanVSAi1_Btn.Click += new System.EventHandler(this.HumanVSAi1_Btn_Click);
            // 
            // HumanVSHuman_Btn
            // 
            this.HumanVSHuman_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.HumanVSHuman_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HumanVSHuman_Btn.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HumanVSHuman_Btn.Location = new System.Drawing.Point(198, 177);
            this.HumanVSHuman_Btn.Name = "HumanVSHuman_Btn";
            this.HumanVSHuman_Btn.Size = new System.Drawing.Size(180, 54);
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
            this.CloseBtn.Location = new System.Drawing.Point(798, 1);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(47, 44);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::ai_gomoku.Properties.Resources.board;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(847, 700);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.HomePanel);
            this.Controls.Add(this.ReturnHomeBtn);
            this.Controls.Add(this.ReNewBtn);
            this.Controls.Add(this.MsgLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.HomePanel.ResumeLayout(false);
            this.HomePanel.PerformLayout();
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
    }
}

