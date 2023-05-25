﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginArchitecture
{
   public delegate void ProcessExited();
   public class ProcessManager
   {
      bool IsRunning = false;
      Process[] pname;
      string ProcessName = "TimeTracker";
      System.IO.FileInfo ProcessPath;
      string ProcessID = string.Empty;
      ProcessExited ExitDelegate = null;
      public ProcessManager(string processName = "TimeTracker", System.IO.FileInfo ProcessNamePath = null)
      {
         this.ProcessName = processName;
         ProcessPath = ProcessNamePath;
         CheckIsRunning();
      }

      protected Process GetFirstProcessWithDebugging()
      {
         if(pname.Length != 1)
         {
            Debugger.Break();
         }

         if (IsRunning && pname.Length > 0)
         {
            return pname[0];
         }
         return null;
      }

      public bool CheckIsRunning()
      {
         pname = Process.GetProcessesByName(ProcessName);
         if (pname.Length == 0)
         {
            IsRunning = false;
         }
         else
         {
            IsRunning = true;
            ProcessID = GetFirstProcessWithDebugging().Id.ToString();
         }
         return IsRunning;
      }
      public bool RegisterListenForExit(ProcessExited callback = null)
      {
         ExitDelegate = callback;
         Process process = GetFirstProcessWithDebugging();
         if (process != null)
         {
            process.EnableRaisingEvents = true;
            process.Exited += ProcessManager_Exited;
            return true;
         }
         else
         {
            return false;
         }
      }

      private void ProcessManager_Exited(object sender, EventArgs e)
      {
         IsRunning = false;
         if(ExitDelegate != null)
         {
            ExitDelegate.Invoke();
         }
      }

      public bool Launch()
      {
         try
         {
            if (ProcessPath != null)
            {
               Process.Start(ProcessPath.FullName);
               if (CheckIsRunning())
                  return true;
            }
         }catch(Exception ex)
         {
            Debugger.Break();
         }
         return false;
      }
      public void Show()
      {
         Process process = GetFirstProcessWithDebugging();
         if (process != null)
         {

         }
      }
      public void Hide()
      {
         Process process = GetFirstProcessWithDebugging();
         if (process != null)
         {

         }
      }
   }
}
