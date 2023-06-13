using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookComsPlugin
{
   public delegate void TimeTrackingCallback(String status, bool Shown, bool running);
   public class Client : NetworkingSharedBase
   {
      TimeTrackingCallback theCallback;
      public Client() 
      {

      }
      public bool Connect()
      {
         return true;
         //return base.Connect();
      }
      public bool Disconnect()
      {
         return true;
      }
      public bool Send(string message)
      {
         return true;
      }
      public bool Receive(string message, string extradata)
      {
         return true;
      }

      public void RegisterCallback(TimeTrackingCallback callback)
      {
         theCallback = callback;
      }

      public void RequestUpdateStatus(string status, bool Shown = true, bool running = false)
      {
         theCallback.Invoke(status, Shown, running);
      }
   }
}
