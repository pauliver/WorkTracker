using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

   }

   public class SettingsManager 
   {
      protected string SettingsFolder = "Settings\\";
      protected string AppSettingsFile;
      protected string AppConfiiguration;
      protected string UserDataSave;
      protected string UserConfig;


      protected SettingsFile UserSettingFile;

      public UserSettingsFile UserSettings
      {
         get
         {
            return (UserSettingsFile)UserSettingFile;
         }
      }

      List<SettingsFile> SettingsFiles;

      public SettingsManager()
      {
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
   }
}
