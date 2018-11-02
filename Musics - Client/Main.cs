using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Utility.Network.Dialog.Edits;
using Utility.Network.Users;
using Utility.Network.Dialog;
using Utility.Network;
using Utility.Network.Dialog.Authentification;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;
using ControlLibrary.Network;
using Musics___Client.API;
using Musics___Client.API.Events;
using Utility.Network.Dialog.Requests;

namespace Musics___Client
{
    public partial class Client : Form
    {
        public User Me { get; set; }

        public Client()
        {
            InitializeComponent();
            Me = LoginServices.Instance.LoggedUser;
        }

        public void InitServices()
        {
            NetworkClient.Packetreceived += TreatObject; 
            SearchServices.Instance.SearchResultEvent += Search_SearchResultEvent;
            RateServices.Instance.RateReportEvent += RateServices_RateReportEvent;
            RateServices.Instance.FavoriteReceivedEvent += RateServices_FavoriteReceivedEvent;
            EditAccountServices.Instance.EditAccountReport += AccountServices_EditAccountReport;
        }

        private void AccountServices_EditAccountReport(object sender, EditAccountReportEventArgs e)
        {

            if (e.IsApproved)
            {
                Invoke((MethodInvoker)delegate
                {
                    Me = e.EditedUser;
                    EditAccountDetails(Me);
                });
            }
            else
            {
                AccountControl.TellError("Username already taken !");
            }
        }

        private void RateServices_FavoriteReceivedEvent(object sender, FavoriteEventArgs e)
            => FavoriteControl.UpdateFavorites(e.Favorites);

        private void FavoriteControl_PlayAllEvent(object sender, PlayEventArgs e)
            => PlayElement(e.Selected);

        private void FavoriteControl_SearchEvent(object sender, RequestBinairiesEventArgs e)
            => NetworkClient.SendObject(new RequestBinairies(e.RequestedMusic));

        private void RateServices_RateReportEvent(object sender, RateReportEventArgs e)
        {
            var selected = SearchControl.selected;
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

            EditAccountDetails(Me);

            NetworkClient.SendObject(new RequestFavorites(Me.UID));

            InitServices();

            homeControl1.SearchEvent += HomeControl1_SearchEvent;
        }

        private void SearchControl_RateEvent(object sender, RateEventArgs e)
            => RateServices.Instance.RateMusic(e.ElementRatedMID, e.Type);

        private void SearchControl_SearchEvent(object sender, SearchEventArgs e)
            => SearchServices.Instance.SearchElement(e.SearchField, e.ElementType);

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

        public void EditAccountDetails(User NewUser)
        {
            Invoke((MethodInvoker)delegate
            {
                Text = "Musics - Client  Connected as " + NewUser.Name + " - Rank : " + NewUser.Rank.ToString();
                if (NewUser.Rank == Rank.Viewer)
                    SearchControl.EnableUpload(false);
                else
                    SearchControl.EnableUpload(true);
                AccountControl.EditAccountDetails(NewUser);
            });
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

        private void Search_SearchResultEvent(object sender, SearchResultEventArgs e)
             => RequestAnswerSearch(e.ReceivedSearchedElement);

        private void HomeControl1_SearchEvent(object sender, SearchEventArgs e)
            => SearchServices.Instance.SearchElement(e.SearchField, e.ElementType);

        private void SearchControl_ClearEvent(object sender, EventArgs e)
        {
            uPlayer1.Playlist.Clear();
            uPlayer1.PlaylistIndex = 0;
        }

        private void TreatObject(object sender, PacketEventArgs obj)
        {
            if (obj.Packet is RequestAnswer)
            {
                var requestAnswer = obj.Packet as RequestAnswer;
                TreatRequestAnswer(requestAnswer);
            }
            if (obj.Packet is AuthInfo authInfo)
            {
                authInfo = obj.Packet as AuthInfo;
                OnloginInfoReceived(EventArgs.Empty);
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

        private void ChangeDescription()
            => SearchControl.ChangeDescription(SearchControl.selected);

        private void SearchControl_PlayEvent(object sender, PlayEventArgs e)
        {
            PlayElement(e.Selected);
        }

        private void PlayElement(IElement element)
        {
            ChangeTabsThreadSafe(1);
            switch (element)
            {
                case Music music: PlayBis(music); break;
                case Album album: PlayBis(album); break;
                case Playlist playlist: PlayBis(playlist); break;
            }
        }

        private void PlayBis(Music music)
            => NetworkClient.SendObject(new RequestBinairies(music));

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
            NetworkClient.SendObject(new RequestBinairies(uPlayer1.Playlist.First()));
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
            NetworkClient.SendObject(new RequestBinairies(uPlayer1.Playlist.First()));
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
            => SearchServices.Instance.SearchElement(e.Name, e.type);


        #endregion
        #region EditUser

        readonly List<User> UserSearchResult = new List<User>();

        private void UISearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UISearchUser.Text != null)
                {
                    NetworkClient.SendObject(new RequestUser(new User(UISearchUser.Text)));
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

                var r = Enum.GetNames(typeof(Rank)).OfType<string>().ToList();
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
                EditMusicsServices.Instance.SendEditMusicRequest(e.ElementToEdit, e.NewName, e.Genre);
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
                PlaylistServices.Instance.SubmitPlaylist(Me, e.PlaylistName, uPlayer1.Playlist, e.IsPrivate);
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

        private void AccountControl_EditAccountDone(object sender, EditAccountEventArgs e)
            => EditAccountServices.Instance.EditUser(e.NewPassword, Me.UID, e.NewName);

    }
}
