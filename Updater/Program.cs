using System;
using System.Diagnostics;
using Updater;
using Diagnostics;

namespace Luncher
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Console = true;

            var updater = new Update();
            updater.CheckOnce();
            
            Console.ReadLine();

            Process.GetCurrentProcess().Kill();
        }
    }
}
