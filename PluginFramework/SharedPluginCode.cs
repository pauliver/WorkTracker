using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginArchitecture
{
   public abstract class SharedPluginCode : PluginInterface
   {
      bool IsInitialized = false;
      bool IsRunning = false;
      bool IsRegistered = false;
 
      public virtual void Register()
      {
         if (!IsInitialized)
            Debugger.Break();

         IsRegistered = true;
      }

      public virtual void DeRegister()
      {
         IsRegistered = false;
      }
      // in seconds
      public virtual int GetDesiredTickFrequency()
      {
         return 60;
      }

      public virtual void Initialize()
      {
         IsInitialized = true;
      }

      public virtual void LoadSettings(FileInfo fi)
      {

      }

      public virtual void Run()
      {
         IsRunning = true;
      }

      public virtual void Pause(bool UnPause = false)
      {
         IsRunning = UnPause;
      }

      public virtual void Tick(int Seconds)
      {
         if (!IsRunning)
            Debugger.Break();
      }

      public virtual void Stop()
      {
         IsRunning = false;
      }
   }
}
