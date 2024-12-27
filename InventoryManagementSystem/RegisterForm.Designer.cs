namespace InventoryManagementSystem
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblQuestionRegister = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtPasswordRegister = new System.Windows.Forms.TextBox();
            this.txtUsernameRegister = new System.Windows.Forms.TextBox();
            this.lblRegisterAccount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtConfirmPasswordRegister = new System.Windows.Forms.TextBox();
            this.chShowPasswordRegister = new System.Windows.Forms.CheckBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.DarkGray;
            this.panelLogin.Controls.Add(this.chShowPasswordRegister);
            this.panelLogin.Controls.Add(this.pictureBox4);
            this.panelLogin.Controls.Add(this.txtConfirmPasswordRegister);
            this.panelLogin.Controls.Add(this.pictureBox3);
            this.panelLogin.Controls.Add(this.pictureBox2);
            this.panelLogin.Controls.Add(this.lblLogin);
            this.panelLogin.Controls.Add(this.lblQuestionRegister);
            this.panelLogin.Controls.Add(this.btnRegister);
            this.panelLogin.Controls.Add(this.txtPasswordRegister);
            this.panelLogin.Controls.Add(this.txtUsernameRegister);
            this.panelLogin.Controls.Add(this.lblRegisterAccount);
            this.panelLogin.Controls.Add(this.pictureBox1);
            this.panelLogin.Location = new System.Drawing.Point(66, 49);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(616, 415);
            this.panelLogin.TabIndex = 2;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogin.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLogin.Location = new System.Drawing.Point(325, 373);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(77, 16);
            this.lblLogin.TabIndex = 5;
            this.lblLogin.Text = "Sign in here";
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // lblQuestionRegister
            // 
            this.lblQuestionRegister.AutoSize = true;
            this.lblQuestionRegister.Location = new System.Drawing.Point(177, 373);
            this.lblQuestionRegister.Name = "lblQuestionRegister";
            this.lblQuestionRegister.Size = new System.Drawing.Size(144, 16);
            this.lblQuestionRegister.TabIndex = 4;
            this.lblQuestionRegister.Text = "Already have account?";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(137, 312);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(311, 46);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtPasswordRegister
            // 
            this.txtPasswordRegister.Location = new System.Drawing.Point(193, 200);
            this.txtPasswordRegister.Name = "txtPasswordRegister";
            this.txtPasswordRegister.PasswordChar = '*';
            this.txtPasswordRegister.Size = new System.Drawing.Size(255, 22);
            this.txtPasswordRegister.TabIndex = 2;
            // 
            // txtUsernameRegister
            // 
            this.txtUsernameRegister.Location = new System.Drawing.Point(193, 147);
            this.txtUsernameRegister.Name = "txtUsernameRegister";
            this.txtUsernameRegister.Size = new System.Drawing.Size(255, 22);
            this.txtUsernameRegister.TabIndex = 1;
            // 
            // lblRegisterAccount
            // 
            this.lblRegisterAccount.AutoSize = true;
            this.lblRegisterAccount.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterAccount.Location = new System.Drawing.Point(193, 104);
            this.lblRegisterAccount.Name = "lblRegisterAccount";
            this.lblRegisterAccount.Size = new System.Drawing.Size(206, 27);
            this.lblRegisterAccount.TabIndex = 0;
            this.lblRegisterAccount.Text = "Register Account";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(680, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::InventoryManagementSystem.Properties.Resources.Lock;
            this.pictureBox3.Location = new System.Drawing.Point(137, 189);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 33);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::InventoryManagementSystem.Properties.Resources.User_Male_1;
            this.pictureBox2.Location = new System.Drawing.Point(137, 140);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 33);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InventoryManagementSystem.Properties.Resources.Female_User;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(244, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::InventoryManagementSystem.Properties.Resources.Lock;
            this.pictureBox4.Location = new System.Drawing.Point(137, 240);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 33);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // txtConfirmPasswordRegister
            // 
            this.txtConfirmPasswordRegister.Location = new System.Drawing.Point(193, 248);
            this.txtConfirmPasswordRegister.Name = "txtConfirmPasswordRegister";
            this.txtConfirmPasswordRegister.PasswordChar = '*';
            this.txtConfirmPasswordRegister.Size = new System.Drawing.Size(255, 22);
            this.txtConfirmPasswordRegister.TabIndex = 9;
            // 
            // chShowPasswordRegister
            // 
            this.chShowPasswordRegister.AutoSize = true;
            this.chShowPasswordRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chShowPasswordRegister.Location = new System.Drawing.Point(297, 281);
            this.chShowPasswordRegister.Name = "chShowPasswordRegister";
            this.chShowPasswordRegister.Size = new System.Drawing.Size(151, 24);
            this.chShowPasswordRegister.TabIndex = 11;
            this.chShowPasswordRegister.Text = "Show Password";
            this.chShowPasswordRegister.UseVisualStyleBackColor = true;
            this.chShowPasswordRegister.CheckedChanged += new System.EventHandler(this.chShowPasswordRegister_CheckedChanged);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(768, 513);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblQuestionRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtPasswordRegister;
        private System.Windows.Forms.TextBox txtUsernameRegister;
        private System.Windows.Forms.Label lblRegisterAccount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtConfirmPasswordRegister;
        private System.Windows.Forms.CheckBox chShowPasswordRegister;
    }
}