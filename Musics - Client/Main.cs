﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Musics___Client.Hue;
using NAudio.CoreAudioApi;
using Musics___Client.MusicsUtils;
using Utility.Network.Dialog.Edits;
using Utility.Network.Users;
using Utility.Network.Dialog;
using Utility.Network;
using Utility.Network.Dialog.Rating;
using Utility.Network.Dialog.Authentification;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;
using Musics___Client.AppSettings;

namespace Musics___Client
{
    public partial class Client : Form
    {
        public Socket _clientSocket { get; set; }
        public User Me { get; set; }
        public IPAddress ip = IPAddress.Loopback;

        private readonly HueMusic HueMusic = new HueMusic();

        public Client()
        {
            InitializeComponent();
            UIMusicImage.BackgroundImage = Properties.Resources.No_Cover_Image;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            //recevoir.Start();
            recevoir.Abort();
            recevoir = new Thread(new ThreadStart(Receive));
            recevoir.Start();

            UIAccountName.Text = Me.Name;
            UIAccountId.Text = Me.UID;
            this.Text = "Musics - Client  Connected as " + Me.Name + " - Rank : " + authInfo.RankofAuthUser.ToString();
            UIRank.Text = authInfo.RankofAuthUser.ToString();
            if (authInfo.RankofAuthUser == Rank.Viewer)
            {
                UIUpload.Enabled = false;
            }
            try
            {
                AppSettings.Settings settings = ApplicationSettings.Get();
                if (settings.HueKey != null && settings.HueIP != null)
                {
                    UIHueApi.Text = settings.HueKey;
                    UIHueIp.Text = settings.HueIP;
                }
            }
            catch
            {
            }

            SendObject(new Request(Me.UID));
            
        }

        #region Network

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            SendObject(new Disconnect());
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close(1000);
        }

