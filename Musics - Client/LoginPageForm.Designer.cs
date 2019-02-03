namespace Musics___Client
{
    partial class LoginPageForm
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
            this.login1 = new Musics___Client.UI.Login();
            this.SuspendLayout();
            // 
            // login1
            // 
            this.login1.Location = new System.Drawing.Point(1, 0);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(381, 367);
            this.login1.TabIndex = 0;
            // 
            // LoginPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 373);
            this.Controls.Add(this.login1);
            this.Name = "LoginPageForm";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        public UI.Login login1;
    }
}