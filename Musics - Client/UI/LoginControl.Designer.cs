namespace Musics___Client.UI
{
    partial class LoginControl
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
            this.SignInButton = new System.Windows.Forms.Button();
            this.CredentialValidatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoginLabel = new System.Windows.Forms.Label();
            this.credentialControl = new Musics___Client.UI.CredentialControl();
            ((System.ComponentModel.ISupportInitialize)(this.CredentialValidatorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SignInButton
            // 
            this.SignInButton.BackColor = System.Drawing.Color.SteelBlue;
            this.SignInButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.CredentialValidatorBindingSource, "IsValidCredential", true));
            this.SignInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SignInButton.Location = new System.Drawing.Point(21, 260);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(357, 45);
            this.SignInButton.TabIndex = 1;
            this.SignInButton.Text = "Log in";
            this.SignInButton.UseVisualStyleBackColor = false;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // CredentialValidatorBindingSource
            // 
            this.CredentialValidatorBindingSource.DataSource = typeof(Utility.Network.Users.ICredentialValidator);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.Location = new System.Drawing.Point(3, 0);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(93, 31);
            this.LoginLabel.TabIndex = 2;
            this.LoginLabel.Text = "Log in";
            // 
            // credentialControl
            // 
            this.credentialControl.Location = new System.Drawing.Point(10, 61);
            this.credentialControl.Name = "credentialControl";
            this.credentialControl.Size = new System.Drawing.Size(379, 185);
            this.credentialControl.TabIndex = 0;
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.credentialControl);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(401, 361);
            this.Load += new System.EventHandler(this.LoginControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CredentialValidatorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CredentialControl credentialControl;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.BindingSource CredentialValidatorBindingSource;
    }
}
