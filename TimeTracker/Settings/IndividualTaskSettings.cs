using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTimeTracker
{

   [DefaultPropertyAttribute("Task"), TypeConverterAttribute(typeof(ExpandableObjectConverter))]
   public class IndividualTaskSettings
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
}
