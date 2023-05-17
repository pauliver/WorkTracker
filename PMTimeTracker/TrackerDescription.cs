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
   [DefaultPropertyAttribute("Task"), TypeConverterAttribute(typeof(ExpandableObjectConverter))]
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

      [CategoryAttribute("Task AutoMatch"), DescriptionAttribute("If we detect a running application that has focus, should we change to this? By the title")]
      public bool AutoMatchBasedOnWindowTitle { get; set; }
      [CategoryAttribute("Task AutoMatch"), DescriptionAttribute("Title to Match")]
      public string WindowTitleMatch { get; set; }
      [CategoryAttribute("Task AutoMatch"), DescriptionAttribute("If we detect a running application that has focus, should we change to this? By the App Name")]
      public bool AutoMatchBasedOnApplication { get; set; }
      [CategoryAttribute("Task AutoMatch"), DescriptionAttribute("App Name to Match")]
      public string WindowAppMatch { get; set; }
   }

   public class TrackerSaveLoad
   {

      [CategoryAttribute("Tasks"), DescriptionAttribute("lorem ipsum")]
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


      [CategoryAttribute("Time Spent"), DescriptionAttribute("lorem ipsum")]
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
         List<TrackerDescription> initialoptions = new List<TrackerDescription>();
         initialoptions.Add(new TrackerDescription() { Task = "Product or Feature work", Color = Color.Green, ExpectedSeconds = THIRTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Career Development", Color = Color.GreenYellow, ExpectedSeconds = NINTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Strategic Thinking", Color = Color.BlueViolet, ExpectedSeconds = THIRTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Status", Color = Color.Red, ExpectedSeconds = SIXTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Contributing to Others", Color = Color.Purple, ExpectedSeconds = THIRTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Pure Overhead", Color = Color.DarkRed, ExpectedSeconds = FIFTEEN_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Team or Org Meeting", Color = Color.DarkSeaGreen, ExpectedSeconds = SIXTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Administrative", Color = Color.Yellow, ExpectedSeconds = FIFTEEN_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });
         initialoptions.Add(new TrackerDescription() { Task = "Fires", Color = Color.OrangeRed, ExpectedSeconds = SIXTY_MIN, MaxSeconds = ONETWENT_MIN, ThirtyMinHardStop = false });

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



