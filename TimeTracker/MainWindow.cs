using PluginArchitecture;
using TimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
#if ATTEMPING_WINDOW_DETECTION
using System.Threading.Tasks;
using System.Web.Script.Serialization; 
#endif
using System.Windows.Forms;

namespace TimeTracker
{
   public partial class TimeTracking : Form
   {
      AppSettingsManager tracker;
      PluginManager pluginManager;
      string currentlytracking = "nothing";
      bool TimerActive = false;
      int accumulated_seconds = 0;
      int timeout = 60 * 60; // 1 hour
      bool LastHourTimedOut = false;
      bool ThirtyMinuteShow = false;
      private System.Windows.Forms.NotifyIcon notifyIcon1;

      PieChart chart;

      System.IO.FileInfo LogFile = new System.IO.FileInfo("Settings\\PMTimeTracker.log");

      public TimeTracking(AppSettingsManager asm, PluginManager PM)//FileInfo new_logfile,AppSettingsManager tsl)
      {
         tracker = asm;
         pluginManager = PM;
         //tracker.CreateOptions();

         notifyIcon1 = new System.Windows.Forms.NotifyIcon();
         notifyIcon1.Icon = Resources.PMTracker;
         notifyIcon1.Text = "PM Time Tracker";
         notifyIcon1.Visible = true;
         notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
         notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, Exit_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("Hide", null, Hide_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("Show", null, Show_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("View &Data and Settings", null, ShowPieChart_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("About", null, ShowAbout_Click);
         notifyIcon1.Click += Show_Click;

         InitializeComponent();
#if ATTEMPING_WINDOW_DETECTION
         try
         {
            if(LogFile.Exists)
            {
               LogFile.Delete();
            }
            LogFile.Create().Close();
         }catch(Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
#endif
         try
         {
            {
               Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle);
               int titleHeight = screenRectangle.Top - this.Top;
            }
            //Firefly in image of a clock screaming at the sky while the world burns around it 26800
            // image from Adobe Firefly
            var bmp = new Bitmap(this.BackgroundImage);

            var WidthRatio = bmp.Size.Width / this.Width;
            var HeightRatio = bmp.Size.Width / this.Height;

            var scope = new Rectangle( OptionsView.Location.X * WidthRatio, OptionsView.Location.Y  * HeightRatio, OptionsView.Width * WidthRatio, OptionsView.Height * HeightRatio);
            var BackgroundBitmap = new Bitmap(OptionsView.Width, OptionsView.Height);
            Graphics bg = Graphics.FromImage(BackgroundBitmap);

            bg.DrawImage(bmp, new Rectangle(0, 0, OptionsView.Width, OptionsView.Height), scope, GraphicsUnit.Pixel);

            OptionsView.BackgroundImageTiled = false;
            OptionsView.BackgroundImage = BackgroundBitmap;
         }catch(Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         OptionsView.Alignment = ListViewAlignment.SnapToGrid;
         OptionsView.AutoArrange = true;
         OptionsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         foreach (var item in tracker.TrackerOptionsAndDescriptions.SettingsObject)
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
         pluginManager.Run();
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
         if(TimerActive && currentlytracking != "nothing")
         {
            CompletePreviousTimeTracking();
         }
         tracker.UpdateUserSave();
         Application.Exit();
      }
      private void ShowPieChart_Click(object sender, EventArgs e)
      {
         try
         {
            chart.Show();
            chart.TransferTracker(tracker);
            chart.DrawPieChart(tracker.TrackerOptionsAndDescriptions.SettingsObject, tracker.UserTimeSpent.SettingsObject);
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

      bool showtoggle = true;
      private void Timer_Tick(object sender, EventArgs e)
      {

         if (TimerActive)
         {
            accumulated_seconds += 1;

            int Minute = System.DateTime.Now.Minute;
            if (ThirtyMinuteShow && (Minute == 0 || Minute == 30))
            {
               // don't collapse this into the above if statement
               if(showtoggle) //ensure we only ever pop it up 1x
               {
                  this.Show();
                  showtoggle = false;
               }
            }
            else
            {
               showtoggle = true;
            }

#if ATTEMPING_WINDOW_DETECTION
            {
               try
               {
                  var ActiveWindowTitle = GrabRunningInfo.GetActiveWindowTitle();
                  var ActiveWindowApp = GrabRunningInfo.GetActiveWindowAppName();

                  if (ActiveWindowApp.Result != LastLogFileApp)
                  {
                     lock (LogFileTemp)
                     {
                        LogFileTemp += Environment.NewLine + ActiveWindowApp.Result + " : " + ActiveWindowTitle.Result + " - " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + Environment.NewLine;
                        LastLogFileApp = ActiveWindowApp.Result;
                     }
                  }
               }
               catch (Exception ex)
               {
                  Console.WriteLine(ex.Message);
               }
#endif

         }

         if(accumulated_seconds <= ExpectedTime.Maximum)
         {
            ExpectedTime.Value = accumulated_seconds;
         }
      

         if (accumulated_seconds > timeout)
         {
            TimerActive = false;
            accumulated_seconds = 0;
            LastHourTimedOut = true;
            StartTracking.Text = "Start Tracking";
            //CompletePreviousTimeTracking();
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
         // Need to make this more visible
      }

      private void StopTracking_Click(object sender, EventArgs e)
      {
         StartTracking.Text = "Start Tracking";
         CompletePreviousTimeTracking();
      }
      private void BeginCurrentTimeTracking(string name)
      {
#if ATTEMPING_WINDOW_DETECTION

         LastLogFileApp = "";
         LogFileTemp = "";
#endif
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

         StartTracking.Text = "Re-Start Tracking";

         var td = tracker.GetTrackerDescriptionbyTask(name);
         if(td != null)
         {
            this.Text = "Time Tracking : " + name;
            ThirtyMinuteShow = td.ThirtyMinHardStop;
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
         StartTracking.Text = "Start Tracking";
         this.Text = "Time Tracking ";
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

#if ATTEMPING_WINDOW_DETECTION
         //clean up the log file
         try
         {
           System.IO.File.AppendAllText(LogFile.Name, Environment.NewLine + currentlytracking + " " + System.DateTime.Now + Environment.NewLine + LogFileTemp);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
         LastLogFileApp = "";
         LogFileTemp = "";
         GC.Collect();
#endif
         currentlytracking = "nothing";
      }

   }
}
