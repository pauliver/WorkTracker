using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGraphQL
{
    public class WindowsGraphQL : PluginArchitecture.PluginInterface
   {
      public WindowsGraphQL() 
      {

      }

      public void Register()
      {

      }

      public void DeRegister()
      {

      }
      // in seconds
      public int GetDesiredTickFrequency()
      {
         return 60;
      }
    }
}
