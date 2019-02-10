using Musics___Client.API.Events;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Windows.Forms;
using Utility.Network.Tracker.Identity;
using System.Collections.Specialized;

namespace Musics___Client.UI
{
    public partial class TrackerControl : UserControl
    {
        public Dictionary<TrackerIdentity,List<ServerIdentity>> TrackersList = new Dictionary<TrackerIdentity, List<ServerIdentity>>();

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
            TrackersList.Add(ti,new List<ServerIdentity>());
            UpdateTrackerList();
        }

        public void AddServerToTracker(ServerIdentity server,TrackerIdentity trackerIdentity)
        {
            TrackersList[TrackersList.Where(x => IPEndPoint.Equals(x.Key.IPEndPoint,trackerIdentity.IPEndPoint)).FirstOrDefault().Key].Add(server);
        }

        public void RemoveServerToTracker(ServerIdentity server, TrackerIdentity trackerIdentity)
        {
            TrackersList[TrackersList.Where(x => IPEndPoint.Equals(x.Key.IPEndPoint, trackerIdentity.IPEndPoint)).FirstOrDefault().Key].Remove(server);
            UpdateServerOfTracker();
        }

        public void RemoveTrackerOfUI(TrackerIdentity ti)
        {
            TrackersList.Remove(TrackersList.Where(s => s.Key.IPEndPoint.ToString() == ti.IPEndPoint.ToString()).FirstOrDefault().Key);
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
                    UITrackers.Items.Add(ti.Key.IPEndPoint.ToString());
                }
            });
        }

        public ServerIdentity[] GetSelectedTrackerServer()
        {
            if(UITrackers.SelectedItem!=null)
                return TrackersList[TrackersList.Where(x => IPEndPoint.Equals(x.Key.IPEndPoint.ToString(), UITrackers.SelectedItem.ToString())).FirstOrDefault().Key].ToArray();
            return null;
        }

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

        public IPEndPoint ParseFromString(string ip)
        {
            string[] splittedIp = ip.Split(':');
            if (!IPAddress.TryParse(splittedIp.First(), out IPAddress iP)) return null;
            if (!int.TryParse(splittedIp[1], out int i)) return null;
            return new IPEndPoint(iP, i);
        }

        private void UITrackers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateServerOfTracker();
        }

        private void UpdateServerOfTracker()
        {
            if (UITrackers.SelectedItem == null)
                return;
            UiTrackerServer.Items.Clear();
            foreach (var si in GetSelectedTrackerServer())
                UiTrackerServer.Items.Add(si.IPEndPoint.ToString());
        }
    }
}
