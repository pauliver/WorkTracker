using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginArchitecture
{
   public interface PluginInterface
   {
      string Name { get; }
      void Initialize();

      void LoadSettings(System.IO.DirectoryInfo fi, PluginConfig config);
      void Register();
      void DeRegister();

      void Run();
      void Pause(bool UnPause = false);
      void Tick(int Seconds);
      void Stop();
   }
}
