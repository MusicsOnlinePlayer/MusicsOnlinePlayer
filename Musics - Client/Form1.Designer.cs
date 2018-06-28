﻿namespace Musics___Client
{
    partial class Client
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.UIHome = new System.Windows.Forms.TabPage();
            this.UISearch = new System.Windows.Forms.TabPage();
            this.UIPlaylist = new System.Windows.Forms.ListBox();
            this.UIAddPlaylistUnder = new System.Windows.Forms.Button();
            this.UIPlayBis = new System.Windows.Forms.Button();
            this.UIselectedartist = new System.Windows.Forms.Label();
            this.UISelectedGenres = new System.Windows.Forms.Label();
            this.UISelectedRating = new System.Windows.Forms.Label();
            this.UISelectedname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UIRadioMusic = new System.Windows.Forms.RadioButton();
            this.UIRadioAlbum = new System.Windows.Forms.RadioButton();
            this.UIRadioArtist = new System.Windows.Forms.RadioButton();
            this.UIThumbup = new System.Windows.Forms.Button();
            this.UISearchListbox = new System.Windows.Forms.ListBox();
            this.UITextboxSearch = new System.Windows.Forms.TextBox();
            this.UIBrowse = new System.Windows.Forms.TabPage();
            this.UIFavorite = new System.Windows.Forms.TabPage();
            this.UIPlaylists = new System.Windows.Forms.TabPage();
            this.UIForums = new System.Windows.Forms.TabPage();
            this.UIAccount = new System.Windows.Forms.TabPage();
            this.UIAccountId = new System.Windows.Forms.Label();
            this.UIAccountName = new System.Windows.Forms.Label();
            this.UISettings = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.UIForward = new System.Windows.Forms.Button();
            this.UIBackward = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.UITrackbarMusic = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.UINextPlaylist = new System.Windows.Forms.Label();
            this.UIArtist = new System.Windows.Forms.Label();
            this.UIPause = new System.Windows.Forms.Button();
            this.UIPlay = new System.Windows.Forms.Button();
            this.UIPlayingMusic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tabs.SuspendLayout();
            this.UISearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.UIAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UITrackbarMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.UIHome);
            this.Tabs.Controls.Add(this.UISearch);
            this.Tabs.Controls.Add(this.UIBrowse);
            this.Tabs.Controls.Add(this.UIFavorite);
            this.Tabs.Controls.Add(this.UIPlaylists);
            this.Tabs.Controls.Add(this.UIForums);
            this.Tabs.Controls.Add(this.UIAccount);
            this.Tabs.Controls.Add(this.UISettings);
            this.Tabs.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tabs.ItemSize = new System.Drawing.Size(90, 30);
            this.Tabs.Location = new System.Drawing.Point(239, 0);
            this.Tabs.Multiline = true;
            this.Tabs.Name = "Tabs";
            this.Tabs.Padding = new System.Drawing.Point(20, 3);
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1213, 800);
            this.Tabs.TabIndex = 0;
            // 
            // UIHome
            // 
            this.UIHome.BackColor = System.Drawing.Color.White;
            this.UIHome.Location = new System.Drawing.Point(4, 34);
            this.UIHome.Name = "UIHome";
            this.UIHome.Padding = new System.Windows.Forms.Padding(3);
            this.UIHome.Size = new System.Drawing.Size(1205, 762);
            this.UIHome.TabIndex = 0;
            this.UIHome.Text = "Home";
            // 
            // UISearch
            // 
            this.UISearch.Controls.Add(this.UIPlaylist);
            this.UISearch.Controls.Add(this.UIAddPlaylistUnder);
            this.UISearch.Controls.Add(this.UIPlayBis);
            this.UISearch.Controls.Add(this.UIselectedartist);
            this.UISearch.Controls.Add(this.UISelectedGenres);
            this.UISearch.Controls.Add(this.UISelectedRating);
            this.UISearch.Controls.Add(this.UISelectedname);
            this.UISearch.Controls.Add(this.panel1);
            this.UISearch.Controls.Add(this.UIThumbup);
            this.UISearch.Controls.Add(this.UISearchListbox);
            this.UISearch.Controls.Add(this.UITextboxSearch);
            this.UISearch.Location = new System.Drawing.Point(4, 34);
            this.UISearch.Name = "UISearch";
            this.UISearch.Padding = new System.Windows.Forms.Padding(3);
            this.UISearch.Size = new System.Drawing.Size(1205, 762);
            this.UISearch.TabIndex = 1;
            this.UISearch.Text = "Search";
            this.UISearch.UseVisualStyleBackColor = true;
            // 
            // UIPlaylist
            // 
            this.UIPlaylist.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Italic);
            this.UIPlaylist.FormattingEnabled = true;
            this.UIPlaylist.ItemHeight = 28;
            this.UIPlaylist.Location = new System.Drawing.Point(428, 377);
            this.UIPlaylist.Name = "UIPlaylist";
            this.UIPlaylist.Size = new System.Drawing.Size(769, 368);
            this.UIPlaylist.TabIndex = 16;
            // 
            // UIAddPlaylistUnder
            // 
            this.UIAddPlaylistUnder.BackgroundImage = global::Musics___Client.Properties.Resources.IcoAdd;
            this.UIAddPlaylistUnder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIAddPlaylistUnder.FlatAppearance.BorderSize = 0;
            this.UIAddPlaylistUnder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIAddPlaylistUnder.Location = new System.Drawing.Point(391, 380);
            this.UIAddPlaylistUnder.Name = "UIAddPlaylistUnder";
            this.UIAddPlaylistUnder.Size = new System.Drawing.Size(30, 30);
            this.UIAddPlaylistUnder.TabIndex = 15;
            this.UIAddPlaylistUnder.UseVisualStyleBackColor = true;
            this.UIAddPlaylistUnder.Click += new System.EventHandler(this.UIAddPlaylistUnder_Click);
            // 
            // UIPlayBis
            // 
            this.UIPlayBis.BackgroundImage = global::Musics___Client.Properties.Resources.Icoplay;
            this.UIPlayBis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIPlayBis.FlatAppearance.BorderSize = 0;
            this.UIPlayBis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIPlayBis.Location = new System.Drawing.Point(342, 380);
            this.UIPlayBis.Name = "UIPlayBis";
            this.UIPlayBis.Size = new System.Drawing.Size(30, 30);
            this.UIPlayBis.TabIndex = 8;
            this.UIPlayBis.UseVisualStyleBackColor = true;
            this.UIPlayBis.Click += new System.EventHandler(this.UIPlayBis_Click);
            // 
            // UIselectedartist
            // 
            this.UIselectedartist.AutoSize = true;
            this.UIselectedartist.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIselectedartist.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UIselectedartist.Location = new System.Drawing.Point(29, 429);
            this.UIselectedartist.Name = "UIselectedartist";
            this.UIselectedartist.Size = new System.Drawing.Size(92, 28);
            this.UIselectedartist.TabIndex = 14;
            this.UIselectedartist.Text = "No artist";
            this.UIselectedartist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UISelectedGenres
            // 
            this.UISelectedGenres.AutoSize = true;
            this.UISelectedGenres.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISelectedGenres.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UISelectedGenres.Location = new System.Drawing.Point(25, 549);
            this.UISelectedGenres.Name = "UISelectedGenres";
            this.UISelectedGenres.Size = new System.Drawing.Size(85, 28);
            this.UISelectedGenres.TabIndex = 10;
            this.UISelectedGenres.Text = "Genres :";
            this.UISelectedGenres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UISelectedRating
            // 
            this.UISelectedRating.AutoSize = true;
            this.UISelectedRating.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISelectedRating.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UISelectedRating.Location = new System.Drawing.Point(29, 489);
            this.UISelectedRating.Name = "UISelectedRating";
            this.UISelectedRating.Size = new System.Drawing.Size(81, 28);
            this.UISelectedRating.TabIndex = 9;
            this.UISelectedRating.Text = "Rating :";
            this.UISelectedRating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UISelectedname
            // 
            this.UISelectedname.AutoSize = true;
            this.UISelectedname.Font = new System.Drawing.Font("Open Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISelectedname.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UISelectedname.Location = new System.Drawing.Point(23, 380);
            this.UISelectedname.Name = "UISelectedname";
            this.UISelectedname.Size = new System.Drawing.Size(135, 37);
            this.UISelectedname.TabIndex = 8;
            this.UISelectedname.Text = "No music";
            this.UISelectedname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.UIRadioMusic);
            this.panel1.Controls.Add(this.UIRadioAlbum);
            this.panel1.Controls.Add(this.UIRadioArtist);
            this.panel1.Location = new System.Drawing.Point(731, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 36);
            this.panel1.TabIndex = 2;
            // 
            // UIRadioMusic
            // 
            this.UIRadioMusic.AutoSize = true;
            this.UIRadioMusic.Checked = true;
            this.UIRadioMusic.Location = new System.Drawing.Point(189, 2);
            this.UIRadioMusic.Name = "UIRadioMusic";
            this.UIRadioMusic.Size = new System.Drawing.Size(87, 32);
            this.UIRadioMusic.TabIndex = 2;
            this.UIRadioMusic.TabStop = true;
            this.UIRadioMusic.Text = "Music";
            this.UIRadioMusic.UseVisualStyleBackColor = true;
            // 
            // UIRadioAlbum
            // 
            this.UIRadioAlbum.AutoSize = true;
            this.UIRadioAlbum.Location = new System.Drawing.Point(90, 2);
            this.UIRadioAlbum.Name = "UIRadioAlbum";
            this.UIRadioAlbum.Size = new System.Drawing.Size(94, 32);
            this.UIRadioAlbum.TabIndex = 1;
            this.UIRadioAlbum.Text = "Album";
            this.UIRadioAlbum.UseVisualStyleBackColor = true;
            // 
            // UIRadioArtist
            // 
            this.UIRadioArtist.AutoSize = true;
            this.UIRadioArtist.Location = new System.Drawing.Point(3, 1);
            this.UIRadioArtist.Name = "UIRadioArtist";
            this.UIRadioArtist.Size = new System.Drawing.Size(81, 32);
            this.UIRadioArtist.TabIndex = 0;
            this.UIRadioArtist.Text = "Artist";
            this.UIRadioArtist.UseVisualStyleBackColor = true;
            // 
            // UIThumbup
            // 
            this.UIThumbup.BackColor = System.Drawing.Color.White;
            this.UIThumbup.BackgroundImage = global::Musics___Client.Properties.Resources.thumbup;
            this.UIThumbup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIThumbup.FlatAppearance.BorderSize = 0;
            this.UIThumbup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIThumbup.Location = new System.Drawing.Point(288, 380);
            this.UIThumbup.Name = "UIThumbup";
            this.UIThumbup.Size = new System.Drawing.Size(30, 30);
            this.UIThumbup.TabIndex = 11;
            this.UIThumbup.UseVisualStyleBackColor = false;
            this.UIThumbup.Click += new System.EventHandler(this.UIThumbup_Click);
            // 
            // UISearchListbox
            // 
            this.UISearchListbox.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UISearchListbox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UISearchListbox.FormattingEnabled = true;
            this.UISearchListbox.ItemHeight = 28;
            this.UISearchListbox.Location = new System.Drawing.Point(30, 59);
            this.UISearchListbox.Name = "UISearchListbox";
            this.UISearchListbox.Size = new System.Drawing.Size(1167, 312);
            this.UISearchListbox.TabIndex = 1;
            this.UISearchListbox.SelectedIndexChanged += new System.EventHandler(this.UISearchListbox_SelectedIndexChanged);
            this.UISearchListbox.DoubleClick += new System.EventHandler(this.UISearchListbox_DoubleClick);
            // 
            // UITextboxSearch
            // 
            this.UITextboxSearch.Location = new System.Drawing.Point(30, 13);
            this.UITextboxSearch.Margin = new System.Windows.Forms.Padding(10);
            this.UITextboxSearch.Name = "UITextboxSearch";
            this.UITextboxSearch.Size = new System.Drawing.Size(688, 36);
            this.UITextboxSearch.TabIndex = 0;
            this.UITextboxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UITextboxSearch_KeyDown);
            // 
            // UIBrowse
            // 
            this.UIBrowse.Location = new System.Drawing.Point(4, 34);
            this.UIBrowse.Name = "UIBrowse";
            this.UIBrowse.Padding = new System.Windows.Forms.Padding(3);
            this.UIBrowse.Size = new System.Drawing.Size(1205, 762);
            this.UIBrowse.TabIndex = 2;
            this.UIBrowse.Text = "Browse";
            this.UIBrowse.UseVisualStyleBackColor = true;
            // 
            // UIFavorite
            // 
            this.UIFavorite.Location = new System.Drawing.Point(4, 34);
            this.UIFavorite.Name = "UIFavorite";
            this.UIFavorite.Padding = new System.Windows.Forms.Padding(3);
            this.UIFavorite.Size = new System.Drawing.Size(1205, 762);
            this.UIFavorite.TabIndex = 3;
            this.UIFavorite.Text = "Favorite";
            this.UIFavorite.UseVisualStyleBackColor = true;
            // 
            // UIPlaylists
            // 
            this.UIPlaylists.Location = new System.Drawing.Point(4, 34);
            this.UIPlaylists.Name = "UIPlaylists";
            this.UIPlaylists.Padding = new System.Windows.Forms.Padding(3);
            this.UIPlaylists.Size = new System.Drawing.Size(1205, 762);
            this.UIPlaylists.TabIndex = 4;
            this.UIPlaylists.Text = "Playlists";
            this.UIPlaylists.UseVisualStyleBackColor = true;
            // 
            // UIForums
            // 
            this.UIForums.Location = new System.Drawing.Point(4, 34);
            this.UIForums.Name = "UIForums";
            this.UIForums.Padding = new System.Windows.Forms.Padding(3);
            this.UIForums.Size = new System.Drawing.Size(1205, 762);
            this.UIForums.TabIndex = 5;
            this.UIForums.Text = "Forums";
            this.UIForums.UseVisualStyleBackColor = true;
            // 
            // UIAccount
            // 
            this.UIAccount.Controls.Add(this.UIAccountId);
            this.UIAccount.Controls.Add(this.UIAccountName);
            this.UIAccount.Location = new System.Drawing.Point(4, 34);
            this.UIAccount.Name = "UIAccount";
            this.UIAccount.Padding = new System.Windows.Forms.Padding(3);
            this.UIAccount.Size = new System.Drawing.Size(1205, 762);
            this.UIAccount.TabIndex = 6;
            this.UIAccount.Text = "Account";
            this.UIAccount.UseVisualStyleBackColor = true;
            // 
            // UIAccountId
            // 
            this.UIAccountId.AutoSize = true;
            this.UIAccountId.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UIAccountId.Location = new System.Drawing.Point(15, 68);
            this.UIAccountId.Name = "UIAccountId";
            this.UIAccountId.Size = new System.Drawing.Size(131, 28);
            this.UIAccountId.TabIndex = 1;
            this.UIAccountId.Text = "UIAccountId";
            // 
            // UIAccountName
            // 
            this.UIAccountName.AutoSize = true;
            this.UIAccountName.Font = new System.Drawing.Font("Open Sans", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIAccountName.Location = new System.Drawing.Point(6, 13);
            this.UIAccountName.Name = "UIAccountName";
            this.UIAccountName.Size = new System.Drawing.Size(313, 51);
            this.UIAccountName.TabIndex = 0;
            this.UIAccountName.Text = "UIAccount Name";
            // 
            // UISettings
            // 
            this.UISettings.Location = new System.Drawing.Point(4, 34);
            this.UISettings.Name = "UISettings";
            this.UISettings.Padding = new System.Windows.Forms.Padding(3);
            this.UISettings.Size = new System.Drawing.Size(1205, 762);
            this.UISettings.TabIndex = 7;
            this.UISettings.Text = "Settings";
            this.UISettings.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.UIForward);
            this.splitContainer1.Panel2.Controls.Add(this.UIBackward);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.UITrackbarMusic);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.UINextPlaylist);
            this.splitContainer1.Panel2.Controls.Add(this.UIArtist);
            this.splitContainer1.Panel2.Controls.Add(this.UIPause);
            this.splitContainer1.Panel2.Controls.Add(this.UIPlay);
            this.splitContainer1.Panel2.Controls.Add(this.UIPlayingMusic);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(237, 796);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 209);
            this.label1.TabIndex = 0;
            this.label1.Text = "M";
            // 
            // UIForward
            // 
            this.UIForward.BackgroundImage = global::Musics___Client.Properties.Resources.IcoForward;
            this.UIForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIForward.FlatAppearance.BorderSize = 0;
            this.UIForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIForward.Location = new System.Drawing.Point(193, 324);
            this.UIForward.Name = "UIForward";
            this.UIForward.Size = new System.Drawing.Size(35, 35);
            this.UIForward.TabIndex = 11;
            this.UIForward.UseVisualStyleBackColor = true;
            this.UIForward.Click += new System.EventHandler(this.UIForward_Click);
            // 
            // UIBackward
            // 
            this.UIBackward.BackgroundImage = global::Musics___Client.Properties.Resources.IcoBackward;
            this.UIBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIBackward.FlatAppearance.BorderSize = 0;
            this.UIBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIBackward.Location = new System.Drawing.Point(19, 324);
            this.UIBackward.Name = "UIBackward";
            this.UIBackward.Size = new System.Drawing.Size(35, 35);
            this.UIBackward.TabIndex = 10;
            this.UIBackward.UseVisualStyleBackColor = true;
            this.UIBackward.Click += new System.EventHandler(this.UIBackward_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 39);
            this.label5.TabIndex = 9;
            this.label5.Text = "-";
            // 
            // UITrackbarMusic
            // 
            this.UITrackbarMusic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.UITrackbarMusic.Location = new System.Drawing.Point(35, 273);
            this.UITrackbarMusic.Maximum = 100;
            this.UITrackbarMusic.Name = "UITrackbarMusic";
            this.UITrackbarMusic.Size = new System.Drawing.Size(162, 45);
            this.UITrackbarMusic.TabIndex = 3;
            this.UITrackbarMusic.TickStyle = System.Windows.Forms.TickStyle.None;
            this.UITrackbarMusic.Value = 100;
            this.UITrackbarMusic.Scroll += new System.EventHandler(this.UITrackbarMusic_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(194, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 39);
            this.label4.TabIndex = 8;
            this.label4.Text = "+";
            // 
            // UINextPlaylist
            // 
            this.UINextPlaylist.AutoSize = true;
            this.UINextPlaylist.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UINextPlaylist.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UINextPlaylist.Location = new System.Drawing.Point(19, 154);
            this.UINextPlaylist.Name = "UINextPlaylist";
            this.UINextPlaylist.Size = new System.Drawing.Size(130, 26);
            this.UINextPlaylist.TabIndex = 7;
            this.UINextPlaylist.Text = "No Music next";
            // 
            // UIArtist
            // 
            this.UIArtist.AutoSize = true;
            this.UIArtist.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIArtist.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UIArtist.Location = new System.Drawing.Point(19, 89);
            this.UIArtist.Name = "UIArtist";
            this.UIArtist.Size = new System.Drawing.Size(85, 26);
            this.UIArtist.TabIndex = 6;
            this.UIArtist.Text = "No Artist";
            // 
            // UIPause
            // 
            this.UIPause.BackgroundImage = global::Musics___Client.Properties.Resources.Icopause;
            this.UIPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIPause.FlatAppearance.BorderSize = 0;
            this.UIPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIPause.Location = new System.Drawing.Point(131, 324);
            this.UIPause.Name = "UIPause";
            this.UIPause.Size = new System.Drawing.Size(35, 35);
            this.UIPause.TabIndex = 5;
            this.UIPause.UseVisualStyleBackColor = true;
            this.UIPause.Click += new System.EventHandler(this.UIPause_Click);
            // 
            // UIPlay
            // 
            this.UIPlay.BackgroundImage = global::Musics___Client.Properties.Resources.Icoplay;
            this.UIPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UIPlay.FlatAppearance.BorderSize = 0;
            this.UIPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UIPlay.Location = new System.Drawing.Point(80, 324);
            this.UIPlay.Name = "UIPlay";
            this.UIPlay.Size = new System.Drawing.Size(35, 35);
            this.UIPlay.TabIndex = 4;
            this.UIPlay.UseVisualStyleBackColor = true;
            this.UIPlay.Click += new System.EventHandler(this.UIPlay_Click);
            // 
            // UIPlayingMusic
            // 
            this.UIPlayingMusic.AutoSize = true;
            this.UIPlayingMusic.Font = new System.Drawing.Font("Open Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIPlayingMusic.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UIPlayingMusic.Location = new System.Drawing.Point(50, 12);
            this.UIPlayingMusic.Name = "UIPlayingMusic";
            this.UIPlayingMusic.Size = new System.Drawing.Size(135, 37);
            this.UIPlayingMusic.TabIndex = 2;
            this.UIPlayingMusic.Text = "No music";
            this.UIPlayingMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Next";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Artist";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1452, 799);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Client";
            this.Text = "Musics - Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            this.Tabs.ResumeLayout(false);
            this.UISearch.ResumeLayout(false);
            this.UISearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.UIAccount.ResumeLayout(false);
            this.UIAccount.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UITrackbarMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage UIHome;
        private System.Windows.Forms.TabPage UISearch;
        private System.Windows.Forms.TabPage UIBrowse;
        private System.Windows.Forms.TabPage UIFavorite;
        private System.Windows.Forms.TabPage UIPlaylists;
        private System.Windows.Forms.TabPage UIForums;
        private System.Windows.Forms.TabPage UIAccount;
        private System.Windows.Forms.TabPage UISettings;
        private System.Windows.Forms.ListBox UISearchListbox;
        private System.Windows.Forms.TextBox UITextboxSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton UIRadioMusic;
        private System.Windows.Forms.RadioButton UIRadioAlbum;
        private System.Windows.Forms.RadioButton UIRadioArtist;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UIPlay;
        private System.Windows.Forms.TrackBar UITrackbarMusic;
        private System.Windows.Forms.Label UIPlayingMusic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UIPause;
        private System.Windows.Forms.Label UINextPlaylist;
        private System.Windows.Forms.Label UIArtist;
        private System.Windows.Forms.Button UIThumbup;
        private System.Windows.Forms.Label UISelectedGenres;
        private System.Windows.Forms.Label UISelectedRating;
        private System.Windows.Forms.Label UISelectedname;
        private System.Windows.Forms.Button UIPlayBis;
        private System.Windows.Forms.Label UIselectedartist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UIAddPlaylistUnder;
        private System.Windows.Forms.Button UIForward;
        private System.Windows.Forms.Button UIBackward;
        private System.Windows.Forms.ListBox UIPlaylist;
        private System.Windows.Forms.Label UIAccountId;
        private System.Windows.Forms.Label UIAccountName;
    }
}

