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

      void LoadSettings();
      void Register();
      void DeRegister();

      void Run();
      void Pause();
      void Tick();
      void Stop();
   }
}
