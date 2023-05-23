using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PMTimeTracker
{
   public class UserSettingsFile
   {
      public string GitHubPAT;
      public string GitHubUser;
      public string GitHubRepo;
      public bool WeeklySaveFiles = true;
      public bool SaveImagesOnExit = false;

      public string AppSettings = "AppSettings.json";
      public string AppConfiguration = "AppConfig.json";
      public string UserSettings = "UserSettings.json";
      public string UserDataStorage = "UserData.json";

      public bool UseWeeklySaves = false;
      public string WeeklySaveFolder = "WeeklySaves\\";
      public bool UseAlternativeBacgkround = false;
      public string AlternativeBackgroundFile = "background.jpg";
      public bool UseAlternativeSize = false;
      public int Height = 1024;
      public int Width = 768;

   }

   // This presumes that weeks start with Monday.
   // Week 1 is the 1st week of the year with a Thursday in it.

   public class SettingsManager 
   {
      protected string SettingsFolder = "Settings\\";
      protected string AppSettingsFile;
      protected string AppConfiiguration;
      protected string UserDataSave;
      protected string UserConfig;

      public int Week;

      protected SettingsFile UserSettingFile;

      public UserSettingsFile UserSettings
      {
         get
         {
            return (UserSettingsFile)UserSettingFile.SettingsObjectAsObject;
         }
      }

      List<SettingsFile> SettingsFiles;

      public SettingsManager()
      {
         Week = GetIso8601WeekOfYear(System.DateTime.Now);
         // In the future could load all settings files out of here
         AppSettingsFile = this.SettingsFolder + "AppSettings.json";

         // Here are the settings file swe care about today
         AppConfiiguration = this.SettingsFolder + "AppConfig.json";
         UserDataSave = this.SettingsFolder + "UserData.json";

         UserConfig = this.SettingsFolder + "UserConfig.json";

         SettingsFiles = new List<SettingsFile>();

         UserSettingFile = new IndividualSettings<UserSettingsFile>(new System.IO.FileInfo(UserConfig));
         UserSettingFile.Load();
         RegisterSettingsFile(UserSettingFile);

      }

      protected void RegisterSettingsFile(SettingsFile newSettings)
      {
         SettingsFiles.Add(newSettings);
      }

      protected void RemoveSettingsFile(SettingsFile oldSettings)
      {
         if (!SettingsFiles.Contains(oldSettings))
            Debugger.Break();
            
          SettingsFiles.Remove(oldSettings);
      }

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

      public virtual void UpdateUserSave()
      {
      }

      public virtual void Load()
      {
         foreach(var temp in SettingsFiles)
         {
            temp.Load();
         }
      }

      public virtual void SaveOptions()
      {
      }

      public virtual void UpdateTracker(string currentlytracking, int accumulated_seconds)
      {
      }

      internal void SetLocalProcessVariable(string EnvVariable, string value)
      {
         System.Environment.SetEnvironmentVariable(EnvVariable, value, EnvironmentVariableTarget.Process);
      }
      public bool AttemptToSetProcessGitHubPat(string EnvVariable) //,string SettingsLookup)
      {
         if(this.UserSettings.GitHubPAT != null && this.UserSettings.GitHubPAT != "")
         {
            SetLocalProcessVariable(EnvVariable, this.UserSettings.GitHubPAT);
            return true;
         }
         else
         {
            return false;
         }
      }
   }
}

