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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.UITrackbarMusic = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.UIArtist = new System.Windows.Forms.Label();
            this.UIPlayingMusic = new System.Windows.Forms.Label();
            this.UIFormat = new System.Windows.Forms.Label();
            this.UIMusicImage = new System.Windows.Forms.PictureBox();
            this.UIBackward = new System.Windows.Forms.Button();
            this.UIPause = new System.Windows.Forms.Button();
            this.UIPlay = new System.Windows.Forms.Button();
            this.UIForward = new System.Windows.Forms.Button();
            this.UIMusicTrackBar = new System.Windows.Forms.TrackBar();
            this.TimerMusic = new System.Windows.Forms.Timer(this.components);
            this.UIMusicPosition = new System.Windows.Forms.Label();
            this.UIMusicLength = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UITrackbarMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1682, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 33);
            this.label5.TabIndex = 35;
            this.label5.Text = "-";
            // 
            // UITrackbarMusic
            // 
            this.UITrackbarMusic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.UITrackbarMusic.Location = new System.Drawing.Point(1713, 44);
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
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1881, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 33);
            this.label4.TabIndex = 34;
            this.label4.Text = "+";
            // 
            // UIArtist
            // 
            this.UIArtist.AutoSize = true;
            this.UIArtist.Font = new System.Drawing.Font("Raleway Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIArtist.ForeColor = System.Drawing.Color.Black;
            this.UIArtist.Location = new System.Drawing.Point(109, 34);
            this.UIArtist.Name = "UIArtist";
            this.UIArtist.Size = new System.Drawing.Size(84, 22);
            this.UIArtist.TabIndex = 32;
            this.UIArtist.Text = "No Artist";
            // 
            // UIPlayingMusic
            // 
            this.UIPlayingMusic.AutoSize = true;
            this.UIPlayingMusic.Font = new System.Drawing.Font("Raleway SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPlayingMusic.ForeColor = System.Drawing.Color.DimGray;
            this.UIPlayingMusic.Location = new System.Drawing.Point(107, 3);
            this.UIPlayingMusic.Name = "UIPlayingMusic";
            this.UIPlayingMusic.Size = new System.Drawing.Size(134, 31);
            this.UIPlayingMusic.TabIndex = 28;
            this.UIPlayingMusic.Text = "No music";
            this.UIPlayingMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIFormat
            // 
            this.UIFormat.AutoSize = true;
            this.UIFormat.Font = new System.Drawing.Font("Raleway SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIFormat.ForeColor = System.Drawing.Color.Black;
            this.UIFormat.Location = new System.Drawing.Point(109, 79);
            this.UIFormat.Name = "UIFormat";
            this.UIFormat.Size = new System.Drawing.Size(0, 22);
            this.UIFormat.TabIndex = 33;
            // 
            // UIMusicImage
            // 
            this.UIMusicImage.BackgroundImage = global::ControlLibrary.Properties.Resources.No_Cover_Image;
            this.UIMusicImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIMusicImage.Location = new System.Drawing.Point(3, 3);
            this.UIMusicImage.Name = "UIMusicImage";
            this.UIMusicImage.Size = new System.Drawing.Size(100, 100);
            this.UIMusicImage.TabIndex = 38;
            this.UIMusicImage.TabStop = false;
            // 
            // UIBackward
            // 
            this.UIBackward.BackgroundImage = global::ControlLibrary.Properties.Resources.IcoBackward;
            this.UIBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIBackward.FlatAppearance.BorderSize = 0;
            this.UIBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIBackward.Location = new System.Drawing.Point(856, 31);
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
            this.UIPause.Location = new System.Drawing.Point(972, 31);
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
            this.UIPlay.Location = new System.Drawing.Point(914, 31);
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
            this.UIForward.Location = new System.Drawing.Point(1030, 31);
            this.UIForward.Name = "UIForward";
            this.UIForward.Size = new System.Drawing.Size(35, 35);
            this.UIForward.TabIndex = 37;
            this.UIForward.UseVisualStyleBackColor = true;
            this.UIForward.Click += new System.EventHandler(this.UIForward_Click);
            // 
            // UIMusicTrackBar
            // 
            this.UIMusicTrackBar.LargeChange = 2;
            this.UIMusicTrackBar.Location = new System.Drawing.Point(260, 76);
            this.UIMusicTrackBar.Maximum = 100;
            this.UIMusicTrackBar.Name = "UIMusicTrackBar";
            this.UIMusicTrackBar.Size = new System.Drawing.Size(1400, 45);
            this.UIMusicTrackBar.TabIndex = 39;
            this.UIMusicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.UIMusicTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIMusicTrackBar_MouseDown);
            this.UIMusicTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UIMusicTrackBar_MouseUp);
            // 
            // TimerMusic
            // 
            this.TimerMusic.Interval = 500;
            this.TimerMusic.Tick += new System.EventHandler(this.TimerMusic_Tick);
            // 
            // UIMusicPosition
            // 
            this.UIMusicPosition.AutoSize = true;
            this.UIMusicPosition.Font = new System.Drawing.Font("Raleway Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIMusicPosition.ForeColor = System.Drawing.Color.Black;
            this.UIMusicPosition.Location = new System.Drawing.Point(217, 76);
            this.UIMusicPosition.Name = "UIMusicPosition";
            this.UIMusicPosition.Size = new System.Drawing.Size(37, 22);
            this.UIMusicPosition.TabIndex = 40;
            this.UIMusicPosition.Text = "0:0";
            // 
            // UIMusicLength
            // 
            this.UIMusicLength.AutoSize = true;
            this.UIMusicLength.Font = new System.Drawing.Font("Raleway Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIMusicLength.ForeColor = System.Drawing.Color.Black;
            this.UIMusicLength.Location = new System.Drawing.Point(1666, 76);
            this.UIMusicLength.Name = "UIMusicLength";
            this.UIMusicLength.Size = new System.Drawing.Size(37, 22);
            this.UIMusicLength.TabIndex = 41;
            this.UIMusicLength.Text = "0:0";
            // 
            // UPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.UIMusicLength);
            this.Controls.Add(this.UIMusicPosition);
            this.Controls.Add(this.UIMusicTrackBar);
            this.Controls.Add(this.UIMusicImage);
            this.Controls.Add(this.UIBackward);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UITrackbarMusic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UIArtist);
            this.Controls.Add(this.UIPause);
            this.Controls.Add(this.UIPlay);
            this.Controls.Add(this.UIPlayingMusic);
            this.Controls.Add(this.UIForward);
            this.Controls.Add(this.UIFormat);
            this.Name = "UPlayer";
            this.Size = new System.Drawing.Size(1920, 106);
            ((System.ComponentModel.ISupportInitialize)(this.UITrackbarMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicTrackBar)).EndInit();
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
        private System.Windows.Forms.Button UIForward;
        private System.Windows.Forms.Label UIFormat;
        private System.Windows.Forms.TrackBar UIMusicTrackBar;
        private System.Windows.Forms.Timer TimerMusic;
        private System.Windows.Forms.Label UIMusicPosition;
        private System.Windows.Forms.Label UIMusicLength;
    }
}
