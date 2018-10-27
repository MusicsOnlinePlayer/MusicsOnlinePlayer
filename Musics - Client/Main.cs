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
using Musics___Client.API.Events;

namespace Musics___Client
{
    public partial class Client : Form
    {
        public User Me { get; set; }

        public SearchServices searchServices;
        public EditMusicsServices editMusicsServices;
        public RateServices rateServices;
        public PlaylistServices playlistServices;

        public Client()
        {
            InitializeComponent();
            Me = LoginServices.Instance.LoggedUser;
            
        }

        public void InitServices()
        {
            NetworkClient.Packetreceived += TreatObject;
            searchServices = new SearchServices();
            searchServices.SearchResultEvent += SearchServices_SearchResultEvent;

            editMusicsServices = new EditMusicsServices();

            rateServices = new RateServices();
            rateServices.RateReportEvent += RateServices_RateReportEvent;

            playlistServices = new PlaylistServices();
        }


        private void RateServices_RateReportEvent(object sender, RateReportEventArgs e)
        {
            IElement selected = SearchControl.selected;
            if (selected != null)
            {
                if (selected is Music)
                {
                    if (e.MID == (selected as Music).MID)
                    {
                        (selected as Music).Rating = e.UpdatedRating;
                        Invoke((MethodInvoker)delegate
                        {
                            ChangeDescription();
                        });
                    }
                }
                if (selected is Playlist)
                {
                    if (e.MID == (selected as Playlist).MID)
                    {
                        (selected as Playlist).Rating = e.UpdatedRating;
                        Invoke((MethodInvoker)delegate
                        {
                            ChangeDescription();
                        });
                    }
                }
            }
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
                SearchControl.EnableUpload(false);
            }
           
            NetworkClient.SendObject(new Request(Me.UID));

            InitServices();

            homeControl1.SearchEvent += HomeControl1_SearchEvent;
            SearchControl.PlayEvent += SearchControl_PlayEvent;
            SearchControl.AddPlaylistEvent += SearchControl_AddPlaylistEvent;
            SearchControl.SearchEvent += SearchControl_SearchEvent;
            SearchControl.ClearEvent += SearchControl_ClearEvent;
            SearchControl.UploadEvent += SearchControl_UploadEvent;
            SearchControl.RateEvent += SearchControl_RateEvent;
            SearchControl.PathClicked += SearchControl_PathClicked;
            SearchControl.EditMusic += SearchControl_EditMusic;
            SearchControl.PlaylistSaved += SearchControl_PlaylistSaved;
        }



        private void SearchControl_RateEvent(object sender, RateEventArgs e)
            => rateServices.RateMusic(e.ElementRatedMID, e.Type);

        private void SearchControl_SearchEvent(object sender, SearchEventArgs e)
            => searchServices.SearchElement(e.SearchField, e.ElementType);

