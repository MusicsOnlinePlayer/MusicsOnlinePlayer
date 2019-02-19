namespace Musics___Client.UI
{
    partial class TrackerControl
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
            this.label12 = new System.Windows.Forms.Label();
            this.UIStatut = new System.Windows.Forms.Label();
            this.UITrackers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UINewtrackerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UITrackerPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UIAddTrackerButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.UiTrackerServer = new System.Windows.Forms.ListBox();
            this.UITrackerRemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Raleway Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(8, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(340, 37);
            this.label12.TabIndex = 20;
            this.label12.Text = "Trackers connection";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIStatut
            // 
            this.UIStatut.AutoSize = true;
            this.UIStatut.Font = new System.Drawing.Font("Raleway", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIStatut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UIStatut.Location = new System.Drawing.Point(354, 7);
            this.UIStatut.Name = "UIStatut";
            this.UIStatut.Size = new System.Drawing.Size(137, 37);
            this.UIStatut.TabIndex = 21;
            this.UIStatut.Text = "UIStatut";
            this.UIStatut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UITrackers
            // 
            this.UITrackers.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UITrackers.FormattingEnabled = true;
            this.UITrackers.ItemHeight = 25;
            this.UITrackers.Location = new System.Drawing.Point(37, 86);
            this.UITrackers.Name = "UITrackers";
            this.UITrackers.Size = new System.Drawing.Size(800, 379);
            this.UITrackers.TabIndex = 39;
            this.UITrackers.SelectedIndexChanged += new System.EventHandler(this.UITrackers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(32, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 29);
            this.label1.TabIndex = 40;
            this.label1.Text = "Active Trackers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(32, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "Add Trackers";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UINewtrackerIP
            // 
            this.UINewtrackerIP.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UINewtrackerIP.Location = new System.Drawing.Point(102, 525);
            this.UINewtrackerIP.Margin = new System.Windows.Forms.Padding(10);
            this.UINewtrackerIP.Name = "UINewtrackerIP";
            this.UINewtrackerIP.Size = new System.Drawing.Size(437, 32);
            this.UINewtrackerIP.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(38, 528);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "IP ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UITrackerPort
            // 
            this.UITrackerPort.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UITrackerPort.Location = new System.Drawing.Point(102, 577);
            this.UITrackerPort.Margin = new System.Windows.Forms.Padding(10);
            this.UITrackerPort.Name = "UITrackerPort";
            this.UITrackerPort.Size = new System.Drawing.Size(201, 32);
            this.UITrackerPort.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(38, 580);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 25);
            this.label4.TabIndex = 46;
            this.label4.Text = "Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIAddTrackerButton
            // 
            this.UIAddTrackerButton.BackColor = System.Drawing.Color.LimeGreen;
            this.UIAddTrackerButton.FlatAppearance.BorderSize = 0;
            this.UIAddTrackerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIAddTrackerButton.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIAddTrackerButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIAddTrackerButton.Location = new System.Drawing.Point(420, 577);
            this.UIAddTrackerButton.Name = "UIAddTrackerButton";
            this.UIAddTrackerButton.Size = new System.Drawing.Size(119, 36);
            this.UIAddTrackerButton.TabIndex = 47;
            this.UIAddTrackerButton.Text = "Add";
            this.UIAddTrackerButton.UseVisualStyleBackColor = false;
            this.UIAddTrackerButton.Click += new System.EventHandler(this.UIUpload_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(884, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 29);
            this.label5.TabIndex = 49;
            this.label5.Text = "Tracker information";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UiTrackerServer
            // 
            this.UiTrackerServer.Enabled = false;
            this.UiTrackerServer.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiTrackerServer.FormattingEnabled = true;
            this.UiTrackerServer.ItemHeight = 25;
            this.UiTrackerServer.Location = new System.Drawing.Point(889, 86);
            this.UiTrackerServer.Name = "UiTrackerServer";
            this.UiTrackerServer.Size = new System.Drawing.Size(800, 379);
            this.UiTrackerServer.TabIndex = 48;
            // 
            // UITrackerRemoveButton
            // 
            this.UITrackerRemoveButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UITrackerRemoveButton.FlatAppearance.BorderSize = 0;
            this.UITrackerRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UITrackerRemoveButton.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UITrackerRemoveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UITrackerRemoveButton.Location = new System.Drawing.Point(718, 471);
            this.UITrackerRemoveButton.Name = "UITrackerRemoveButton";
            this.UITrackerRemoveButton.Size = new System.Drawing.Size(119, 36);
            this.UITrackerRemoveButton.TabIndex = 50;
            this.UITrackerRemoveButton.Text = "Remove";
            this.UITrackerRemoveButton.UseVisualStyleBackColor = false;
            this.UITrackerRemoveButton.Click += new System.EventHandler(this.UITrackerRemoveButton_Click);
            // 
            // TrackerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UITrackerRemoveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UiTrackerServer);
            this.Controls.Add(this.UIAddTrackerButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UITrackerPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UINewtrackerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UITrackers);
            this.Controls.Add(this.UIStatut);
            this.Controls.Add(this.label12);
            this.Name = "TrackerControl";
            this.Size = new System.Drawing.Size(1901, 897);
            this.Load += new System.EventHandler(this.TrackerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label UIStatut;
        private System.Windows.Forms.ListBox UITrackers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UINewtrackerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UITrackerPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UIAddTrackerButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox UiTrackerServer;
        private System.Windows.Forms.Button UITrackerRemoveButton;
    }
}
