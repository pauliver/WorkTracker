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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.PieChartPage = new System.Windows.Forms.TabPage();
         this.ApieChartPlease = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.BarGraphPage = new System.Windows.Forms.TabPage();
         this.BarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.SettingsPage = new System.Windows.Forms.TabPage();
         this.button6 = new System.Windows.Forms.Button();
         this.button5 = new System.Windows.Forms.Button();
         this.button4 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.TDPropertyGrid = new System.Windows.Forms.PropertyGrid();
         this.button1 = new System.Windows.Forms.Button();
         this.OptionsView = new System.Windows.Forms.ListView();
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
         this.tabControl1.Location = new System.Drawing.Point(0, 2);
         this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(1014, 1063);
         this.tabControl1.TabIndex = 0;
         // 
         // PieChartPage
         // 
         this.PieChartPage.Controls.Add(this.ApieChartPlease);
         this.PieChartPage.Location = new System.Drawing.Point(8, 39);
         this.PieChartPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.PieChartPage.Name = "PieChartPage";
         this.PieChartPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.PieChartPage.Size = new System.Drawing.Size(1036, 1016);
         this.PieChartPage.TabIndex = 0;
         this.PieChartPage.Text = "PieChart";
         this.PieChartPage.UseVisualStyleBackColor = true;
         // 
         // ApieChartPlease
         // 
         this.ApieChartPlease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         chartArea9.Name = "ChartArea1";
         this.ApieChartPlease.ChartAreas.Add(chartArea9);
         legend9.Name = "Legend1";
         this.ApieChartPlease.Legends.Add(legend9);
         this.ApieChartPlease.Location = new System.Drawing.Point(4, 4);
         this.ApieChartPlease.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.ApieChartPlease.Name = "ApieChartPlease";
         series9.ChartArea = "ChartArea1";
         series9.Legend = "Legend1";
         series9.Name = "Series1";
         this.ApieChartPlease.Series.Add(series9);
         this.ApieChartPlease.Size = new System.Drawing.Size(1036, 1010);
         this.ApieChartPlease.TabIndex = 1;
         this.ApieChartPlease.Text = "chart1";
         // 
         // BarGraphPage
         // 
         this.BarGraphPage.Controls.Add(this.BarChart);
         this.BarGraphPage.Location = new System.Drawing.Point(8, 39);
         this.BarGraphPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.BarGraphPage.Name = "BarGraphPage";
         this.BarGraphPage.Size = new System.Drawing.Size(1036, 1016);
         this.BarGraphPage.TabIndex = 2;
         this.BarGraphPage.Text = "Second Data Visualization";
         this.BarGraphPage.UseVisualStyleBackColor = true;
         // 
         // BarChart
         // 
         this.BarChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         chartArea10.Name = "ChartArea1";
         this.BarChart.ChartAreas.Add(chartArea10);
         legend10.Name = "Legend1";
         this.BarChart.Legends.Add(legend10);
         this.BarChart.Location = new System.Drawing.Point(4, 4);
         this.BarChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.BarChart.Name = "BarChart";
         series10.ChartArea = "ChartArea1";
         series10.Legend = "Legend1";
         series10.Name = "Series1";
         this.BarChart.Series.Add(series10);
         this.BarChart.Size = new System.Drawing.Size(1036, 1010);
         this.BarChart.TabIndex = 2;
         this.BarChart.Text = "chart1";
         // 
         // SettingsPage
         // 
         this.SettingsPage.Controls.Add(this.OptionsView);
         this.SettingsPage.Controls.Add(this.button6);
         this.SettingsPage.Controls.Add(this.button5);
         this.SettingsPage.Controls.Add(this.button4);
         this.SettingsPage.Controls.Add(this.button3);
         this.SettingsPage.Controls.Add(this.button2);
         this.SettingsPage.Controls.Add(this.TDPropertyGrid);
         this.SettingsPage.Controls.Add(this.button1);
         this.SettingsPage.Location = new System.Drawing.Point(8, 39);
         this.SettingsPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.SettingsPage.Name = "SettingsPage";
         this.SettingsPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.SettingsPage.Size = new System.Drawing.Size(998, 1016);
         this.SettingsPage.TabIndex = 1;
         this.SettingsPage.Text = "Settings";
         this.SettingsPage.UseVisualStyleBackColor = true;
         this.SettingsPage.Click += new System.EventHandler(this.SettingsPage_Click);
         // 
         // button6
         // 
         this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button6.Location = new System.Drawing.Point(760, 375);
         this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.button6.Name = "button6";
         this.button6.Size = new System.Drawing.Size(216, 73);
         this.button6.TabIndex = 3;
         this.button6.Text = "&Update UserTime";
         this.button6.UseVisualStyleBackColor = true;
         this.button6.Click += new System.EventHandler(this.button6_Click);
         // 
         // button5
         // 
         this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button5.Location = new System.Drawing.Point(760, 594);
         this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.button5.Name = "button5";
         this.button5.Size = new System.Drawing.Size(216, 73);
         this.button5.TabIndex = 5;
         this.button5.Text = "&About";
         this.button5.UseVisualStyleBackColor = true;
         this.button5.Click += new System.EventHandler(this.button5_Click);
         // 
         // button4
         // 
         this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button4.Location = new System.Drawing.Point(760, 483);
         this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.button4.Name = "button4";
         this.button4.Size = new System.Drawing.Size(216, 73);
         this.button4.TabIndex = 4;
         this.button4.Text = "&GitHub";
         this.button4.UseVisualStyleBackColor = true;
         this.button4.Click += new System.EventHandler(this.button4_Click);
         // 
         // button3
         // 
         this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button3.Location = new System.Drawing.Point(760, 710);
         this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(216, 73);
         this.button3.TabIndex = 7;
         this.button3.Text = "&Close";
         this.button3.UseVisualStyleBackColor = true;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.Location = new System.Drawing.Point(760, 269);
         this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(216, 73);
         this.button2.TabIndex = 2;
         this.button2.Text = "&ReLoad Optioms";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // TDPropertyGrid
         // 
         this.TDPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.TDPropertyGrid.Location = new System.Drawing.Point(10, 352);
         this.TDPropertyGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.TDPropertyGrid.Name = "TDPropertyGrid";
         this.TDPropertyGrid.Size = new System.Drawing.Size(730, 658);
         this.TDPropertyGrid.TabIndex = 8;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.Location = new System.Drawing.Point(760, 165);
         this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(216, 73);
         this.button1.TabIndex = 1;
         this.button1.Text = "&Save Options";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // OptionsView
         // 
         this.OptionsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.OptionsView.BackColor = System.Drawing.SystemColors.Window;
         this.OptionsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.OptionsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.OptionsView.ForeColor = System.Drawing.Color.Black;
         this.OptionsView.HideSelection = false;
         this.OptionsView.Location = new System.Drawing.Point(7, 6);
         this.OptionsView.Margin = new System.Windows.Forms.Padding(6);
         this.OptionsView.Name = "OptionsView";
         this.OptionsView.Size = new System.Drawing.Size(732, 336);
         this.OptionsView.TabIndex = 9;
         this.OptionsView.UseCompatibleStateImageBehavior = false;
         this.OptionsView.View = System.Windows.Forms.View.List;
         this.OptionsView.SelectedIndexChanged += new System.EventHandler(this.OptionsView_SelectedIndexChanged);
         // 
         // PieChart
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1014, 1075);
         this.Controls.Add(this.tabControl1);
         this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
      private System.Windows.Forms.Button button5;
      private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListView OptionsView;
    }
}