namespace ATM
{
    partial class Choose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Choose));
            this.label1 = new System.Windows.Forms.Label();
            this.Deposit = new System.Windows.Forms.Button();
            this.Transfer = new System.Windows.Forms.Button();
            this.Draw = new System.Windows.Forms.Button();
            this.Find = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.Find_Time = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("STLiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(56, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择你要执行的操作";
            // 
            // Deposit
            // 
            this.Deposit.BackColor = System.Drawing.Color.Red;
            this.Deposit.Font = new System.Drawing.Font("STLiti", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Deposit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Deposit.Location = new System.Drawing.Point(60, 167);
            this.Deposit.Name = "Deposit";
            this.Deposit.Size = new System.Drawing.Size(110, 45);
            this.Deposit.TabIndex = 1;
            this.Deposit.Text = "存款";
            this.Deposit.UseVisualStyleBackColor = false;
            this.Deposit.Click += new System.EventHandler(this.Deposit_Click);
            // 
            // Transfer
            // 
            this.Transfer.BackColor = System.Drawing.Color.Red;
            this.Transfer.Font = new System.Drawing.Font("STLiti", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Transfer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Transfer.Location = new System.Drawing.Point(60, 337);
            this.Transfer.Name = "Transfer";
            this.Transfer.Size = new System.Drawing.Size(110, 45);
            this.Transfer.TabIndex = 1;
            this.Transfer.Text = "转账";
            this.Transfer.UseVisualStyleBackColor = false;
            this.Transfer.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // Draw
            // 
            this.Draw.BackColor = System.Drawing.Color.Red;
            this.Draw.Font = new System.Drawing.Font("STLiti", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Draw.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Draw.Location = new System.Drawing.Point(554, 167);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(110, 45);
            this.Draw.TabIndex = 1;
            this.Draw.Text = "取款";
            this.Draw.UseVisualStyleBackColor = false;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Find
            // 
            this.Find.BackColor = System.Drawing.Color.Red;
            this.Find.Font = new System.Drawing.Font("STLiti", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Find.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Find.Location = new System.Drawing.Point(554, 322);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(110, 45);
            this.Find.TabIndex = 1;
            this.Find.Text = "查询";
            this.Find.UseVisualStyleBackColor = false;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // Return
            // 
            this.Return.BackColor = System.Drawing.Color.Red;
            this.Return.Font = new System.Drawing.Font("STLiti", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Return.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Return.Location = new System.Drawing.Point(60, 472);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(110, 45);
            this.Return.TabIndex = 1;
            this.Return.Text = "返回界面";
            this.Return.UseVisualStyleBackColor = false;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // Find_Time
            // 
            this.Find_Time.BackColor = System.Drawing.Color.Red;
            this.Find_Time.Font = new System.Drawing.Font("LiSu", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Find_Time.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Find_Time.Location = new System.Drawing.Point(554, 472);
            this.Find_Time.Name = "Find_Time";
            this.Find_Time.Size = new System.Drawing.Size(112, 45);
            this.Find_Time.TabIndex = 2;
            this.Find_Time.Text = "时间查询";
            this.Find_Time.UseVisualStyleBackColor = false;
            this.Find_Time.Click += new System.EventHandler(this.Find_Time_Click);
            // 
            // Choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1015, 703);
            this.Controls.Add(this.Find_Time);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.Transfer);
            this.Controls.Add(this.Deposit);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Name = "Choose";
            this.Text = "Choose";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Deposit;
        private System.Windows.Forms.Button Transfer;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Button Find_Time;
    }
}