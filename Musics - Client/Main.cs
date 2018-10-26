using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Utility.Network.Dialog.Edits;
using Utility.Network.Users;
using Utility.Network.Dialog;
using Utility.Network;
using Utility.Network.Dialog.Rating;
using Utility.Network.Dialog.Authentification;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;
using Musics___Client.AppSettings;
using ControlLibrary.Network;
using Musics___Client.API;

namespace Musics___Client
{
    public partial class Client : Form
    {
        public User Me { get; set; }

        public Client()
        {
            InitializeComponent();
            Me = LoginServices.Instance.LoggedUser;
          //  NetworkClient.Connect();
         //   NetworkClient.PacketReceived += TreatObject;
            NetworkClient.Packetreceived += TreatObject;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            NetworkClient.recevoir.Abort();
            NetworkClient.recevoir = new Thread(new ThreadStart(NetworkClient.Receive));
            NetworkClient.recevoir.Start();

            UIAccountName.Text = Me.Name;
            UIAccountId.Text = Me.UID;
            Text = "Musics - Client  Connected as " + Me.Name + " - Rank : " + Me.Rank.ToString();
            UIRank.Text = Me.Rank.ToString();
            if( Me.Rank == Rank.Viewer)
            {
                UIUpload.Enabled = false;
            }
           
            NetworkClient.SendObject(new Request(Me.UID));
            
        }

        #region Network

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            NetworkClient.SendObject(new Disconnect());
            NetworkClient.CloseSocket();
        }

        public event EventHandler LoginInfoReceived;

        protected void OnloginInfoReceived(EventArgs e)
        {
            LoginInfoReceived?.Invoke(this, e);
        }

        #endregion

