using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if(UIFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserSelection = UIFileDialog.FileNames;
                UIInfos.Text = UserSelection.Length.ToString();
            }
        }
    }
}
