namespace Musics___Client.UI
{
    partial class CredentialControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.TextBox UILogin;
            System.Windows.Forms.Label loginLabel;
            System.Windows.Forms.TextBox UIPassword;
            this.CredentialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            passwordLabel = new System.Windows.Forms.Label();
            UILogin = new System.Windows.Forms.TextBox();
            loginLabel = new System.Windows.Forms.Label();
            UIPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CredentialBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            passwordLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            passwordLabel.Location = new System.Drawing.Point(13, 101);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(106, 25);
            passwordLabel.TabIndex = 9;
            passwordLabel.Text = "Password";
            // 
            // UILogin
            // 
            UILogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            UILogin.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CredentialBindingSource, "Login", true));
            UILogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UILogin.Location = new System.Drawing.Point(18, 43);
            UILogin.Name = "UILogin";
            UILogin.Size = new System.Drawing.Size(350, 33);
            UILogin.TabIndex = 6;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            loginLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            loginLabel.Location = new System.Drawing.Point(14, 12);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(110, 25);
            loginLabel.TabIndex = 8;
            loginLabel.Text = "Username";
            // 
            // UIPassword
            // 
            UIPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            UIPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CredentialBindingSource, "Password", true));
            UIPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UIPassword.Location = new System.Drawing.Point(17, 132);
            UIPassword.Name = "UIPassword";
            UIPassword.PasswordChar = '*';
            UIPassword.Size = new System.Drawing.Size(350, 33);
            UIPassword.TabIndex = 7;
            // 
            // CredentialBindingSource
            // 
            this.CredentialBindingSource.AllowNew = false;
            this.CredentialBindingSource.DataSource = typeof(Utility.Network.Users.ICredentials);
            // 
            // CredentialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(passwordLabel);
            this.Controls.Add(UILogin);
            this.Controls.Add(loginLabel);
            this.Controls.Add(UIPassword);
            this.Name = "CredentialControl";
            this.Size = new System.Drawing.Size(379, 185);
            ((System.ComponentModel.ISupportInitialize)(this.CredentialBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource CredentialBindingSource;
    }
}
