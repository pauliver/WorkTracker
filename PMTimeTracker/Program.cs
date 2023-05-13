using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMTimeTracker
{
   internal static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
#if (!DEBUG)

         MessageBox.Show("This is a pre-alpha release.  It is not ready for production use.  Please use at your own risk." + Environment.NewLine + Environment.NewLine + "Pie chart only works in debug" + Environment.NewLine + Environment.NewLine + "Windows doesn't handle scales other than 100% well...");
#endif
         var CR = new CrashReporter();
         try
         {
            CR.AttemptLogin();
            var icon = new NotifyIcon();
            icon.ContextMenu = new ContextMenu();

            {
               var menustrip = new MenuItem();
               menustrip.Text = "Exit";
               menustrip.Click += (s, e) => Application.Exit();
               icon.ContextMenu.MenuItems.Add(menustrip);
            }
            var form1 = new TimeTracking();
            {
               var menustrip = new MenuItem();
               menustrip.Text = "Show";
               menustrip.Click += (s, e) => form1.Show();
               icon.ContextMenu.MenuItems.Add(menustrip);
            }

            icon.Visible = true;
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form1);

         }catch (Exception ex)
         {
            CR.ItsGoneWrong(ex, "PM Tracker : " + "replace this with app.version, but for now, pre-alpha");
         }

      }

   }
}
