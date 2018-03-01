using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Deployment;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Diagnostics;
using System.Web;
using System.Collections.Specialized;


namespace IQPEngineLib
{

    /**************************************************************************************************************************************************
     * Module with program independent utils
     * 
     * 
     ***************************************************************************************************************************************************/
    class UtilsFunctions
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent, int maxCount)
        {
            List<IntPtr> result = new List<IntPtr>();
            int ct = 0;
            IntPtr prevChild = IntPtr.Zero;
            IntPtr currChild = IntPtr.Zero;
            while (true && ct < maxCount)
            {
                currChild = FindWindowEx(hParent, prevChild, null, null);
                if (currChild == IntPtr.Zero) break;

                result.Add(currChild);
                prevChild = currChild;

                ++ct;
            }
            return result;
        }

        private enum ShowWindowEnum
        {
            SW_HIDE = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, SW_SHOW = 5,
            SW_MINIMIZE = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            SW_RESTORE = 9, ShowDefault = 10, SW_FORCEMINIMIZE = 11
        };


        public static void BringWindowToFront(string WindowName)
        {
            BringWindowToFront(WindowName, WindowName, 0);
        }

        public static void BringWindowToFront(string ProcessName, string WindowName, int ChildIndx = 0)
        {
            IntPtr handleMainWindow = IntPtr.Zero; //parent window handler
            IntPtr handleTargetWindow = IntPtr.Zero; //target window handler

            IntPtr wdwIntPtr2 = FindWindow(null, WindowName); //main window handler
                                                              //IntPtr wdwIntPtr2 = (IntPtr) 0x216A8; - CCDC handler

            IntPtr wdwIntPtr3 = FindWindow(null, "CCD Commmander - "); //main window handler
            IntPtr wdwIntPtr4 = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, "CCD Commander");

            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName == ProcessName)
                {
                    handleMainWindow = clsProcess.MainWindowHandle;
                }
            }


            //if ChildIndx is not zero, search child windows
            if (ChildIndx > 0)
            {
                List<IntPtr> childWindowsList = GetAllChildrenWindowHandles(handleMainWindow, 100);
                if (childWindowsList.Count >= ChildIndx)
                {
                    handleTargetWindow = childWindowsList[ChildIndx - 1];
                }
                else
                {
                    handleTargetWindow = handleMainWindow;
                }
            }
            else
            {
                handleTargetWindow = handleMainWindow;
            }

            ////Get the palcement of window
            //Windowplacement placement = new Windowplacement();
            //GetWindowPlacement(handleTargetWindow, ref placement);

            //// Check if window is minimized
            //if (placement.showCmd == 2)
            //{
            //    //the window is hidden so we restore it
            //    ShowWindow(handleTargetWindow, ShowWindowEnum.SW_RESTORE);
            //}

            ShowWindow(handleMainWindow, ShowWindowEnum.SW_SHOW);  // Make the window visible if it was hidden
            ShowWindow(handleMainWindow, ShowWindowEnum.SW_RESTORE);  // Next, restore it if it was minimized
            SetForegroundWindow(handleMainWindow);  // Finally, activate the window 


            ShowWindow(handleTargetWindow, ShowWindowEnum.SW_SHOW);  // Make the window visible if it was hidden
            ShowWindow(handleTargetWindow, ShowWindowEnum.SW_RESTORE);  // Next, restore it if it was minimized
            SetForegroundWindow(handleTargetWindow);  // Finally, activate the window 

        }


        /// <summary>
        /// Send current process window to foreground using WinAPI functions
        /// </summary>
        public static void SetCurrentWindowToForeground()
        {
            Process current = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id)
                {
                    SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
        }


        /// <summary>
        /// Create URL shortcut of current run program
        /// </summary>
        /// <param name="linkName">The name of the shortcut</param>
        /// <param name="linkPath">Path where to place the shortcut</param>
        public static void CreateURLShortcut(string linkName, string linkPath)
        {
            using (StreamWriter writer = new StreamWriter(linkPath + "\\" + linkName + ".url"))
            {
                string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");

                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);

                writer.Flush();
            }
        }

        /// <summary>
        /// Convert from string to double, but check for alternative separator
        /// </summary>
        /// <param name="Val">double in string format</param>
        /// <returns>double value</returns>
        public static double ConvertToDouble(string Val)
        {
            double DblRes = double.MinValue;
            //1. Try to convert
            if (double.TryParse(Val, out DblRes))
            {
                return DblRes;
            }
            else
            {
                //2.1. Automatic decimal point correction
                char Separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                char BadSeparator = '.';

                if (Separator == '.') { BadSeparator = ','; }
                if (Separator == ',') { BadSeparator = '.'; }

                string Val_st = Val.Replace(BadSeparator, Separator);

                //2.2. Try to convert to double. 
                try
                {
                    DblRes = Convert.ToDouble(Val_st);
                }
                catch (Exception Ex)
                {
                    throw;
                }

                return DblRes;
            }
        }
        public static bool TryParseToDouble(string Val, out double DblRes)
        {
            DblRes = double.MinValue;
            //1. Try to convert
            if (double.TryParse(Val, out DblRes))
            {
                return true;
            }
            else
            {
                //2.1. Automatic decimal point correction
                char Separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                char BadSeparator = '.';

                if (Separator == '.') { BadSeparator = ','; }
                if (Separator == ',') { BadSeparator = '.'; }

                string Val_st = Val.Replace(BadSeparator, Separator);

                //2.2. Try to convert to double. 
                try
                {
                    DblRes = Convert.ToDouble(Val_st);
                    return true;
                }
                catch (Exception Ex)
                {
                    return false;
                }

                return true;
            }
        }

    }

}
