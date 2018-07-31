namespace Musics___Client
{
    partial class Upload
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
            this.UIUploadButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UIMusicInformation = new System.Windows.Forms.ListView();
            this.UIMusicsBoxList = new System.Windows.Forms.ComboBox();
            this.UIUserEntry = new System.Windows.Forms.TextBox();
            this.UIUserEnter = new System.Windows.Forms.Button();
            this.UISubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upload";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(19, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "1. Select a music";
            // 
            // UIUploadButton
            // 
            this.UIUploadButton.Location = new System.Drawing.Point(22, 101);
            this.UIUploadButton.Name = "UIUploadButton";
            this.UIUploadButton.Size = new System.Drawing.Size(149, 24);
            this.UIUploadButton.TabIndex = 3;
            this.UIUploadButton.Text = "OpenFile";
            this.UIUploadButton.UseVisualStyleBackColor = true;
            this.UIUploadButton.Click += new System.EventHandler(this.UIUploadButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(19, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "2. Edit music info";
            // 
            // UIMusicInformation
            // 
            this.UIMusicInformation.LabelEdit = true;
            this.UIMusicInformation.Location = new System.Drawing.Point(22, 212);
            this.UIMusicInformation.MultiSelect = false;
            this.UIMusicInformation.Name = "UIMusicInformation";
            this.UIMusicInformation.Size = new System.Drawing.Size(376, 133);
            this.UIMusicInformation.TabIndex = 5;
            this.UIMusicInformation.UseCompatibleStateImageBehavior = false;
            this.UIMusicInformation.SelectedIndexChanged += new System.EventHandler(this.UIMusicInformation_SelectedIndexChanged);
            // 
            // UIMusicsBoxList
            // 
            this.UIMusicsBoxList.FormattingEnabled = true;
            this.UIMusicsBoxList.Location = new System.Drawing.Point(22, 176);
            this.UIMusicsBoxList.Name = "UIMusicsBoxList";
            this.UIMusicsBoxList.Size = new System.Drawing.Size(376, 21);
            this.UIMusicsBoxList.TabIndex = 6;
            this.UIMusicsBoxList.SelectedIndexChanged += new System.EventHandler(this.UIMusicsBoxList_SelectedIndexChanged);
            // 
            // UIUserEntry
            // 
            this.UIUserEntry.Location = new System.Drawing.Point(22, 352);
            this.UIUserEntry.Name = "UIUserEntry";
            this.UIUserEntry.Size = new System.Drawing.Size(291, 20);
            this.UIUserEntry.TabIndex = 7;
            // 
            // UIUserEnter
            // 
            this.UIUserEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.UIUserEnter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.UIUserEnter.Location = new System.Drawing.Point(319, 351);
            this.UIUserEnter.Name = "UIUserEnter";
            this.UIUserEnter.Size = new System.Drawing.Size(79, 21);
            this.UIUserEnter.TabIndex = 8;
            this.UIUserEnter.Text = "Enter";
            this.UIUserEnter.UseVisualStyleBackColor = false;
            this.UIUserEnter.Click += new System.EventHandler(this.UIUserEnter_Click);
            // 
            // UISubmit
            // 
            this.UISubmit.BackColor = System.Drawing.Color.LimeGreen;
            this.UISubmit.FlatAppearance.BorderSize = 0;
            this.UISubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UISubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UISubmit.Location = new System.Drawing.Point(279, 473);
            this.UISubmit.Name = "UISubmit";
            this.UISubmit.Size = new System.Drawing.Size(119, 36);
            this.UISubmit.TabIndex = 17;
            this.UISubmit.Text = "Submit";
            this.UISubmit.UseVisualStyleBackColor = false;
            this.UISubmit.Click += new System.EventHandler(this.UISubmit_Click);
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 521);
            this.Controls.Add(this.UISubmit);
            this.Controls.Add(this.UIUserEnter);
            this.Controls.Add(this.UIUserEntry);
            this.Controls.Add(this.UIMusicsBoxList);
            this.Controls.Add(this.UIMusicInformation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UIUploadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Upload";
            this.Text = "Upload";
            this.Load += new System.EventHandler(this.Upload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UIUploadButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView UIMusicInformation;
        private System.Windows.Forms.ComboBox UIMusicsBoxList;
        private System.Windows.Forms.TextBox UIUserEntry;
        private System.Windows.Forms.Button UIUserEnter;
        private System.Windows.Forms.Button UISubmit;
    }
}