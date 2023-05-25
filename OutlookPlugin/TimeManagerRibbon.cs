using Microsoft.Office.Tools.Ribbon;
using OutlookComsPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OutlookPlugin
{
   public partial class TimeManagerRibbon
   {
      string statuslblstart = "Status: ";
      OutlookComsPlugin.Client client;

      PluginArchitecture.ProcessManager pm; 
      public void UpdateStatus(string status, bool Shown = true, bool running = false)
      {
         ConnectionLbl.Label = "Connected";
         StatusLbl.Label = statuslblstart + status;
         ShowHideApp(true);
         StatusLbl.Label = status;
         if (running)
         {
            StopBtn.Enabled = true;
            StartBtn.Enabled = false;
         }
         else
         {
            StopBtn.Enabled = false;
            StartBtn.Enabled = true;
         }
      }

      private void TaskTrackingRibbon_Load(object sender, RibbonUIEventArgs e)
      {
         ConnectionLbl.Label = "Disconnected";
         StatusLbl.Label = statuslblstart + "Disconnected";

         client = new OutlookComsPlugin.Client();
         client.RegisterCallback(this.UpdateStatus);
         StopBtn.Enabled = false;
         StartBtn.Enabled = false;

         pm = new PluginArchitecture.ProcessManager();
         AppRunning = pm.CheckIsRunning();
         if(AppRunning)
         {
            pm.RegisterListenForExit(CheckIfAppIsRunningAndUpdateUI);
            CheckIfAppIsRunningAndUpdateUI();
         }
         else
         {
            CheckIfAppIsRunningAndUpdateUI();
            pm.Launch();
            pm.RegisterListenForExit(CheckIfAppIsRunningAndUpdateUI);
            CheckIfAppIsRunningAndUpdateUI();
         }

         client.Send(NetworkingSharedBase.UpdatePlease);
      }

      private void StartBtn_Click(object sender, RibbonControlEventArgs e)
      {
         client.Send(NetworkingSharedBase.StartTracking);
      }

      private void ToggleShowHide_Click(object sender, RibbonControlEventArgs e)
      {
         if(pm.CheckIsRunning())
         {
            // leaving this here as a note to myself
            // dont' want to have to import win32.dll's and do this that way.
         }
         if(ToggleShowHide.Checked)
         {
            client.Send(NetworkingSharedBase.HideApp);
         }
         else
         {
            client.Send(NetworkingSharedBase.ShowApp);
         }
         //ShowHideApp(ToggleShowHide.Checked);
      }
      public void ShowHideApp(bool show)
      {
         if (show)
         {
            ToggleShowHide.Checked = true;
            ToggleShowHide.Label = "Hide Tracking App";
         }
         else
         {
            ToggleShowHide.Checked = false;
            ToggleShowHide.Label = "Show Tracking App";
         }
      }

      private void StopBtn_Click(object sender, RibbonControlEventArgs e)
      {
         client.Send(NetworkingSharedBase.StopTracking);
      }

      int TicksPerSecond = 10;
      int Ticks = 0;
      bool AppRunning = false;
      private void timer1_Tick(object sender, EventArgs e)
      {
         //Listen for calendar requests
         if (++Ticks >= 10)
         {        
            Ticks = 0;
           
            if(!AppRunning)
            {//doing all this async and not every second.
               CheckIfAppIsRunningAndUpdateUI();
            }
         }
      }

      protected void CheckIfAppIsRunningAndUpdateUI()
      {
         if (pm!= null && pm.CheckIsRunning())
         {
            LaunchButton.Checked = true;
            LaunchButton.Label = "Tracker Running";
            AppRunning = true;
         }
         else
         {
            LaunchButton.Checked = false;
            LaunchButton.Label = "Launch Tracker";
            AppRunning = false;
         }
      }

      private void LaunchButton_Click(object sender, RibbonControlEventArgs e)
      {
         bool Checked = LaunchButton.Checked;
         if(Checked)
         {
            if(!pm.CheckIsRunning())
               pm.Launch();
         }
         CheckIfAppIsRunningAndUpdateUI();
      }

   }
}
