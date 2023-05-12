using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMTimeTracker
{
   public partial class TimeTracking : Form
   {
      bool TimerActive = false;
      int accumulated_seconds = 0;
      int timeout = 60 * 60; // 1 hour
      bool LastHourTimedOut = false;
      private System.Windows.Forms.NotifyIcon notifyIcon1;
      public TimeTracking()
      {
         notifyIcon1 = new System.Windows.Forms.NotifyIcon();
         notifyIcon1.Icon = new Icon("PMTracker.ico");
         notifyIcon1.Text = "PM Time Tracker";
         notifyIcon1.Visible = true;
         notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
         notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, Exit_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("Show", null, Show_Click);
         notifyIcon1.ContextMenuStrip.Items.Add("Hide", null, Hide_Click);
         notifyIcon1.Click += Show_Click;

         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         myPieGraphic = DrawingPanel.CreateGraphics();
         DrawingPanel.Hide();
      }

      private void Exit_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void Hide_Click(object sender, EventArgs e)
      {
         this.Hide();
      }
      private void Show_Click(object sender, EventArgs e)
      {
         this.Show();
         DrawPieChart(myPiePercent, myPieColors);
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
            MessageBox.Show("Sum Do Not Add Up To 100.");
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
   }
}
