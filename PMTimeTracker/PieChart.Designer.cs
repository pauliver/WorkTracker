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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.PieChartPage = new System.Windows.Forms.TabPage();
         this.ApieChartPlease = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.BarGraphPage = new System.Windows.Forms.TabPage();
         this.BarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.SettingsPage = new System.Windows.Forms.TabPage();
         this.button4 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.TDPropertyGrid = new System.Windows.Forms.PropertyGrid();
         this.button1 = new System.Windows.Forms.Button();
         this.tabControl1.SuspendLayout();
         this.PieChartPage.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ApieChartPlease)).BeginInit();
         this.BarGraphPage.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.BarChart)).BeginInit();
         this.SettingsPage.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.PieChartPage);
         this.tabControl1.Controls.Add(this.BarGraphPage);
         this.tabControl1.Controls.Add(this.SettingsPage);
         this.tabControl1.Location = new System.Drawing.Point(0, 1);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(702, 681);
         this.tabControl1.TabIndex = 1;
         // 
         // PieChartPage
         // 
         this.PieChartPage.Controls.Add(this.ApieChartPlease);
         this.PieChartPage.Location = new System.Drawing.Point(4, 25);
         this.PieChartPage.Name = "PieChartPage";
         this.PieChartPage.Padding = new System.Windows.Forms.Padding(3);
         this.PieChartPage.Size = new System.Drawing.Size(694, 652);
         this.PieChartPage.TabIndex = 0;
         this.PieChartPage.Text = "PieChart";
         this.PieChartPage.UseVisualStyleBackColor = true;
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
         this.ApieChartPlease.Location = new System.Drawing.Point(3, 3);
         this.ApieChartPlease.Name = "ApieChartPlease";
         series1.ChartArea = "ChartArea1";
         series1.Legend = "Legend1";
         series1.Name = "Series1";
         this.ApieChartPlease.Series.Add(series1);
         this.ApieChartPlease.Size = new System.Drawing.Size(691, 646);
         this.ApieChartPlease.TabIndex = 1;
         this.ApieChartPlease.Text = "chart1";
         // 
         // BarGraphPage
         // 
         this.BarGraphPage.Controls.Add(this.BarChart);
         this.BarGraphPage.Location = new System.Drawing.Point(4, 25);
         this.BarGraphPage.Name = "BarGraphPage";
         this.BarGraphPage.Size = new System.Drawing.Size(694, 652);
         this.BarGraphPage.TabIndex = 2;
         this.BarGraphPage.Text = "Second Data Visualization";
         this.BarGraphPage.UseVisualStyleBackColor = true;
         // 
         // BarChart
         // 
         this.BarChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         chartArea2.Name = "ChartArea1";
         this.BarChart.ChartAreas.Add(chartArea2);
         legend2.Name = "Legend1";
         this.BarChart.Legends.Add(legend2);
         this.BarChart.Location = new System.Drawing.Point(2, 3);
         this.BarChart.Name = "BarChart";
         series2.ChartArea = "ChartArea1";
         series2.Legend = "Legend1";
         series2.Name = "Series1";
         this.BarChart.Series.Add(series2);
         this.BarChart.Size = new System.Drawing.Size(691, 646);
         this.BarChart.TabIndex = 2;
         this.BarChart.Text = "chart1";
         // 
         // SettingsPage
         // 
         this.SettingsPage.Controls.Add(this.button4);
         this.SettingsPage.Controls.Add(this.button3);
         this.SettingsPage.Controls.Add(this.button2);
         this.SettingsPage.Controls.Add(this.TDPropertyGrid);
         this.SettingsPage.Controls.Add(this.button1);
         this.SettingsPage.Location = new System.Drawing.Point(4, 25);
         this.SettingsPage.Name = "SettingsPage";
         this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
         this.SettingsPage.Size = new System.Drawing.Size(694, 652);
         this.SettingsPage.TabIndex = 1;
         this.SettingsPage.Text = "Settings";
         this.SettingsPage.UseVisualStyleBackColor = true;
         this.SettingsPage.Click += new System.EventHandler(this.SettingsPage_Click);
         // 
         // button4
         // 
         this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button4.Location = new System.Drawing.Point(463, 160);
         this.button4.Name = "button4";
         this.button4.Size = new System.Drawing.Size(144, 47);
         this.button4.TabIndex = 5;
         this.button4.Text = "button4";
         this.button4.UseVisualStyleBackColor = true;
         // 
         // button3
         // 
         this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button3.Location = new System.Drawing.Point(463, 243);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(144, 47);
         this.button3.TabIndex = 4;
         this.button3.Text = "button3";
         this.button3.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.Location = new System.Drawing.Point(463, 91);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(144, 47);
         this.button2.TabIndex = 3;
         this.button2.Text = "button2";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // TDPropertyGrid
         // 
         this.TDPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.TDPropertyGrid.Location = new System.Drawing.Point(7, 7);
         this.TDPropertyGrid.Name = "TDPropertyGrid";
         this.TDPropertyGrid.Size = new System.Drawing.Size(346, 639);
         this.TDPropertyGrid.TabIndex = 1;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.Location = new System.Drawing.Point(463, 25);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(144, 47);
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // PieChart
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(701, 688);
         this.Controls.Add(this.tabControl1);
         this.Margin = new System.Windows.Forms.Padding(4);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PieChart";
         this.Text = "PieChart";
         this.Load += new System.EventHandler(this.PieChart_Load);
         this.tabControl1.ResumeLayout(false);
         this.PieChartPage.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.ApieChartPlease)).EndInit();
         this.BarGraphPage.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.BarChart)).EndInit();
         this.SettingsPage.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage PieChartPage;
      private System.Windows.Forms.DataVisualization.Charting.Chart ApieChartPlease;
      private System.Windows.Forms.TabPage SettingsPage;
      private System.Windows.Forms.TabPage BarGraphPage;
      private System.Windows.Forms.DataVisualization.Charting.Chart BarChart;
      private System.Windows.Forms.Button button4;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.PropertyGrid TDPropertyGrid;
      private System.Windows.Forms.Button button1;
   }
}