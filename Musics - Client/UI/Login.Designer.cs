namespace Musics___Client.UI
{
    partial class Login
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.UILoginButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.UILogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UIPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 55);
            this.label1.TabIndex = 7;
            this.label1.Text = "Login";
            // 
            // UILoginButton
            // 
            this.UILoginButton.BackColor = System.Drawing.Color.SteelBlue;
            this.UILoginButton.FlatAppearance.BorderSize = 0;
            this.UILoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UILoginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UILoginButton.Location = new System.Drawing.Point(16, 287);
            this.UILoginButton.Name = "UILoginButton";
            this.UILoginButton.Size = new System.Drawing.Size(350, 62);
            this.UILoginButton.TabIndex = 12;
            this.UILoginButton.Text = "Login";
            this.UILoginButton.UseVisualStyleBackColor = false;
            this.UILoginButton.Click += new System.EventHandler(this.UILoginButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(11, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Password";
            // 
            // UILogin
            // 
            this.UILogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UILogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UILogin.Location = new System.Drawing.Point(17, 106);
            this.UILogin.Name = "UILogin";
            this.UILogin.Size = new System.Drawing.Size(350, 49);
            this.UILogin.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(11, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Username";
            // 
            // UIPassword
            // 
            this.UIPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UIPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPassword.Location = new System.Drawing.Point(16, 208);
            this.UIPassword.Name = "UIPassword";
            this.UIPassword.PasswordChar = '*';
            this.UIPassword.Size = new System.Drawing.Size(350, 49);
            this.UIPassword.TabIndex = 9;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UILoginButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UILogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UIPassword);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(381, 367);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UILoginButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UILogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UIPassword;
    }
}
