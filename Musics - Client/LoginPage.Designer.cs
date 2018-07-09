namespace Musics___Client
{
    partial class LoginPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UILogin = new System.Windows.Forms.TextBox();
            this.UIPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UILoginButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.UIErrorLogin = new System.Windows.Forms.Label();
            this.UIGoSignin = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UIErrorSignin = new System.Windows.Forms.Label();
            this.UIGoLogin = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.UISecondPasswordSign = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UISigninButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UIUserNameSign = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.UIPasswordSign = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "to your musics account";
            // 
            // UILogin
            // 
            this.UILogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UILogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UILogin.Location = new System.Drawing.Point(19, 170);
            this.UILogin.Name = "UILogin";
            this.UILogin.Size = new System.Drawing.Size(350, 49);
            this.UILogin.TabIndex = 2;
            this.UILogin.TextChanged += new System.EventHandler(this.UILogin_TextChanged);
            // 
            // UIPassword
            // 
            this.UIPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UIPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPassword.Location = new System.Drawing.Point(18, 272);
            this.UIPassword.Name = "UIPassword";
            this.UIPassword.PasswordChar = '*';
            this.UIPassword.Size = new System.Drawing.Size(350, 49);
            this.UIPassword.TabIndex = 3;
            this.UIPassword.TextChanged += new System.EventHandler(this.UIPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(14, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(14, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // UILoginButton
            // 
            this.UILoginButton.BackColor = System.Drawing.Color.SteelBlue;
            this.UILoginButton.FlatAppearance.BorderSize = 0;
            this.UILoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UILoginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UILoginButton.Location = new System.Drawing.Point(19, 341);
            this.UILoginButton.Name = "UILoginButton";
            this.UILoginButton.Size = new System.Drawing.Size(350, 62);
            this.UILoginButton.TabIndex = 6;
            this.UILoginButton.Text = "Login";
            this.UILoginButton.UseVisualStyleBackColor = false;
            this.UILoginButton.Click += new System.EventHandler(this.UILoginButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, -24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(422, 550);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.UIErrorLogin);
            this.tabPage1.Controls.Add(this.UIGoSignin);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.UILoginButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.UILogin);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.UIPassword);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(414, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // UIErrorLogin
            // 
            this.UIErrorLogin.AutoSize = true;
            this.UIErrorLogin.ForeColor = System.Drawing.Color.Red;
            this.UIErrorLogin.Location = new System.Drawing.Point(27, 299);
            this.UIErrorLogin.Name = "UIErrorLogin";
            this.UIErrorLogin.Size = new System.Drawing.Size(0, 13);
            this.UIErrorLogin.TabIndex = 18;
            // 
            // UIGoSignin
            // 
            this.UIGoSignin.AutoSize = true;
            this.UIGoSignin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIGoSignin.Location = new System.Drawing.Point(203, 13);
            this.UIGoSignin.Name = "UIGoSignin";
            this.UIGoSignin.Size = new System.Drawing.Size(208, 16);
            this.UIGoSignin.TabIndex = 7;
            this.UIGoSignin.TabStop = true;
            this.UIGoSignin.Text = "No account ? - Sign in in a second";
            this.UIGoSignin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UIGoSignin_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UIErrorSignin);
            this.tabPage2.Controls.Add(this.UIGoLogin);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.UISecondPasswordSign);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.UISigninButton);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.UIUserNameSign);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.UIPasswordSign);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(414, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UIErrorSignin
            // 
            this.UIErrorSignin.AutoSize = true;
            this.UIErrorSignin.ForeColor = System.Drawing.Color.Red;
            this.UIErrorSignin.Location = new System.Drawing.Point(19, 382);
            this.UIErrorSignin.Name = "UIErrorSignin";
            this.UIErrorSignin.Size = new System.Drawing.Size(0, 13);
            this.UIErrorSignin.TabIndex = 17;
            // 
            // UIGoLogin
            // 
            this.UIGoLogin.AutoSize = true;
            this.UIGoLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIGoLogin.Location = new System.Drawing.Point(203, 13);
            this.UIGoLogin.Name = "UIGoLogin";
            this.UIGoLogin.Size = new System.Drawing.Size(205, 16);
            this.UIGoLogin.TabIndex = 16;
            this.UIGoLogin.TabStop = true;
            this.UIGoLogin.Text = "Already have a account ? - Log in";
            this.UIGoLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UIGoLogin_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(14, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Repeat password";
            // 
            // UISecondPasswordSign
            // 
            this.UISecondPasswordSign.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UISecondPasswordSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISecondPasswordSign.Location = new System.Drawing.Point(19, 331);
            this.UISecondPasswordSign.Name = "UISecondPasswordSign";
            this.UISecondPasswordSign.PasswordChar = '*';
            this.UISecondPasswordSign.Size = new System.Drawing.Size(350, 49);
            this.UISecondPasswordSign.TabIndex = 14;
            this.UISecondPasswordSign.TextChanged += new System.EventHandler(this.UISecondPasswordSign_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 55);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sign in";
            // 
            // UISigninButton
            // 
            this.UISigninButton.BackColor = System.Drawing.Color.SteelBlue;
            this.UISigninButton.FlatAppearance.BorderSize = 0;
            this.UISigninButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISigninButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UISigninButton.Location = new System.Drawing.Point(19, 406);
            this.UISigninButton.Name = "UISigninButton";
            this.UISigninButton.Size = new System.Drawing.Size(350, 62);
            this.UISigninButton.TabIndex = 13;
            this.UISigninButton.Text = "Sign in";
            this.UISigninButton.UseVisualStyleBackColor = false;
            this.UISigninButton.Click += new System.EventHandler(this.UISigninButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(14, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "to your musics account";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(14, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Password";
            // 
            // UIUserNameSign
            // 
            this.UIUserNameSign.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UIUserNameSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIUserNameSign.Location = new System.Drawing.Point(19, 152);
            this.UIUserNameSign.Name = "UIUserNameSign";
            this.UIUserNameSign.Size = new System.Drawing.Size(350, 49);
            this.UIUserNameSign.TabIndex = 9;
            this.UIUserNameSign.TextChanged += new System.EventHandler(this.UIUserNameSign_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(14, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Username";
            // 
            // UIPasswordSign
            // 
            this.UIPasswordSign.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UIPasswordSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPasswordSign.Location = new System.Drawing.Point(19, 244);
            this.UIPasswordSign.Name = "UIPasswordSign";
            this.UIPasswordSign.PasswordChar = '*';
            this.UIPasswordSign.Size = new System.Drawing.Size(350, 49);
            this.UIPasswordSign.TabIndex = 10;
            this.UIPasswordSign.TextChanged += new System.EventHandler(this.UIPasswordSign_TextChanged);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 523);
            this.Controls.Add(this.tabControl1);
            this.Name = "LoginPage";
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UILogin;
        private System.Windows.Forms.TextBox UIPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UILoginButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.LinkLabel UIGoSignin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel UIGoLogin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox UISecondPasswordSign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button UISigninButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UIUserNameSign;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UIPasswordSign;
        private System.Windows.Forms.Label UIErrorLogin;
        private System.Windows.Forms.Label UIErrorSignin;
    }
}