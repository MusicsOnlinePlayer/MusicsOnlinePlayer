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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UIMusicsBoxList = new System.Windows.Forms.ComboBox();
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
            this.UIMusicInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.UIMusicInformation.LabelEdit = true;
            this.UIMusicInformation.Location = new System.Drawing.Point(22, 212);
            this.UIMusicInformation.Name = "UIMusicInformation";
            this.UIMusicInformation.Size = new System.Drawing.Size(376, 133);
            this.UIMusicInformation.TabIndex = 5;
            this.UIMusicInformation.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Information";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User Input";
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
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 521);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox UIMusicsBoxList;
    }
}