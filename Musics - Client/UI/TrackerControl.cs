using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.UI
{
    public partial class TrackerControl : UserControl
    {
        public List<TrackerIdentity> TrackersList = new List<TrackerIdentity>();

        public TrackerControl()
        {
            InitializeComponent();
        }

        private void TrackerControl_Load(object sender, EventArgs e)
        {

        }

        public void AddTrackerToUI(TrackerIdentity ti)
        {
            TrackersList.Add(ti);
            UpdateTrackerList();
        }

        public void UpdateTrackerList()
        {
            UITrackers.Items.Clear();
            foreach(var ti in TrackersList)
            {
                UITrackers.Items.Add(ti.IPEndPoint.ToString());
            }
        }

        public TrackerIdentity GetSelectedTracker()
            => TrackersList[UITrackers.SelectedIndex];

        public void UpdateStatut(ConnectionState connectionState)
        {

        }
    }
}
