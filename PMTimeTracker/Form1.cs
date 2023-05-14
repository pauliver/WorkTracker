using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization; 

namespace PMTimeTracker
{
   public partial class TimeTracking : Form
   {
      TrackerSaveLoad tracker = new TrackerSaveLoad();
      string currentlytracking = "nothing";
      bool TimerActive = false;
      int accumulated_seconds = 0;
      int timeout = 60 * 60; // 1 hour
      bool LastHourTimedOut = false;
      private System.Windows.Forms.NotifyIcon notifyIcon1;

      PieChart chart;


      public TimeTracking()
      {
         //tracker.CreateOptions();

         notifyIcon1 = new System.Windows.Forms.NotifyIcon();
         notifyIcon1.Icon = new Icon("PMTracker.ico");
         notifyIcon1.Text = "PM Time Tracker";
         notifyIcon1.Visible = true;
         notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
         notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, Exit_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("Hide", null, Hide_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("Show", null, Show_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("View Data & Settings", null, ShowPieChart_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("About", null, ShowAbout_Click);
         notifyIcon1.Click += Show_Click;

         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         OptionsView.Alignment = ListViewAlignment.SnapToGrid;
         OptionsView.AutoArrange = true;
         OptionsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         foreach (var item in tracker.TrackerDescriptions)
         {
            OptionsView.Items.Add(item.Task);
         }
         OptionsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         if (OptionsView.Items.Count > 0)
         {
            OptionsView.Items[0].Selected = true;
            currentlytracking = OptionsView.Items[0].Text;
         }

         chart = new PieChart();
         chart.Hide();
      }
      private void ShowAbout_Click(object sender, EventArgs e)
      {
         try
         {
            AboutAndSettings abs = new AboutAndSettings();
            abs.Show();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
      private void Exit_Click(object sender, EventArgs e)
      {
         tracker.UpdateUserSave();
         Application.Exit();
      }
      private void ShowPieChart_Click(object sender, EventArgs e)
      {
         try
         {
            chart.Show();
            chart.DrawPieChart(tracker.TrackerDescriptions, tracker.TimeSpent);
         }
         catch (Exception ex)
         {
           Console.WriteLine(ex.Message);
         }
      }
      private void Hide_Click(object sender, EventArgs e)
      {
         this.Hide();
      }
      private void Show_Click(object sender, EventArgs e)
      {
         this.Show();
      }

      private void Timer_Tick(object sender, EventArgs e)
      {
         if (TimerActive)
         {
            accumulated_seconds += 1;
            ExpectedTime.Value = accumulated_seconds;
         }
         if (accumulated_seconds > timeout)
         {
            TimerActive = false;
            accumulated_seconds = 0;
            LastHourTimedOut = true;
         }
      }


      private void StartTracking_Click(object sender, EventArgs e)
      {
         CompletePreviousTimeTracking();
         currentlytracking = OptionsView.SelectedItems[0].Text;
         BeginCurrentTimeTracking(currentlytracking);
         StopTracking.Enabled = true;
      }

      private void OptionsView_SelectedIndexChanged(object sender, EventArgs e)
      {
         //currentlytracking = OptionsView.SelectedItems().Text;
      }

      private void StopTracking_Click(object sender, EventArgs e)
      {
         CompletePreviousTimeTracking();
      }
      private void BeginCurrentTimeTracking(string name)
      {
         //name == OptionsView.SelectedItems[0].Text;
         LastHourTimedOut = false;
         accumulated_seconds = 0;
         TimerActive = true;
         Timer.Enabled = true;
         //StartTracking.Enabled = false; //we want to let you just mash 'start tracking' if you want to
         StopTracking.Visible = true;
         StopTracking.Enabled = true;

         ExpectedTime.Value = 0;
         ExpectedTime.Visible = true;

         var td = tracker.GetTrackerDescriptionbyTask(name);
         if(td != null)
         {
            timeout = td.MaxSeconds;
            //should also do something with the '30 min hard stop', that invovles system time
            ExpectedTime.Maximum = td.ExpectedSeconds;
            ExpectedTime.Value = 0;
         }
         else
         {
            MessageBox.Show("Error: could not find task " + name);
         }
      }
      private void CompletePreviousTimeTracking()
      {
         Timer.Enabled = false;
         if (LastHourTimedOut)  // if we timed out, we need to complete the previous task
         {
            tracker.UpdateTracker(currentlytracking, accumulated_seconds);

         }
         else if (TimerActive) //&& currentlytracking != "nothing" 
         {
            tracker.UpdateTracker(currentlytracking, accumulated_seconds);

         }
         accumulated_seconds = 0;
         TimerActive = false;
         LastHourTimedOut = false;
         currentlytracking = "nothing";
         StopTracking.Enabled = false;
         StopTracking.Visible = false;
         StartTracking.Enabled = true;
         ExpectedTime.Value = 0;
         ExpectedTime.Visible = false; 
      }

   }
}
