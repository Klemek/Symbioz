using Symbioz.Core;
using Symbioz.Core.Startup;
using Symbioz.ORM;
using System;
using System.Threading;

namespace Symbioz
{
    class Program
    {
        static void Main(string[] args)
        {

            Logger.OnStartup();

            Startup.Initialize();

            if (ConfigurationManager.Instance.SafeRun)
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; // Safe Run

            Startup.StartServers();

            new Thread(new ThreadStart(SymbiozCommands.HandleCommands)).Start();


        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            SaveTask.Save();
            Thread.Sleep(1000);
            Environment.Exit(1);

        }

    }
}
