using System;
using System.Diagnostics;
using System.Text;
using Updater;
using Diagnostics;

namespace Luncher
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"./ Cleaner.exe";

            Log.Console = true;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var updater = new Update();
            updater.StartMonitoring();
            Console.ReadLine();

            Process.GetCurrentProcess().Kill();
            Process.Start(path);
        }
    }
}
