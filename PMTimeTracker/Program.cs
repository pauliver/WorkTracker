using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace PMTimeTracker
{
   internal static class Program
   {
      // This presumes that weeks start with Monday.
      // Week 1 is the 1st week of the year with a Thursday in it.
      public static int GetIso8601WeekOfYear(DateTime time)
      {
         // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
         // be the same week# as whatever Thursday, Friday or Saturday are,
         // and we always get those right
         DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
         if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
         {
            time = time.AddDays(3);
         }

         // Return the week of our adjusted day
         return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
      }

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

            int Week = Program.GetIso8601WeekOfYear( System.DateTime.Now );
            string UserSettings = Application.ProductName + "_" + "UserSettings" + ".json";
            string logFile = Application.ProductName + "_" + Week.ToString() + ".log";

            // initialize logging

            // move options loading to here


            var form1 = new TimeTracking();

            Application.Run(form1);

         }catch (Exception ex)
         {
            if (!CR.CleanlyLoggedIn)
               MessageBox.Show("We can log crashes if you have a GitHub PAT (Personal Access Token) and a GitHub account.  Please create an Envornment Variable named GITHUB_TOKEN with a PAT scoped to create new issues." + Environment.NewLine + Environment.NewLine + "If you don't have a GitHub account, you can create one for free at");

            CR.ItsGoneWrong(ex, "PM Tracker : " + Application.ProductVersion + "Crash : " + System.DateTime.Now.ToString());
         }

      }

   }
}
