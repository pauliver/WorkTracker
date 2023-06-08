using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
   interface IPluginMessage
   {
      string[] Sender { get; set; }
      string[] Recipient { get; set; }
      string[] CC { get; set; }
      string[] Optional { get; set; }
      string Subject { get; set; }
      string Body { get; set; }
      string[] Attachments { get; set; }

      DateTime Sent { get; set; } // same as created
      DateTime Created { get; set; } // same as sent

      DateTime Received { get; set; }
      DateTime Happening { get; set; }
      TimeSpan Extent { get; set; }

   }
}
