namespace InventoryManagementSystem
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblRegister = new System.Windows.Forms.Label();
            this.lblQuestionLogin = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPasswordLogin = new System.Windows.Forms.TextBox();
            this.txtUsernameLogin = new System.Windows.Forms.TextBox();
            this.lblLoginAccount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chShowPasswordLogin = new System.Windows.Forms.CheckBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.DarkGray;
            this.panelLogin.Controls.Add(this.chShowPasswordLogin);
            this.panelLogin.Controls.Add(this.pictureBox3);
            this.panelLogin.Controls.Add(this.pictureBox2);
            this.panelLogin.Controls.Add(this.pictureBox1);
            this.panelLogin.Controls.Add(this.lblRegister);
            this.panelLogin.Controls.Add(this.lblQuestionLogin);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.txtPasswordLogin);
            this.panelLogin.Controls.Add(this.txtUsernameLogin);
            this.panelLogin.Controls.Add(this.lblLoginAccount);
            this.panelLogin.Location = new System.Drawing.Point(78, 52);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(608, 408);
            this.panelLogin.TabIndex = 0;
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegister.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblRegister.Location = new System.Drawing.Point(322, 370);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(88, 16);
            this.lblRegister.TabIndex = 5;
            this.lblRegister.Text = "Register here";
            this.lblRegister.Click += new System.EventHandler(this.lblRegister_Click);
            // 
            // lblQuestionLogin
            // 
            this.lblQuestionLogin.AutoSize = true;
            this.lblQuestionLogin.Location = new System.Drawing.Point(177, 370);
            this.lblQuestionLogin.Name = "lblQuestionLogin";
            this.lblQuestionLogin.Size = new System.Drawing.Size(136, 16);
            this.lblQuestionLogin.TabIndex = 4;
            this.lblQuestionLogin.Text = "Have no account yet?";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(124, 289);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(360, 39);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtPasswordLogin
            // 
            this.txtPasswordLogin.Location = new System.Drawing.Point(180, 218);
            this.txtPasswordLogin.Name = "txtPasswordLogin";
            this.txtPasswordLogin.PasswordChar = '*';
            this.txtPasswordLogin.Size = new System.Drawing.Size(304, 22);
            this.txtPasswordLogin.TabIndex = 2;
            // 
            // txtUsernameLogin
            // 
            this.txtUsernameLogin.Location = new System.Drawing.Point(180, 159);
            this.txtUsernameLogin.Name = "txtUsernameLogin";
            this.txtUsernameLogin.Size = new System.Drawing.Size(304, 22);
            this.txtUsernameLogin.TabIndex = 1;
            // 
            // lblLoginAccount
            // 
            this.lblLoginAccount.AutoSize = true;
            this.lblLoginAccount.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginAccount.Location = new System.Drawing.Point(207, 112);
            this.lblLoginAccount.Name = "lblLoginAccount";
            this.lblLoginAccount.Size = new System.Drawing.Size(176, 27);
            this.lblLoginAccount.TabIndex = 0;
            this.lblLoginAccount.Text = "Login Account";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(692, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::InventoryManagementSystem.Properties.Resources.Lock;
            this.pictureBox3.Location = new System.Drawing.Point(124, 214);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 26);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::InventoryManagementSystem.Properties.Resources.User_Male_1;
            this.pictureBox2.Location = new System.Drawing.Point(124, 159);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 26);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InventoryManagementSystem.Properties.Resources.Female_User;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(243, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // chShowPasswordLogin
            // 
            this.chShowPasswordLogin.AutoSize = true;
            this.chShowPasswordLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chShowPasswordLogin.Location = new System.Drawing.Point(333, 246);
            this.chShowPasswordLogin.Name = "chShowPasswordLogin";
            this.chShowPasswordLogin.Size = new System.Drawing.Size(151, 24);
            this.chShowPasswordLogin.TabIndex = 9;
            this.chShowPasswordLogin.Text = "Show Password";
            this.chShowPasswordLogin.UseVisualStyleBackColor = true;
            this.chShowPasswordLogin.CheckedChanged += new System.EventHandler(this.chShowPasswordLogin_CheckedChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(768, 513);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLoginAccount;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPasswordLogin;
        private System.Windows.Forms.TextBox txtUsernameLogin;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label lblQuestionLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chShowPasswordLogin;
    }
}

