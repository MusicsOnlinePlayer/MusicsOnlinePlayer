namespace Musics___Client
{
    partial class LoginForm
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
            this.LoginControl = new Musics___Client.UI.LoginControl();
            this.SuspendLayout();
            // 
            // loginControl1
            // 
            this.LoginControl.Location = new System.Drawing.Point(13, 28);
            this.LoginControl.Name = "loginControl1";
            this.LoginControl.Size = new System.Drawing.Size(414, 410);
            this.LoginControl.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 587);
            this.Controls.Add(this.LoginControl);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.LoginControl LoginControl;
    }
}