using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace OutlookComsPlugin
{
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

   // Contains the method executed in the context of the impersonated user
   public class ReadFileToStream
   {
      private string fn;
      private StreamString ss;

      public ReadFileToStream(StreamString str, string filename)
      {
         fn = filename;
         ss = str;
      }

      public void Start()
      {
         string contents = File.ReadAllText(fn);
         ss.WriteString(contents);
      }
   }

   abstract class NetworkingSharedBase
   {
      public static string NamedPipe = "OutlookComsPlugin";
      public static string ServerName = ".";
      protected bool Client = true;
      //https://stackoverflow.com/questions/1053593/what-is-the-easiest-way-for-two-separate-c-sharp-net-apps-to-talk-to-each-other

      NamedPipeClientStream pipeClient;
      NamedPipeServerStream pipeServer;

      StreamString pipestream;

      System.Threading.CancellationToken cancellationToken;

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
      public async void Listen(int TickFrequency = 5)//every 5 seconds
      {
         
         cancellationToken = new CancellationToken();
         pipeServer.WaitForConnection(cancellationToken);


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
