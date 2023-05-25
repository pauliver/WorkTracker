using PluginArchitecture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookComsPlugin
{
   public class OutlookComsPlugin : PluginArchitecture.SharedPluginCode, PluginArchitecture.PluginInterface
   {
      public OutlookComsPlugin()
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
         return 1; //network should tick 1x a second
      }

      public override void Initialize()
      {
         base.Initialize();
      }

      public override void LoadSettings(System.IO.DirectoryInfo fi, PluginConfig config)
      {
         base.LoadSettings(fi, config);
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

