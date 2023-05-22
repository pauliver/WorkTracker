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
      public SettingsManager()
      {
      }

      public virtual void UpdateUserSave()
      {
      }

      public virtual void CreateOptions()
      {

      }

      public virtual void LoadOptions()
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
