using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace WindowsGraphQL
{
    public class WindowsGraphQL : PluginArchitecture.SharedPluginCode, PluginArchitecture.PluginInterface
   {
      bool IsInitialized = false;
      bool IsRunning = false;
      bool IsRegistered = false;
      public WindowsGraphQL()
      {
         bool IsInitialized = false;
         bool IsRunning = false;
         bool IsRegistered = false;

      }

      public override void Register()
      {
         base.Register();
      }

      public override void DeRegister()
      {
         base.DeRegister();
      }
      // in seconds
      public override int GetDesiredTickFrequency()
      {
         return 60;
      }

      public override void Initialize()
      {
         base.Initialize();
      }

      public override void LoadSettings(FileInfo fi)
      {
         base.LoadSettings(fi);
      }

      public override void Run()
      {
         base.Run();

      }

      public override void Pause(bool UnPause = false)
      {
         base.Pause(UnPause);
      }

      public override void Tick(int Seconds)
      {
         base.Tick(Seconds);

      }

      public override void Stop()
      {
         base.Stop();

      }
   }
}
