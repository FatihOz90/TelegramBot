
namespace TelegramBot
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.btn_ListMembers = new System.Windows.Forms.Button();
            this.txtGetGroupID = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtApiID = new System.Windows.Forms.TextBox();
            this.txtAPiHash = new System.Windows.Forms.TextBox();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baslatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durdurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grubaUyeEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYourGroupID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.databaseAllDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(619, 59);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(543, 476);
            this.txtLogs.TabIndex = 0;
            // 
            // btn_ListMembers
            // 
            this.btn_ListMembers.Location = new System.Drawing.Point(1032, 30);
            this.btn_ListMembers.Name = "btn_ListMembers";
            this.btn_ListMembers.Size = new System.Drawing.Size(111, 23);
            this.btn_ListMembers.TabIndex = 2;
            this.btn_ListMembers.Text = "Uyeleri Listele";
            this.btn_ListMembers.UseVisualStyleBackColor = true;
            this.btn_ListMembers.Click += new System.EventHandler(this.Run_btn_listmembers);
            // 
            // txtGetGroupID
            // 
            this.txtGetGroupID.Location = new System.Drawing.Point(915, 32);
            this.txtGetGroupID.Name = "txtGetGroupID";
            this.txtGetGroupID.Size = new System.Drawing.Size(111, 20);
            this.txtGetGroupID.TabIndex = 3;
            this.txtGetGroupID.Tag = "Grup Num.";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(498, 128);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(92, 30);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.Text = "Mesaj Gönder";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 128);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(601, 407);
            this.txtMessage.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(387, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtApiID
            // 
            this.txtApiID.Location = new System.Drawing.Point(75, 28);
            this.txtApiID.Name = "txtApiID";
            this.txtApiID.Size = new System.Drawing.Size(306, 20);
            this.txtApiID.TabIndex = 9;
            // 
            // txtAPiHash
            // 
            this.txtAPiHash.Location = new System.Drawing.Point(75, 51);
            this.txtAPiHash.Name = "txtAPiHash";
            this.txtAPiHash.Size = new System.Drawing.Size(306, 20);
            this.txtAPiHash.TabIndex = 10;
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(75, 77);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(119, 20);
            this.txtPhoneNum.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "API ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "API HASH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "TEL. NO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "+90 ile başlamalıdır";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemToolStripMenuItem,
            this.grupListeleToolStripMenuItem,
            this.grubaUyeEkleToolStripMenuItem,
            this.databaseUpdateToolStripMenuItem,
            this.databaseAllDeleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1162, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemToolStripMenuItem
            // 
            this.sistemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baslatToolStripMenuItem,
            this.durdurToolStripMenuItem});
            this.sistemToolStripMenuItem.Name = "sistemToolStripMenuItem";
            this.sistemToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.sistemToolStripMenuItem.Text = "Sistem";
            // 
            // baslatToolStripMenuItem
            // 
            this.baslatToolStripMenuItem.Name = "baslatToolStripMenuItem";
            this.baslatToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.baslatToolStripMenuItem.Text = "Başlat";
            this.baslatToolStripMenuItem.Click += new System.EventHandler(this.baslatToolStripMenuItem_Click);
            // 
            // durdurToolStripMenuItem
            // 
            this.durdurToolStripMenuItem.Enabled = false;
            this.durdurToolStripMenuItem.Name = "durdurToolStripMenuItem";
            this.durdurToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.durdurToolStripMenuItem.Text = "Durdur";
            this.durdurToolStripMenuItem.Click += new System.EventHandler(this.durdurToolStripMenuItem_Click);
            // 
            // grupListeleToolStripMenuItem
            // 
            this.grupListeleToolStripMenuItem.Name = "grupListeleToolStripMenuItem";
            this.grupListeleToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.grupListeleToolStripMenuItem.Text = "Grup Listele";
            this.grupListeleToolStripMenuItem.Click += new System.EventHandler(this.grupListeleToolStripMenuItem_Click);
            // 
            // grubaUyeEkleToolStripMenuItem
            // 
            this.grubaUyeEkleToolStripMenuItem.Name = "grubaUyeEkleToolStripMenuItem";
            this.grubaUyeEkleToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.grubaUyeEkleToolStripMenuItem.Text = "Gruba Uye Ekle";
            this.grubaUyeEkleToolStripMenuItem.Click += new System.EventHandler(this.grubaUyeEkleToolStripMenuItem_Click);
            // 
            // databaseUpdateToolStripMenuItem
            // 
            this.databaseUpdateToolStripMenuItem.Name = "databaseUpdateToolStripMenuItem";
            this.databaseUpdateToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.databaseUpdateToolStripMenuItem.Text = "Veritabanı Guncelle";
            this.databaseUpdateToolStripMenuItem.Click += new System.EventHandler(this.databaseUpdateToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "GROUP ID";
            // 
            // txtYourGroupID
            // 
            this.txtYourGroupID.Location = new System.Drawing.Point(75, 102);
            this.txtYourGroupID.Name = "txtYourGroupID";
            this.txtYourGroupID.Size = new System.Drawing.Size(119, 20);
            this.txtYourGroupID.TabIndex = 18;
            this.txtYourGroupID.Text = "0000000000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Kendi Grup id bilgisini buraya giriniz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(775, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Üyelerin çekileceği grup ID";
            // 
            // databaseAllDeleteToolStripMenuItem
            // 
            this.databaseAllDeleteToolStripMenuItem.Name = "databaseAllDeleteToolStripMenuItem";
            this.databaseAllDeleteToolStripMenuItem.Size = new System.Drawing.Size(162, 20);
            this.databaseAllDeleteToolStripMenuItem.Text = "Veritabanı Uyelerini Temizle";
            this.databaseAllDeleteToolStripMenuItem.Click += new System.EventHandler(this.databaseAllDeleteToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 547);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtYourGroupID);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhoneNum);
            this.Controls.Add(this.txtAPiHash);
            this.Controls.Add(this.txtApiID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtGetGroupID);
            this.Controls.Add(this.btn_ListMembers);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Telegram Bot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btn_ListMembers;
        private System.Windows.Forms.TextBox txtGetGroupID;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtApiID;
        private System.Windows.Forms.TextBox txtAPiHash;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grupListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grubaUyeEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baslatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem durdurToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYourGroupID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem databaseAllDeleteToolStripMenuItem;
    }
}

