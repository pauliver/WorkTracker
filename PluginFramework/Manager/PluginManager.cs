﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using TimeTracker;
using System.Diagnostics;

namespace PluginArchitecture
{
   public class PluginManager
   {
      public static string PluginFolder = "Plugins";

      List<PluginInterface> FoundPlugins = new List<PluginInterface>();
      List<PluginInterface> ActivePlugins = new List<PluginInterface>();
      List<PluginInterface> PausedPlugins = new List<PluginInterface>();
      public PluginManager()
      {

      }

      public DirectoryInfo[] FindPlugins(DirectoryInfo Folder)
      {
         var directories = Folder.GetDirectories();
         return directories;
      }  

      public void LoadPlugins(DirectoryInfo directory = null)
      {
         System.IO.DirectoryInfo di = new DirectoryInfo(PluginFolder);
         if (directory != null)
         {
            di = directory;
         }
         if (!di.Exists)
         {
            di.Create();
         }
         DirectoryInfo[] folders = FindPlugins(di);
         LoadPlugins(folders);
      }

      protected void LoadPlugins(DirectoryInfo[] folders)
      {
         foreach (var item in folders)
         {
            string FolderName = item.Name;
            System.IO.FileInfo fi = new FileInfo(item.FullName + "\\plugin.json");
            IndividualSettings<PluginConfig> PluginSettings = null;
            if (fi.Exists)
            {
               PluginSettings = new IndividualSettings<PluginConfig>(fi);
               PluginSettings.Load();
               if(PluginSettings.SettingsObject.FolderName != FolderName)
               {
                  Debugger.Break();
               }
            }
            var files = item.GetFiles();
            foreach (var file in files)
            {
               if (file.Extension == ".dll" && file.Name == PluginSettings.SettingsObject.EntrypointDLL)
               {
                  var assembly = Assembly.LoadFile(file.FullName);
                  var types = assembly.GetTypes();
                  foreach (var type in types)
                  {
                     if (type.GetInterfaces().Contains(typeof(PluginInterface)) && type.Name == PluginSettings.SettingsObject.EntryClass)
                     {
                        var plugin = Activator.CreateInstance(type);
                        var pluginInterface = plugin as PluginInterface;
                        pluginInterface.LoadSettings(item, PluginSettings.SettingsObject);
                        pluginInterface.Register();
                        FoundPlugins.Add(pluginInterface);
                     }
                     else
                     {
                        Debugger.Break();
                     }
                  }
               }
            }
         }
      }

      public void Run()
      {
         // wired into the main loop
         foreach (var plugin in FoundPlugins)
         {
            plugin.Run();
            ActivePlugins.Add(plugin);
         }
      }

      public void Pause(bool UnPause = false)
      {
         foreach (var plugin in ActivePlugins)
         {
            plugin.Pause(UnPause);
            if(UnPause)
            {
               ActivePlugins.Add(plugin);
            }
            else
            {
               PausedPlugins.Add(plugin);
            }
         }

         if(UnPause)
         {
            PausedPlugins.Clear();
         }
         else
         {
            ActivePlugins.Clear();
         }
      }
      public void Tick(int Seconds)
      {
         // wired into the main loop
         foreach (var plugin in ActivePlugins)
         {
            plugin.Tick(Seconds);
         }
      }
      public void Stop()
      {
         foreach(var plugin in ActivePlugins)
         {
            plugin.Stop();
         }
         ActivePlugins.Clear();
      }

      public void DeRegister(PluginInterface pluginInterface)
      {
         if (ActivePlugins.Contains(pluginInterface))
         {
            pluginInterface.Stop();
            ActivePlugins.Remove(pluginInterface);
         }
         if (PausedPlugins.Contains(pluginInterface))
         {
            PausedPlugins.Remove(pluginInterface);
         }
         if (FoundPlugins.Contains(pluginInterface))
         {
            FoundPlugins.Remove(pluginInterface);
         }
      }
   }

}

