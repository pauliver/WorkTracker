using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PluginArchitecture
{
   public abstract class SharedPluginCode : PluginInterface
   {
      protected bool IsInitialized = false;
      protected bool IsRunning = false;
      protected bool IsRegistered = false;
      protected PluginConfig configFile = null;
      protected DirectoryInfo MyDirectory = null;
      public virtual void Register()
      {
         if (!IsInitialized)
            Debugger.Break();

         IsRegistered = true;
      }

      public string Name
      {
         get
         {
            if(configFile == null)
               return "Unknown";
            if (configFile.FullName == null)
            {
               return configFile.EntryClass;
            }
            if(configFile.FullName.Length == 0)
            {
               return configFile.EntryClass;
            }
            return configFile.FullName; //this is ideally what we return
         }
      }
      public int APIVersion
      {
         get { return configFile.APIVersion; }
      }
      public bool Initialized
      {
         get { return IsInitialized; }
      }
      public bool Running
      {
         get { return IsRunning; }
      }
      public bool Registered
      {
         get { return IsRegistered; }
      }
      public int DesiredTickFrequency
      { 
         get { return configFile.DesiredTickFrequency; }
      }
      public string EntryClass
      {
         get { return configFile.EntryClass; }
      }
      public string EntrypointDLL
      {
         get { return configFile.EntrypointDLL; }
      }
      public string FullName
      {
         get { return configFile.FullName; }
      }
      public string FolderName
      {
         get { return configFile.FolderName; }
      }
      public String Directory
      {
         get { return MyDirectory.Name; }
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

      public virtual void LoadSettings(System.IO.DirectoryInfo fi, PluginConfig config)
      {
         MyDirectory= fi;
         configFile = config;
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
