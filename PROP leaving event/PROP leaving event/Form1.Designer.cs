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
            this.lbemail = new System.Windows.Forms.Label();
            this.tbChipOrEmail = new System.Windows.Forms.TextBox();
            this.labelemail = new System.Windows.Forms.Label();
            this.btCheckviaemail = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbsuccess = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.lbemail);
            this.panel1.Controls.Add(this.tbChipOrEmail);
            this.panel1.Controls.Add(this.labelemail);
            this.panel1.Controls.Add(this.btCheckviaemail);
            this.panel1.Location = new System.Drawing.Point(109, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 226);
            this.panel1.TabIndex = 0;
            // 
            // lbemail
            // 
            this.lbemail.AutoSize = true;
            this.lbemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbemail.Location = new System.Drawing.Point(131, 164);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(19, 25);
            this.lbemail.TabIndex = 3;
            this.lbemail.Text = "-";
            // 
            // tbChipOrEmail
            // 
            this.tbChipOrEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChipOrEmail.Location = new System.Drawing.Point(99, 34);
            this.tbChipOrEmail.Name = "tbChipOrEmail";
            this.tbChipOrEmail.Size = new System.Drawing.Size(221, 31);
            this.tbChipOrEmail.TabIndex = 2;
            // 
            // labelemail
            // 
            this.labelemail.AutoSize = true;
            this.labelemail.BackColor = System.Drawing.Color.Transparent;
            this.labelemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelemail.Location = new System.Drawing.Point(31, 164);
            this.labelemail.Name = "labelemail";
            this.labelemail.Size = new System.Drawing.Size(71, 25);
            this.labelemail.TabIndex = 2;
            this.labelemail.Text = "Email:";
            // 
            // btCheckviaemail
            // 
            this.btCheckviaemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCheckviaemail.Location = new System.Drawing.Point(99, 83);
            this.btCheckviaemail.Name = "btCheckviaemail";
            this.btCheckviaemail.Size = new System.Drawing.Size(222, 38);
            this.btCheckviaemail.TabIndex = 1;
            this.btCheckviaemail.Text = "Check via email";
            this.btCheckviaemail.UseVisualStyleBackColor = true;
            this.btCheckviaemail.Click += new System.EventHandler(this.btCheckviaemail_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 25;
            this.lbInfo.Location = new System.Drawing.Point(109, 385);
            this.lbInfo.MultiColumn = true;
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(933, 229);
            this.lbInfo.TabIndex = 3;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStatus.Location = new System.Drawing.Point(635, 281);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(120, 33);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "READY";
            // 
            // lbsuccess
            // 
            this.lbsuccess.AutoSize = true;
            this.lbsuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsuccess.ForeColor = System.Drawing.Color.DarkRed;
            this.lbsuccess.Location = new System.Drawing.Point(638, 330);
            this.lbsuccess.Name = "lbsuccess";
            this.lbsuccess.Size = new System.Drawing.Size(19, 25);
            this.lbsuccess.TabIndex = 5;
            this.lbsuccess.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 731);
            this.Controls.Add(this.lbsuccess);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbChipOrEmail;
        private System.Windows.Forms.Label labelemail;
        private System.Windows.Forms.Button btCheckviaemail;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Label lbemail;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbsuccess;
    }
}

