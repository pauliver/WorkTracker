using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms.VisualStyles;

namespace TimeTracker
{

   public class AppSettingsManager : SettingsManager
   {

      public static int FIFTEEN_MIN = 15 * 60;
      public static int THIRTY_MIN = 30 * 60;
      public static int SIXTY_MIN = 60 * 60;
      public static int NINTY_MIN = 90 * 60;
      public static int ONETWENT_MIN = 120 * 60;


      [CategoryAttribute("Tasks"), DescriptionAttribute("lorem ipsum")]
      public IndividualSettings<List<IndividualTaskSettings>> TrackerOptionsAndDescriptions { get; set; }

      [CategoryAttribute("Time Spent"), DescriptionAttribute("lorem ipsum")]
      public IndividualSettingsDictionary<Dictionary<string, int>, string, int> UserTimeSpent { get; set; }


      public IndividualTaskSettings GetTrackerDescriptionbyTask(string task)
      {
         foreach (IndividualTaskSettings tracker in TrackerOptionsAndDescriptions.SettingsObject)
         {
            if (tracker.Task == task)
            {
               return tracker;
            }
         }
         return null;
      }
      public float[] PiePercent
      {
         get
         {
            float runningtotal = 0.0f;
            var totals = new List<float>();
            foreach (var item in TrackerOptionsAndDescriptions.SettingsObject)
            {
               if (UserTimeSpent.SettingsObject.ContainsKey(item.Task))
               {
                  int value = UserTimeSpent.SettingsObject[item.Task];
                  totals.Add(value);
                  runningtotal += value;
               }
               else
               {
                  totals.Add(0);
               }
            }
            return totals.ToArray();
         }
      }
      public Color[] PieColor
      {
         get
         {
            var colors = new List<Color>();
            foreach (var item in TrackerOptionsAndDescriptions.SettingsObject)
            {
               colors.Add(item.Color);
            }
            return colors.ToArray();
         }
      }

      public static string SaveFileFolder = "SaveFiles\\";
      public AppSettingsManager() : base()
      {
         UserTimeSpent = new IndividualSettingsDictionary<Dictionary<string, int>, string, int>(new System.IO.FileInfo(UserDataSave));
         TrackerOptionsAndDescriptions = new IndividualSettings<List<IndividualTaskSettings>>(new System.IO.FileInfo(AppConfiiguration));

         RegisterSettingsFile(UserTimeSpent);
         RegisterSettingsFile(TrackerOptionsAndDescriptions);

         Load();
      }

      public override void UpdateUserSave()
      {
         UserTimeSpent.RefreshSave();
      }

      public void LoadUserData()
      {
         UserTimeSpent.Load();
      }
      public void LoadOptions()
      {
         TrackerOptionsAndDescriptions.Load();
      }

      public override void SaveOptions()
      {
         TrackerOptionsAndDescriptions.Save();
         //don't save out the time spent
      }

      public override void UpdateTracker(string currentlytracking, int accumulated_seconds)
      {
         if (UserTimeSpent.SettingsObject.ContainsKey(currentlytracking))
         {
            UserTimeSpent.SettingsObject[currentlytracking] += accumulated_seconds;
         }
         else
         {
            UserTimeSpent.SettingsObject[currentlytracking] = accumulated_seconds;
         }
      }
   }
}



