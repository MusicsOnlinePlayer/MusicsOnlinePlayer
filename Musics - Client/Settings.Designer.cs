namespace Musics___Client
{
    partial class Settings
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
            this.UISettingsIp = new System.Windows.Forms.TextBox();
            this.UISettingsApply = new System.Windows.Forms.Button();
            this.UIError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server ip";
            // 
            // UISettingsIp
            // 
            this.UISettingsIp.Location = new System.Drawing.Point(16, 101);
            this.UISettingsIp.Name = "UISettingsIp";
            this.UISettingsIp.Size = new System.Drawing.Size(328, 20);
            this.UISettingsIp.TabIndex = 2;
            this.UISettingsIp.TextChanged += new System.EventHandler(this.UISettingsIp_TextChanged);
            // 
            // UISettingsApply
            // 
            this.UISettingsApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.UISettingsApply.FlatAppearance.BorderSize = 0;
            this.UISettingsApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISettingsApply.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UISettingsApply.Location = new System.Drawing.Point(241, 439);
            this.UISettingsApply.Name = "UISettingsApply";
            this.UISettingsApply.Size = new System.Drawing.Size(166, 62);
            this.UISettingsApply.TabIndex = 7;
            this.UISettingsApply.Text = "Apply";
            this.UISettingsApply.UseVisualStyleBackColor = false;
            this.UISettingsApply.Click += new System.EventHandler(this.UISettingsApply_Click);
            // 
            // UIError
            // 
            this.UIError.AutoSize = true;
            this.UIError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UIError.Location = new System.Drawing.Point(16, 128);
            this.UIError.Name = "UIError";
            this.UIError.Size = new System.Drawing.Size(111, 13);
            this.UIError.TabIndex = 8;
            this.UIError.Text = "Please enter a valid ip";
            this.UIError.Visible = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 523);
            this.Controls.Add(this.UIError);
            this.Controls.Add(this.UISettingsApply);
            this.Controls.Add(this.UISettingsIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UISettingsIp;
        private System.Windows.Forms.Button UISettingsApply;
        private System.Windows.Forms.Label UIError;
    }
}