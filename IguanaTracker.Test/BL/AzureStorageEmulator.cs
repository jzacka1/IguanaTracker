using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IguanaTracker.Test.BL
{
	public class AzureStorageEmulator
	{
        public static void Start()
        {
            // check if emulator is already running
            var processes = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();
            if (processes.Any(process => process.ProcessName.Contains("DSServiceLDB")))
            {
                return;
            }

            //var command = Environment.GetEnvironmentVariable("PROGRAMFILES") + @"\Microsoft SDKs\Windows Azure\Emulator\csrun.exe";
            const string command = @"c:\Program Files\Microsoft SDKs\Windows Azure\Emulator\csrun.exe";

            using (var process = Process.Start(command, "/devstore:start"))
            {
                process.WaitForExit();
            }
        }
    }
}
