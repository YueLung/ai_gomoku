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
            this.SuspendLayout();
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MsgLabel.Location = new System.Drawing.Point(678, 19);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(0, 20);
            this.MsgLabel.TabIndex = 0;
            // 
            // ReNewBtn
            // 
            this.ReNewBtn.BackColor = System.Drawing.Color.Gold;
            this.ReNewBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReNewBtn.Location = new System.Drawing.Point(714, 172);
            this.ReNewBtn.Name = "ReNewBtn";
            this.ReNewBtn.Size = new System.Drawing.Size(84, 37);
            this.ReNewBtn.TabIndex = 1;
            this.ReNewBtn.Text = "重來";
            this.ReNewBtn.UseVisualStyleBackColor = false;
            this.ReNewBtn.Click += new System.EventHandler(this.ReNewBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::ai_gomoku.Properties.Resources.board;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(858, 700);
            this.Controls.Add(this.ReNewBtn);
            this.Controls.Add(this.MsgLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label MsgLabel;
        private System.Windows.Forms.Button ReNewBtn;
    }
}

