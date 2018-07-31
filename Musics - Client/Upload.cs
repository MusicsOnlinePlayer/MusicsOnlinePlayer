using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using TagLib;
using System.Threading;
using Utility;

namespace Musics___Client
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
            UIMusicInformation.View = View.Details;
            UIMusicInformation.Columns.Add("Info",-2,HorizontalAlignment.Left);
            UIMusicInformation.Columns.Add("User Input", -2, HorizontalAlignment.Left);
            UIMusicInformation.GridLines = true;
        }

        string[] FilesPath;

        private void UIUploadButton_Click(object sender, EventArgs e)
        {
            Thread threadGetFile = new Thread(new ThreadStart(GetMusics));
            threadGetFile.SetApartmentState(ApartmentState.STA);
            threadGetFile.Start();
        }

        private void GetMusics()
        {
            OpenFileDialog openFileDialogMusic = new OpenFileDialog
            {
                Multiselect = true
            };

            if (openFileDialogMusic.ShowDialog() == DialogResult.OK)
            {
                FilesPath = openFileDialogMusic.FileNames;
                Invoke((MethodInvoker)delegate
                {
                    UIMusicsBoxList.Items.Clear();
                    UIMusicsBoxList.Items.AddRange((from file in FilesPath let name = Path.GetFileName(file) select name).ToArray());
                });
            }
        }

        private void Upload_Load(object sender, EventArgs e)
        {
        }

        private void UIMusicsBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIMusicInformation.Items.Clear();
            AddItem(UIMusicsBoxList.SelectedIndex);
        }

        TagLib.File music;
        private void AddItem(int Index)
        {
            var selected = FilesPath[Index];
            music = TagLib.File.Create(selected);

            ListViewItem[] items = new ListViewItem[4];

            items[0] = new ListViewItem(new string[] { "Name", music.Tag.Title });
            items[1] = new ListViewItem(new string[] { "Genre", String.Join(";", music.Tag.Genres) });
            items[2] = new ListViewItem(new string[] { "Album", music.Tag.Album });
            items[3] = new ListViewItem(new string[] { "Artist", music.Tag.FirstPerformer });

            UIMusicInformation.Items.AddRange(items);
        }

        private void UIMusicInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UIUserEntry.Text = UIMusicInformation.SelectedItems[0].SubItems[1].Text;
              
            }
            catch
            {
            }
        }

        private void UIUserEnter_Click(object sender, EventArgs e)
        {
            try
            {
                UIMusicInformation.SelectedItems[0].SubItems[1].Text = UIUserEntry.Text;
                switch (UIMusicInformation.SelectedItems[0].Index)
                {
                    case 0:
                        music.Tag.Title = UIUserEntry.Text;
                        break;
                    case 1:
                        music.Tag.Genres = UIUserEnter.Text.Split(';');
                        break;
                    case 2:
                        music.Tag.Album = UIUserEntry.Text;
                        break;
                    case 3:
                        music.Tag.Performers[0] = UIUserEntry.Text;
                        break;
                }
                music.Save();
            }
            catch
            {
            }      
        }

        public Album AlbumToSend;
        public bool IsUploadValid = false;

        private void UISubmit_Click(object sender, EventArgs e)
        {
            AlbumToSend  = new Album(music.Tag.Album);

            foreach(var p in FilesPath)
            {
                var tmpFile = TagLib.File.Create(p);
                Music MusicUpload = new Music(tmpFile.Tag.Title, new Author(tmpFile.Tag.Performers[0]), System.IO.File.ReadAllBytes(p));
                AlbumToSend.Add(MusicUpload);
            }

            IsUploadValid = true;

            this.Close();
        }
    }
}
