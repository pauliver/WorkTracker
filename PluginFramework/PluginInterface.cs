using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginArchitecture
{
   public interface PluginInterface
   {
      void Initialize();

      void LoadSettings(System.IO.FileInfo fi);
      void Register();
      void DeRegister();

      void Run();
      void Pause(bool UnPause = false);
      void Tick(int Seconds);
      void Stop();
   }
}
