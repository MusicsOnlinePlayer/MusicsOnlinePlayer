namespace Musics___Client.UI
{
    partial class SearchControl
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
            this.UIPlaylistClear = new System.Windows.Forms.LinkLabel();
            this.UIEditMusicGenres = new System.Windows.Forms.TextBox();
            this.UIEditMusicName = new System.Windows.Forms.TextBox();
            this.UITextboxSearch = new System.Windows.Forms.TextBox();
            this.UIUpload = new System.Windows.Forms.Button();
            this.UIEditPlaylist = new System.Windows.Forms.Panel();
            this.UIPlaylistPrivate = new System.Windows.Forms.CheckBox();
            this.UIPlaylistName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UIPathMusic = new System.Windows.Forms.LinkLabel();
            this.UIPathAlbum = new System.Windows.Forms.LinkLabel();
            this.UIPathAuthor = new System.Windows.Forms.LinkLabel();
            this.UIPlaylist = new System.Windows.Forms.ListBox();
            this.UIselectedartist = new System.Windows.Forms.Label();
            this.UISelectedGenres = new System.Windows.Forms.Label();
            this.UISelectedRating = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UIRadioPlaylist = new System.Windows.Forms.RadioButton();
            this.UIRadioMusic = new System.Windows.Forms.RadioButton();
            this.UIRadioAlbum = new System.Windows.Forms.RadioButton();
            this.UIRadioArtist = new System.Windows.Forms.RadioButton();
            this.UISelectedname = new System.Windows.Forms.Label();
            this.UISavePlaylist = new System.Windows.Forms.Button();
            this.UIEditMusic = new System.Windows.Forms.Button();
            this.UIThumbup = new System.Windows.Forms.Button();
            this.UIAddPlaylistUnder = new System.Windows.Forms.Button();
            this.UIPlayBis = new System.Windows.Forms.Button();
            this.UIListView = new System.Windows.Forms.FlowLayoutPanel();
            this.UIMusicTags = new System.Windows.Forms.Label();
            this.UIProvider = new System.Windows.Forms.Label();
            this.UIEditPlaylist.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UIPlaylistClear
            // 
            this.UIPlaylistClear.AutoSize = true;
            this.UIPlaylistClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPlaylistClear.Location = new System.Drawing.Point(1844, 870);
            this.UIPlaylistClear.Margin = new System.Windows.Forms.Padding(3);
            this.UIPlaylistClear.Name = "UIPlaylistClear";
            this.UIPlaylistClear.Size = new System.Drawing.Size(54, 24);
            this.UIPlaylistClear.TabIndex = 46;
            this.UIPlaylistClear.TabStop = true;
            this.UIPlaylistClear.Text = "Clear";
            this.UIPlaylistClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UIPlaylistClear_LinkClicked);
            this.UIPlaylistClear.Click += new System.EventHandler(this.UIPlaylistClear_LinkClicked);
            // 
            // UIEditMusicGenres
            // 
            this.UIEditMusicGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIEditMusicGenres.Location = new System.Drawing.Point(23, 623);
            this.UIEditMusicGenres.Name = "UIEditMusicGenres";
            this.UIEditMusicGenres.Size = new System.Drawing.Size(357, 31);
            this.UIEditMusicGenres.TabIndex = 45;
            this.UIEditMusicGenres.Visible = false;
            // 
            // UIEditMusicName
            // 
            this.UIEditMusicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIEditMusicName.Location = new System.Drawing.Point(20, 462);
            this.UIEditMusicName.Name = "UIEditMusicName";
            this.UIEditMusicName.Size = new System.Drawing.Size(683, 31);
            this.UIEditMusicName.TabIndex = 41;
            this.UIEditMusicName.Visible = false;
            this.UIEditMusicName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIEditMusicName_KeyDown);
            // 
            // UITextboxSearch
            // 
            this.UITextboxSearch.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UITextboxSearch.Location = new System.Drawing.Point(10, 4);
            this.UITextboxSearch.Margin = new System.Windows.Forms.Padding(10);
            this.UITextboxSearch.Name = "UITextboxSearch";
            this.UITextboxSearch.Size = new System.Drawing.Size(688, 32);
            this.UITextboxSearch.TabIndex = 28;
            this.UITextboxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UITextboxSearch_KeyDown);
            // 
            // UIUpload
            // 
            this.UIUpload.BackColor = System.Drawing.Color.LimeGreen;
            this.UIUpload.FlatAppearance.BorderSize = 0;
            this.UIUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIUpload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIUpload.Location = new System.Drawing.Point(15, 841);
            this.UIUpload.Name = "UIUpload";
            this.UIUpload.Size = new System.Drawing.Size(119, 36);
            this.UIUpload.TabIndex = 44;
            this.UIUpload.Text = "Upload";
            this.UIUpload.UseVisualStyleBackColor = false;
            this.UIUpload.Click += new System.EventHandler(this.UIUpload_Click);
            // 
            // UIEditPlaylist
            // 
            this.UIEditPlaylist.Controls.Add(this.UIPlaylistPrivate);
            this.UIEditPlaylist.Controls.Add(this.UIPlaylistName);
            this.UIEditPlaylist.Controls.Add(this.label21);
            this.UIEditPlaylist.Location = new System.Drawing.Point(769, 509);
            this.UIEditPlaylist.Name = "UIEditPlaylist";
            this.UIEditPlaylist.Size = new System.Drawing.Size(216, 145);
            this.UIEditPlaylist.TabIndex = 43;
            this.UIEditPlaylist.Visible = false;
            // 
            // UIPlaylistPrivate
            // 
            this.UIPlaylistPrivate.AutoSize = true;
            this.UIPlaylistPrivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPlaylistPrivate.Location = new System.Drawing.Point(7, 56);
            this.UIPlaylistPrivate.Name = "UIPlaylistPrivate";
            this.UIPlaylistPrivate.Size = new System.Drawing.Size(69, 20);
            this.UIPlaylistPrivate.TabIndex = 26;
            this.UIPlaylistPrivate.Text = "Private";
            this.UIPlaylistPrivate.UseVisualStyleBackColor = true;
            // 
            // UIPlaylistName
            // 
            this.UIPlaylistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPlaylistName.Location = new System.Drawing.Point(0, 28);
            this.UIPlaylistName.Name = "UIPlaylistName";
            this.UIPlaylistName.Size = new System.Drawing.Size(215, 22);
            this.UIPlaylistName.TabIndex = 25;
            this.UIPlaylistName.Visible = false;
            this.UIPlaylistName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIPlaylistName_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label21.Location = new System.Drawing.Point(3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(150, 25);
            this.label21.TabIndex = 15;
            this.label21.Text = "Playlist Name :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.23116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.76884F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel1.Controls.Add(this.UIPathMusic, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.UIPathAlbum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.UIPathAuthor, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 35);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 19);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // UIPathMusic
            // 
            this.UIPathMusic.AutoSize = true;
            this.UIPathMusic.Font = new System.Drawing.Font("Raleway ExtraLight", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPathMusic.LinkColor = System.Drawing.Color.Blue;
            this.UIPathMusic.Location = new System.Drawing.Point(315, 0);
            this.UIPathMusic.Name = "UIPathMusic";
            this.UIPathMusic.Size = new System.Drawing.Size(39, 14);
            this.UIPathMusic.TabIndex = 19;
            this.UIPathMusic.TabStop = true;
            this.UIPathMusic.Text = "Music";
            // 
            // UIPathAlbum
            // 
            this.UIPathAlbum.AutoSize = true;
            this.UIPathAlbum.Font = new System.Drawing.Font("Raleway ExtraLight", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPathAlbum.LinkColor = System.Drawing.Color.Blue;
            this.UIPathAlbum.Location = new System.Drawing.Point(147, 0);
            this.UIPathAlbum.Name = "UIPathAlbum";
            this.UIPathAlbum.Size = new System.Drawing.Size(43, 14);
            this.UIPathAlbum.TabIndex = 18;
            this.UIPathAlbum.TabStop = true;
            this.UIPathAlbum.Text = "Album";
            this.UIPathAlbum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UIPathAlbum_LinkClicked);
            // 
            // UIPathAuthor
            // 
            this.UIPathAuthor.AutoSize = true;
            this.UIPathAuthor.Font = new System.Drawing.Font("Raleway ExtraLight", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPathAuthor.LinkColor = System.Drawing.Color.Blue;
            this.UIPathAuthor.Location = new System.Drawing.Point(3, 0);
            this.UIPathAuthor.Name = "UIPathAuthor";
            this.UIPathAuthor.Size = new System.Drawing.Size(44, 14);
            this.UIPathAuthor.TabIndex = 17;
            this.UIPathAuthor.TabStop = true;
            this.UIPathAuthor.Text = "Author";
            this.UIPathAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UIPathAuthor_LinkClicked);
            // 
            // UIPlaylist
            // 
            this.UIPlaylist.Enabled = false;
            this.UIPlaylist.Font = new System.Drawing.Font("Raleway", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPlaylist.FormattingEnabled = true;
            this.UIPlaylist.ItemHeight = 25;
            this.UIPlaylist.Location = new System.Drawing.Point(1069, 460);
            this.UIPlaylist.Name = "UIPlaylist";
            this.UIPlaylist.Size = new System.Drawing.Size(800, 379);
            this.UIPlaylist.TabIndex = 38;
            // 
            // UIselectedartist
            // 
            this.UIselectedartist.AutoSize = true;
            this.UIselectedartist.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIselectedartist.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIselectedartist.Location = new System.Drawing.Point(15, 509);
            this.UIselectedartist.Name = "UIselectedartist";
            this.UIselectedartist.Size = new System.Drawing.Size(91, 25);
            this.UIselectedartist.TabIndex = 36;
            this.UIselectedartist.Text = "No artist";
            this.UIselectedartist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UISelectedGenres
            // 
            this.UISelectedGenres.AutoSize = true;
            this.UISelectedGenres.Font = new System.Drawing.Font("Raleway Light", 15.75F);
            this.UISelectedGenres.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UISelectedGenres.Location = new System.Drawing.Point(18, 629);
            this.UISelectedGenres.Name = "UISelectedGenres";
            this.UISelectedGenres.Size = new System.Drawing.Size(88, 25);
            this.UISelectedGenres.TabIndex = 34;
            this.UISelectedGenres.Text = "Genres :";
            this.UISelectedGenres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UISelectedRating
            // 
            this.UISelectedRating.AutoSize = true;
            this.UISelectedRating.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISelectedRating.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UISelectedRating.Location = new System.Drawing.Point(15, 569);
            this.UISelectedRating.Name = "UISelectedRating";
            this.UISelectedRating.Size = new System.Drawing.Size(82, 25);
            this.UISelectedRating.TabIndex = 33;
            this.UISelectedRating.Text = "Rating :";
            this.UISelectedRating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.UIRadioPlaylist);
            this.panel1.Controls.Add(this.UIRadioMusic);
            this.panel1.Controls.Add(this.UIRadioAlbum);
            this.panel1.Controls.Add(this.UIRadioArtist);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(711, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 36);
            this.panel1.TabIndex = 30;
            // 
            // UIRadioPlaylist
            // 
            this.UIRadioPlaylist.AutoSize = true;
            this.UIRadioPlaylist.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIRadioPlaylist.Location = new System.Drawing.Point(282, 2);
            this.UIRadioPlaylist.Name = "UIRadioPlaylist";
            this.UIRadioPlaylist.Size = new System.Drawing.Size(96, 29);
            this.UIRadioPlaylist.TabIndex = 3;
            this.UIRadioPlaylist.Text = "Playlist";
            this.UIRadioPlaylist.UseVisualStyleBackColor = true;
            // 
            // UIRadioMusic
            // 
            this.UIRadioMusic.AutoSize = true;
            this.UIRadioMusic.Checked = true;
            this.UIRadioMusic.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIRadioMusic.Location = new System.Drawing.Point(189, 2);
            this.UIRadioMusic.Name = "UIRadioMusic";
            this.UIRadioMusic.Size = new System.Drawing.Size(85, 29);
            this.UIRadioMusic.TabIndex = 2;
            this.UIRadioMusic.TabStop = true;
            this.UIRadioMusic.Text = "Music";
            this.UIRadioMusic.UseVisualStyleBackColor = true;
            // 
            // UIRadioAlbum
            // 
            this.UIRadioAlbum.AutoSize = true;
            this.UIRadioAlbum.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIRadioAlbum.Location = new System.Drawing.Point(90, 2);
            this.UIRadioAlbum.Name = "UIRadioAlbum";
            this.UIRadioAlbum.Size = new System.Drawing.Size(93, 29);
            this.UIRadioAlbum.TabIndex = 1;
            this.UIRadioAlbum.Text = "Album";
            this.UIRadioAlbum.UseVisualStyleBackColor = true;
            // 
            // UIRadioArtist
            // 
            this.UIRadioArtist.AutoSize = true;
            this.UIRadioArtist.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIRadioArtist.Location = new System.Drawing.Point(3, 1);
            this.UIRadioArtist.Name = "UIRadioArtist";
            this.UIRadioArtist.Size = new System.Drawing.Size(79, 29);
            this.UIRadioArtist.TabIndex = 0;
            this.UIRadioArtist.Text = "Artist";
            this.UIRadioArtist.UseVisualStyleBackColor = true;
            // 
            // UISelectedname
            // 
            this.UISelectedname.AutoSize = true;
            this.UISelectedname.Font = new System.Drawing.Font("Raleway Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISelectedname.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UISelectedname.Location = new System.Drawing.Point(14, 460);
            this.UISelectedname.Name = "UISelectedname";
            this.UISelectedname.Size = new System.Drawing.Size(141, 31);
            this.UISelectedname.TabIndex = 31;
            this.UISelectedname.Text = "No music";
            this.UISelectedname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UISavePlaylist
            // 
            this.UISavePlaylist.BackgroundImage = global::Musics___Client.Properties.Resources.IcoSave;
            this.UISavePlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UISavePlaylist.FlatAppearance.BorderSize = 0;
            this.UISavePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UISavePlaylist.Location = new System.Drawing.Point(1005, 553);
            this.UISavePlaylist.Name = "UISavePlaylist";
            this.UISavePlaylist.Size = new System.Drawing.Size(30, 30);
            this.UISavePlaylist.TabIndex = 42;
            this.UISavePlaylist.UseVisualStyleBackColor = true;
            this.UISavePlaylist.Click += new System.EventHandler(this.UISavePlaylist_Click);
            // 
            // UIEditMusic
            // 
            this.UIEditMusic.BackgroundImage = global::Musics___Client.Properties.Resources.IcoEdit;
            this.UIEditMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIEditMusic.FlatAppearance.BorderSize = 0;
            this.UIEditMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIEditMusic.Location = new System.Drawing.Point(1005, 504);
            this.UIEditMusic.Name = "UIEditMusic";
            this.UIEditMusic.Size = new System.Drawing.Size(30, 30);
            this.UIEditMusic.TabIndex = 40;
            this.UIEditMusic.UseVisualStyleBackColor = true;
            this.UIEditMusic.Click += new System.EventHandler(this.UIEditMusic_Click);
            // 
            // UIThumbup
            // 
            this.UIThumbup.BackColor = System.Drawing.Color.White;
            this.UIThumbup.BackgroundImage = global::Musics___Client.Properties.Resources.thumbup;
            this.UIThumbup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIThumbup.FlatAppearance.BorderSize = 0;
            this.UIThumbup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIThumbup.Location = new System.Drawing.Point(901, 460);
            this.UIThumbup.Name = "UIThumbup";
            this.UIThumbup.Size = new System.Drawing.Size(30, 30);
            this.UIThumbup.TabIndex = 35;
            this.UIThumbup.UseVisualStyleBackColor = false;
            this.UIThumbup.Click += new System.EventHandler(this.UIThumbup_Click);
            // 
            // UIAddPlaylistUnder
            // 
            this.UIAddPlaylistUnder.BackgroundImage = global::Musics___Client.Properties.Resources.IcoAdd;
            this.UIAddPlaylistUnder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIAddPlaylistUnder.FlatAppearance.BorderSize = 0;
            this.UIAddPlaylistUnder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIAddPlaylistUnder.Location = new System.Drawing.Point(1004, 460);
            this.UIAddPlaylistUnder.Name = "UIAddPlaylistUnder";
            this.UIAddPlaylistUnder.Size = new System.Drawing.Size(30, 30);
            this.UIAddPlaylistUnder.TabIndex = 37;
            this.UIAddPlaylistUnder.UseVisualStyleBackColor = true;
            this.UIAddPlaylistUnder.Click += new System.EventHandler(this.UIAddPlaylistUnder_Click);
            // 
            // UIPlayBis
            // 
            this.UIPlayBis.BackgroundImage = global::Musics___Client.Properties.Resources.Icoplay;
            this.UIPlayBis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIPlayBis.FlatAppearance.BorderSize = 0;
            this.UIPlayBis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIPlayBis.Location = new System.Drawing.Point(955, 460);
            this.UIPlayBis.Name = "UIPlayBis";
            this.UIPlayBis.Size = new System.Drawing.Size(30, 30);
            this.UIPlayBis.TabIndex = 32;
            this.UIPlayBis.UseVisualStyleBackColor = true;
            this.UIPlayBis.Click += new System.EventHandler(this.UIPlayBis_Click);
            // 
            // UIListView
            // 
            this.UIListView.AutoScroll = true;
            this.UIListView.Location = new System.Drawing.Point(9, 58);
            this.UIListView.Name = "UIListView";
            this.UIListView.Size = new System.Drawing.Size(1860, 385);
            this.UIListView.TabIndex = 47;
            // 
            // UIMusicTags
            // 
            this.UIMusicTags.AutoSize = true;
            this.UIMusicTags.Font = new System.Drawing.Font("Raleway Light", 15.75F);
            this.UIMusicTags.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIMusicTags.Location = new System.Drawing.Point(18, 686);
            this.UIMusicTags.Name = "UIMusicTags";
            this.UIMusicTags.Size = new System.Drawing.Size(66, 25);
            this.UIMusicTags.TabIndex = 48;
            this.UIMusicTags.Text = "Tags :";
            this.UIMusicTags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIProvider
            // 
            this.UIProvider.AutoSize = true;
            this.UIProvider.Font = new System.Drawing.Font("Raleway Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIProvider.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIProvider.Location = new System.Drawing.Point(15, 739);
            this.UIProvider.Name = "UIProvider";
            this.UIProvider.Size = new System.Drawing.Size(118, 25);
            this.UIProvider.TabIndex = 49;
            this.UIProvider.Text = "NoProvider";
            this.UIProvider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UIProvider);
            this.Controls.Add(this.UIMusicTags);
            this.Controls.Add(this.UIListView);
            this.Controls.Add(this.UIPlaylistClear);
            this.Controls.Add(this.UIEditMusicGenres);
            this.Controls.Add(this.UIEditMusicName);
            this.Controls.Add(this.UITextboxSearch);
            this.Controls.Add(this.UIUpload);
            this.Controls.Add(this.UIEditPlaylist);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.UISavePlaylist);
            this.Controls.Add(this.UIEditMusic);
            this.Controls.Add(this.UIThumbup);
            this.Controls.Add(this.UIPlaylist);
            this.Controls.Add(this.UIselectedartist);
            this.Controls.Add(this.UISelectedGenres);
            this.Controls.Add(this.UISelectedRating);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UIAddPlaylistUnder);
            this.Controls.Add(this.UIPlayBis);
            this.Controls.Add(this.UISelectedname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(1901, 897);
            this.UIEditPlaylist.ResumeLayout(false);
            this.UIEditPlaylist.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel UIPlaylistClear;
        private System.Windows.Forms.TextBox UIEditMusicGenres;
        private System.Windows.Forms.TextBox UIEditMusicName;
        private System.Windows.Forms.TextBox UITextboxSearch;
        private System.Windows.Forms.Button UIUpload;
        private System.Windows.Forms.Panel UIEditPlaylist;
        private System.Windows.Forms.CheckBox UIPlaylistPrivate;
        private System.Windows.Forms.TextBox UIPlaylistName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel UIPathMusic;
        private System.Windows.Forms.LinkLabel UIPathAlbum;
        private System.Windows.Forms.LinkLabel UIPathAuthor;
        private System.Windows.Forms.Button UISavePlaylist;
        private System.Windows.Forms.Button UIEditMusic;
        private System.Windows.Forms.Button UIThumbup;
        private System.Windows.Forms.ListBox UIPlaylist;
        private System.Windows.Forms.Label UIselectedartist;
        private System.Windows.Forms.Label UISelectedGenres;
        private System.Windows.Forms.Label UISelectedRating;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton UIRadioPlaylist;
        private System.Windows.Forms.RadioButton UIRadioMusic;
        private System.Windows.Forms.RadioButton UIRadioAlbum;
        private System.Windows.Forms.RadioButton UIRadioArtist;
        private System.Windows.Forms.Button UIAddPlaylistUnder;
        private System.Windows.Forms.Button UIPlayBis;
        private System.Windows.Forms.Label UISelectedname;
        private System.Windows.Forms.FlowLayoutPanel UIListView;
        private System.Windows.Forms.Label UIMusicTags;
        private System.Windows.Forms.Label UIProvider;
    }
}
