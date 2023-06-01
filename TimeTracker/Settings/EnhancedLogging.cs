using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
   public class EnhancedLogging : TimeTracker.GetID
   {
      public string item = "";
      public float Id = 0.0f;
      public string UserName = "";
      public DateTime StartTime;
      public DateTime EndTime;
      public int TimeSpent = 0;

      public float GetID
      {
         get
         {
            return Id;
         }
         set
         {
            Id = value;
         }
      }

      public override bool Equals(object obj)
      {
         if (obj != null && obj is EnhancedLogging)
         {
            if ((obj as EnhancedLogging).Id == this.Id)
            {
               return true;
            }
         }
         return false;
      }
      public override int GetHashCode()
      {
         return Id.GetHashCode();
      }
   }
}
