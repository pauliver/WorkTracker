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
      List<PluginInterface> FoundPlugins = new List<PluginInterface>();
      List<PluginInterface> ActivePlugins = new List<PluginInterface>();
      public PluginManager()
      {

      }

      public List<FileInfo> FindPlugins(FileInfo Folder)
      {
         //var files = Folder.GetFiles("*.dll");
         //return files.ToList();
         return null;
      }  

      public void LoadPluginSettings()
      {

      }

      public void LoadPlugins(List<FileInfo> files)
      {
         foreach (var file in files)
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
