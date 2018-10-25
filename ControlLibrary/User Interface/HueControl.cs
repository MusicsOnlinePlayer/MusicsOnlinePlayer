using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Q42.HueApi;
using ControlLibrary.Hue;
using NAudio.CoreAudioApi;
using ControlLibrary.AppSettings;
using Utility.Network;

namespace ControlLibrary.User_Interface
{
    public partial class HueControl : UserControl
    {
        private readonly HueMusic HueMusic = new HueMusic();

        private List<Light> LightHue = new List<Light>();

        public HueControl()
        {
            InitializeComponent();

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
        }

        private void UIHueConnectKey_Click(object sender, EventArgs e)
        {
            if (UIHueApi != null && UIHueIp.Text != null)
            {
                try
                {
                    UIHueConnectKey.Hide();
                    UIHueConnectRegister.Hide();
                    ConnectHue();
                    ShowLights();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    UIHueConnectKey.Show();
                    UIHueConnectRegister.Show();
                }
            }
        }

        private void ConnectHue()
        {
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

        private void UIHueConnectRegister_Click(object sender, EventArgs e)
        {
            if (UIHueIp.Text != null)
            {
                try
                {
                    UIHueConnectKey.Hide();
                    UIHueConnectRegister.Hide();
                    ConnectHue();
                    ShowLights();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    UIHueConnectKey.Show();
                    UIHueConnectRegister.Show();
                }
            }
        }

        private void ConnectRegisterHue()
        {
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

        private void ShowLights()
        {
            foreach (var l in HueMusic.GetLights())
            {
                UILightList.Items.Add(l.Name + "(" + l.Id + ")", false);
                LightHue.Add(l);
            }
        }

        private void UIHueDelay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(UIHueDelay.Text, out int delay))
                {
                    HueTimer.Interval = delay;
                }
                else
                {
                    UIHueDelay.Text = HueTimer.Interval.ToString();
                }
            }
        }

        void EndConnectHue()
        {
            ApplicationSettings.Save(new AppSettings.Settings(UIHueIp.Text, UIHueApi.Text, null));

            UILightList.Items.Clear();
            LightHue.Clear();

            UIHueConnection.Text = "Connected";
            UIHueConnection.ForeColor = Color.Green;

            SetupHueTimer();
        }

        private void SetupHueTimer()
        {
            Device = MDeviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

            HueTimer.Enabled = true;
            HueTimer.Start();
        }

        MMDeviceEnumerator MDeviceEnumerator = new MMDeviceEnumerator();
        MMDevice Device;

        private async void HueTimer_Tick(object sender, EventArgs e)
        {
            var scale = Function.Map(Device.AudioMeterInformation.MasterPeakValue, 0, 1, 0, 100);

            UISoundLevel.Value = (int)scale;

            List<string> LightsNames = new List<string>();

            GetSelectedLights(LightsNames);

            try
            {
                await HueMusic.TurnOnLight(new Q42.HueApi.ColorConverters.RGBColor(100, 100, 100), Convert.ToByte(2.5 * scale), LightsNames);
            }
            catch
            {
            }
        }

        private void GetSelectedLights(List<string> LightsNames)
        {
            foreach (int s in UILightList.CheckedIndices)
            {
                LightsNames.Add(LightHue[s].Id);
            }
        }
    }
}
