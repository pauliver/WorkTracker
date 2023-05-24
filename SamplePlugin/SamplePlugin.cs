using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SamplePluginNameSpace
{
    public class SamplePlugin : PluginArchitecture.SharedPluginCode, PluginArchitecture.PluginInterface
   {
      public SamplePlugin()
      {
         IsInitialized = false;
         IsRunning = false;
         IsRegistered = false;

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
