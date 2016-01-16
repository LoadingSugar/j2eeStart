namespace ATM
{
    partial class Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            this.Transfer_account = new System.Windows.Forms.TextBox();
            this.Transfer_money = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Transfer_OK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Transfer_account
            // 
            this.Transfer_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transfer_account.Location = new System.Drawing.Point(412, 24);
            this.Transfer_account.MaxLength = 16;
            this.Transfer_account.Name = "Transfer_account";
            this.Transfer_account.Size = new System.Drawing.Size(205, 29);
            this.Transfer_account.TabIndex = 0;
            // 
            // Transfer_money
            // 
            this.Transfer_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transfer_money.Location = new System.Drawing.Point(412, 116);
            this.Transfer_money.Name = "Transfer_money";
            this.Transfer_money.Size = new System.Drawing.Size(205, 29);
            this.Transfer_money.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "转账帐号";
            // 
            // Transfer_OK
            // 
            this.Transfer_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transfer_OK.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Transfer_OK.Location = new System.Drawing.Point(253, 194);
            this.Transfer_OK.Name = "Transfer_OK";
            this.Transfer_OK.Size = new System.Drawing.Size(68, 46);
            this.Transfer_OK.TabIndex = 3;
            this.Transfer_OK.Text = "OK";
            this.Transfer_OK.UseVisualStyleBackColor = true;
            this.Transfer_OK.Click += new System.EventHandler(this.Transfer_OK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "转账金额";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(775, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "return";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_return_click);
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(907, 583);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Transfer_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Transfer_money);
            this.Controls.Add(this.Transfer_account);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "Transfer";
            this.Text = "Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Transfer_account;
        private System.Windows.Forms.TextBox Transfer_money;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Transfer_OK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}