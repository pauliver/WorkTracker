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
   [DefaultPropertyAttribute("Task")]
   public class TrackerDescription
   {
      [CategoryAttribute("Task"), DescriptionAttribute("Name of the task")]
      public string Task { get; set; }
      [CategoryAttribute("Task"), DescriptionAttribute("a more complete description")]
      public string Task_LongDescription { get; set; }

      [CategoryAttribute("Task"), DescriptionAttribute("Color to render")]
      public Color Color { get; set; }

      [CategoryAttribute("Task Timing"), DescriptionAttribute("lorem ipsum")]
      public int ExpectedSeconds { get; set; }
      [CategoryAttribute("Task Timing"), DescriptionAttribute("lorem ipsum")]
      public int MaxSeconds { get; set; }
      [CategoryAttribute("Task Timing"), DescriptionAttribute("lorem ipsum")]
      public bool ThirtyMinHardStop { get; set; }
      [CategoryAttribute("Task Visualization"), DescriptionAttribute("lorem ipsum")]
      public string ImagePath { get; set; }
   }

   public class TrackerSaveLoad
   {
      public List<TrackerDescription> TrackerDescriptions { get; set; }

      public TrackerDescription GetTrackerDescriptionbyTask(string task)
      {
         foreach (TrackerDescription tracker in TrackerDescriptions)
         {
            if (tracker.Task == task)
            {
               return tracker;
            }
         }
         return null;
      }

      public Dictionary<string, int> TimeSpent { get; set; }

      string optionsfilename = "config.json";
      string savedtimefile = "user.json";

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


      public TrackerSaveLoad()
      {
         TrackerDescriptions = new List<TrackerDescription>();
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

      public void CreateOptions()
      {
         var fi = new System.IO.FileInfo(optionsfilename);
         if (fi.Exists)
         {
            //return;
         }
         List<TrackerDescription> initialoptions = new List<TrackerDescription>();
         initialoptions.Add(new TrackerDescription() { Task = "Meeting : Team", Color = Color.Green, ExpectedSeconds = 30 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Meeting : Huge", Color = Color.GreenYellow, ExpectedSeconds = 90 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Meeting : 1on1", Color = Color.BlueViolet, ExpectedSeconds = 30 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Training", Color = Color.Red, ExpectedSeconds = 60 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Helping Others", Color = Color.Purple, ExpectedSeconds = 30 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Pure Overhead", Color = Color.DarkRed, ExpectedSeconds = 15 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Feature Work", Color = Color.DarkSeaGreen, ExpectedSeconds = 60 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Mandatory Follow UP", Color = Color.Yellow, ExpectedSeconds = 15 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Taxes", Color = Color.OrangeRed, ExpectedSeconds = 60 * 60, MaxSeconds = 60 * 60 * 2, ThirtyMinHardStop = false });

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
            var deserializedResult = serializer.Deserialize<List<TrackerDescription>>(searilizationstring);
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



