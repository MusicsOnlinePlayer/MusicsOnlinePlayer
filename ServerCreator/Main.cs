using System;
using System.IO;
using System.Windows.Forms;

namespace ServerCreator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private string[] UserSelection;

        private void UIButtonSelectFile_Click(object sender, EventArgs e)
        {
            if (UIFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserSelection = UIFileDialog.FileNames;
                UIInfos.Text = UserSelection.Length.ToString();
            }
        }

        private void UIExplore_Click(object sender, EventArgs e)
        {
            if (UserSelection.Length < 1)
            {
                MessageBox.Show("You must select at least onemusics !");
                return;
            }
            if (UIFolderPath.ShowDialog() == DialogResult.OK)
            {
                UIPath.Text = UIFolderPath.SelectedPath;
            }
        }

        private void UIFinnish_Click(object sender, EventArgs e)
        {
            if (UserSelection.Length < 1)
            {
                MessageBox.Show("You must select at least onemusics !");
                return;
            }
            if(UIPath.Text == null)
            {
                MessageBox.Show("You must select a destination path");
                return;
            }
            UIProgress.Maximum = UserSelection.Length;
            UIProgress.Value = 0;
            try
            {
                foreach(var s in UserSelection)
                {
                    TagLib.File tmpTag = TagLib.File.Create(s);
                    if (!Directory.Exists(Path.Combine(UIPath.Text, tmpTag.Tag.FirstPerformer))){
                        Directory.CreateDirectory(Path.Combine(UIPath.Text, tmpTag.Tag.FirstPerformer));
                    }
                    if (!Directory.Exists(Path.Combine(new string[] { UIPath.Text , tmpTag.Tag.FirstPerformer, tmpTag.Tag.Album })))
                    {
                        Directory.CreateDirectory(Path.Combine(new string[] { UIPath.Text, tmpTag.Tag.FirstPerformer, tmpTag.Tag.Album }));
                    }
                    string title = string.Join("_", tmpTag.Tag.Title.Split(Path.GetInvalidFileNameChars()));
                    File.Copy(s, Path.Combine(new string[] { UIPath.Text, tmpTag.Tag.FirstPerformer, tmpTag.Tag.Album ,title}) + Path.GetExtension(s), true);
                    UIProgress.Value++;
                }
                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
                throw ex;
            }
        }
    }
}
