namespace ProP_app_shop
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
            this.lbNotification = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lb5 = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lb7 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lb6 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.numudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.listboxItems = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNotification
            // 
            this.lbNotification.AutoSize = true;
            this.lbNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotification.Location = new System.Drawing.Point(61, 64);
            this.lbNotification.Name = "lbNotification";
            this.lbNotification.Size = new System.Drawing.Size(141, 32);
            this.lbNotification.TabIndex = 0;
            this.lbNotification.Text = "Welcome,";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(653, 188);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(86, 36);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lb5
            // 
            this.lb5.AutoSize = true;
            this.lb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb5.Location = new System.Drawing.Point(1151, 88);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(68, 25);
            this.lb5.TabIndex = 7;
            this.lb5.Text = "Menu:";
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBalance.Location = new System.Drawing.Point(62, 132);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(106, 29);
            this.lbBalance.TabIndex = 5;
            this.lbBalance.Text = "Balance:";
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3.Location = new System.Drawing.Point(64, 195);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(126, 20);
            this.lb3.TabIndex = 1;
            this.lb3.Text = "*Visitor\'s email:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(859, 716);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(133, 58);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lb7
            // 
            this.lb7.AutoSize = true;
            this.lb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb7.Location = new System.Drawing.Point(313, 925);
            this.lb7.Name = "lb7";
            this.lb7.Size = new System.Drawing.Size(62, 24);
            this.lb7.TabIndex = 15;
            this.lb7.Text = "Total:";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(397, 925);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(70, 24);
            this.lbTotal.TabIndex = 16;
            this.lbTotal.Text = "0 euro";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(859, 428);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 61);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(859, 522);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(133, 61);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lb6
            // 
            this.lb6.AutoSize = true;
            this.lb6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb6.Location = new System.Drawing.Point(786, 364);
            this.lb6.Name = "lb6";
            this.lb6.Size = new System.Drawing.Size(83, 24);
            this.lb6.TabIndex = 22;
            this.lb6.Text = "Quantity:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(252, 195);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(333, 22);
            this.tbEmail.TabIndex = 23;
            // 
            // numudQuantity
            // 
            this.numudQuantity.Location = new System.Drawing.Point(892, 367);
            this.numudQuantity.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numudQuantity.Name = "numudQuantity";
            this.numudQuantity.Size = new System.Drawing.Size(165, 22);
            this.numudQuantity.TabIndex = 24;
            this.numudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(859, 618);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 58);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(786, 320);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(50, 24);
            this.lbInfo.TabIndex = 26;
            this.lbInfo.Text = "Item:";
            // 
            // listboxItems
            // 
            this.listboxItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxItems.FormattingEnabled = true;
            this.listboxItems.ItemHeight = 25;
            this.listboxItems.Location = new System.Drawing.Point(70, 320);
            this.listboxItems.Name = "listboxItems";
            this.listboxItems.Size = new System.Drawing.Size(669, 554);
            this.listboxItems.TabIndex = 27;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(859, 813);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(133, 61);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.listboxItems);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numudQuantity);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.lb6);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lb7);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lb5);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lbNotification);
            this.Name = "Form1";
            this.Text = "Shop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNotification;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lb7;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lb6;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.NumericUpDown numudQuantity;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.ListBox listboxItems;
        private System.Windows.Forms.Button btnRefresh;
    }
}

