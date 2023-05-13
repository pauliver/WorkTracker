﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMTimeTracker
{
   public partial class PieChart : Form
   {
      public PieChart()
      {
         myPieGraphic = this.CreateGraphics();

         InitializeComponent();
      }
      int[] myPiePercent = { 10, 20, 25, 5, 40 };
      Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon };
      Graphics myPieGraphic;

#if false
      public void TestPieChart()
      {
         DrawPieChart(myPiePercent, myPieColors);
      }

      //https://www.c-sharpcorner.com/uploadfile/9f4ff8/draw-a-pie-chart-in-C-Sharp/

      public void DrawPieChart(int[] myPiePerecents, Color[] myPieColors)
      {
         myPieGraphic.Clear(Color.White);
         Point myPieLocation = new Point(10, 10);

         //Set Here Size Of The Chartâ€¦
         Size myPieSize = new Size(250, 250);

         //Check if sections add up to 100.
         int sum = 0;
         foreach (int percent_loopVariable in myPiePerecents)
         {
            sum += percent_loopVariable;
         }

         if (sum != 100)
         {
            this.Text = "Sum Do Not Add Up To 100. it is : " + sum;
         }

         //Check Here Number Of Values & Colors Are Same Or Not.They Must Be Same.
         if (myPiePerecents.Length != myPieColors.Length)
         {
            this.Text = "There Must Be The Same Number Of Percents And Colors.";
         }

         int PiePercentTotal = 0;
         for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
         {
            using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
            {

               //Here it Will Convert Each Value Into 360, So Total Into 360 & Then It Will Draw A Full Pie Chart.
               myPieGraphic.FillPie(brush, new Rectangle(new Point (10,10), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
            }

            PiePercentTotal += myPiePerecents[PiePercents];
         }
      }
      public void DrawPieChart(float[] myPiePerecents, Color[] myPieColors)
      {
         myPieGraphic.Clear(Color.White);
         Point myPieLocation = new Point(10, 10);

         //Set Here Size Of The Chartâ€¦
         Size myPieSize = new Size(250, 250);

         //Check if sections add up to 100.
         float sum = 0;
         foreach (float percent_loopVariable in myPiePerecents)
         {
            sum += percent_loopVariable;
         }


         //Check Here Number Of Values & Colors Are Same Or Not.They Must Be Same.
         if (myPiePerecents.Length != myPieColors.Length)
         {
            this.Text = "There Must Be The Same Number Of Percents And Colors.";
         }

         float PiePercentTotal = 0;
         for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
         {
            using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
            {

               //Here it Will Convert Each Value Into 360, So Total Into 360 & Then It Will Draw A Full Pie Chart.
               myPieGraphic.FillPie(brush, new Rectangle(new Point(10, 10), myPieSize), Convert.ToSingle(PiePercentTotal * 360.0f / 100.0f), Convert.ToSingle(myPiePerecents[PiePercents] * 360.0f / sum));
            }

            PiePercentTotal += myPiePerecents[PiePercents];
         }
      }

#endif
      private void PieChart_Load(object sender, EventArgs e)
      {

      }

      private void ApieChartPlease_Click(object sender, EventArgs e)
      {
         this.Hide();
      }

      public void DrawPieChart(List<TrackerDescription> TrackerDescriptions, Dictionary<string, int> TimeSpent)
      {
         ApieChartPlease.Series.Clear();
         ApieChartPlease.Legends.Clear();

         //Add a new Legend(if needed) and do some formating
         ApieChartPlease.Legends.Add("MyLegend");
         ApieChartPlease.Legends[0].LegendStyle = LegendStyle.Table;
         ApieChartPlease.Legends[0].Docking = Docking.Bottom;
         ApieChartPlease.Legends[0].Alignment = StringAlignment.Center;
         ApieChartPlease.Legends[0].Title = "Time Spent";
         ApieChartPlease.Legends[0].BorderColor = Color.Black;

         //Add a new chart-series
         string seriesname = "Time Spent";
         ApieChartPlease.Series.Add(seriesname);
         //set the chart-type to "Pie"
         ApieChartPlease.Series[seriesname].ChartType = SeriesChartType.Pie;


         // Reminder X++ returns X and then increments it. ++X increments X and then returns it.
         //  this makes ++X more efficient than X++.
         //  this also means we can use X++ in the for loop and not have to worry about the increment

         int fakex = 0;
         for(int x = 0; x < TrackerDescriptions.Count();++x)
         {
            //Add some datapoints so the series. in this case you can pass the values to this method
            if (TimeSpent.ContainsKey(TrackerDescriptions[x].Task) && TimeSpent[TrackerDescriptions[x].Task] > 0)
            {
               ApieChartPlease.Series[seriesname].Points.AddXY( TrackerDescriptions[x].Task + " | " + (float)(TimeSpent[TrackerDescriptions[x].Task]) / 360.0f + " hours", TimeSpent[TrackerDescriptions[x].Task]);
               ApieChartPlease.Series[seriesname].Points[fakex++].Color = TrackerDescriptions[x].Color; 
            }
         }


      }
   }
}
