using System.Threading;
using System;
using System.Collections.Generic;
using Diagnostics;

namespace Guitor.Controllers
{
    class LauncherController
    {
        private static readonly object _mutex = new object();
        private static Thread _main;
        public static Action<(string log, DateTime timestamp)> OnLogAdded;

        public static void StartDebuging()
        {
            lock (_mutex)
            {
                if (_main == null)
                {
                    _main = new Thread(new ThreadStart(Debug));
                    _main.Start();
                }
            }
        }

        private static void Debug()
        {
            Log.Event += (sender, e) => OnLogAdded?.Invoke((e.Message, DateTime.Now));;
        }
    }
}
