namespace ServerCreator
{
    partial class Main
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UIButtonSelectFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UIInfos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UIPath = new System.Windows.Forms.TextBox();
            this.UIExplore = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.UIFinnish = new System.Windows.Forms.Button();
            this.UIProgress = new System.Windows.Forms.ProgressBar();
            this.UIFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.UIFolderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Creator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(19, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "1. Select your musics";
            // 
            // UIButtonSelectFile
            // 
            this.UIButtonSelectFile.BackColor = System.Drawing.Color.LimeGreen;
            this.UIButtonSelectFile.FlatAppearance.BorderSize = 0;
            this.UIButtonSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIButtonSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIButtonSelectFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIButtonSelectFile.Location = new System.Drawing.Point(23, 110);
            this.UIButtonSelectFile.Name = "UIButtonSelectFile";
            this.UIButtonSelectFile.Size = new System.Drawing.Size(154, 36);
            this.UIButtonSelectFile.TabIndex = 17;
            this.UIButtonSelectFile.Text = "Select ...";
            this.UIButtonSelectFile.UseVisualStyleBackColor = false;
            this.UIButtonSelectFile.Click += new System.EventHandler(this.UIButtonSelectFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(19, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "2. Selection infos";
            // 
            // UIInfos
            // 
            this.UIInfos.AutoSize = true;
            this.UIInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIInfos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UIInfos.Location = new System.Drawing.Point(30, 228);
            this.UIInfos.Name = "UIInfos";
            this.UIInfos.Size = new System.Drawing.Size(0, 24);
            this.UIInfos.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(19, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "3. Select destination path";
            // 
            // UIPath
            // 
            this.UIPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPath.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIPath.Location = new System.Drawing.Point(23, 349);
            this.UIPath.Name = "UIPath";
            this.UIPath.Size = new System.Drawing.Size(497, 29);
            this.UIPath.TabIndex = 21;
            // 
            // UIExplore
            // 
            this.UIExplore.BackColor = System.Drawing.Color.Teal;
            this.UIExplore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIExplore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIExplore.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.UIExplore.Location = new System.Drawing.Point(527, 349);
            this.UIExplore.Name = "UIExplore";
            this.UIExplore.Size = new System.Drawing.Size(98, 29);
            this.UIExplore.TabIndex = 23;
            this.UIExplore.Text = "Explorer";
            this.UIExplore.UseVisualStyleBackColor = false;
            this.UIExplore.Click += new System.EventHandler(this.UIExplore_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(19, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "4. Finish !";
            // 
            // UIFinnish
            // 
            this.UIFinnish.BackColor = System.Drawing.Color.LimeGreen;
            this.UIFinnish.FlatAppearance.BorderSize = 0;
            this.UIFinnish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIFinnish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIFinnish.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIFinnish.Location = new System.Drawing.Point(23, 463);
            this.UIFinnish.Name = "UIFinnish";
            this.UIFinnish.Size = new System.Drawing.Size(115, 36);
            this.UIFinnish.TabIndex = 25;
            this.UIFinnish.Text = "Finish";
            this.UIFinnish.UseVisualStyleBackColor = false;
            this.UIFinnish.Click += new System.EventHandler(this.UIFinnish_Click);
            // 
            // UIProgress
            // 
            this.UIProgress.Location = new System.Drawing.Point(23, 524);
            this.UIProgress.Name = "UIProgress";
            this.UIProgress.Size = new System.Drawing.Size(602, 23);
            this.UIProgress.TabIndex = 26;
            // 
            // UIFileDialog
            // 
            this.UIFileDialog.FileName = "openFileDialog1";
            this.UIFileDialog.Multiselect = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 559);
            this.Controls.Add(this.UIProgress);
            this.Controls.Add(this.UIFinnish);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UIExplore);
            this.Controls.Add(this.UIPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UIInfos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UIButtonSelectFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UIButtonSelectFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label UIInfos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UIPath;
        private System.Windows.Forms.Button UIExplore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button UIFinnish;
        private System.Windows.Forms.ProgressBar UIProgress;
        private System.Windows.Forms.OpenFileDialog UIFileDialog;
        private System.Windows.Forms.FolderBrowserDialog UIFolderPath;
    }
}

