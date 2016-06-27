namespace ProP_app_loaning
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
            this.lbBalance = new System.Windows.Forms.Label();
            this.lb5 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lb7 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.listboxItemsToLoan = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbNotification = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.listboxItemsToReturn = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnItemCamera = new System.Windows.Forms.Button();
            this.btnItemCameraBt = new System.Windows.Forms.Button();
            this.btnItemHeadphones = new System.Windows.Forms.Button();
            this.btnItemIPhoneCharger = new System.Windows.Forms.Button();
            this.btnItemLaptopCharger = new System.Windows.Forms.Button();
            this.btnItemSamsungCharger = new System.Windows.Forms.Button();
            this.btnItemTripod = new System.Windows.Forms.Button();
            this.btnItemUmbrella = new System.Windows.Forms.Button();
            this.btnItemUSB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBalance.Location = new System.Drawing.Point(94, 131);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(106, 29);
            this.lbBalance.TabIndex = 2;
            this.lbBalance.Text = "Balance:";
            // 
            // lb5
            // 
            this.lb5.AutoSize = true;
            this.lb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb5.Location = new System.Drawing.Point(40, 311);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(201, 24);
            this.lb5.TabIndex = 8;
            this.lb5.Text = "List of items for loan:";
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(964, 620);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(170, 100);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1253, 834);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(170, 100);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lb7
            // 
            this.lb7.AutoSize = true;
            this.lb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb7.Location = new System.Drawing.Point(993, 868);
            this.lb7.Name = "lb7";
            this.lb7.Size = new System.Drawing.Size(80, 29);
            this.lb7.TabIndex = 14;
            this.lb7.Text = "Total:";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(1079, 868);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(87, 29);
            this.lbTotal.TabIndex = 15;
            this.lbTotal.Text = "0 euro";
            // 
            // listboxItemsToLoan
            // 
            this.listboxItemsToLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxItemsToLoan.FormattingEnabled = true;
            this.listboxItemsToLoan.ItemHeight = 25;
            this.listboxItemsToLoan.Location = new System.Drawing.Point(897, 84);
            this.listboxItemsToLoan.Name = "listboxItemsToLoan";
            this.listboxItemsToLoan.Size = new System.Drawing.Size(526, 504);
            this.listboxItemsToLoan.TabIndex = 21;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1197, 620);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 100);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbNotification
            // 
            this.lbNotification.AutoSize = true;
            this.lbNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbNotification.Location = new System.Drawing.Point(93, 65);
            this.lbNotification.Name = "lbNotification";
            this.lbNotification.Size = new System.Drawing.Size(134, 31);
            this.lbNotification.TabIndex = 24;
            this.lbNotification.Text = "Welcome,";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(282, 201);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(336, 22);
            this.tbEmail.TabIndex = 25;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(333, 311);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(55, 25);
            this.lbInfo.TabIndex = 27;
            this.lbInfo.Text = "Item:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1654, 834);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 100);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(1654, 620);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(170, 100);
            this.btnReturn.TabIndex = 29;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // listboxItemsToReturn
            // 
            this.listboxItemsToReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxItemsToReturn.FormattingEnabled = true;
            this.listboxItemsToReturn.ItemHeight = 25;
            this.listboxItemsToReturn.Location = new System.Drawing.Point(1480, 84);
            this.listboxItemsToReturn.Name = "listboxItemsToReturn";
            this.listboxItemsToReturn.Size = new System.Drawing.Size(526, 504);
            this.listboxItemsToReturn.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(893, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 24);
            this.label2.TabIndex = 31;
            this.label2.Text = "Items to be loaned:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1476, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 24);
            this.label3.TabIndex = 32;
            this.label3.Text = "Items to be returned:";
            // 
            // btnItemCamera
            // 
            this.btnItemCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemCamera.Location = new System.Drawing.Point(99, 402);
            this.btnItemCamera.Name = "btnItemCamera";
            this.btnItemCamera.Size = new System.Drawing.Size(169, 106);
            this.btnItemCamera.TabIndex = 33;
            this.btnItemCamera.Text = "Camera";
            this.btnItemCamera.UseVisualStyleBackColor = true;
            this.btnItemCamera.Click += new System.EventHandler(this.btnItemCamera_Click);
            // 
            // btnItemCameraBt
            // 
            this.btnItemCameraBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemCameraBt.Location = new System.Drawing.Point(364, 402);
            this.btnItemCameraBt.Name = "btnItemCameraBt";
            this.btnItemCameraBt.Size = new System.Drawing.Size(169, 106);
            this.btnItemCameraBt.TabIndex = 34;
            this.btnItemCameraBt.Text = "Camera battery";
            this.btnItemCameraBt.UseVisualStyleBackColor = true;
            this.btnItemCameraBt.Click += new System.EventHandler(this.btnItemCameraBt_Click);
            // 
            // btnItemHeadphones
            // 
            this.btnItemHeadphones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemHeadphones.Location = new System.Drawing.Point(632, 402);
            this.btnItemHeadphones.Name = "btnItemHeadphones";
            this.btnItemHeadphones.Size = new System.Drawing.Size(169, 106);
            this.btnItemHeadphones.TabIndex = 35;
            this.btnItemHeadphones.Text = "Headphones";
            this.btnItemHeadphones.UseVisualStyleBackColor = true;
            this.btnItemHeadphones.Click += new System.EventHandler(this.btnItemHeadphones_Click);
            // 
            // btnItemIPhoneCharger
            // 
            this.btnItemIPhoneCharger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemIPhoneCharger.Location = new System.Drawing.Point(99, 589);
            this.btnItemIPhoneCharger.Name = "btnItemIPhoneCharger";
            this.btnItemIPhoneCharger.Size = new System.Drawing.Size(169, 106);
            this.btnItemIPhoneCharger.TabIndex = 36;
            this.btnItemIPhoneCharger.Text = "iPhone charger";
            this.btnItemIPhoneCharger.UseVisualStyleBackColor = true;
            this.btnItemIPhoneCharger.Click += new System.EventHandler(this.btnItemIPhoneCharger_Click);
            // 
            // btnItemLaptopCharger
            // 
            this.btnItemLaptopCharger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemLaptopCharger.Location = new System.Drawing.Point(364, 589);
            this.btnItemLaptopCharger.Name = "btnItemLaptopCharger";
            this.btnItemLaptopCharger.Size = new System.Drawing.Size(169, 106);
            this.btnItemLaptopCharger.TabIndex = 37;
            this.btnItemLaptopCharger.Text = "Laptop charger";
            this.btnItemLaptopCharger.UseVisualStyleBackColor = true;
            this.btnItemLaptopCharger.Click += new System.EventHandler(this.btnItemLaptopCharger_Click);
            // 
            // btnItemSamsungCharger
            // 
            this.btnItemSamsungCharger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemSamsungCharger.Location = new System.Drawing.Point(632, 589);
            this.btnItemSamsungCharger.Name = "btnItemSamsungCharger";
            this.btnItemSamsungCharger.Size = new System.Drawing.Size(169, 106);
            this.btnItemSamsungCharger.TabIndex = 38;
            this.btnItemSamsungCharger.Text = "Samsung charger";
            this.btnItemSamsungCharger.UseVisualStyleBackColor = true;
            this.btnItemSamsungCharger.Click += new System.EventHandler(this.btnItemSamsungCharger_Click);
            // 
            // btnItemTripod
            // 
            this.btnItemTripod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemTripod.Location = new System.Drawing.Point(99, 770);
            this.btnItemTripod.Name = "btnItemTripod";
            this.btnItemTripod.Size = new System.Drawing.Size(169, 106);
            this.btnItemTripod.TabIndex = 39;
            this.btnItemTripod.Text = "Tripod";
            this.btnItemTripod.UseVisualStyleBackColor = true;
            this.btnItemTripod.Click += new System.EventHandler(this.btnItemTripod_Click);
            // 
            // btnItemUmbrella
            // 
            this.btnItemUmbrella.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemUmbrella.Location = new System.Drawing.Point(364, 770);
            this.btnItemUmbrella.Name = "btnItemUmbrella";
            this.btnItemUmbrella.Size = new System.Drawing.Size(169, 106);
            this.btnItemUmbrella.TabIndex = 40;
            this.btnItemUmbrella.Text = "Umbrella";
            this.btnItemUmbrella.UseVisualStyleBackColor = true;
            this.btnItemUmbrella.Click += new System.EventHandler(this.btnItemUmbrella_Click);
            // 
            // btnItemUSB
            // 
            this.btnItemUSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemUSB.Location = new System.Drawing.Point(632, 770);
            this.btnItemUSB.Name = "btnItemUSB";
            this.btnItemUSB.Size = new System.Drawing.Size(169, 106);
            this.btnItemUSB.TabIndex = 41;
            this.btnItemUSB.Text = "USB (10GB)";
            this.btnItemUSB.UseVisualStyleBackColor = true;
            this.btnItemUSB.Click += new System.EventHandler(this.btnItemUSB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "* Visitor\'s email:";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(656, 195);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 34);
            this.btnCheck.TabIndex = 43;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 1033);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnItemUSB);
            this.Controls.Add(this.btnItemUmbrella);
            this.Controls.Add(this.btnItemTripod);
            this.Controls.Add(this.btnItemSamsungCharger);
            this.Controls.Add(this.btnItemLaptopCharger);
            this.Controls.Add(this.btnItemIPhoneCharger);
            this.Controls.Add(this.btnItemHeadphones);
            this.Controls.Add(this.btnItemCameraBt);
            this.Controls.Add(this.btnItemCamera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listboxItemsToReturn);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbNotification);
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listboxItemsToLoan);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lb7);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lb5);
            this.Name = "Form1";
            this.Text = "Renting items";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lb7;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.ListBox listboxItemsToLoan;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbNotification;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.ListBox listboxItemsToReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnItemCamera;
        private System.Windows.Forms.Button btnItemCameraBt;
        private System.Windows.Forms.Button btnItemHeadphones;
        private System.Windows.Forms.Button btnItemIPhoneCharger;
        private System.Windows.Forms.Button btnItemLaptopCharger;
        private System.Windows.Forms.Button btnItemSamsungCharger;
        private System.Windows.Forms.Button btnItemTripod;
        private System.Windows.Forms.Button btnItemUmbrella;
        private System.Windows.Forms.Button btnItemUSB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
    }
}

