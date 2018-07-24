using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using TagLib;
using Utility;
using Musics___Client.Hue;
using NAudio.CoreAudioApi;

namespace Musics___Client
{

    public partial class Client : Form
    {
        public Socket _clientSocket;
        public User Me;
        public IPAddress ip = IPAddress.Loopback;

        private HueMusic HueMusic = new HueMusic();

        public Client()
        {
            InitializeComponent();


        }

        private void Client_Load(object sender, EventArgs e)
        {
            //recevoir.Start();
            recevoir.Abort();
            recevoir = new Thread(new ThreadStart(Receive));
            recevoir.Start();

            UIAccountName.Text = Me.Name;
            UIAccountId.Text = Me.UID;
            this.Text = "Musics - Client  Connected as " + Me.Name + " - Rank : " + authInfo.rankofAuthUser.ToString();
            UIRank.Text = authInfo.rankofAuthUser.ToString();

            try
            {
                if (Properties.Settings.Default.HueKey != null && Properties.Settings.Default.HueIp != null)
                {
                    UIHueApi.Text = Properties.Settings.Default.HueKey;
                    UIHueIp.Text = Properties.Settings.Default.HueIp;
                }
            }
            catch { }

            SendObject(new Request(Me.UID));

        }


        public void Connect()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIp), 2003);
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

        
        #region PlayerSearch
        private void Player_PlayStateChange(int NewState)
        {
            if(NewState == 8)
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
                int ren = _clientSocket.EndReceive(AR);
               // Array.Resize(ref recbuffer, ren + 1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            


            TreatObject(Function.Deserialize(new MessageTCP(recbuffer)));

            recbuffer = new byte[100000000];

            _clientSocket.BeginReceive(recbuffer, 0, recbuffer.Length, SocketFlags.Partial,
                new AsyncCallback(ReceiveCallback), null);

        }

        protected virtual void OnloginInfoReceived(EventArgs e)
        {
            LoginInfoReceived?.Invoke(this, e);
        }

        private void TreatObject(object obj)
        {
            if (obj is RequestAnswer)
            {
                RequestAnswer searchAnswer = obj as RequestAnswer;

                if (searchAnswer.requestsTypes == RequestsTypes.Search)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        UISearchListbox.Items.Clear();

                    });
                    SearchlistboxItems.Clear();

                    if (searchAnswer.Requested == Element.Author)
                    {
                        List<Author> authors = searchAnswer.AnswerList as List<Author>;
                        foreach (Author a in authors)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UISearchListbox.Items.Add(a.Name);
                                SearchlistboxItems.Add(a);
                            });
                        }
                    }
                    if (searchAnswer.Requested == Element.Album)
                    {
                        List<Album> albums = searchAnswer.AnswerList as List<Album>;
                        foreach (Album a in albums)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UISearchListbox.Items.Add(a.Name);
                                SearchlistboxItems.Add(a);
                            });
                        }
                    }
                    if (searchAnswer.Requested == Element.Music)
                    {
                        List<Music> musics = searchAnswer.AnswerList as List<Music>;
                        foreach (Music a in musics)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UISearchListbox.Items.Add(a.Title);
                                SearchlistboxItems.Add(a);
                            });
                        }
                    }
                    if(searchAnswer.Requested == Element.Playlist)
                    {
                        List<Playlist> playlists = searchAnswer.AnswerList as List<Playlist>;
                        foreach (Playlist a in playlists)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UISearchListbox.Items.Add(a.Name);
                                SearchlistboxItems.Add(a);
                            });
                        }
                    }
                    Invoke((MethodInvoker)delegate
                    {
                        ChangeDescription();
                    });
                }
                if (searchAnswer.requestsTypes == RequestsTypes.MusicsBinaries)
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
                            Music m = new Music()
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
                    });

                    

                    p.PlayMusic(InPlaying);



                    try
                    {
                        UIMusicImage.BackgroundImage = GetMetaImage(p.player.URL);
                    }
                    catch
                    {
                        UIMusicImage.BackgroundImage = null;
                    }


                }
                if (searchAnswer.requestsTypes == RequestsTypes.Favorites)
                {
                    UILikedMusicsList.Items.Clear();
                    LikedMusics.Clear();
                    foreach (var m in searchAnswer.Favorites)
                    {
                        UILikedMusicsList.Items.Add(m.Title);
                        LikedMusics.Add(m);
                    }
                }
                if (searchAnswer.requestsTypes == RequestsTypes.Users)
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
            }
            if (obj is AuthInfo)
            {
                authInfo = obj as AuthInfo;
                OnloginInfoReceived(EventArgs.Empty);
            }
            if (obj is RateReport)
            {
                RateReport temp = obj as RateReport;

                if (selected != null && selected is Music)
                {
                    if (temp.MID == (selected as Music).MID)
                    {
                        (selected as Music).Rating = temp.UpdatedRating;
                        ChangeDescription();
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
                        this.Text = "Musics - Client  Connected as " + Me.Name + " - Rank : " + Me.rank.ToString();
                        UIRank.Text = Me.rank.ToString();
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

        }
        Player p = new Player();

        public AuthInfo authInfo;
        Music InPlaying;

        private List<object> SearchlistboxItems = new List<object>();
        private List<Music> LikedMusics = new List<Music>();

        public static Image GetMetaImage(string MusicPath)
        {
            TagLib.File f = new TagLib.Mpeg.AudioFile(MusicPath);

            TagLib.IPicture pic = f.Tag.Pictures[0];
            using (MemoryStream ms = new MemoryStream(pic.Data.Data))
            {
                Image image = Image.FromStream(ms);
                return image;
            }


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
            _clientSocket.EndSend(ar);
        }

        private void UITextboxSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (UIRadioAlbum.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, Element.Album));
                    return;
                }
                if (UIRadioArtist.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, Element.Author));
                    return;
                }
                if (UIRadioMusic.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, Element.Music));
                    return;
                }
                if (UIRadioPlaylist.Checked)
                {
                    SendObject(new Request(UITextboxSearch.Text, Element.Playlist));
                }
            }
        }

        object selected;
        Element typeOfSelected;

        private void UISearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Invoke((MethodInvoker)delegate
            {
                ChangeDescription();
            });


        }
        private void ChangeDescription()
        {
            if (UISearchListbox.SelectedItem != null)
            {
                if (SearchlistboxItems.First() is Music)
                {
                    selected = SearchlistboxItems[UISearchListbox.SelectedIndex] as Music;
                    typeOfSelected = Element.Music;
                    UISelectedname.Text = (selected as Music).Title;
                    UIselectedartist.Text = (selected as Music).Author.Name;
                    UISelectedRating.Text = "Rating : " + (selected as Music).Rating;

                    UIPathAuthor.Text = (selected as Music).Author.Name;
                    UIPathAlbum.Text = (selected as Music).Album.Name;
                    UIPathMusic.Text = (selected as Music).Title;
                }

                if (SearchlistboxItems.First() is Album)
                {
                    selected = SearchlistboxItems[UISearchListbox.SelectedIndex] as Album;
                    typeOfSelected = Element.Album;
                    UISelectedname.Text = (selected as Album).Name;
                    UIselectedartist.Text = (selected as Album).Author.Name;
                    UISelectedRating.Text = "Rating : ";


                    UIPathAuthor.Text = (selected as Album).Author.Name;
                    UIPathAlbum.Text = (selected as Album).Name;
                    UIPathMusic.Text = "";

                }
                if (SearchlistboxItems.First() is Author)
                {
                    typeOfSelected = Element.Author;
                    selected = SearchlistboxItems[UISearchListbox.SelectedIndex] as Author;
                    UISelectedname.Text = (selected as Author).Name;
                    UIselectedartist.Text = "";
                    UISelectedRating.Text = "Rating : ";

                    UIPathAuthor.Text = (selected as Author).Name;
                    UIPathAlbum.Text = "";
                    UIPathMusic.Text = "";
                }
                if(SearchlistboxItems.First() is Playlist)
                {
                    typeOfSelected = Element.Playlist;
                    selected = SearchlistboxItems[UISearchListbox.SelectedIndex] as Utility.Playlist;
                    UISelectedname.Text = (selected as Playlist).Name;
                    UIselectedartist.Text = (selected as Playlist).Creator.Name;
                    UIPathAuthor.Text = "";
                    UIPathAlbum.Text = "";
                    UIPathMusic.Text = "";

                    Playlist.Clear();
                    PlaylistIndex = 0;
                    UIPlaylist.Items.Clear();
                    foreach (var m in (selected as Playlist).musics)
                    {
                        Playlist.Add(m);
                        UIPlaylist.Items.Add(m.Title);
                    }

                }
            }

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
            else if(selected is Playlist)
            {
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

            _clientSocket.Disconnect(false);
            _clientSocket.Dispose();

        }



        private void UISearchListbox_DoubleClick(object sender, EventArgs e)
        {
            if (UISearchListbox.SelectedItem != null)
            {
                if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Author)
                {
                    Author tmp = SearchlistboxItems[UISearchListbox.SelectedIndex] as Author;

                    UISearchListbox.Items.Clear();
                    SearchlistboxItems.Clear();

                    foreach (var m in tmp.albums)
                    {
                        UISearchListbox.Items.Add(m.Name);
                        SearchlistboxItems.Add(m);
                    }
                    return;
                }
                if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Album)
                {
                    Album tmp = SearchlistboxItems[UISearchListbox.SelectedIndex] as Album;

                    if (tmp.Musics != null)
                    {
                        UISearchListbox.Items.Clear();
                        SearchlistboxItems.Clear();

                        foreach (var m in tmp.Musics)
                        {
                            UISearchListbox.Items.Add(m.Title);
                            SearchlistboxItems.Add(m);
                        }
                        return;
                    }
                }
                if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Music)
                {
                    SendObject(new Request(SearchlistboxItems[UISearchListbox.SelectedIndex] as Music));
;
                }
                if(SearchlistboxItems[UISearchListbox.SelectedIndex] is Playlist)
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
        }

        private List<Music> Playlist = new List<Music>();
        private int PlaylistIndex = 0;

        private void UIAddPlaylistUnder_Click(object sender, EventArgs e)
        {
            if(selected is Music)
            {
                Playlist.Add(selected as Music);
                UIPlaylist.Items.Add((selected as Music).Title);
            }
            else if (selected is Album)
            {
                foreach(var m in (selected as Album).Musics)
                {
                    Playlist.Add(m);
                    UIPlaylist.Items.Add(m.Title);
                }
            }
        }

        private bool PlaylistContainsMusic(string MID)
        {
            foreach(var m in Playlist)
            {
                if(m.MID == MID)
                {
                    return true;
                }
            }
            return false;
        }

        private void UIBackward_Click(object sender, EventArgs e)
        {
            if(PlaylistIndex - 1 >= 0)
            {
                PlaylistIndex--;
                SendObject(new Request(Playlist[PlaylistIndex]));
            }
        }

        private void UIForward_Click(object sender, EventArgs e)
        {
            if (PlaylistIndex + 1 < Playlist.Count)
            {
                PlaylistIndex++;
                SendObject(new Request(Playlist[PlaylistIndex]));
            }
        }

        private void UIThumbup_Click(object sender, EventArgs e)
        {
            if (SearchlistboxItems[UISearchListbox.SelectedIndex] != null && SearchlistboxItems[UISearchListbox.SelectedIndex] is Music)
            {
                SendObject(new Rate((SearchlistboxItems[UISearchListbox.SelectedIndex] as Music).MID));
            }
        }

        private void UIPathAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(SearchlistboxItems.Count != 0)
            {
                if (!(SearchlistboxItems.First() is Author))
                {
                    SendObject(new Request(UIPathAuthor.Text, Element.Author));
                }
            }
            
        }

        private void UIPathAlbum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchlistboxItems.Count != 0)
            {
                if (!(SearchlistboxItems.First() is Album))
                {
                    SendObject(new Request(UIPathAlbum.Text, Element.Album));
                }
            }
        }

        private void UILikedMusicsList_DoubleClick(object sender, EventArgs e)
        {
            if (UILikedMusicsList.SelectedItem != null)
            {
                Tabs.SelectedIndex = 1;
                SendObject(new Request(LikedMusics[UILikedMusicsList.SelectedIndex].Title, Element.Music));
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
                        Properties.Settings.Default.HueKey = UIHueApi.Text;
                        Properties.Settings.Default.HueIp = UIHueIp.Text;
                        Properties.Settings.Default.Save();



                        UIHueConnection.Text = "Connected";
                        UIHueConnection.ForeColor = Color.Green;

                        HueTimer.Enabled = true;
                        HueTimer.Start();
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
                        Properties.Settings.Default.HueKey = HueMusic.ApiKey;
                        UIHueApi.Text = HueMusic.ApiKey;
                        Properties.Settings.Default.HueIp = UIHueIp.Text;
                        Properties.Settings.Default.Save();



                        UIHueConnection.Text = "Connected";
                        UIHueConnection.ForeColor = Color.Green;

                        HueTimer.Enabled = true;
                        HueTimer.Start();
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

        private void HueTimer_Tick(object sender, EventArgs e)
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            var scale = (int)Math.Floor(device.AudioMeterInformation.MasterPeakValue * 100);

            UISoundLevel.Value = scale;

            try
            {
                HueMusic.TurnOnLight(new Q42.HueApi.ColorConverters.RGBColor(100, 100, 100), Convert.ToByte(10 * scale));
            }
            catch { }
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

        List<User> UserSearchResult = new List<User>();

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

                UIAdminUser.Text = UIUsersResult.Text + " - " + UserSearchResult[UIUsersResult.SelectedIndex].rank.ToString();
                UIAdminUID.Text = UserSearchResult[UIUsersResult.SelectedIndex].UID;

                UIEditUserRank.Items.Clear();

                List<string> r = Enum.GetNames(typeof(Rank)).OfType<string>().ToList();
                for (int i = 0; i < (int)Me.rank; i++)
                {
                    UIEditUserRank.Items.Add(r[i]);
                }

                UIEditUserRank.SelectedIndex = (int)UserSearchResult[UIUsersResult.SelectedIndex].rank;
            }
        }



        private void UIEditUserConfirm_Click(object sender, EventArgs e)
        {

            if (UIEditUserRank.SelectedIndex != (int)UserSearchResult[UIUsersResult.SelectedIndex].rank && Enum.TryParse(UIEditUserRank.SelectedItem.ToString(), out Rank rank))
            {

                SendObject(new EditRequest(UserSearchResult[UIUsersResult.SelectedIndex].UID, rank));
            }
        }

        #endregion

        #region EditMusic

        private void UIEditMusic_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                UIEditMusicName.Visible = true;
                UIEditMusicName.Text = UISelectedname.Text;
            }
        }

        private void UIEditMusicName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((int)Me.rank > 1 && UIEditMusicName.Text != null)
                {
                    SendObject(new EditRequest(selected,UIEditMusicName.Text,typeOfSelected));
                    UIEditMusicName.Visible = false;
                }
            }

        }

        #endregion

        #region Playlist

        private void UISavePlaylist_Click(object sender, EventArgs e)
        {
            if(Playlist.Count != 0)
            {
                UIEditPlaylist.Visible = true;
                UIPlaylistName.Visible = true;
            }
        }

        

        private void UIPlaylistName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendObject(new SavePlaylist(Me.UID, new Playlist(Me,UIPlaylistName.Text, Playlist,UIPlaylistPrivate.Checked)));
            }
         
        }

        #endregion
    }
}
