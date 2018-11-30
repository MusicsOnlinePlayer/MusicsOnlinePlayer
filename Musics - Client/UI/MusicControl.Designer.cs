namespace Musics___Client.UI
{
    partial class MusicControl
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
            this.UIMusicImage = new System.Windows.Forms.PictureBox();
            this.UIMusicname = new System.Windows.Forms.Label();
            this.UIArtistName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // UIMusicImage
            // 
            this.UIMusicImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIMusicImage.Location = new System.Drawing.Point(0, 0);
            this.UIMusicImage.Name = "UIMusicImage";
            this.UIMusicImage.Size = new System.Drawing.Size(100, 100);
            this.UIMusicImage.TabIndex = 39;
            this.UIMusicImage.TabStop = false;
            // 
            // UIMusicname
            // 
            this.UIMusicname.AutoSize = true;
            this.UIMusicname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIMusicname.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UIMusicname.Location = new System.Drawing.Point(106, 9);
            this.UIMusicname.Name = "UIMusicname";
            this.UIMusicname.Size = new System.Drawing.Size(180, 31);
            this.UIMusicname.TabIndex = 40;
            this.UIMusicname.Text = "UIMusicname";
            this.UIMusicname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIArtistName
            // 
            this.UIArtistName.AutoSize = true;
            this.UIArtistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIArtistName.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.UIArtistName.Location = new System.Drawing.Point(108, 53);
            this.UIArtistName.Name = "UIArtistName";
            this.UIArtistName.Size = new System.Drawing.Size(118, 24);
            this.UIArtistName.TabIndex = 41;
            this.UIArtistName.Text = "UIArtistName";
            // 
            // MusicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UIArtistName);
            this.Controls.Add(this.UIMusicname);
            this.Controls.Add(this.UIMusicImage);
            this.Name = "MusicControl";
            this.Size = new System.Drawing.Size(350, 100);
            ((System.ComponentModel.ISupportInitialize)(this.UIMusicImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UIMusicImage;
        private System.Windows.Forms.Label UIMusicname;
        private System.Windows.Forms.Label UIArtistName;
    }
}