        public void Connect()
        {
            if (IPAddress.TryParse(AppSettings.ApplicationSettings.Get().ServerIp, out IPAddress iPAddress))
            {
                IPEndPoint ip = new IPEndPoint(iPAddress, 2003);
                try
                {
                    _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {
                        SendTimeout = 600000,
                        ReceiveTimeout = 600000
                    };
                    _clientSocket.BeginConnect(ip, new AsyncCallback(ConnectCallBack), null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                p.player.PlayStateChange += Player_PlayStateChange;
            }
        }

        private void Player_PlayStateChange(int NewState)
        {
            if (NewState == 8)
            {
                if (PlaylistIndex + 1 < Playlist.Count)
                {
                    PlaylistIndex++;
                    SendObject(new Request(Playlist[PlaylistIndex]));
                }
            }
        }
        byte[] recbuffer = new byte[100000000];
        Thread recevoir;

        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndConnect(ar);

                recevoir = new Thread(new ThreadStart(Receive));
                recevoir.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Receive()
        {
            _clientSocket.BeginReceive(recbuffer, 0, 100000000, SocketFlags.Partial,
                    new AsyncCallback(ReceiveCallback), null);
        }

        public event EventHandler LoginInfoReceived;

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                _clientSocket.EndReceive(AR);
                // Array.Resize(ref recbuffer, ren + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            TreatObject(Function.Deserialize(new MessageTCP(recbuffer)));

            recbuffer = new byte[100000000];

            try
            {
                _clientSocket.BeginReceive(recbuffer, 0, recbuffer.Length, SocketFlags.Partial,
                new AsyncCallback(ReceiveCallback), null);
            }
            catch
            {
            }
        }

        protected virtual void OnloginInfoReceived(EventArgs e)
        {
            LoginInfoReceived?.Invoke(this, e);
        }

        public void SendObject(object obj)
        {
            var msg = Function.Serialize(obj);
            try
            {
                _clientSocket.BeginSend(msg.Data, 0, msg.Data.Length, SocketFlags.Partial, new AsyncCallback(SendCallback), null);
            }
            catch
            {
                MessageBox.Show("Can't send message. Check your connection", "Connection exception");
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndSend(ar);
            }
            catch
            {
            }
        }
        #endregion

        #region PlayerSearch
        private void TreatObject(object obj)
        {
            if (obj is RequestAnswer)
            {
                RequestAnswer searchAnswer = obj as RequestAnswer;
                TreatRequestAnswer(searchAnswer);
            }
            if (obj is AuthInfo)
            {
                authInfo = obj as AuthInfo;
                OnloginInfoReceived(EventArgs.Empty);
            }
            if (obj is RateReport)
            {
                RateReport temp = obj as RateReport;

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
            if (obj is EditUserReport)
            {
                EditUserReport tmp = obj as EditUserReport;
                if (tmp.IsApproved)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        Me = tmp.NewUser;
                        UIAccountName.Text = Me.Name + " (Modified)";
                        UIAccountId.Text = Me.UID;
                        this.Text = "Musics - Client  Connected as " + Me.Name + " - Rank : " + Me.Userrank.ToString();
                        UIRank.Text = Me.Userrank.ToString();
                        if (Me.Userrank == Rank.Viewer)
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
            if (obj is UploadReport)
            {
                if ((obj as UploadReport).UploadPartOk)
                {
                    if (UploadStatus < MusicsToSend.Musics.Count())
                    {
                        var music = MusicsToSend.Musics.ElementAt(UploadStatus);
                        SendObject(new UploadMusic(new Album(music.Author, MusicsToSend.Name, new Music[] { music })));
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

        //private void  UpdateSearchList(IEnumerable<Element>)

        public void RequestAnswerBinaries(RequestAnswer searchAnswer)
        {
            InPlaying = searchAnswer.Binaries;

            Invoke((MethodInvoker)delegate
            {
                if (PlaylistContainsMusic(InPlaying.MID))
                {
                    UIPlaylist.SelectedIndex = PlaylistIndex;
                }
                else
                {
                    Playlist.Clear();
                    PlaylistIndex = 0;
                    UIPlaylist.Items.Clear();
                    Music m = new Music
                    {
                        MID = InPlaying.MID
                    };
                    Playlist.Add(InPlaying);
                    UIPlaylist.Items.Add(InPlaying.Title);
                    PlaylistIndex = 0;
                    UIPlaylist.SelectedIndex = PlaylistIndex;
                }
                UIPlayingMusic.Text = InPlaying.Title;
                UIArtist.Text = InPlaying.Author.Name;
                UIFormat.Text = InPlaying.Format;
                UIForward.Enabled = true;
                UIBackward.Enabled = true;
            });

            p.PlayMusic(InPlaying);

            try
            {
                UIMusicImage.BackgroundImage = Tags.GetMetaImage(p.player.URL);
            }
            catch
            {
                UIMusicImage.BackgroundImage = Properties.Resources.No_Cover_Image;
            }
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
                SendObject(new Request(SelectedFavorites[UILikedMusicsList.SelectedIndex].Title, ElementType.Music));
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

        Player p = new Player();

        public AuthInfo authInfo;
        Music InPlaying;

        private List<object> SearchlistboxItems = new List<object>();
        private List<Music> LikedMusics = new List<Music>();

        private void UITextboxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UIRadioAlbum.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, ElementType.Album));
                    return;
                }
                if (UIRadioArtist.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, ElementType.Author));
                    return;
                }
                if (UIRadioMusic.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, ElementType.Music));
                    return;
                }
                if (UIRadioPlaylist.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, ElementType.Playlist));
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
            Playlist.Clear();
            PlaylistIndex = 0;
            UIPlaylist.Items.Clear();           
            UIPlayingMusic.Text = "No music";
            UIArtist.Text = "Artist";
            UIFormat.Text = "Format";
            UIForward.Enabled = false;
            UIBackward.Enabled = false;
            UIMusicImage.BackgroundImage = null;
            p.player.controls.stop();
        }

        private void UIPlayBis_Click(object sender, EventArgs e)
        {
            if (selected is Music)
            {
                SendObject(new Request(selected as Music));
            }
            else if (selected is Album)
            {
                Playlist.Clear();
                PlaylistIndex = 0;
                UIPlaylist.Items.Clear();
                foreach (var m in (selected as Album).Musics)
                {
                    Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
                SendObject(new Request(Playlist.First()));
            }
            else if (selected is Playlist)
            {
                Playlist.Clear();
                PlaylistIndex = 0;
                UIPlaylist.Items.Clear();
                foreach (var m in (selected as Playlist).musics)
                {
                    Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
                SendObject(new Request(Playlist.First()));
            }
        }

        private void UIPlay_Click(object sender, EventArgs e)
        {
            p.player.controls.play();
        }

        private void UIPause_Click(object sender, EventArgs e)
        {
            p.player.controls.pause();
        }

        private void UITrackbarMusic_Scroll(object sender, EventArgs e)
        {
            p.player.settings.volume = UITrackbarMusic.Value;
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            p.player.close();

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
                    SendObject(new Request(music));
                    break;
                case Playlist playlist:
                    Playlist.Clear();
                    PlaylistIndex = 0;
                    UIPlaylist.Items.Clear();
                    foreach (var m in (selected as Playlist).musics)
                    {
                        Playlist.Add(m);
                        UIPlaylist.Items.Add(m.Title);
                    }
                    SendObject(new Request(Playlist.First()));
                    break;
                default: throw new InvalidCastException();
            }
        }

        private readonly List<Music> Playlist = new List<Music>();
        private int PlaylistIndex;

        private void UIAddPlaylistUnder_Click(object sender, EventArgs e)
        {
            if (selected is Music)
            {
                Playlist.Add(selected as Music);
                UIPlaylist.Items.Add((selected as Music).Title);
            }
            else if (selected is Album)
            {
                foreach (var m in (selected as Album).Musics)
                {
                    Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
            }
        }

        private bool PlaylistContainsMusic(string MID)
        {
            foreach (var m in Playlist)
            {
                if (m.MID == MID)
                {
                    return true;
                }
            }
            return false;
        }

        private void UIBackward_Click(object sender, EventArgs e)
        {
            if (PlaylistIndex - 1 >= 0)
            {
                PlaylistIndex--;
                UIForward.Enabled = false;
                UIBackward.Enabled = false;
                SendObject(new Request(Playlist[PlaylistIndex]));
            }
        }

        private void UIForward_Click(object sender, EventArgs e)
        {
            if (PlaylistIndex + 1 < Playlist.Count)
            {
                PlaylistIndex++;
                UIForward.Enabled = false;
                UIBackward.Enabled = false;
                SendObject(new Request(Playlist[PlaylistIndex]));
            }
        }

        private void UIThumbup_Click(object sender, EventArgs e)
        {
            if (SearchlistboxItems[UISearchListbox.SelectedIndex] != null)
            {
                if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Music)
                {
                    SendObject(new Rate((SearchlistboxItems[UISearchListbox.SelectedIndex] as Music).MID, ElementType.Music));
                }
                if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Playlist)
                {
                    SendObject(new Rate((SearchlistboxItems[UISearchListbox.SelectedIndex] as Playlist).MID, ElementType.Playlist));
                }
            }
        }

        private void UIPathAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchlistboxItems.Count != 0)
            {
                if (!(SearchlistboxItems.First() is Author))
                {
                    SendObject(new Request(UIPathAuthor.Text, ElementType.Author));
                }
            }
        }

        void UIPathAlbum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchlistboxItems.Count != 0)
            {
                if (!(SearchlistboxItems.First() is Album))
                {
                    SendObject(new Request(UIPathAlbum.Text, ElementType.Album));
                }
            }
        }

        private void UIHomeSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Tabs.SelectedIndex = 1;
                if (UIHomeAlbum.Checked)
                {
                    SendObject(new Request(UIHomeSearchBar.Text, ElementType.Album));
                    return;
                }
                if (UIHomeArtist.Checked)
                {
                    SendObject(new Request(UIHomeSearchBar.Text, ElementType.Author));
                    return;
                }
                if (UIHomeMusic.Checked)
                {
                    SendObject(new Request(UIHomeSearchBar.Text, ElementType.Music));
                    return;
                }
                if (UIHomePlaylist.Checked)
                {
                    SendObject(new Request(UIHomeSearchBar.Text, ElementType.Playlist));
                    return;
                }
            }
        }


        private void UIPlayFavorites_Click(object sender, EventArgs e)
        {
            if (LikedMusics.Count >= 1)
            {
                Playlist.Clear();
                PlaylistIndex = 0;
                UIPlaylist.Items.Clear();
                foreach (var m in LikedMusics)
                {
                    Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
                SendObject(new Request(Playlist.First()));
                Tabs.SelectedIndex = 1;
            }
        }

        #endregion

        #region Hue

        private void UIHueConnectKey_Click(object sender, EventArgs e)
        {
            if (UIHueApi != null && UIHueIp.Text != null)
            {
                try
                {
                    UIHueConnectKey.Hide();
                    UIHueConnectRegister.Hide();
                    HueMusic.Connect(UIHueIp.Text, UIHueApi.Text);
                    if (!AsyncHelper.RunSync(() => HueMusic.client.CheckConnection()))
                    {
                        UIHueConnectKey.Show();
                        UIHueConnectRegister.Show();
                    }
                    else
                    {
                        EndConnectHue();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    UIHueConnectKey.Show();
                    UIHueConnectRegister.Show();
                }
            }
        }

        private void UIHueConnectRegister_Click(object sender, EventArgs e)
        {
            if (UIHueIp.Text != null)
            {
                try
                {
                    UIHueConnectKey.Hide();
                    UIHueConnectRegister.Hide();
                    HueMusic.ConnectRegister(UIHueIp.Text);
                    if (!AsyncHelper.RunSync(() => HueMusic.client.CheckConnection()))
                    {
                        UIHueConnectKey.Show();
                        UIHueConnectRegister.Show();
                    }
                    else
                    {
                        EndConnectHue();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    UIHueConnectKey.Show();
                    UIHueConnectRegister.Show();
                }
            }
        }

        void EndConnectHue()
        {
            ApplicationSettings.Save(new AppSettings.Settings(UIHueIp.Text, UIHueApi.Text, null));

            UIHueConnection.Text = "Connected";
            UIHueConnection.ForeColor = Color.Green;

            HueTimer.Enabled = true;
            HueTimer.Start();
        }

        private async void HueTimer_Tick(object sender, EventArgs e)
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            var scale = (int)Math.Floor(device.AudioMeterInformation.MasterPeakValue * 100);

            UISoundLevel.Value = scale;

            try
            {
                await HueMusic.TurnOnLight(new Q42.HueApi.ColorConverters.RGBColor(100, 100, 100), Convert.ToByte(10 * scale));
            }
            catch
            {
            }
        }

        #endregion Hue

        #region Account

        private void UIAccountEdit_Click(object sender, EventArgs e)
        {
            if (UIEditPassword1.Text != null && UIEditPassword1.Text == UIEditPassword2.Text)
            {
                if (UIEditName.Text == "")
                {
                    SendObject(new EditUser(Me.UID, new User(Me.Name, UIEditPassword1.Text)));
                }
                else
                {
                    SendObject(new EditUser(Me.UID, new User(UIEditName.Text, UIEditPassword1.Text)));
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
                    SendObject(new Request(new User(UISearchUser.Text)));
                }
            }
        }

        private void UIUsersResult_MouseDown(object sender, MouseEventArgs e)
        {
            if (UIUsersResult.SelectedItem != null)
            {
                UIPanelEditUser.Visible = true;

                UIAdminUser.Text = UIUsersResult.Text + " - " + UserSearchResult[UIUsersResult.SelectedIndex].Userrank.ToString();
                UIAdminUID.Text = UserSearchResult[UIUsersResult.SelectedIndex].UID;

                UIEditUserRank.Items.Clear();

                List<string> r = Enum.GetNames(typeof(Rank)).OfType<string>().ToList();
                for (int i = 0; i < (int)Me.Userrank; i++)
                {
                    UIEditUserRank.Items.Add(r[i]);
                }

                UIEditUserRank.SelectedIndex = (int)UserSearchResult[UIUsersResult.SelectedIndex].Userrank;
            }
        }

        private void UIEditUserConfirm_Click(object sender, EventArgs e)
        {
            if (UIEditUserRank.SelectedIndex != (int)UserSearchResult[UIUsersResult.SelectedIndex].Userrank && Enum.TryParse(UIEditUserRank.SelectedItem.ToString(), out Rank rank))
            {
                SendObject(new EditRequest(UserSearchResult[UIUsersResult.SelectedIndex].UID, rank));
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
                if ((int)Me.Userrank > 1 && UIEditMusicName.Text != null)
                {
                    if (selected is Music)
                    {
                        (selected as Music).Type = ElementType.Music;
                        SendObject(new EditRequest(selected, UIEditMusicName.Text, UIEditMusicGenres.Text.Split(';'), typeOfSelected));
                    }
                    else
                    {
                        SendObject(new EditRequest(selected, UIEditMusicName.Text, typeOfSelected));
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
            if (Playlist.Count != 0)
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
                SendObject(new SavePlaylist(Me.UID, new Playlist(Me, UIPlaylistName.Text, Playlist, UIPlaylistPrivate.Checked)));
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
                SendObject(new UploadMusic(new Album(music.Author, uploadForm.AlbumToSend.Name, new Music[] { music })));

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
