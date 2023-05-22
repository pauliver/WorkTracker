using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms.VisualStyles;

namespace PMTimeTracker
{

   public class AppSettingsManager : SettingsManager
   {

      [CategoryAttribute("Tasks"), DescriptionAttribute("lorem ipsum")]
      public List<IndividualTaskSettings> TrackerDescriptions { get; set; }

      public IndividualTaskSettings GetTrackerDescriptionbyTask(string task)
      {
         foreach (IndividualTaskSettings tracker in TrackerDescriptions)
         {
            if (tracker.Task == task)
            {
               return tracker;
            }
         }
         return null;
      }


      [CategoryAttribute("Time Spent"), DescriptionAttribute("lorem ipsum")]
      public Dictionary<string, int> TimeSpent { get; set; }

      public float[] PiePercent
      {
         get
         {
            float runningtotal = 0.0f;
            var totals = new List<float>();
            foreach (var item in TrackerDescriptions)
            {
               if (TimeSpent.ContainsKey(item.Task))
               {
                  int value = TimeSpent[item.Task];
                  totals.Add(value);
                  runningtotal += value;
               }
               else
               {
                  totals.Add(0);
               }
            }
            return totals.ToArray();
            /*
            int newtotal = 0;
            float tempval = (float) runningtotal / 100.0f;
            for (int x = 0; x < totals.Count; x++)
            {
               try
               {
                  totals[x] = (int)((float)totals[x] / tempval);
                  newtotal += totals[x];
               }
               catch (Exception ex)
               {
                  Console.WriteLine(ex.Message);
               }
            }
            if (newtotal != 100)
            {
               // yeah, could be off by a bit due to rounding
            }
            return totals.ToArray();
            */
         }
      }


      public Color[] PieColor
      {
         get
         {
            var colors = new List<Color>();
            foreach (var item in TrackerDescriptions)
            {
               colors.Add(item.Color);
            }
            return colors.ToArray();
         }
      }


      string optionsfilename = "config.json";
      string savedtimefile = "user.json";

      public AppSettingsManager():base()
      {
         optionsfilename = this.SettingsFolder + "config.json";
         savedtimefile = this.SettingsFolder + "user.json";

         TrackerDescriptions = new List<IndividualTaskSettings>();
         TimeSpent = new Dictionary<string, int>();
         LoadOptions();
      }

      public void UpdateUserSave()
      {
         var serializer = new JavaScriptSerializer();
         Dictionary<string, int> UpdatedTime = new Dictionary<string, int>();
         try
         {
            var fi = new System.IO.FileInfo(savedtimefile);
            if (fi.Exists)
            {
               var searilizationstring = System.IO.File.ReadAllText(fi.FullName);
               UpdatedTime = serializer.Deserialize<Dictionary<string, int>>(searilizationstring);
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
         {
            foreach (var item in TimeSpent)
            {
               if (UpdatedTime.ContainsKey(item.Key))
               {
                  UpdatedTime[item.Key] = item.Value;
               }
               else
               {
                  UpdatedTime.Add(item.Key, item.Value);
               }
            }
         }
         try
         {
            var fi = new System.IO.FileInfo(savedtimefile);

            var serializedResult = serializer.Serialize(UpdatedTime);
            System.IO.File.WriteAllText(fi.FullName, serializedResult);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
      public static int FIFTEEN_MIN = 15 * 60;
      public static int THIRTY_MIN = 30 * 60;
      public static int SIXTY_MIN = 60 * 60;
      public static int NINTY_MIN = 90 * 60;
      public static int ONETWENT_MIN =  120 * 60;

      public void CreateOptions()
      {
         var fi = new System.IO.FileInfo(optionsfilename);
         if (fi.Exists)
         {
            //return;
         }
         List<IndividualTaskSettings> initialoptions = new List<IndividualTaskSettings>();
         initialoptions.Add(new IndividualTaskSettings() { Task = "Product or Feature work", Color = Color.Green, ExpectedSeconds = THIRTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Career Development", Color = Color.GreenYellow, ExpectedSeconds = NINTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Strategic Thinking", Color = Color.BlueViolet, ExpectedSeconds = THIRTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Status", Color = Color.Red, ExpectedSeconds = SIXTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Contributing to Others", Color = Color.Purple, ExpectedSeconds = THIRTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Pure Overhead", Color = Color.DarkRed, ExpectedSeconds = FIFTEEN_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Team or Org Meeting", Color = Color.DarkSeaGreen, ExpectedSeconds = SIXTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Administrative", Color = Color.Yellow, ExpectedSeconds = FIFTEEN_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new IndividualTaskSettings() { Task = "Fires", Color = Color.OrangeRed, ExpectedSeconds = SIXTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });

         var serializer = new JavaScriptSerializer();
         try
         {
            var serializedResult = serializer.Serialize(initialoptions);
            System.IO.File.WriteAllText(fi.FullName, serializedResult);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      public void LoadOptions()
      {
         var serializer = new JavaScriptSerializer();
         try
         {
            var fi = new System.IO.FileInfo(optionsfilename);
            if (!fi.Exists)
            {
               return;
            }
            var searilizationstring = System.IO.File.ReadAllText(fi.FullName);
            var deserializedResult = serializer.Deserialize<List<IndividualTaskSettings>>(searilizationstring);
            TrackerDescriptions = deserializedResult;

         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }

         try
         {
            var fi = new System.IO.FileInfo(savedtimefile);
            if (!fi.Exists)
            {
               return;
            }
            var searilizationstring = System.IO.File.ReadAllText(fi.FullName);
            var deserializedResult = serializer.Deserialize< Dictionary<string, int> > (searilizationstring);
            TimeSpent = deserializedResult;

         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      public void SaveOptions()
      {
         var serializer = new JavaScriptSerializer();
         try
         {
            var fi = new System.IO.FileInfo(optionsfilename);

            var serializedResult = serializer.Serialize(TrackerDescriptions);
            System.IO.File.WriteAllText(fi.FullName, serializedResult);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      internal void UpdateTracker(string currentlytracking, int accumulated_seconds)
      {
         if (TimeSpent.ContainsKey(currentlytracking))
         {
            TimeSpent[currentlytracking] += accumulated_seconds;
         }
         else
         {
            TimeSpent[currentlytracking] = accumulated_seconds;
         }
      }

   }
}



