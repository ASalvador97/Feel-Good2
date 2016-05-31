namespace StatusApp
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
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbnotentered = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbmoney = new System.Windows.Forms.TextBox();
            this.tbtotalamount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbwholeft = new System.Windows.Forms.TextBox();
            this.tbentered = new System.Windows.Forms.TextBox();
            this.tbwhowillvisit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbemail = new System.Windows.Forms.TextBox();
            this.btnLoadAllStudents = new System.Windows.Forms.Button();
            this.listboxStatusAndHistory = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Controls.Add(this.tabPage1);
            this.menu.Controls.Add(this.tabPage2);
            this.menu.Controls.Add(this.tabPage3);
            this.menu.Controls.Add(this.tabPage4);
            this.menu.Location = new System.Drawing.Point(22, 26);
            this.menu.Name = "menu";
            this.menu.SelectedIndex = 0;
            this.menu.Size = new System.Drawing.Size(736, 547);
            this.menu.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbnotentered);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbmoney);
            this.tabPage1.Controls.Add(this.tbtotalamount);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbwholeft);
            this.tabPage1.Controls.Add(this.tbentered);
            this.tabPage1.Controls.Add(this.tbwhowillvisit);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbnotentered
            // 
            this.tbnotentered.Location = new System.Drawing.Point(549, 124);
            this.tbnotentered.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbnotentered.Name = "tbnotentered";
            this.tbnotentered.Size = new System.Drawing.Size(112, 26);
            this.tbnotentered.TabIndex = 25;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(-69, 748);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 26);
            this.textBox3.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(86, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(456, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Number of visitors who entered the event:";
            // 
            // tbmoney
            // 
            this.tbmoney.Location = new System.Drawing.Point(540, 348);
            this.tbmoney.Name = "tbmoney";
            this.tbmoney.Size = new System.Drawing.Size(121, 26);
            this.tbmoney.TabIndex = 22;
            // 
            // tbtotalamount
            // 
            this.tbtotalamount.Location = new System.Drawing.Point(540, 303);
            this.tbtotalamount.Name = "tbtotalamount";
            this.tbtotalamount.Size = new System.Drawing.Size(121, 26);
            this.tbtotalamount.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 344);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(517, 29);
            this.label5.TabIndex = 20;
            this.label5.Text = "Total of money earned from shops and lending:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 299);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(496, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "Total amount of money in the Event-accounts:";
            // 
            // tbwholeft
            // 
            this.tbwholeft.Location = new System.Drawing.Point(549, 169);
            this.tbwholeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbwholeft.Name = "tbwholeft";
            this.tbwholeft.Size = new System.Drawing.Size(112, 26);
            this.tbwholeft.TabIndex = 18;
            // 
            // tbentered
            // 
            this.tbentered.Location = new System.Drawing.Point(549, 77);
            this.tbentered.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbentered.Name = "tbentered";
            this.tbentered.Size = new System.Drawing.Size(112, 26);
            this.tbentered.TabIndex = 17;
            // 
            // tbwhowillvisit
            // 
            this.tbwhowillvisit.Location = new System.Drawing.Point(549, 32);
            this.tbwhowillvisit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbwhowillvisit.Name = "tbwhowillvisit";
            this.tbwhowillvisit.Size = new System.Drawing.Size(112, 26);
            this.tbwhowillvisit.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(405, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "Number of visitors who left the event:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(491, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Number of visitors who didn\'t enter the event:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Number of visitors who will visit the event: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbemail);
            this.tabPage2.Controls.Add(this.btnLoadAllStudents);
            this.tabPage2.Controls.Add(this.listboxStatusAndHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 514);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Client Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbemail
            // 
            this.tbemail.Location = new System.Drawing.Point(44, 47);
            this.tbemail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbemail.Name = "tbemail";
            this.tbemail.Size = new System.Drawing.Size(134, 26);
            this.tbemail.TabIndex = 9;
            this.tbemail.Text = "Insert email";
            // 
            // btnLoadAllStudents
            // 
            this.btnLoadAllStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAllStudents.Location = new System.Drawing.Point(43, 107);
            this.btnLoadAllStudents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadAllStudents.Name = "btnLoadAllStudents";
            this.btnLoadAllStudents.Size = new System.Drawing.Size(135, 124);
            this.btnLoadAllStudents.TabIndex = 11;
            this.btnLoadAllStudents.Text = "Load Visitor info";
            this.btnLoadAllStudents.UseVisualStyleBackColor = true;
            this.btnLoadAllStudents.Click += new System.EventHandler(this.btnLoadAllStudents_Click);
            // 
            // listboxStatusAndHistory
            // 
            this.listboxStatusAndHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxStatusAndHistory.FormattingEnabled = true;
            this.listboxStatusAndHistory.ItemHeight = 29;
            this.listboxStatusAndHistory.Location = new System.Drawing.Point(247, 22);
            this.listboxStatusAndHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listboxStatusAndHistory.Name = "listboxStatusAndHistory";
            this.listboxStatusAndHistory.Size = new System.Drawing.Size(458, 468);
            this.listboxStatusAndHistory.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(728, 514);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Camping Availability";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(728, 514);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Shop Revenue";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 606);
            this.Controls.Add(this.menu);
            this.Name = "Form1";
            this.Text = "Status";
            this.menu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl menu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbwholeft;
        private System.Windows.Forms.TextBox tbentered;
        private System.Windows.Forms.TextBox tbwhowillvisit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbmoney;
        private System.Windows.Forms.TextBox tbtotalamount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbnotentered;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbemail;
        private System.Windows.Forms.Button btnLoadAllStudents;
        private System.Windows.Forms.ListBox listboxStatusAndHistory;
        private System.Windows.Forms.Timer timer1;
    }
}

