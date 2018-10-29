namespace ControlLibrary.User_Interface
{
    partial class HueControl
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
            this.components = new System.ComponentModel.Container();
            this.UIHueDelay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.UILightList = new System.Windows.Forms.CheckedListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.UISoundLevel = new System.Windows.Forms.ProgressBar();
            this.UIHueIp = new System.Windows.Forms.TextBox();
            this.UIHueApi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.UIHueConnection = new System.Windows.Forms.Label();
            this.UIHueConnectRegister = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UIHueConnectKey = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.HueTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UIHueDelay
            // 
            this.UIHueDelay.Location = new System.Drawing.Point(428, 376);
            this.UIHueDelay.Name = "UIHueDelay";
            this.UIHueDelay.Size = new System.Drawing.Size(412, 20);
            this.UIHueDelay.TabIndex = 47;
            this.UIHueDelay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIHueDelay_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(423, 347);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 24);
            this.label13.TabIndex = 46;
            this.label13.Text = "Delay (ms)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UILightList
            // 
            this.UILightList.FormattingEnabled = true;
            this.UILightList.Location = new System.Drawing.Point(427, 217);
            this.UILightList.Name = "UILightList";
            this.UILightList.Size = new System.Drawing.Size(756, 94);
            this.UILightList.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(720, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 24);
            this.label11.TabIndex = 44;
            this.label11.Text = "Sound level :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UISoundLevel
            // 
            this.UISoundLevel.Location = new System.Drawing.Point(850, 12);
            this.UISoundLevel.Name = "UISoundLevel";
            this.UISoundLevel.Size = new System.Drawing.Size(298, 26);
            this.UISoundLevel.TabIndex = 43;
            // 
            // UIHueIp
            // 
            this.UIHueIp.Location = new System.Drawing.Point(30, 83);
            this.UIHueIp.Name = "UIHueIp";
            this.UIHueIp.Size = new System.Drawing.Size(412, 20);
            this.UIHueIp.TabIndex = 42;
            // 
            // UIHueApi
            // 
            this.UIHueApi.Location = new System.Drawing.Point(30, 161);
            this.UIHueApi.Name = "UIHueApi";
            this.UIHueApi.Size = new System.Drawing.Size(780, 20);
            this.UIHueApi.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(25, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 24);
            this.label10.TabIndex = 41;
            this.label10.Text = "Bridge Ip";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIHueConnection
            // 
            this.UIHueConnection.AutoSize = true;
            this.UIHueConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIHueConnection.ForeColor = System.Drawing.Color.Brown;
            this.UIHueConnection.Location = new System.Drawing.Point(90, 12);
            this.UIHueConnection.Name = "UIHueConnection";
            this.UIHueConnection.Size = new System.Drawing.Size(151, 25);
            this.UIHueConnection.TabIndex = 40;
            this.UIHueConnection.Text = "Not connected";
            this.UIHueConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIHueConnectRegister
            // 
            this.UIHueConnectRegister.BackColor = System.Drawing.Color.LimeGreen;
            this.UIHueConnectRegister.FlatAppearance.BorderSize = 0;
            this.UIHueConnectRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIHueConnectRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIHueConnectRegister.Location = new System.Drawing.Point(29, 281);
            this.UIHueConnectRegister.Name = "UIHueConnectRegister";
            this.UIHueConnectRegister.Size = new System.Drawing.Size(272, 36);
            this.UIHueConnectRegister.TabIndex = 39;
            this.UIHueConnectRegister.Text = "Connect and Register";
            this.UIHueConnectRegister.UseVisualStyleBackColor = false;
            this.UIHueConnectRegister.Click += new System.EventHandler(this.UIHueConnectRegister_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(26, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 20);
            this.label9.TabIndex = 38;
            this.label9.Text = "Press the button and click connect";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(26, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 24);
            this.label8.TabIndex = 37;
            this.label8.Text = "Register :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIHueConnectKey
            // 
            this.UIHueConnectKey.BackColor = System.Drawing.Color.LimeGreen;
            this.UIHueConnectKey.FlatAppearance.BorderSize = 0;
            this.UIHueConnectKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIHueConnectKey.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIHueConnectKey.Location = new System.Drawing.Point(816, 160);
            this.UIHueConnectKey.Name = "UIHueConnectKey";
            this.UIHueConnectKey.Size = new System.Drawing.Size(119, 36);
            this.UIHueConnectKey.TabIndex = 36;
            this.UIHueConnectKey.Text = "Connect";
            this.UIHueConnectKey.UseVisualStyleBackColor = false;
            this.UIHueConnectKey.Click += new System.EventHandler(this.UIHueConnectKey_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(25, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 24);
            this.label7.TabIndex = 34;
            this.label7.Text = "Api key :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 37);
            this.label6.TabIndex = 33;
            this.label6.Text = "Hue";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HueTimer
            // 
            this.HueTimer.Tick += new System.EventHandler(this.HueTimer_Tick);
            // 
            // HueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.UIHueDelay);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.UILightList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.UISoundLevel);
            this.Controls.Add(this.UIHueIp);
            this.Controls.Add(this.UIHueApi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.UIHueConnection);
            this.Controls.Add(this.UIHueConnectRegister);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.UIHueConnectKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HueControl";
            this.Size = new System.Drawing.Size(1186, 399);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UIHueDelay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox UILightList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar UISoundLevel;
        private System.Windows.Forms.TextBox UIHueIp;
        private System.Windows.Forms.TextBox UIHueApi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label UIHueConnection;
        private System.Windows.Forms.Button UIHueConnectRegister;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button UIHueConnectKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer HueTimer;
    }
}
