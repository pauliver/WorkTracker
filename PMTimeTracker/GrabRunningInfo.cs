using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#if ATTEMPING_WINDOW_DETECTION
using System.Diagnostics;
using System.Runtime.InteropServices;
#endif

namespace PMTimeTracker
{


   public class GrabRunningInfo
   {
#if ATTEMPING_WINDOW_DETECTION
      [DllImport("user32.dll")]
      static extern IntPtr GetForegroundWindow();
      [DllImport("user32.dll")]
      static extern int GetWindowText(IntPtr hwnd, StringBuilder ss, int count);

      [DllImport("user32.dll")]
      public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

      async public static Task<string> GetActiveWindowTitle()
      {
         try
         {
            StringBuilder sbBufferText = new StringBuilder(255);
            GetWindowText(GetForegroundWindow(), sbBufferText, sbBufferText.Capacity);
            return sbBufferText.ToString();
         }catch (Exception ex)
         {
            return "No Window : " + ex.Message;
         }
      }
      async public static ValueTask<string> GetActiveWindowAppName()
      {
         try
         {
            IntPtr hWnd = GetForegroundWindow();
            uint procId = 0;
            GetWindowThreadProcessId(hWnd, out procId);
            var proc = Process.GetProcessById((int)procId);
            return proc.MainModule.FileVersionInfo.ProductName;
         }
         catch (Exception ex)
         {
            return "No AppName : " + ex.Message;
         }
      }
#endif
   }
}
