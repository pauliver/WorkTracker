using System;
using System.Collections.Generic;
using System.Linq;
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

         //Application.EnableVisualStyles();
         //Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(form1);

         icon.Visible = true;

      }

   }
}
