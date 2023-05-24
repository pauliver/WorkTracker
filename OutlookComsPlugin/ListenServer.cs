using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookComsPlugin
{
   class ListenServer : NetworkingSharedBase
   {
      public bool Listen()
      {
         return true;
      }
      public bool StopListening()
      {
         return true;
      }
      public bool OnConnect()
      {
         return true;
      }
      public bool OnDisconnect() 
      {
         return true;
      }
   }
}
