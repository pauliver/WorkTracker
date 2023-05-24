using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace OutlookComsPlugin
{
   //https://stackoverflow.com/questions/1053593/what-is-the-easiest-way-for-two-separate-c-sharp-net-apps-to-talk-to-each-other


   //https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-use-named-pipes-for-network-interprocess-communication?source=recommendations


   public class StreamString
   {
      private Stream ioStream;
      private UnicodeEncoding streamEncoding;

      public StreamString(Stream ioStream)
      {
         this.ioStream = ioStream;
         streamEncoding = new UnicodeEncoding();
      }

      public string ReadString()
      {
         int len = 0;

         len = ioStream.ReadByte() * 256;
         len += ioStream.ReadByte();
         byte[] inBuffer = new byte[len];
         ioStream.Read(inBuffer, 0, len);

         return streamEncoding.GetString(inBuffer);
      }

      public int WriteString(string outString)
      {
         byte[] outBuffer = streamEncoding.GetBytes(outString);
         int len = outBuffer.Length;
         if (len > UInt16.MaxValue)
         {
            len = (int)UInt16.MaxValue;
         }
         ioStream.WriteByte((byte)(len / 256));
         ioStream.WriteByte((byte)(len & 255));
         ioStream.Write(outBuffer, 0, len);
         ioStream.Flush();

         return outBuffer.Length + 2;
      }
   }


   public class NetworkBuffer
   {
      protected List<string> inbound_messages
      {
         get; set;
      }
      protected List<string> outbound_messages
      {
         get; set;
      }

      public System.Threading.CancellationToken cancellationToken;

      public NetworkBuffer()
      {
         inbound_messages = new List<string>();
         outbound_messages = new List<string>();

         cancellationToken = new System.Threading.CancellationToken();
      }

      public void AddInboundMessage(string message)
      {
         lock (inbound_messages)
         {
            inbound_messages.Add(message);
         }
      }
      public string DequeueOutboundMessage()
      {
         var retstring = string.Empty;
         lock (outbound_messages)
         {
            retstring = outbound_messages.FirstOrDefault();
            outbound_messages.RemoveAt(0);
         }
         return retstring;
      }
      public void AddOutboundMessage(string message)
      {
         lock (outbound_messages)
         {
            outbound_messages.Add(message);
         }
      }
      public string DequeueInboundMessage()
      {
         var retstring = string.Empty;
         lock (inbound_messages)
         {
            retstring = inbound_messages.FirstOrDefault();
            inbound_messages.RemoveAt(0);
         }
         return retstring;
      }
   }

   abstract class NetworkingSharedBase
   {
      public static string NamedPipe = "OutlookComsPlugin";
      public static string ServerName = ".";
      protected bool Client = true;

      NamedPipeClientStream pipeClient;
      NamedPipeServerStream pipeServer;

      StreamString pipestream;

      NetworkBuffer networkBuffer = new NetworkBuffer();

      public NetworkingSharedBase(bool isClient = true)
      {
         Client = isClient;

         if (Client)
         {
            pipeClient = new NamedPipeClientStream(ServerName, NamedPipe, PipeDirection.InOut, PipeOptions.Asynchronous);
            pipeClient.ReadMode = PipeTransmissionMode.Message;
         }
         else
         {
            pipeServer = new NamedPipeServerStream(NamedPipe, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
         }   
      }

      public bool Connect(int Timeout = -1)
      {
         if(Client)
         {
            pipeClient.Connect(Timeout);
            pipestream = new StreamString(pipeClient);
         }
         return true;
      }

      public void StartListen(int TickFrequency = 5)
      {
         System.Threading.Tasks.Task.Run(() => Listen(TickFrequency));
      }
      async protected void Listen(int TickFrequency = 5)//every 5 seconds
      {
         await pipeServer.WaitForConnectionAsync(networkBuffer.cancellationToken);

         pipestream = new StreamString(pipeServer);

      }

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
