using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
   class PluginMessage : IPluginMessage
   {
      protected List<string> sender = new List<string>();
      public string[] Sender
      {
         get
         {
            return sender.ToArray();
         }
         set
         {
            sender.Clear();
            sender.AddRange(value);
         }
      }

      protected List<string> recipient = new List<string>();
      public string[] Recipient
      {
         get
         {
            return recipient.ToArray();
         }
         set
         {
            recipient.Clear();
            recipient.AddRange(value);
         }
      }
      protected List<string> cc_optional = new List<string>();
      public string[] CC
      {
         get
         {
            return cc_optional.ToArray();
         }
         set
         {
            cc_optional.Clear();
            cc_optional.AddRange(value);
         }
      }
      public string[] Optional
      {
         get
         {
            return cc_optional.ToArray();
         }
         set
         {
            cc_optional.Clear();
            cc_optional.AddRange(value);
         }
      }

      protected List<string> attachments = new List<string>();
      public string[] Attachments
      {
         get
         {
            return attachments.ToArray();
         }
         set
         {
            attachments.Clear();
            attachments.AddRange(value);
         }
      }


      protected string subject = "";
      public string Subject
      {
         get
         {
            return subject;
         }
         set
         {
            subject = value;
         }
      }
      protected string body = "";
      public string Body
      {
         get
         {
            return body;
         }
         set
         {
            body = value;
         }
      }

      protected DateTime sent_created = new DateTime();
      public DateTime Sent { get { return sent_created; } set { sent_created = value; } } // same as created
      public DateTime Created { get { return sent_created; } set { sent_created = value; } } // same as Sent



      protected DateTime recieved_happening = new DateTime();
      public DateTime Received { get { return recieved_happening; } set { recieved_happening = value; } } // same as Happening
      public DateTime Happening { get { return recieved_happening; } set { recieved_happening = value; } } // same as Received

      protected TimeSpan extent_length = TimeSpan.Zero; 
      public TimeSpan Extent { get { return extent_length; } set { extent_length = value; } }

      public delegate bool AbortDelegate();

      public delegate void ShowWindowDelegate(Form window,string currentlyTracking, AbortDelegate NotNow);

      public delegate string SwitchTrackingDelegate(bool Is_tracking, string current_task, AbortDelegate NotNow);

      public virtual bool MightRequest_ShowWindow()
      {
         return false;
      }

      public virtual bool MightRequest_SwitchTracking()
      {
         return false;
      }
   }
}
