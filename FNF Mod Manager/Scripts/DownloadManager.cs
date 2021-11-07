using System;
using System.Linq;
using Windows;

namespace Scripts
{
    class DownloadManager
    {
        ModShop shop = new ModShop();
        public void CheckForDownload()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("-download"))
            {
                var daproto = new ProtocolHandlers().ParseProtocol(args[2]);
            }
            else
            {
                new ProtocolHandlers().MakeProtocol();
            }
        }
    }
}
