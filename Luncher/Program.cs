using System;
using System.Diagnostics;
using System.Text;
using Diagnostics.Update;

namespace Erebos.Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"./ Cleaner.exe";

            Log.Console = true;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var updater = new Updater();
            updater.StartMonitoring();
            Console.ReadLine();

            Process.GetCurrentProcess().Kill();
            Process.Start(path);
        }
    }
}
