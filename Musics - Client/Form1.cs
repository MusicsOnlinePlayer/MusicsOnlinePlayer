using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
           
        }

        public void Connect()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 2003);

            try
            {
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
                ChangeMusicPlaylist(true); 
            }
        }

        private void ChangeMusicPlaylist(bool forward)
        {
            
            try
            {
                if (forward)
                {
                    
                    SendObject(new RequestMusic(playlist[playlist.IndexOf(InPlaying) + 1]));
                    UIPlaylist.SelectedIndex++;
                }
                else
                {
                    SendObject(new RequestMusic(playlist[playlist.IndexOf(InPlaying) - 1]));
                    UIPlaylist.SelectedIndex--;
                }
            }
            catch
            {

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
            _clientSocket.BeginReceive(recbuffer, 0, recbuffer.Length, SocketFlags.None,
                    new AsyncCallback(ReceiveCallback), null);

        }

        public event EventHandler LoginInfoReceived;

        private void ReceiveCallback(IAsyncResult AR)
        {
            int ren = _clientSocket.EndReceive(AR);
            //Array.Resize(ref recbuffer, ren);



            TreatObject(Function.Deserialize(new MessageTCP(recbuffer)));

            _clientSocket.BeginReceive(recbuffer, 0, recbuffer.Length, SocketFlags.None,
                new AsyncCallback(ReceiveCallback), null);

        }

        protected virtual void OnloginInfoReceived(EventArgs e)
        {
            LoginInfoReceived?.Invoke(this, e);
        }

        private void TreatObject(object obj)
        {
            if (obj is RequestSearchAnswer)
            {
                RequestSearchAnswer searchAnswer = obj as RequestSearchAnswer;

                Invoke((MethodInvoker)delegate
                {
                    UISearchListbox.Items.Clear();

                });
                SearchlistboxItems.Clear();

                if (searchAnswer.Requested is Author)
                {
                    List<Author> authors = searchAnswer.answerList as List<Author>;
                    foreach (Author a in authors)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            UISearchListbox.Items.Add(a.Name);
                            SearchlistboxItems.Add(a);
                        });
                    }
                }
                if (searchAnswer.Requested is Album)
                {
                    List<Album> albums = searchAnswer.answerList as List<Album>;
                    foreach (Album a in albums)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            UISearchListbox.Items.Add(a.Name);
                            SearchlistboxItems.Add(a);
                        });
                    }
                }
                if (searchAnswer.Requested is Music)
                {
                    List<Music> musics = searchAnswer.answerList as List<Music>;
                    foreach (Music a in musics)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            UISearchListbox.Items.Add(a.Title);
                            SearchlistboxItems.Add(a);
                        });
                    }
                }
                Invoke((MethodInvoker)delegate
                {
                    ChangeDescription();
                });

            }
            if(obj is RequestMusicAnswer)
            {

                InPlaying = (obj as RequestMusicAnswer).Requested;
                

                Invoke((MethodInvoker)delegate
                {
                    UIPlayingMusic.Text = InPlaying.Title;
                    UIArtist.Text = InPlaying.Author.Name;
                });

                
               
                p.PlayMusic(InPlaying);

                try
                {
                    UIMusicImage.BackgroundImage = GetMetaImage(p.player.URL);
                }
                catch {
                    UIMusicImage.BackgroundImage = null;
                }

                Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        UIPlaylist.SelectedIndex = playlist.IndexOf(InPlaying);
                        UINextPlaylist.Text = playlist[playlist.IndexOf(InPlaying) + 1].Title;
                    }
                    catch
                    {
                        UINextPlaylist.Text = "No music Next";
                    }
                });


            }
            if(obj is AuthInfo)
            {
                authInfo = obj as AuthInfo;
                OnloginInfoReceived(EventArgs.Empty);
            }
            if(obj is RateReport)
            {
                RateReport temp = obj as RateReport;

                if(selected != null && selected is Music)
                {
                    if(temp.MID == (selected as Music).MID)
                    {
                        (selected as Music).Rating = temp.UpdatedRating;
                        ChangeDescription();
                    }
                }
            }

        }
        Player p = new Player();

        public AuthInfo authInfo;
        Music InPlaying;

        private List<object> SearchlistboxItems = new List<object>();


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
                _clientSocket.BeginSend(msg.Data, 0, msg.Data.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);

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
                    SendObject(new RequestSearch(UITextboxSearch.Text, new Album(null, null)));
                    return;
                }
                if (UIRadioArtist.Checked)
                {
                    SendObject(new RequestSearch(UITextboxSearch.Text, new Author(null)));
                    return;
                }
                if (UIRadioMusic.Checked)
                {
                    //MessageBox.Show("TestOk");
                    SendObject(new RequestSearch(UITextboxSearch.Text, new Music()));
                    return;
                }
            }
        }

        object selected;

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
                    UISelectedname.Text = (selected as Music).Title;
                    UIselectedartist.Text = (selected as Music).Author.Name;
                    UISelectedRating.Text = "Rating : " + (selected as Music).Rating;
                }
                if (SearchlistboxItems.First() is Album)
                {
                    selected = SearchlistboxItems[UISearchListbox.SelectedIndex] as Album;
                    UISelectedname.Text = (selected as Album).Name;
                    UIselectedartist.Text = (selected as Album).Author.Name;
                    UISelectedRating.Text = "Rating : ";

                }
                if (SearchlistboxItems.First() is Author)
                {
                    selected = SearchlistboxItems[UISearchListbox.SelectedIndex] as Author;
                    UISelectedname.Text = (selected as Author).Name;
                    UIselectedartist.Text = "";
                    UISelectedRating.Text = "Rating : ";
                }
            }
            
        }

        private void UIPlayBis_Click(object sender, EventArgs e)
        {
            if(selected is Music)
            {
                SendObject(new RequestMusic(selected as Music));
                playlist.Clear();
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

            

            foreach(var p in System.IO.Directory.GetFiles(@"c:\MusicsFiles"))
            {
                System.IO.File.Delete(p);
            }

            //_clientSocket.Close();
            
        }

        private List<Music> playlist = new List<Music>();




        private void UIBackward_Click(object sender, EventArgs e)
        {
            ChangeMusicPlaylist(false);
        }

        private void UIForward_Click(object sender, EventArgs e)
        {
            ChangeMusicPlaylist(true);
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
                if(SearchlistboxItems[UISearchListbox.SelectedIndex] is Album)
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
                if(SearchlistboxItems[UISearchListbox.SelectedIndex] is Music)
                {
                    SendObject(new RequestMusic(SearchlistboxItems[UISearchListbox.SelectedIndex] as Music));
                    playlist.Clear();
                    UIPlaylist.Items.Clear();
                }
                
            }
        }

        private void UIAddPlaylistUnder_Click(object sender, EventArgs e)
        {
            if (SearchlistboxItems[UISearchListbox.SelectedIndex] is Music)
            {
                playlist.Add(SearchlistboxItems[UISearchListbox.SelectedIndex] as Music);
                UIPlaylist.Items.Add((SearchlistboxItems[UISearchListbox.SelectedIndex] as Music).Title);
                if(playlist.Count == 1)
                {
                    SendObject(new RequestMusic(playlist.First()));
                    UIPlaylist.SelectedIndex = 0;
                }
            }
            try
            {
                UINextPlaylist.Text = playlist[playlist.IndexOf(InPlaying) + 1].Title;
            }
            catch { }
        }

        private void UIThumbup_Click(object sender, EventArgs e)
        {
            if(SearchlistboxItems[UISearchListbox.SelectedIndex] != null && SearchlistboxItems[UISearchListbox.SelectedIndex] is Music)
            {
                SendObject(new Rate((SearchlistboxItems[UISearchListbox.SelectedIndex] as Music).MID));
            }
        }

        #endregion

        #region Hue


        private void UIHueConnectKey_Click(object sender, EventArgs e)
        {
            if(UIHueApi != null && UIHueIp.Text != null)
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
            if(UIHueIp.Text != null)
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
    }
}
