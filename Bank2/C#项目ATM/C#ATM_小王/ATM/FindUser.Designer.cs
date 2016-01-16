namespace ATM
{
    partial class FindUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindUser));
            this.button_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_Name = new System.Windows.Forms.TextBox();
            this.money1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.return_click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.BackColor = System.Drawing.Color.Blue;
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.ForeColor = System.Drawing.Color.Red;
            this.button_OK.Location = new System.Drawing.Point(536, 373);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(139, 65);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("LiSu", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(285, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名";
            // 
            // m_Name
            // 
            this.m_Name.BackColor = System.Drawing.Color.Blue;
            this.m_Name.Enabled = false;
            this.m_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Name.ForeColor = System.Drawing.Color.Yellow;
            this.m_Name.Location = new System.Drawing.Point(486, 65);
            this.m_Name.Name = "m_Name";
            this.m_Name.Size = new System.Drawing.Size(230, 44);
            this.m_Name.TabIndex = 2;
            // 
            // money1
            // 
            this.money1.BackColor = System.Drawing.Color.Blue;
            this.money1.Enabled = false;
            this.money1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money1.ForeColor = System.Drawing.Color.Yellow;
            this.money1.Location = new System.Drawing.Point(496, 225);
            this.money1.Name = "money1";
            this.money1.Size = new System.Drawing.Size(220, 44);
            this.money1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("LiSu", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(241, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "你的余额";
            // 
            // return_click
            // 
            this.return_click.BackColor = System.Drawing.Color.Blue;
            this.return_click.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_click.ForeColor = System.Drawing.Color.Red;
            this.return_click.Location = new System.Drawing.Point(259, 373);
            this.return_click.Name = "return_click";
            this.return_click.Size = new System.Drawing.Size(139, 65);
            this.return_click.TabIndex = 5;
            this.return_click.Text = "return";
            this.return_click.UseVisualStyleBackColor = false;
            this.return_click.Click += new System.EventHandler(this.return_click_Click);
            // 
            // FindUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(995, 614);
            this.Controls.Add(this.return_click);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.money1);
            this.Controls.Add(this.m_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_OK);
            this.Name = "FindUser";
            this.Text = "FindUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_Name;
        private System.Windows.Forms.TextBox money1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button return_click;
    }
}