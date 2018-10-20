namespace ControlLibrary
{
    partial class UPlayer
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
            this.label5 = new System.Windows.Forms.Label();
            this.UITrackbarMusic = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.UIArtist = new System.Windows.Forms.Label();
            this.UIPlayingMusic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UIFormat = new System.Windows.Forms.Label();
            this.UIMusicImage = new System.Windows.Forms.PictureBox();
            this.UIBackward = new System.Windows.Forms.Button();
            this.UIPause = new System.Windows.Forms.Button();
            this.UIPlay = new System.Windows.Forms.Button();
            this.UIForward = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UITrackbarMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(13, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 33);
            this.label5.TabIndex = 35;
            this.label5.Text = "-";
            // 
            // UITrackbarMusic
            // 
            this.UITrackbarMusic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.UITrackbarMusic.Location = new System.Drawing.Point(36, 403);
            this.UITrackbarMusic.Maximum = 100;
            this.UITrackbarMusic.Name = "UITrackbarMusic";
            this.UITrackbarMusic.Size = new System.Drawing.Size(162, 45);
            this.UITrackbarMusic.TabIndex = 29;
            this.UITrackbarMusic.TickStyle = System.Windows.Forms.TickStyle.None;
            this.UITrackbarMusic.Value = 100;
            this.UITrackbarMusic.Scroll += new System.EventHandler(this.UITrackbarMusic_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(195, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 33);
            this.label4.TabIndex = 34;
            this.label4.Text = "+";
            // 
            // UIArtist
            // 
            this.UIArtist.AutoSize = true;
            this.UIArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIArtist.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIArtist.Location = new System.Drawing.Point(20, 89);
            this.UIArtist.Name = "UIArtist";
            this.UIArtist.Size = new System.Drawing.Size(80, 24);
            this.UIArtist.TabIndex = 32;
            this.UIArtist.Text = "No Artist";
            // 
            // UIPlayingMusic
            // 
            this.UIPlayingMusic.AutoSize = true;
            this.UIPlayingMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPlayingMusic.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UIPlayingMusic.Location = new System.Drawing.Point(12, 10);
            this.UIPlayingMusic.Name = "UIPlayingMusic";
            this.UIPlayingMusic.Size = new System.Drawing.Size(127, 31);
            this.UIPlayingMusic.TabIndex = 28;
            this.UIPlayingMusic.Text = "No music";
            this.UIPlayingMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(13, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Format";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Artist";
            // 
            // UIFormat
            // 
            this.UIFormat.AutoSize = true;
            this.UIFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIFormat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIFormat.Location = new System.Drawing.Point(96, 127);
            this.UIFormat.Name = "UIFormat";
            this.UIFormat.Size = new System.Drawing.Size(0, 24);
            this.UIFormat.TabIndex = 33;
            // 
            // UIMusicImage
            // 
            this.UIMusicImage.BackgroundImage = global::ControlLibrary.Properties.Resources.No_Cover_Image;
            this.UIMusicImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIMusicImage.Location = new System.Drawing.Point(25, 195);
            this.UIMusicImage.Name = "UIMusicImage";
            this.UIMusicImage.Size = new System.Drawing.Size(175, 175);
            this.UIMusicImage.TabIndex = 38;
            this.UIMusicImage.TabStop = false;
            // 
            // UIBackward
            // 
            this.UIBackward.BackgroundImage = global::ControlLibrary.Properties.Resources.IcoBackward;
            this.UIBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIBackward.FlatAppearance.BorderSize = 0;
            this.UIBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIBackward.Location = new System.Drawing.Point(20, 454);
            this.UIBackward.Name = "UIBackward";
            this.UIBackward.Size = new System.Drawing.Size(35, 35);
            this.UIBackward.TabIndex = 36;
            this.UIBackward.UseVisualStyleBackColor = true;
            this.UIBackward.Click += new System.EventHandler(this.UIBackward_Click);
            // 
            // UIPause
            // 
            this.UIPause.BackgroundImage = global::ControlLibrary.Properties.Resources.Icopause;
            this.UIPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIPause.FlatAppearance.BorderSize = 0;
            this.UIPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIPause.Location = new System.Drawing.Point(132, 454);
            this.UIPause.Name = "UIPause";
            this.UIPause.Size = new System.Drawing.Size(35, 35);
            this.UIPause.TabIndex = 31;
            this.UIPause.UseVisualStyleBackColor = true;
            this.UIPause.Click += new System.EventHandler(this.UIPause_Click);
            // 
            // UIPlay
            // 
            this.UIPlay.BackgroundImage = global::ControlLibrary.Properties.Resources.Icoplay;
            this.UIPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIPlay.FlatAppearance.BorderSize = 0;
            this.UIPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIPlay.Location = new System.Drawing.Point(81, 454);
            this.UIPlay.Name = "UIPlay";
            this.UIPlay.Size = new System.Drawing.Size(35, 35);
            this.UIPlay.TabIndex = 30;
            this.UIPlay.UseVisualStyleBackColor = true;
            this.UIPlay.Click += new System.EventHandler(this.UIPlay_Click);
            // 
            // UIForward
            // 
            this.UIForward.BackgroundImage = global::ControlLibrary.Properties.Resources.IcoForward;
            this.UIForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIForward.FlatAppearance.BorderSize = 0;
            this.UIForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIForward.Location = new System.Drawing.Point(194, 454);
            this.UIForward.Name = "UIForward";
            this.UIForward.Size = new System.Drawing.Size(35, 35);
            this.UIForward.TabIndex = 37;
            this.UIForward.UseVisualStyleBackColor = true;
            this.UIForward.Click += new System.EventHandler(this.UIForward_Click);
            // 
            // UPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.UIMusicImage);
            this.Controls.Add(this.UIBackward);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UITrackbarMusic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UIArtist);
            this.Controls.Add(this.UIPause);
            this.Controls.Add(this.UIPlay);
            this.Controls.Add(this.UIPlayingMusic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UIForward);
            this.Controls.Add(this.UIFormat);
            this.Name = "UPlayer";
            this.Size = new System.Drawing.Size(248, 503);
            ((System.ComponentModel.ISupportInitialize)(this.UITrackbarMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UIMusicImage;
        private System.Windows.Forms.Button UIBackward;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar UITrackbarMusic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label UIArtist;
        private System.Windows.Forms.Button UIPause;
        private System.Windows.Forms.Button UIPlay;
        private System.Windows.Forms.Label UIPlayingMusic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UIForward;
        private System.Windows.Forms.Label UIFormat;
    }
}
