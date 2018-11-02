namespace Musics___Client.UI
{
    partial class AccountControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.UIEditError = new System.Windows.Forms.Label();
            this.UIAccountEdit = new System.Windows.Forms.Button();
            this.UIEditPassword2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.UIEditPassword1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.UIEditName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.UIRank = new System.Windows.Forms.Label();
            this.UIAccountId = new System.Windows.Forms.Label();
            this.UIAccountName = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UIEditError);
            this.panel2.Controls.Add(this.UIAccountEdit);
            this.panel2.Controls.Add(this.UIEditPassword2);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.UIEditPassword1);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.UIEditName);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(21, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 389);
            this.panel2.TabIndex = 8;
            // 
            // UIEditError
            // 
            this.UIEditError.AutoSize = true;
            this.UIEditError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIEditError.ForeColor = System.Drawing.Color.Red;
            this.UIEditError.Location = new System.Drawing.Point(444, 295);
            this.UIEditError.Name = "UIEditError";
            this.UIEditError.Size = new System.Drawing.Size(0, 16);
            this.UIEditError.TabIndex = 5;
            // 
            // UIAccountEdit
            // 
            this.UIAccountEdit.BackColor = System.Drawing.Color.LimeGreen;
            this.UIAccountEdit.Enabled = false;
            this.UIAccountEdit.FlatAppearance.BorderSize = 0;
            this.UIAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIAccountEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIAccountEdit.Location = new System.Drawing.Point(496, 319);
            this.UIAccountEdit.Name = "UIAccountEdit";
            this.UIAccountEdit.Size = new System.Drawing.Size(119, 36);
            this.UIAccountEdit.TabIndex = 17;
            this.UIAccountEdit.Text = "Edit";
            this.UIAccountEdit.UseVisualStyleBackColor = false;
            this.UIAccountEdit.Click += new System.EventHandler(this.UIAccountEdit_Click);
            // 
            // UIEditPassword2
            // 
            this.UIEditPassword2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIEditPassword2.Location = new System.Drawing.Point(39, 233);
            this.UIEditPassword2.Name = "UIEditPassword2";
            this.UIEditPassword2.Size = new System.Drawing.Size(576, 31);
            this.UIEditPassword2.TabIndex = 10;
            this.UIEditPassword2.TextChanged += new System.EventHandler(this.UIEditPassword2_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(34, 204);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(191, 25);
            this.label17.TabIndex = 9;
            this.label17.Text = "Repeat password :";
            // 
            // UIEditPassword1
            // 
            this.UIEditPassword1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIEditPassword1.Location = new System.Drawing.Point(39, 153);
            this.UIEditPassword1.Name = "UIEditPassword1";
            this.UIEditPassword1.Size = new System.Drawing.Size(576, 31);
            this.UIEditPassword1.TabIndex = 8;
            this.UIEditPassword1.TextChanged += new System.EventHandler(this.UIEditPassword1_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(34, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 25);
            this.label16.TabIndex = 7;
            this.label16.Text = "New password :";
            // 
            // UIEditName
            // 
            this.UIEditName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIEditName.Location = new System.Drawing.Point(39, 78);
            this.UIEditName.Name = "UIEditName";
            this.UIEditName.Size = new System.Drawing.Size(576, 31);
            this.UIEditName.TabIndex = 6;
            this.UIEditName.TextChanged += new System.EventHandler(this.UIEditName_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(34, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 25);
            this.label15.TabIndex = 5;
            this.label15.Text = "Name :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(16, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 29);
            this.label14.TabIndex = 3;
            this.label14.Text = "Edit account";
            // 
            // UIRank
            // 
            this.UIRank.AutoSize = true;
            this.UIRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIRank.ForeColor = System.Drawing.Color.Maroon;
            this.UIRank.Location = new System.Drawing.Point(319, 11);
            this.UIRank.Name = "UIRank";
            this.UIRank.Size = new System.Drawing.Size(82, 25);
            this.UIRank.TabIndex = 7;
            this.UIRank.Text = "UIRank";
            // 
            // UIAccountId
            // 
            this.UIAccountId.AutoSize = true;
            this.UIAccountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIAccountId.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UIAccountId.Location = new System.Drawing.Point(23, 66);
            this.UIAccountId.Name = "UIAccountId";
            this.UIAccountId.Size = new System.Drawing.Size(127, 25);
            this.UIAccountId.TabIndex = 6;
            this.UIAccountId.Text = "UIAccountId";
            // 
            // UIAccountName
            // 
            this.UIAccountName.AutoSize = true;
            this.UIAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIAccountName.Location = new System.Drawing.Point(14, 11);
            this.UIAccountName.Name = "UIAccountName";
            this.UIAccountName.Size = new System.Drawing.Size(299, 42);
            this.UIAccountName.TabIndex = 5;
            this.UIAccountName.Text = "UIAccount Name";
            // 
            // AccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.UIRank);
            this.Controls.Add(this.UIAccountId);
            this.Controls.Add(this.UIAccountName);
            this.Name = "AccountControl";
            this.Size = new System.Drawing.Size(683, 539);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label UIEditError;
        private System.Windows.Forms.Button UIAccountEdit;
        private System.Windows.Forms.TextBox UIEditPassword2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox UIEditPassword1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox UIEditName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label UIRank;
        private System.Windows.Forms.Label UIAccountId;
        private System.Windows.Forms.Label UIAccountName;
    }
}
