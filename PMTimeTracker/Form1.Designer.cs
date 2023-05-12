namespace PMTimeTracker
{
   partial class TimeTracking
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeTracking));
         this.ExitBtn = new System.Windows.Forms.Button();
         this.HideBtn = new System.Windows.Forms.Button();
         this.Timer = new System.Windows.Forms.Timer(this.components);
         this.DrawingPanel = new System.Windows.Forms.Panel();
         this.SuspendLayout();
         // 
         // ExitBtn
         // 
         this.ExitBtn.Location = new System.Drawing.Point(564, 12);
         this.ExitBtn.Name = "ExitBtn";
         this.ExitBtn.Size = new System.Drawing.Size(67, 26);
         this.ExitBtn.TabIndex = 0;
         this.ExitBtn.Text = "Exit";
         this.ExitBtn.UseVisualStyleBackColor = true;
         this.ExitBtn.Click += new System.EventHandler(this.Exit_Click);
         // 
         // HideBtn
         // 
         this.HideBtn.Location = new System.Drawing.Point(564, 432);
         this.HideBtn.Name = "HideBtn";
         this.HideBtn.Size = new System.Drawing.Size(67, 26);
         this.HideBtn.TabIndex = 1;
         this.HideBtn.Text = "Hide";
         this.HideBtn.UseVisualStyleBackColor = true;
         this.HideBtn.Click += new System.EventHandler(this.Hide_Click);
         // 
         // Timer
         // 
         this.Timer.Interval = 1000;
         this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
         // 
         // DrawingPanel
         // 
         this.DrawingPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawingPanel.BackgroundImage")));
         this.DrawingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.DrawingPanel.ForeColor = System.Drawing.SystemColors.Window;
         this.DrawingPanel.Location = new System.Drawing.Point(1, 3);
         this.DrawingPanel.Name = "DrawingPanel";
         this.DrawingPanel.Size = new System.Drawing.Size(637, 466);
         this.DrawingPanel.TabIndex = 2;
         this.DrawingPanel.DoubleClick += new System.EventHandler(this.DrawingPanel_Click);
         // 
         // TimeTracking
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.ClientSize = new System.Drawing.Size(634, 461);
         this.ControlBox = false;
         this.Controls.Add(this.DrawingPanel);
         this.Controls.Add(this.HideBtn);
         this.Controls.Add(this.ExitBtn);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TimeTracking";
         this.Text = "Time Tracking";
         this.TopMost = true;
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button ExitBtn;
      private System.Windows.Forms.Button HideBtn;
      private System.Windows.Forms.Timer Timer;
      private System.Windows.Forms.Panel DrawingPanel;
   }
}

