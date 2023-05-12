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
         notifyIcon1.ContextMenuStrip.Items.Add("ShowPieChart", null, ShowPieChart_Click);
         notifyIcon1.Click += Show_Click;

         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         myPieGraphic = DrawingPanel.CreateGraphics();
         DrawingPanel.Location = new Point(0, 0);
         DrawingPanel.Hide();
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
            DrawPieChart(tracker.PiePercent, tracker.PieColor);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
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
         }
         if(accumulated_seconds > timeout)
         {
            TimerActive = false;
            accumulated_seconds = 0;
            LastHourTimedOut = true;
         }
      }

      int[] myPiePercent = { 10, 20, 25, 5, 40 };
      Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon };
      Graphics myPieGraphic;

      public void DrawPieChart(int[] myPiePerecents, Color[] myPieColors)
      {
         //myPieGraphic.Clear(Color.White);
         DrawingPanel.Show();
         Point myPieLocation = new Point(125, 50);

         //Set Here Size Of The Chartâ€¦
         Size myPieSize = new Size(400, 400);

         //Check if sections add up to 100.
         int sum = 0;
         foreach (int percent_loopVariable in myPiePerecents)
         {
            sum += percent_loopVariable;
         }

         if (sum != 100)
         {
            MessageBox.Show("Sum Do Not Add Up To 100. it is : " + sum);
         }

         //Check Here Number Of Values & Colors Are Same Or Not.They Must Be Same.
         if (myPiePerecents.Length != myPieColors.Length)
         {
            MessageBox.Show("There Must Be The Same Number Of Percents And Colors.");
         }

         int PiePercentTotal = 0;
         for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
         {
            using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
            {

               //Here it Will Convert Each Value Into 360, So Total Into 360 & Then It Will Draw A Full Pie Chart.
               myPieGraphic.FillPie(brush, new Rectangle(myPieLocation, myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
            }

            PiePercentTotal += myPiePerecents[PiePercents];
         }
         return;
      }

      private void DrawingPanel_Click(object sender, EventArgs e)
      {
         DrawingPanel.Hide();
      }

      private void StartTracking_Click(object sender, EventArgs e)
      {
         currentlytracking = OptionsView.SelectedItems[0].Text;
      }

      private void OptionsView_SelectedIndexChanged(object sender, EventArgs e)
      {
         //currentlytracking = OptionsView.SelectedItems().Text;
      }
   }
}
