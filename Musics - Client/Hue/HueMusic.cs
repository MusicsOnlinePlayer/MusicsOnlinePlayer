using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.HSB;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;

namespace Musics___Client.Hue
{
    class HueMusic
    {
        public IBridgeLocator locator = new HttpBridgeLocator();

        public ILocalHueClient client;

        public string ApiKey;

        public List<LocatedBridge> GetBridgesSync()
        {

            try
            {
                IEnumerable<LocatedBridge> bridges = AsyncHelper.RunSync(() => locator.LocateBridgesAsync(new TimeSpan(50)));
                return bridges.ToList();
            }
            catch
            {

            }
            return null;
            
        }

        public void Connect(string BridgeIp, string ApiKey)
        {
            client = new LocalHueClient(BridgeIp);
            client.Initialize(ApiKey);
           
        }

        public void ConnectRegister(string BridgeIp)
        {
            client = new LocalHueClient(BridgeIp);
            ApiKey = AsyncHelper.RunSync(() => client.RegisterAsync("MusicsClient", "Windows"));

        }

        public async void TurnOnLight(List<string> Lights,RGBColor RgbColor,byte Brightness)
        {
            try
            {
                var command = new LightCommand();
                command.TurnOn().SetColor(RgbColor);
                command.Brightness = Brightness;
                await client.SendCommandAsync(command, Lights);
            }
            catch { }
        }
        public async void TurnOffLight(List<string> Lights)
        {
            try
            {
                var command = new LightCommand();
                command.TurnOff();
                await client.SendCommandAsync(command, Lights);
            }
            catch { }
        }
    }
    public static class AsyncHelper
    {
        private static readonly TaskFactory _taskFactory = new
            TaskFactory(CancellationToken.None,
                        TaskCreationOptions.None,
                        TaskContinuationOptions.None,
                        TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}
