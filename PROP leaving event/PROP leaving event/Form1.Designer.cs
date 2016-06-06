namespace PROP_leaving_event
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbChipOrEmail = new System.Windows.Forms.TextBox();
            this.labelemail = new System.Windows.Forms.Label();
            this.btCheckviaemail = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.lbemail = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Moccasin;
            this.panel1.Controls.Add(this.lbemail);
            this.panel1.Controls.Add(this.tbChipOrEmail);
            this.panel1.Controls.Add(this.labelemail);
            this.panel1.Controls.Add(this.btCheckviaemail);
            this.panel1.Location = new System.Drawing.Point(32, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 180);
            this.panel1.TabIndex = 0;
            // 
            // tbChipOrEmail
            // 
            this.tbChipOrEmail.Location = new System.Drawing.Point(24, 32);
            this.tbChipOrEmail.Name = "tbChipOrEmail";
            this.tbChipOrEmail.Size = new System.Drawing.Size(182, 20);
            this.tbChipOrEmail.TabIndex = 2;
            // 
            // labelemail
            // 
            this.labelemail.AutoSize = true;
            this.labelemail.BackColor = System.Drawing.Color.Transparent;
            this.labelemail.Location = new System.Drawing.Point(21, 149);
            this.labelemail.Name = "labelemail";
            this.labelemail.Size = new System.Drawing.Size(35, 13);
            this.labelemail.TabIndex = 2;
            this.labelemail.Text = "Email:";
            // 
            // btCheckviaemail
            // 
            this.btCheckviaemail.Location = new System.Drawing.Point(56, 67);
            this.btCheckviaemail.Name = "btCheckviaemail";
            this.btCheckviaemail.Size = new System.Drawing.Size(100, 23);
            this.btCheckviaemail.TabIndex = 1;
            this.btCheckviaemail.Text = "Check via email";
            this.btCheckviaemail.UseVisualStyleBackColor = true;
            this.btCheckviaemail.Click += new System.EventHandler(this.btCheckviaemail_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.Location = new System.Drawing.Point(310, 45);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(243, 173);
            this.lbInfo.TabIndex = 3;
            // 
            // lbemail
            // 
            this.lbemail.AutoSize = true;
            this.lbemail.Location = new System.Drawing.Point(62, 149);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(10, 13);
            this.lbemail.TabIndex = 3;
            this.lbemail.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 351);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbChipOrEmail;
        private System.Windows.Forms.Label labelemail;
        private System.Windows.Forms.Button btCheckviaemail;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Label lbemail;
    }
}

