//using System.Threading;
//using System;
//using Diagnostics;

//namespace Guitor.Controllers
//{
//    class LauncherController
//    {
//        private static readonly object _mutex = new object();
//        private static Thread _main;
//        public static Action<(string log, DateTime timestamp)> OnLogAdded;
//        private static readonly Update updater = new Update();

//        public static void StartChecking()
//        {
//            lock (_mutex)
//            {
//                if (_main == null)
//                {
//                    _main = new Thread(new ThreadStart(Debug));
//                    _main.Start();
//                }
//            }
//        }

//        private static void Debug()
//        {
//            Log.Event += (sender, e) => OnLogAdded?.Invoke((e.Message, DateTime.Now));
//            updater.CheckOnce();
//        }
//    }
//}
