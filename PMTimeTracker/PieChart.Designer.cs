namespace PMTimeTracker
{
   partial class PieChart
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.ApieChartPlease = new System.Windows.Forms.DataVisualization.Charting.Chart();
         ((System.ComponentModel.ISupportInitialize)(this.ApieChartPlease)).BeginInit();
         this.SuspendLayout();
         // 
         // ApieChartPlease
         // 
         this.ApieChartPlease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         chartArea1.Name = "ChartArea1";
         this.ApieChartPlease.ChartAreas.Add(chartArea1);
         legend1.Name = "Legend1";
         this.ApieChartPlease.Legends.Add(legend1);
         this.ApieChartPlease.Location = new System.Drawing.Point(1, 0);
         this.ApieChartPlease.Name = "ApieChartPlease";
         series1.ChartArea = "ChartArea1";
         series1.Legend = "Legend1";
         series1.Name = "Series1";
         this.ApieChartPlease.Series.Add(series1);
         this.ApieChartPlease.Size = new System.Drawing.Size(379, 322);
         this.ApieChartPlease.TabIndex = 0;
         this.ApieChartPlease.Text = "chart1";
         this.ApieChartPlease.Click += new System.EventHandler(this.ApieChartPlease_Click_1);
         this.ApieChartPlease.DoubleClick += new System.EventHandler(this.ApieChartPlease_Click);
         // 
         // PieChart
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(379, 321);
         this.Controls.Add(this.ApieChartPlease);
         this.Margin = new System.Windows.Forms.Padding(4);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PieChart";
         this.Text = "PieChart";
         this.Load += new System.EventHandler(this.PieChart_Load);
         ((System.ComponentModel.ISupportInitialize)(this.ApieChartPlease)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataVisualization.Charting.Chart ApieChartPlease;
   }
}