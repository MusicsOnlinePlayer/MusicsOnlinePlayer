using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using TagLib;
using System.Threading;

namespace Musics___Client
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
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
            UIMusicInformation.Columns.Add("Info", 100);
            UIMusicInformation.Columns.Add("User Input",400);
        }

        private void UIMusicsBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIMusicInformation.Items.Clear();
            AddItem(UIMusicsBoxList.SelectedIndex);
        }

        private void AddItem(int Index)
        {
            var selected = FilesPath[Index];

            TagLib.File music = TagLib.File.Create(selected);

            ListViewItem[] items = new ListViewItem[4];

            items[0] = new ListViewItem(new string[] { "Name", music.Tag.Title });
            items[1] = new ListViewItem(new string[] { "Genre (space with ; )", String.Join(";", music.Tag.Genres) });
            items[2] = new ListViewItem(new string[] { "Album", music.Tag.Album });
            items[3] = new ListViewItem(new string[] { "Artist", music.Tag.FirstPerformer });

            UIMusicInformation.Items.AddRange(items);
        }
    }
}
