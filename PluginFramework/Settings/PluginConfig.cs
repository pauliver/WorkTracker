using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginArchitecture
{
   public class PluginConfig
   {
      public int APIVersion = 0;
      public string EntrypointDLL = "";
      public string FolderName = "";
      public string EntryClass = "";
      public int DesiredTickFrequency = 1;
   }

}
