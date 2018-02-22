﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleGeolocation
{
    static class Program
    {
        private const int SW_RESTORE = 9;
        private const uint SW_RESTORE_HEX = 0x09;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, UInt32 wParam, UInt32 lParam);
        const UInt32 WM_SYSCOMMAND = 0x0112;
        const UInt32 SC_RESTORE = 0xF120;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var createdNew = true;
            using (new Mutex(true, "GoogleGeolocation", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                {
                    var current = Process.GetCurrentProcess();
                    var thisProgram = Process.GetProcessesByName(current.ProcessName);

                    foreach (Process process in thisProgram)
                    {
                        SetForegroundWindow(process.MainWindowHandle);

                        try
                        {
                            ShowWindowAsync(process.MainWindowHandle, SW_RESTORE);
                            ShowWindow(process.MainWindowHandle, SW_RESTORE_HEX);

                            ShowWindowAsync(process.Handle, SW_RESTORE);
                            ShowWindow(process.Handle, SW_RESTORE_HEX);

                            SendMessage(process.MainWindowHandle, WM_SYSCOMMAND, SC_RESTORE, 0);

                            SetForegroundWindow(process.MainWindowHandle);
                        }
                        catch 
                        {
                            break;
                        }
                    }

                    MessageBox.Show("Google Geolocation is already running", "Google Geolocation Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
