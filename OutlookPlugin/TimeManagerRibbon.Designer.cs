namespace OutlookPlugin
{
   partial class TimeManagerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      public TimeManagerRibbon()
          : base(Globals.Factory.GetRibbonFactory())
      {
         InitializeComponent();
      }

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.TaskTrackingInfo = this.Factory.CreateRibbonTab();
         this.Core = this.Factory.CreateRibbonGroup();
         this.ConnectionLbl = this.Factory.CreateRibbonLabel();
         this.StartBtn = this.Factory.CreateRibbonButton();
         this.StopBtn = this.Factory.CreateRibbonButton();
         this.Settings = this.Factory.CreateRibbonGroup();
         this.LaunchButton = this.Factory.CreateRibbonToggleButton();
         this.StatusLbl = this.Factory.CreateRibbonLabel();
         this.ToggleShowHide = this.Factory.CreateRibbonToggleButton();
         this.DataDisplay = this.Factory.CreateRibbonGroup();
         this.TimingTimer = new System.Windows.Forms.Timer(this.components);
         this.TaskTrackingInfo.SuspendLayout();
         this.Core.SuspendLayout();
         this.Settings.SuspendLayout();
         this.SuspendLayout();
         // 
         // TaskTrackingInfo
         // 
         this.TaskTrackingInfo.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
         this.TaskTrackingInfo.Groups.Add(this.Core);
         this.TaskTrackingInfo.Groups.Add(this.Settings);
         this.TaskTrackingInfo.Groups.Add(this.DataDisplay);
         this.TaskTrackingInfo.Label = "Task Tracking";
         this.TaskTrackingInfo.Name = "TaskTrackingInfo";
         // 
         // Core
         // 
         this.Core.Items.Add(this.ConnectionLbl);
         this.Core.Items.Add(this.StartBtn);
         this.Core.Items.Add(this.StopBtn);
         this.Core.Label = "Progress";
         this.Core.Name = "Core";
         // 
         // ConnectionLbl
         // 
         this.ConnectionLbl.Label = "Not Connected";
         this.ConnectionLbl.Name = "ConnectionLbl";
         // 
         // StartBtn
         // 
         this.StartBtn.Label = "Start Tracking";
         this.StartBtn.Name = "StartBtn";
         this.StartBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.StartBtn_Click);
         // 
         // StopBtn
         // 
         this.StopBtn.Label = "Stop Tracking";
         this.StopBtn.Name = "StopBtn";
         this.StopBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.StopBtn_Click);
         // 
         // Settings
         // 
         this.Settings.Items.Add(this.LaunchButton);
         this.Settings.Items.Add(this.StatusLbl);
         this.Settings.Items.Add(this.ToggleShowHide);
         this.Settings.Label = "Settings";
         this.Settings.Name = "Settings";
         // 
         // LaunchButton
         // 
         this.LaunchButton.Label = "Launch Tracker";
         this.LaunchButton.Name = "LaunchButton";
         this.LaunchButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.LaunchButton_Click);
         // 
         // StatusLbl
         // 
         this.StatusLbl.Label = "Status:";
         this.StatusLbl.Name = "StatusLbl";
         // 
         // ToggleShowHide
         // 
         this.ToggleShowHide.Label = "Show Tracking App";
         this.ToggleShowHide.Name = "ToggleShowHide";
         this.ToggleShowHide.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ToggleShowHide_Click);
         // 
         // DataDisplay
         // 
         this.DataDisplay.Label = "Data Display";
         this.DataDisplay.Name = "DataDisplay";
         // 
         // TimingTimer
         // 
         this.TimingTimer.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // TimeManagerRibbon
         // 
         this.Name = "TimeManagerRibbon";
         this.RibbonType = "Microsoft.Outlook.Appointment, Microsoft.Outlook.Explorer";
         this.Tabs.Add(this.TaskTrackingInfo);
         this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.TaskTrackingRibbon_Load);
         this.TaskTrackingInfo.ResumeLayout(false);
         this.TaskTrackingInfo.PerformLayout();
         this.Core.ResumeLayout(false);
         this.Core.PerformLayout();
         this.Settings.ResumeLayout(false);
         this.Settings.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      internal Microsoft.Office.Tools.Ribbon.RibbonTab TaskTrackingInfo;
      internal Microsoft.Office.Tools.Ribbon.RibbonGroup Core;
      internal Microsoft.Office.Tools.Ribbon.RibbonButton StartBtn;
      internal Microsoft.Office.Tools.Ribbon.RibbonButton StopBtn;
      internal Microsoft.Office.Tools.Ribbon.RibbonLabel ConnectionLbl;
      internal Microsoft.Office.Tools.Ribbon.RibbonGroup Settings;
      internal Microsoft.Office.Tools.Ribbon.RibbonGroup DataDisplay;
      internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ToggleShowHide;
      private System.Windows.Forms.Timer TimingTimer;
      internal Microsoft.Office.Tools.Ribbon.RibbonLabel StatusLbl;
      internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton LaunchButton;
   }

   partial class ThisRibbonCollection
   {
      internal TimeManagerRibbon TaskTrackingRibbon
      {
         get { return this.GetRibbon<TimeManagerRibbon>(); }
      }
   }
}
