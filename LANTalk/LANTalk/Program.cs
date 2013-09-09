using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;

namespace LANTalk
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (CheckProcess())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LANTalk());
            }
        }

        static bool CheckProcess()
        {
            var currentProcess = Process.GetCurrentProcess();
            if (Process.GetProcessesByName(currentProcess.ProcessName).Length > 1)
            {
                return false;
            }
            return true;
        }
    }
}
