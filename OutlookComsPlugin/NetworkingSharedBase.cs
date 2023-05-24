using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookComsPlugin
{
   abstract class NetworkingSharedBase
   {
      public static string NamedPipe = "OutlookComsPlugin";
      //https://stackoverflow.com/questions/1053593/what-is-the-easiest-way-for-two-separate-c-sharp-net-apps-to-talk-to-each-other

      public bool ProcessIndividualMessage(string message, string sender)
      {
         return true;
      }
      public bool ProcessMessage(string message, string sender)
      {
         return true;
      }
   }
}
