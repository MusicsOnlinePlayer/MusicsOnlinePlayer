namespace Musics___Client.UI
{
    partial class HomeControl
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
            this.UIHomeSearchBar = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UIHomePlaylist = new System.Windows.Forms.RadioButton();
            this.UIHomeMusic = new System.Windows.Forms.RadioButton();
            this.UIHomeAlbum = new System.Windows.Forms.RadioButton();
            this.UIHomeArtist = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // UIHomeSearchBar
            // 
            this.UIHomeSearchBar.Location = new System.Drawing.Point(77, 366);
            this.UIHomeSearchBar.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.UIHomeSearchBar.Name = "UIHomeSearchBar";
            this.UIHomeSearchBar.Size = new System.Drawing.Size(650, 20);
            this.UIHomeSearchBar.TabIndex = 6;
            this.UIHomeSearchBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIHomeSearchBar_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.UIHomePlaylist);
            this.panel3.Controls.Add(this.UIHomeMusic);
            this.panel3.Controls.Add(this.UIHomeAlbum);
            this.panel3.Controls.Add(this.UIHomeArtist);
            this.panel3.Location = new System.Drawing.Point(209, 398);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(387, 36);
            this.panel3.TabIndex = 7;
            // 
            // UIHomePlaylist
            // 
            this.UIHomePlaylist.AutoSize = true;
            this.UIHomePlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIHomePlaylist.Location = new System.Drawing.Point(282, 2);
            this.UIHomePlaylist.Name = "UIHomePlaylist";
            this.UIHomePlaylist.Size = new System.Drawing.Size(99, 29);
            this.UIHomePlaylist.TabIndex = 3;
            this.UIHomePlaylist.Text = "Playlist";
            this.UIHomePlaylist.UseVisualStyleBackColor = true;
            // 
            // UIHomeMusic
            // 
            this.UIHomeMusic.AutoSize = true;
            this.UIHomeMusic.Checked = true;
            this.UIHomeMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIHomeMusic.Location = new System.Drawing.Point(186, 2);
            this.UIHomeMusic.Name = "UIHomeMusic";
            this.UIHomeMusic.Size = new System.Drawing.Size(87, 29);
            this.UIHomeMusic.TabIndex = 2;
            this.UIHomeMusic.TabStop = true;
            this.UIHomeMusic.Text = "Music";
            this.UIHomeMusic.UseVisualStyleBackColor = true;
            // 
            // UIHomeAlbum
            // 
            this.UIHomeAlbum.AutoSize = true;
            this.UIHomeAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIHomeAlbum.Location = new System.Drawing.Point(90, 2);
            this.UIHomeAlbum.Name = "UIHomeAlbum";
            this.UIHomeAlbum.Size = new System.Drawing.Size(90, 29);
            this.UIHomeAlbum.TabIndex = 1;
            this.UIHomeAlbum.Text = "Album";
            this.UIHomeAlbum.UseVisualStyleBackColor = true;
            // 
            // UIHomeArtist
            // 
            this.UIHomeArtist.AutoSize = true;
            this.UIHomeArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIHomeArtist.Location = new System.Drawing.Point(3, 1);
            this.UIHomeArtist.Name = "UIHomeArtist";
            this.UIHomeArtist.Size = new System.Drawing.Size(79, 29);
            this.UIHomeArtist.TabIndex = 0;
            this.UIHomeArtist.Text = "Artist";
            this.UIHomeArtist.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Musics___Client.Properties.Resources.MusicicodLarge;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 350);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UIHomeSearchBar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox2);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(806, 444);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UIHomeSearchBar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton UIHomePlaylist;
        private System.Windows.Forms.RadioButton UIHomeMusic;
        private System.Windows.Forms.RadioButton UIHomeAlbum;
        private System.Windows.Forms.RadioButton UIHomeArtist;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
