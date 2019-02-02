using Musics___Client.API.Events;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Windows.Forms;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.UI
{
    public partial class TrackerControl : UserControl
    {
        public List<TrackerIdentity> TrackersList = new List<TrackerIdentity>();

        public event EventHandler<AddingTrackerEventArgs> UIAddTracker;

        public virtual void OnUIAddTracker(object sender, AddingTrackerEventArgs addingTrackerEventArgs)
            => UIAddTracker?.Invoke(sender, addingTrackerEventArgs);

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

        public void RemoveTrackerOfUI(TrackerIdentity ti)
        {
            TrackersList.Remove(TrackersList.Where(s => s.IPEndPoint.ToString() == ti.IPEndPoint.ToString()).FirstOrDefault());
            UpdateTrackerList();
            if (TrackersList.Count == 0)
                UpdateStatut(ConnectionState.Closed);
        }

        public void UpdateTrackerList()
        {
            Invoke((MethodInvoker)delegate
            {
                UITrackers.Items.Clear();
                foreach (var ti in TrackersList)
                {
                    UITrackers.Items.Add(ti.IPEndPoint.ToString());
                }
            });
        }

        public TrackerIdentity GetSelectedTracker()
            => TrackersList[UITrackers.SelectedIndex];

        public void UpdateStatut(ConnectionState connectionState)
        {
            Invoke((MethodInvoker)delegate
            {
                UIStatut.Text = connectionState.ToString();
            });
        }

        private void UIUpload_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(UINewtrackerIP.Text, out IPAddress iP)) { MessageBox.Show("Invalid Address"); return; }
            if (!int.TryParse(UITrackerPort.Text, out int i)) { MessageBox.Show("Invalid Port"); return; }
            OnUIAddTracker(null, new AddingTrackerEventArgs(new TrackerIdentity(new IPEndPoint(iP, i))));
        }
    }
}
