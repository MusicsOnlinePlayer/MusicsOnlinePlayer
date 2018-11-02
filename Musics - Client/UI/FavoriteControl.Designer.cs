namespace Musics___Client.UI
{
    partial class FavoriteControl
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
            this.UILikedMusicsList = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.UIFavoritesBack = new System.Windows.Forms.Button();
            this.UIPlayFavorites = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UILikedMusicsList
            // 
            this.UILikedMusicsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UILikedMusicsList.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UILikedMusicsList.FormattingEnabled = true;
            this.UILikedMusicsList.ItemHeight = 25;
            this.UILikedMusicsList.Location = new System.Drawing.Point(15, 49);
            this.UILikedMusicsList.Margin = new System.Windows.Forms.Padding(0);
            this.UILikedMusicsList.Name = "UILikedMusicsList";
            this.UILikedMusicsList.Size = new System.Drawing.Size(1168, 304);
            this.UILikedMusicsList.TabIndex = 20;
            this.UILikedMusicsList.DoubleClick += new System.EventHandler(this.UILikedMusicsList_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(8, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(202, 37);
            this.label12.TabIndex = 19;
            this.label12.Text = "Liked musics";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIFavoritesBack
            // 
            this.UIFavoritesBack.BackgroundImage = global::Musics___Client.Properties.Resources.IcoBack;
            this.UIFavoritesBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIFavoritesBack.FlatAppearance.BorderSize = 0;
            this.UIFavoritesBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIFavoritesBack.Location = new System.Drawing.Point(216, 16);
            this.UIFavoritesBack.Name = "UIFavoritesBack";
            this.UIFavoritesBack.Size = new System.Drawing.Size(30, 30);
            this.UIFavoritesBack.TabIndex = 22;
            this.UIFavoritesBack.UseVisualStyleBackColor = true;
            this.UIFavoritesBack.Click += new System.EventHandler(this.UIFavoritesBack_Click);
            // 
            // UIPlayFavorites
            // 
            this.UIPlayFavorites.BackgroundImage = global::Musics___Client.Properties.Resources.Icoplay;
            this.UIPlayFavorites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIPlayFavorites.FlatAppearance.BorderSize = 0;
            this.UIPlayFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIPlayFavorites.Location = new System.Drawing.Point(265, 18);
            this.UIPlayFavorites.Name = "UIPlayFavorites";
            this.UIPlayFavorites.Size = new System.Drawing.Size(30, 30);
            this.UIPlayFavorites.TabIndex = 21;
            this.UIPlayFavorites.UseVisualStyleBackColor = true;
            this.UIPlayFavorites.Click += new System.EventHandler(this.UIPlayFavorites_Click);
            // 
            // FavoriteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UIFavoritesBack);
            this.Controls.Add(this.UIPlayFavorites);
            this.Controls.Add(this.UILikedMusicsList);
            this.Controls.Add(this.label12);
            this.Name = "FavoriteControl";
            this.Size = new System.Drawing.Size(1193, 361);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UIFavoritesBack;
        private System.Windows.Forms.Button UIPlayFavorites;
        private System.Windows.Forms.ListBox UILikedMusicsList;
        private System.Windows.Forms.Label label12;
    }
}