        private void SearchControl_AddPlaylistEvent(object sender, EventArgs e)
        {
            if (SearchControl.selected is Music)
            {
                uPlayer1.Playlist.Add(SearchControl.selected as Music);
                SearchControl.AddToPlaylist((SearchControl.selected as Music).Title);
            }
            else if (SearchControl.selected is Album)
            {
                foreach (var m in (SearchControl.selected as Album).Musics)
                {
                    uPlayer1.Playlist.Add(m);
                    SearchControl.AddToPlaylist(m.Title);
                }
                if (uPlayer1.PlaylistIndex == 0)
                    uPlayer1.PlayMusic(uPlayer1.Playlist.First());
            }
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

        private void SearchServices_SearchResultEvent(object sender, SearchResultEventArgs e)
             => RequestAnswerSearch(e.ReceivedSearchedElement);

        private void HomeControl1_SearchEvent(object sender, SearchEventArgs e)
            => searchServices.SearchElement(e.SearchField, e.ElementType);

        private void SearchControl_ClearEvent(object sender, EventArgs e)
        {
            uPlayer1.Playlist.Clear();
            uPlayer1.PlaylistIndex = 0;
        }

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
                            SearchControl.EnableUpload(false);
                        }
                        else
                        {
                            SearchControl.EnableUpload(false);
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

        public void RequestAnswerSearch(IReadOnlyList<IElement> searchAnswer)
        {
            ChangeTabsThreadSafe(1);



            SearchControl.ClearSearchListBoxes();
            SearchControl.FillSearchListBoxes(searchAnswer);

            Invoke((MethodInvoker)delegate
            {
                ChangeDescription();
            });
        }



      

        private void ChangeTabsThreadSafe(int tab) => Invoke((MethodInvoker)delegate { Tabs.SelectedIndex = tab; });
        
        public void RequestAnswerBinaries(RequestAnswer searchAnswer)
        {
            Invoke((MethodInvoker)delegate
            {
                if (PlaylistContainsMusic(searchAnswer.Binaries.MID))
                {
                    SearchControl.SetPlaylistIndex(uPlayer1.PlaylistIndex);
                }
                else
                {
                    uPlayer1.Playlist.Clear();
                    uPlayer1.PlaylistIndex = 0;
                    SearchControl.ClearPlaylist();
       
                    uPlayer1.Playlist.Add(searchAnswer.Binaries);
                    SearchControl.AddToPlaylist(searchAnswer.Binaries.Title);
                    uPlayer1.PlaylistIndex = 0;
                    SearchControl.SetPlaylistIndex(uPlayer1.PlaylistIndex);
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
        private List<Music> LikedMusics = new List<Music>();

        private void UISearchListbox_SelectedIndexChanged(object sender, EventArgs e)
            {
            Invoke((MethodInvoker)delegate
            {
                ChangeDescription();
            });
        }

        private void ChangeDescription()
            => SearchControl.ChangeDescription(SearchControl.selected);

        private void SearchControl_PlayEvent(object sender, PlayEventArgs e)
        {
            switch (e.Selected)
            {
                case Music music : PlayBis(music); break;
                case Album album: PlayBis(album); break;
                case Playlist playlist: PlayBis(playlist); break;
            }
        }

        private void PlayBis(Music music)
            => NetworkClient.SendObject(new Request(music));

        private void PlayBis(Album album)
        {
            uPlayer1.Playlist.Clear();
            uPlayer1.PlaylistIndex = 0;
            SearchControl.ClearPlaylist();
            foreach (var m in album.Musics)
            {
                uPlayer1.Playlist.Add(m);
                SearchControl.AddToPlaylist(m.Title);
            }
            NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
        }

        private void PlayBis(Playlist playlist)
        {
            uPlayer1.Playlist.Clear();
            uPlayer1.PlaylistIndex = 0;
            SearchControl.ClearPlaylist();
            foreach (var m in playlist.musics)
            {
                uPlayer1.Playlist.Add(m);
                SearchControl.AddToPlaylist(m.Title);
            }
            NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var p in System.IO.Directory.GetFiles(@"c:\MusicsFiles"))
            {
                System.IO.File.Delete(p);
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

        private void SearchControl_PathClicked(object sender, PathClickedEventArgs e)
            => searchServices.SearchElement(e.Name, e.type);

        private void UIPlayFavorites_Click(object sender, EventArgs e)
        {
            if (LikedMusics.Count >= 1)
            {
                uPlayer1.Playlist.Clear();
                uPlayer1.PlaylistIndex = 0;
                SearchControl.ClearPlaylist();
                foreach (var m in LikedMusics)
                {
                    uPlayer1.Playlist.Add(m);
                    SearchControl.AddToPlaylist(m.Title);
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

        private void SearchControl_EditMusic(object sender, EditMusicEventArgs e)
        {
            if ((int)Me.Rank > 1 && e.NewName != null)
            {
                editMusicsServices.SendEditMusicRequest(e.ElementToEdit, e.NewName, e.Genre);
                SearchControl.EditMusicDone();
            }
            else
            {
                MessageBox.Show("You have to be at least a user to edit this music");
                SearchControl.EditMusicDone();
            }
        }

        private void SearchControl_PlaylistSaved(object sender, PlaylistSavedEventArgs e)
        {
            if (uPlayer1.Playlist.Count != 0)
                playlistServices.SubmitPlaylist(Me, e.PlaylistName, uPlayer1.Playlist, e.IsPrivate);
        }

        #region Upload

        Upload uploadForm;
        int UploadStatus;
        public Album MusicsToSend;

        private void SearchControl_UploadEvent(object sender, EventArgs e)
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
