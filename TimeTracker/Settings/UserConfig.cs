using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
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

      public string UserName = "";
      public bool EnahncedLogging = true;

      public float LastID = 0;
   }

}
