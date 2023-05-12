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
         this.HideBtn = new System.Windows.Forms.Button();
         this.Timer = new System.Windows.Forms.Timer(this.components);
         this.DrawingPanel = new System.Windows.Forms.Panel();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.StartTracking = new System.Windows.Forms.Button();
         this.StopTracking = new System.Windows.Forms.Button();
         this.OptionsView = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // HideBtn
         // 
         this.HideBtn.BackColor = System.Drawing.Color.Transparent;
         this.HideBtn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
         this.HideBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.HideBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.HideBtn.ForeColor = System.Drawing.Color.Yellow;
         this.HideBtn.Location = new System.Drawing.Point(563, 405);
         this.HideBtn.Name = "HideBtn";
         this.HideBtn.Size = new System.Drawing.Size(67, 49);
         this.HideBtn.TabIndex = 1;
         this.HideBtn.Text = "Hide";
         this.HideBtn.UseVisualStyleBackColor = false;
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
         this.DrawingPanel.Location = new System.Drawing.Point(537, 464);
         this.DrawingPanel.Name = "DrawingPanel";
         this.DrawingPanel.Size = new System.Drawing.Size(637, 466);
         this.DrawingPanel.TabIndex = 2;
         this.DrawingPanel.DoubleClick += new System.EventHandler(this.DrawingPanel_Click);
         // 
         // progressBar1
         // 
         this.progressBar1.Location = new System.Drawing.Point(5, 3);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(625, 21);
         this.progressBar1.TabIndex = 3;
         // 
         // StartTracking
         // 
         this.StartTracking.BackColor = System.Drawing.Color.Transparent;
         this.StartTracking.FlatAppearance.BorderColor = System.Drawing.Color.White;
         this.StartTracking.FlatAppearance.BorderSize = 2;
         this.StartTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.StartTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.StartTracking.ForeColor = System.Drawing.Color.Cornsilk;
         this.StartTracking.Location = new System.Drawing.Point(231, 397);
         this.StartTracking.Name = "StartTracking";
         this.StartTracking.Size = new System.Drawing.Size(179, 55);
         this.StartTracking.TabIndex = 5;
         this.StartTracking.Text = "TRACK TIME";
         this.StartTracking.UseVisualStyleBackColor = false;
         this.StartTracking.Click += new System.EventHandler(this.StartTracking_Click);
         // 
         // StopTracking
         // 
         this.StopTracking.BackColor = System.Drawing.Color.Transparent;
         this.StopTracking.FlatAppearance.BorderColor = System.Drawing.Color.White;
         this.StopTracking.FlatAppearance.BorderSize = 2;
         this.StopTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.StopTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.StopTracking.ForeColor = System.Drawing.Color.Yellow;
         this.StopTracking.Location = new System.Drawing.Point(413, 410);
         this.StopTracking.Name = "StopTracking";
         this.StopTracking.Size = new System.Drawing.Size(147, 31);
         this.StopTracking.TabIndex = 6;
         this.StopTracking.Text = "Stop Tracking";
         this.StopTracking.UseVisualStyleBackColor = false;
         // 
         // OptionsView
         // 
         this.OptionsView.HideSelection = false;
         this.OptionsView.Location = new System.Drawing.Point(5, 30);
         this.OptionsView.Name = "OptionsView";
         this.OptionsView.Size = new System.Drawing.Size(130, 309);
         this.OptionsView.TabIndex = 7;
         this.OptionsView.UseCompatibleStateImageBehavior = false;
         this.OptionsView.View = System.Windows.Forms.View.List;
         this.OptionsView.SelectedIndexChanged += new System.EventHandler(this.OptionsView_SelectedIndexChanged);
         // 
         // TimeTracking
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.ClientSize = new System.Drawing.Size(634, 461);
         this.ControlBox = false;
         this.Controls.Add(this.OptionsView);
         this.Controls.Add(this.StopTracking);
         this.Controls.Add(this.StartTracking);
         this.Controls.Add(this.progressBar1);
         this.Controls.Add(this.DrawingPanel);
         this.Controls.Add(this.HideBtn);
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
      private System.Windows.Forms.Button HideBtn;
      private System.Windows.Forms.Timer Timer;
      private System.Windows.Forms.Panel DrawingPanel;
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.Button StartTracking;
      private System.Windows.Forms.Button StopTracking;
      private System.Windows.Forms.ListView OptionsView;
   }
}

