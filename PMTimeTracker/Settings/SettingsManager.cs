using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PMTimeTracker
{
   public class SettingsManager
   {
      protected string SettingsFolder = "Settings\\";
      protected string AppSettingsFile;
      protected string AppConfiiguration;
      protected string UserDataSave;
      protected string UserConfig;
      public SettingsManager()
      {
         // In the future could load all settings files out of here
         AppSettingsFile = this.SettingsFolder + "AppSettings.json";

         // Here are the settings file swe care about today
         AppConfiiguration = this.SettingsFolder + "AppConfig.json";
         UserDataSave = this.SettingsFolder + "UserData.json";

      }

      public virtual void UpdateUserSave()
      {
      }

      public virtual void Load()
      {
      }

      public virtual void SaveOptions()
      {
      }

      public virtual void UpdateTracker(string currentlytracking, int accumulated_seconds)
      {
      }
   }
}