        #region PlayerSearch
        private void TreatObject(object sender,PacketEventArgs obj)
        {
            if (obj.Packet is RequestAnswer)
            {
                RequestAnswer searchAnswer = obj.Packet as RequestAnswer;
                TreatRequestAnswer(searchAnswer);
            }
            if (obj.Packet is AuthInfo authInfo)
            {
                authInfo = obj.Packet as AuthInfo;
                OnloginInfoReceived(EventArgs.Empty);
            }
            if (obj.Packet is RateReport)
            {
                RateReport temp = obj.Packet as RateReport;

                if (selected != null)
                {
                    if (selected is Music)
                    {
                        if (temp.MID == (selected as Music).MID)
                        {
                            (selected as Music).Rating = temp.UpdatedRating;
                            Invoke((MethodInvoker)delegate
                            {
                                ChangeDescription();
                            });
                        }
                    }
                    if (selected is Playlist)
                    {
                        if (temp.MID == (selected as Playlist).MID)
                        {
                            (selected as Playlist).Rating = temp.UpdatedRating;
                            Invoke((MethodInvoker)delegate
                            {
                                ChangeDescription();
                            });
                        }
                    }
                }
            }
            if (obj.Packet is EditUserReport)
            {
                EditUserReport tmp = obj.Packet as EditUserReport;
                if (tmp.IsApproved)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        Me = tmp.NewUser;
                        UIAccountName.Text = Me.Name + " (Modified)";
                        UIAccountId.Text = Me.UID;
                        Text = "Musics - Client  Connected as " + Me.Name + " - Rank : " + Me.Rank.ToString();
                        UIRank.Text = Me.Rank.ToString();
                        if (Me.Rank == Rank.Viewer)
                        {
                            UIUpload.Enabled = false;
                        }
                        else
                        {
                            UIUpload.Enabled = true;
                        }
                    });
                }
                else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        UIEditError.Text = "Username use by another person !";
                    });
                }
            }
            if (obj.Packet is UploadReport)
            {
                if ((obj.Packet as UploadReport).UploadPartOk)
                {
                    if (UploadStatus < MusicsToSend.Musics.Count())
                    {
                        var music = MusicsToSend.Musics.ElementAt(UploadStatus);
                        NetworkClient.SendObject(new UploadMusic(new Album(music.Author, MusicsToSend.Name, new Music[] { music })));
                        UploadStatus++;
                    }
                    else
                    {
                        UploadStatus = 0;
                        MessageBox.Show("Upload is finished !");
                        MusicsToSend = null;
                    }
                }
                else
                {
                    UploadStatus = 0;
                    MessageBox.Show("Something is not working !");
                    MusicsToSend = null;
                }
            }
        }

        void TreatRequestAnswer(RequestAnswer searchAnswer)
        {
            switch (searchAnswer.RequestsTypes)
            {
                case RequestsTypes.Search:
                    RequestAnswerSearch(searchAnswer);
                    break;
                case RequestsTypes.MusicsBinaries:
                    RequestAnswerBinaries(searchAnswer);
                    break;
                case RequestsTypes.Favorites:
                    LikedMusics.Clear();
                    Invoke((MethodInvoker)delegate
                    {
                        RequestAnswerFavorites(searchAnswer);
                    });
                    break;
                case RequestsTypes.Users:
                    RequestAnswerUsers(searchAnswer);
                    break;
            }
        }

        public void RequestAnswerSearch(RequestAnswer searchAnswer)
        {
            ClearSearchListBoxes();
            FillSearchListBoxes(searchAnswer.AnswerList);

            Invoke((MethodInvoker)delegate
            {
                ChangeDescription();
            });
        }

        /// <summary>
        /// Clear all Search list boxes.
        /// </summary>
        private void ClearSearchListBoxes()
        {
            Invoke((MethodInvoker)delegate
           {
               ClearSearchListBoxesThreadSafe();
           });
        }

        private void ClearSearchListBoxesThreadSafe()
        {
            UISearchListbox.Items.Clear();
            SearchlistboxItems.Clear();
        }

        private void FillSearchListBoxes(IEnumerable<IElement> elements)
        {
            Invoke((MethodInvoker)delegate
            {
                FillSearchListBoxesThreadSafe(elements);
            });
        }

        private void FillSearchListBoxesThreadSafe(IEnumerable<IElement> elements)
        {
            UISearchListbox.Items.AddRange(elements.Select(a => a.Name).ToArray());
            SearchlistboxItems.AddRange(elements);
        }

        public void RequestAnswerBinaries(RequestAnswer searchAnswer)
        {
            Invoke((MethodInvoker)delegate
            {
                if (PlaylistContainsMusic(searchAnswer.Binaries.MID))
                {
                    UIPlaylist.SelectedIndex = uPlayer1.PlaylistIndex;
                }
                else
                {
                    uPlayer1.Playlist.Clear();
                    uPlayer1.PlaylistIndex = 0;
                    UIPlaylist.Items.Clear();
       
                    uPlayer1.Playlist.Add(searchAnswer.Binaries);
                    UIPlaylist.Items.Add(searchAnswer.Binaries.Title);
                    uPlayer1.PlaylistIndex = 0;
                    UIPlaylist.SelectedIndex = uPlayer1.PlaylistIndex;
                }
                uPlayer1.PlayMusic(searchAnswer.Binaries);
            });
        }

        public void RequestAnswerFavorites(RequestAnswer searchAnswer)
        {
            UILikedMusicsList.Items.Clear();

            foreach (var m in (from val in searchAnswer.Favorites select val.Genre.First()).Cast<string>().Distinct().ToList())
            {
                UILikedMusicsList.Items.Add(m);
                //LikedMusics.Add(m);
            }
            var tmp = searchAnswer.Favorites;
            //LikedMusics.Clear();
            LikedMusics = tmp;

            uPlayer1.Reset();
        }

        private List<Music> SelectedFavorites = new List<Music>();

        private void UILikedMusicsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (UILikedMusicsList.SelectedItem != null && SelectedFavorites.Count == 0)
            {
                SelectedFavorites.Clear();
                SelectedFavorites = (from val in LikedMusics
                                     where val.Genre.First() == UILikedMusicsList.SelectedItem.ToString()
                                     select val).ToList();
                UILikedMusicsList.Items.Clear();
                foreach (var m in SelectedFavorites)
                {
                    UILikedMusicsList.Items.Add(m.Title);
                }
            }
            else if (UILikedMusicsList.SelectedItem != null)
            {
                Tabs.SelectedIndex = 1;
                NetworkClient.SendObject(new Request(SelectedFavorites[UILikedMusicsList.SelectedIndex].Title, ElementType.Music));
            }
        }

        private void UIFavoritesBack_Click(object sender, EventArgs e)
        {
            SelectedFavorites.Clear();
            RequestAnswerFavorites(new RequestAnswer(LikedMusics));
        }

        public void RequestAnswerUsers(RequestAnswer searchAnswer)
        {
            if (searchAnswer.IsAccepted)
            {
                Invoke((MethodInvoker)delegate
                {
                    UserSearchResult.Clear();
                    UIUsersResult.Items.Clear();
                    foreach (var u in searchAnswer.Users)
                    {
                        if (u.UID != Me.UID)
                        {
                            UserSearchResult.Add(u);
                            UIUsersResult.Items.Add(u.Name);
                        }
                    }
                    if (UserSearchResult.Count != 0)
                    {
                        UIUsersResult.SelectedIndex = 0;
                    }
                });
            }
            else
            {
                MessageBox.Show("Invalid rank, you must be at least a -User-");
            }
        }
        public AuthInfo authInfo;

        private List<object> SearchlistboxItems = new List<object>();
        private List<Music> LikedMusics = new List<Music>();

        private void UITextboxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UIRadioAlbum.Checked)
                {
                    NetworkClient.SendObject(new Request(UITextboxSearch.Text, ElementType.Album));
                    return;
                }
                if (UIRadioArtist.Checked)
                {
                    NetworkClient.SendObject(new Request(UITextboxSearch.Text, ElementType.Author));
                    return;
                }
                if (UIRadioMusic.Checked)
                {
                    NetworkClient.SendObject(new Request(UITextboxSearch.Text, ElementType.Music));
                    return;
                }
                if (UIRadioPlaylist.Checked)
                {
                    NetworkClient.SendObject(new Request(UITextboxSearch.Text, ElementType.Playlist));
                }
            }
        }

        IElement selected;
        ElementType typeOfSelected;

        private void UISearchListbox_SelectedIndexChanged(object sender, EventArgs e)
            {
            Invoke((MethodInvoker)delegate
            {
                ChangeDescription();
            });
        }

        private void ChangeDescription()
        {
            if (UISearchListbox.SelectedItem == null) return;
            selected = SearchlistboxItems[UISearchListbox.SelectedIndex] as IElement;

            switch (selected)
            {
                case Music music: ChangeDescription(music); break;
                case Album album: ChangeDescription(album); break;
                case Author author: ChangeDescription(author); break;
                case Playlist playlist: ChangeDescription(playlist); break;
                default: throw new InvalidCastException();
            }
        }

        private void ChangeDescription(Playlist playlist)
        {
            UISelectedname.Text = playlist.Name;
            UIselectedartist.Text = playlist.Creator.Name;
            UISelectedRating.Text = $"Rating : {playlist.Rating}";
            UIPathAuthor.Text = string.Empty;
            UIPathAlbum.Text = string.Empty;
            UIPathMusic.Text = string.Empty;
            UIThumbup.Visible = true;

            //Playlist.Clear();
            //PlaylistIndex = 0;
            UIPlaylist.Items.Clear();
            UIPlaylist.Items.AddRange(playlist.musics.Select(x => x.Title).ToArray());
        }

        private void ChangeDescription(Author author)
        {
            UISelectedname.Text = author.Name;
            UIselectedartist.Text = string.Empty;
            UISelectedRating.Text = "Rating : ";

            UIPathAuthor.Text = author.Name;
            UIPathAlbum.Text = string.Empty;
            UIPathMusic.Text = string.Empty;
            UIThumbup.Visible = false;
        }

        private void ChangeDescription(Album album)
        {
            UISelectedname.Text = album.Name;
            UIselectedartist.Text = album.Author.Name;
            UISelectedRating.Text = "Rating : ";
            UISelectedGenres.Text = $"Genres : {string.Join(" ", album.Musics.First().Genre)}";

            UIPathAuthor.Text = album.Author.Name;
            UIPathAlbum.Text = album.Name;
            UIPathMusic.Text = string.Empty;
            UIThumbup.Visible = false;
        }

        private void ChangeDescription(Music music)
        {
            UISelectedname.Text = music.Title;
            UIselectedartist.Text = music.Author.Name;
            UISelectedRating.Text = $"Rating : {music.Rating}";
            UISelectedGenres.Text = $"Genres :  {string.Join(" ", music.Genre)}";
            UIThumbup.Visible = true;

            UIPathAuthor.Text = music.Author.Name;
            UIPathAlbum.Text = music.Album.Name;
            UIPathMusic.Text = music.Title;
        }

        private void UIPlaylistClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uPlayer1.Playlist.Clear();
            uPlayer1.PlaylistIndex = 0;
            UIPlaylist.Items.Clear();           

        }

        private void UIPlayBis_Click(object sender, EventArgs e)
        {

            switch(selected)
            {
                case Music music:  PlayBis(music); break;
                case Album album:  PlayBis(album); break;
                case Playlist playlist: PlayBis(playlist); break;
                default: throw new NotImplementedException();
            }
            if (selected is Music)
            {
                NetworkClient.SendObject(new Request(selected as Music));
            }
            else if (selected is Album)
            {
                uPlayer1.Playlist.Clear();
                uPlayer1.PlaylistIndex = 0;
                UIPlaylist.Items.Clear();
                foreach (var m in (selected as Album).Musics)
                {
                    uPlayer1.Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
                NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
            }
            else if (selected is Playlist)
            {
                uPlayer1.Playlist.Clear();
                uPlayer1.PlaylistIndex = 0;
                UIPlaylist.Items.Clear();
                foreach (var m in (selected as Playlist).musics)
                {
                    uPlayer1.Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
                NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
            }
        }

        private void PlayBis(Music music)
        {
            NetworkClient.SendObject(new Request(music));
        }
        private void PlayBis(Album album)
        {
            uPlayer1.Playlist.Clear();
            uPlayer1.PlaylistIndex = 0;
            UIPlaylist.Items.Clear();
            foreach (var m in album.Musics)
            {
                uPlayer1.Playlist.Add(m);
                UIPlaylist.Items.Add(m.Title);
            }
            NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
        }

        private void PlayBis(Playlist playlist)
        {
            uPlayer1.Playlist.Clear();
            uPlayer1.PlaylistIndex = 0;
            UIPlaylist.Items.Clear();
            foreach (var m in playlist.musics)
            {
                uPlayer1.Playlist.Add(m);
                UIPlaylist.Items.Add(m.Title);
            }
            NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            //uPlayer1.player.close();

            foreach (var p in System.IO.Directory.GetFiles(@"c:\MusicsFiles"))
            {
                System.IO.File.Delete(p);
            }
        }

        private void UISearchListbox_DoubleClick(object sender, EventArgs e)
        {
            if (UISearchListbox == null) return;
            var selectedItem = SearchlistboxItems[UISearchListbox.SelectedIndex];
            switch (selectedItem)
            {
                case Author author:
                    ClearSearchListBoxesThreadSafe();
                    FillSearchListBoxesThreadSafe(author.Albums);
                    break;
                case Album album:
                    ClearSearchListBoxesThreadSafe();
                    FillSearchListBoxesThreadSafe(album.Musics);
                    break;
                case Music music:



                    if (uPlayer1.IsInCache(music))
                    {
                        uPlayer1.Playlist.Clear();
                        uPlayer1.PlaylistIndex = 0;
                        UIPlaylist.Items.Clear();

                        uPlayer1.Playlist.Add(music);
                        UIPlaylist.Items.Add(music.Title);
                        uPlayer1.PlaylistIndex = 0;
                        UIPlaylist.SelectedIndex = uPlayer1.PlaylistIndex;

                        uPlayer1.PlayMusic(music);
                    }
                    else
                    {
                        NetworkClient.SendObject(new Request(music));
                    }
                    break;
                case Playlist playlist:
                    uPlayer1.Playlist.Clear();
                    uPlayer1.PlaylistIndex = 0;
                    UIPlaylist.Items.Clear();
                    foreach (var m in (selected as Playlist).musics)
                    {
                        uPlayer1.Playlist.Add(m);
                        UIPlaylist.Items.Add(m.Title);
                    }
                    NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
                    break;
                default: throw new InvalidCastException();
            }
        }


        private void UIAddPlaylistUnder_Click(object sender, EventArgs e)
        {
            if (selected is Music)
            {
                uPlayer1.Playlist.Add(selected as Music);
                UIPlaylist.Items.Add((selected as Music).Title);
            }
            else if (selected is Album)
            {
                foreach (var m in (selected as Album).Musics)
                {
                    uPlayer1.Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);        
                }
                if (uPlayer1.PlaylistIndex == 0)
                    uPlayer1.PlayMusic(uPlayer1.Playlist.First());
            }
        }

        private bool PlaylistContainsMusic(string MID)
        {
            foreach (var m in uPlayer1.Playlist)
            {
                if (m.MID == MID)
                {
                    return true;
                }
            }
            return false;
        }

        private void UIThumbup_Click(object sender, EventArgs e)
        {
            if (SearchlistboxItems[UISearchListbox.SelectedIndex] != null)
            {
                if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Music)
                {
                    NetworkClient.SendObject(new Rate((SearchlistboxItems[UISearchListbox.SelectedIndex] as Music).MID, ElementType.Music));
                }
                if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Playlist)
                {
                    NetworkClient.SendObject(new Rate((SearchlistboxItems[UISearchListbox.SelectedIndex] as Playlist).MID, ElementType.Playlist));
                }
            }
        }

        private void UIPathAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchlistboxItems.Count != 0)
            {
                if (!(SearchlistboxItems.First() is Author))
                {
                    NetworkClient.SendObject(new Request(UIPathAuthor.Text, ElementType.Author));
                }
            }
        }

        void UIPathAlbum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchlistboxItems.Count != 0)
            {
                if (!(SearchlistboxItems.First() is Album))
                {
                    NetworkClient.SendObject(new Request(UIPathAlbum.Text, ElementType.Album));
                }
            }
        }

        private void UIPlayFavorites_Click(object sender, EventArgs e)
        {
            if (LikedMusics.Count >= 1)
            {
                uPlayer1.Playlist.Clear();
                uPlayer1.PlaylistIndex = 0;
                UIPlaylist.Items.Clear();
                foreach (var m in LikedMusics)
                {
                    uPlayer1.Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
                NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
                Tabs.SelectedIndex = 1;
            }
        }

        #endregion

        #region Account

        private void UIAccountEdit_Click(object sender, EventArgs e)
        {
            if (UIEditPassword1.Text != null && UIEditPassword1.Text == UIEditPassword2.Text)
            {
                if (UIEditName.Text == "")
                {
                   //NetworkClient.SendObject(new EditUser(Me.UID, new User(Me.Name, UIEditPassword1.Text)));
                }
                else
                {
                  //  NetworkClient.SendObject(new EditUser(Me.UID, new User(UIEditName.Text, UIEditPassword1.Text)));
                }
            }
            else if (UIEditPassword1.Text == null)
            {
                UIEditError.Text = "Please enter the new password";
            }
            else
            {
                UIEditError.Text = "Passwords don't match";
            }
        }

        #endregion

        #region EditUser

        readonly List<User> UserSearchResult = new List<User>();

        private void UISearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UISearchUser.Text != null)
                {
                    NetworkClient.SendObject(new Request(new User(UISearchUser.Text)));
                }
            }
        }

        private void UIUsersResult_MouseDown(object sender, MouseEventArgs e)
        {
            if (UIUsersResult.SelectedItem != null)
            {
                UIPanelEditUser.Visible = true;

                UIAdminUser.Text = UIUsersResult.Text + " - " + UserSearchResult[UIUsersResult.SelectedIndex].Rank.ToString();
                UIAdminUID.Text = UserSearchResult[UIUsersResult.SelectedIndex].UID;

                UIEditUserRank.Items.Clear();

                List<string> r = Enum.GetNames(typeof(Rank)).OfType<string>().ToList();
                for (int i = 0; i < (int)Me.Rank; i++)
                {
                    UIEditUserRank.Items.Add(r[i]);
                }

                UIEditUserRank.SelectedIndex = (int)UserSearchResult[UIUsersResult.SelectedIndex].Rank;
            }
        }

        private void UIEditUserConfirm_Click(object sender, EventArgs e)
        {
            if (UIEditUserRank.SelectedIndex != (int)UserSearchResult[UIUsersResult.SelectedIndex].Rank && Enum.TryParse(UIEditUserRank.SelectedItem.ToString(), out Rank rank))
            {
                NetworkClient.SendObject(new EditRequest(UserSearchResult[UIUsersResult.SelectedIndex].UID, rank));
            }
        }

        #endregion

        #region EditMusic

        private void UIEditMusic_Click(object sender, EventArgs e)
        {
            if (selected != null && !(selected is Playlist))
            {
                UIEditMusicName.Visible = true;
                UIEditMusicName.Text = UISelectedname.Text;

                if (selected is Music)
                {
                    UIEditMusicGenres.Text = string.Join(";", (selected as Music).Genre);
                    UIEditMusicGenres.Visible = true;
                }
            }
            if (UIEditMusicName.Visible)
            {
                // UIEditMusicName.Visible = false;
            }
        }

        void UIEditMusicName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((int)Me.Rank > 1 && UIEditMusicName.Text != null)
                {
                    if (selected is Music)
                    {
                        (selected as Music).Type = ElementType.Music;
                        NetworkClient.SendObject(new EditRequest(selected, UIEditMusicName.Text, UIEditMusicGenres.Text.Split(';'), typeOfSelected));
                    }
                    else
                    {
                        NetworkClient.SendObject(new EditRequest(selected, UIEditMusicName.Text, typeOfSelected));
                    }
                    UIEditMusicName.Visible = false;
                    UIEditMusicGenres.Visible = false;
                }
                else
                {
                    MessageBox.Show("You have to be at least a user to edit this music");
                    UIEditMusicName.Visible = false;
                    UIEditMusicGenres.Visible = false;
                }
            }
        }

        #endregion

        #region Playlist

        private void UISavePlaylist_Click(object sender, EventArgs e)
        {
            if (uPlayer1.Playlist.Count != 0)
            {
                UIEditPlaylist.Visible = true;
                UIPlaylistName.Visible = true;
            }
        }

        private void UIPlaylistName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UIEditPlaylist.Visible = false;
                UIPlaylistName.Visible = false;
                NetworkClient.SendObject(new SavePlaylist(Me.UID, new Playlist(Me, UIPlaylistName.Text, uPlayer1.Playlist, UIPlaylistPrivate.Checked)));
            }
        }

        #endregion

        #region Upload

        Upload uploadForm;
        int UploadStatus;
        public Album MusicsToSend;

        private void UIUpload_Click(object sender, EventArgs e)
        {
            if (MusicsToSend == null)
            {
                uploadForm = new Upload();
                uploadForm.Show();
                uploadForm.FormClosing += UploadForm_FormClosing;
            }
            else
            {
                MessageBox.Show("Please wait for the previous Upload to finish");
            }
        }

        private void UploadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (uploadForm.IsUploadValid)
            {
                MusicsToSend = uploadForm.AlbumToSend;
                var music = MusicsToSend.Musics.First();
                NetworkClient.SendObject(new UploadMusic(new Album(music.Author, uploadForm.AlbumToSend.Name, new Music[] { music })));

                UploadStatus = 1;

                MessageBox.Show("Musics has been sent to the server");
            }
            else
            {
                //MessageBox.Show("Error");
            }
        }
        #endregion

    }
}
