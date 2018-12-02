using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLibrary.Network
{
    public class NetworkEventArgs : EventArgs
    {
        public NetworkEventArgs(NetworkErrors networkError)
        {
            NetworkError = networkError;
        }

        public NetworkErrors NetworkError { get; set; }
    }

    public enum NetworkErrors
    {
        ServerError
    }
}
