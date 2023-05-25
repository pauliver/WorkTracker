using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

      public void InitialLoadPlugins()
      {
         System.IO.DirectoryInfo di = new DirectoryInfo(PluginFolder);
         if (!di.Exists)
         {
            di.Create();
         }
         var folders = FindPlugins(di);
         LoadPlugins(folders);
      }

      protected void InitialLoadPlugins(DirectoryInfo[] folders)
      {
         foreach (var item in folders)
         {
            string FolderName = item.Name;
            System.IO.FileInfo fi = new FileInfo(FolderName + ".json");
            if(fi.Exists)
            {
               fi.Create();
            }
            var files = item.GetFiles();
            foreach (var file in files)
            {
               if (file.Extension == ".dll")
               {
                  var assembly = Assembly.LoadFile(file.FullName);
                  var types = assembly.GetTypes();
                  foreach (var type in types)
                  {
                     if (type.GetInterfaces().Contains(typeof(PluginInterface)))
                     {
                        var plugin = Activator.CreateInstance(type);
                        var pluginInterface = plugin as PluginInterface;
                        pluginInterface.Register();
                     }
                  }
               }
            }
         }
      }

      public void LoadPlugins(DirectoryInfo[] folders)
      {

      }

   }
}
