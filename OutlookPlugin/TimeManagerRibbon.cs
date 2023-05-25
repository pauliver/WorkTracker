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

         client.Send(NetworkingSharedBase.UpdatePlease);
      }

      private void StartBtn_Click(object sender, RibbonControlEventArgs e)
      {
         client.Send(NetworkingSharedBase.StartTracking);
      }

      private void ToggleShowHide_Click(object sender, RibbonControlEventArgs e)
      {
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

      private void timer1_Tick(object sender, EventArgs e)
      {
         //Listen for calendar requests
      }
   }
}
