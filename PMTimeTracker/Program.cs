using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
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
         CrashReporter CR = null;
         try
         {
            CR = new CrashReporter();

            var form1 = new TimeTracking();

            Application.Run(form1);

         }catch (Exception ex)
         {
            CR.ItsGoneWrong(ex, "PM Tracker : " + "replace this with app.version, but for now, pre-alpha");
         }

      }

   }
}
