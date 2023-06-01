using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using PluginArchitecture;

namespace TimeTracker
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
         AppSettingsManager asm = null;

         System.IO.FileInfo LogFile = new System.IO.FileInfo("Settings\\Crash.log");

         PluginArchitecture.PluginManager PM = new PluginManager(LogFile);

         try
         {

            // initialize logging

            // move options loading to here
            asm = new AppSettingsManager();
            bool PATSet = asm.AttemptToSetProcessGitHubPat(CrashReporter.GITHUB_TOKEN);
            if(PATSet)
            {
               CR = new CrashReporter();
            }
            else
            {
               
               string getEnv = Environment.GetEnvironmentVariable(CrashReporter.GITHUB_TOKEN);
               if (getEnv != null && getEnv != "")
               {
                  CR = new CrashReporter();
               }
            }

            PM.LoadPlugins();

            var form1 = new TimeTracking(asm, PM);

            Application.Run(form1);

         }catch (Exception ex)
         {
            Debugger.Break();
            try 
            {    
               System.IO.File.AppendAllText(LogFile.FullName, ex.ToString());
            }
            catch (Exception ex2)
            {
               Console.WriteLine(ex2.Message);
            }
            Console.WriteLine(ex.Message);
            
            if (!CR.CleanlyLoggedIn)
            {
               MessageBox.Show("We can log crashes if you have a GitHub PAT (Personal Access Token) and a GitHub account.  Please create an Envornment Variable named GITHUB_TOKEN with a PAT scoped to create new issues." + Environment.NewLine + Environment.NewLine + "If you don't have a GitHub account, you can create one for free at");

               CR.ItsGoneWrong(ex, "PM Tracker : " + Application.ProductVersion + "Crash : " + System.DateTime.Now.ToString());
            }
            else
            {
               Debug.Write(ex);
               Debug.Write("PM Tracker : " + Application.ProductVersion + "Crash : " + System.DateTime.Now.ToString());
            }
         }
         asm.UpdateUserSave();

      }

   }
}
