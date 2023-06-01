namespace TimeTracker
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
         this.ExpectedTime = new System.Windows.Forms.ProgressBar();
         this.StartTracking = new System.Windows.Forms.Button();
         this.StopTracking = new System.Windows.Forms.Button();
         this.OptionsView = new System.Windows.Forms.ListView();
         this.pluginTimer = new System.Windows.Forms.Timer(this.components);
         this.SuspendLayout();
         // 
         // HideBtn
         // 
         this.HideBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.HideBtn.BackColor = System.Drawing.Color.Transparent;
         this.HideBtn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
         this.HideBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.HideBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.HideBtn.ForeColor = System.Drawing.Color.Black;
         this.HideBtn.Location = new System.Drawing.Point(4, 313);
         this.HideBtn.Name = "HideBtn";
         this.HideBtn.Size = new System.Drawing.Size(130, 42);
         this.HideBtn.TabIndex = 4;
         this.HideBtn.Text = "Hide";
         this.HideBtn.UseVisualStyleBackColor = false;
         this.HideBtn.Click += new System.EventHandler(this.Hide_Click);
         // 
         // Timer
         // 
         this.Timer.Interval = 1000;
         this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
         // 
         // ExpectedTime
         // 
         this.ExpectedTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.ExpectedTime.Location = new System.Drawing.Point(12, 458);
         this.ExpectedTime.Name = "ExpectedTime";
         this.ExpectedTime.Size = new System.Drawing.Size(654, 21);
         this.ExpectedTime.TabIndex = 3;
         this.ExpectedTime.Visible = false;
         // 
         // StartTracking
         // 
         this.StartTracking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.StartTracking.BackColor = System.Drawing.Color.Transparent;
         this.StartTracking.FlatAppearance.BorderColor = System.Drawing.Color.White;
         this.StartTracking.FlatAppearance.BorderSize = 2;
         this.StartTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.StartTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.StartTracking.ForeColor = System.Drawing.Color.Cornsilk;
         this.StartTracking.Location = new System.Drawing.Point(231, 397);
         this.StartTracking.Name = "StartTracking";
         this.StartTracking.Size = new System.Drawing.Size(179, 55);
         this.StartTracking.TabIndex = 2;
         this.StartTracking.Text = "TRACK TIME";
         this.StartTracking.UseVisualStyleBackColor = false;
         this.StartTracking.Click += new System.EventHandler(this.StartTracking_Click);
         // 
         // StopTracking
         // 
         this.StopTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.StopTracking.BackColor = System.Drawing.Color.Transparent;
         this.StopTracking.Enabled = false;
         this.StopTracking.FlatAppearance.BorderColor = System.Drawing.Color.White;
         this.StopTracking.FlatAppearance.BorderSize = 2;
         this.StopTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.StopTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.StopTracking.ForeColor = System.Drawing.Color.Yellow;
         this.StopTracking.Location = new System.Drawing.Point(4, 361);
         this.StopTracking.Name = "StopTracking";
         this.StopTracking.Size = new System.Drawing.Size(130, 31);
         this.StopTracking.TabIndex = 3;
         this.StopTracking.Text = "Stop Tracking";
         this.StopTracking.UseVisualStyleBackColor = false;
         this.StopTracking.Visible = false;
         this.StopTracking.Click += new System.EventHandler(this.StopTracking_Click);
         // 
         // OptionsView
         // 
         this.OptionsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.OptionsView.BackColor = System.Drawing.SystemColors.Window;
         this.OptionsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.OptionsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.OptionsView.ForeColor = System.Drawing.Color.Black;
         this.OptionsView.HideSelection = false;
         this.OptionsView.Location = new System.Drawing.Point(4, 6);
         this.OptionsView.MultiSelect = false;
         this.OptionsView.Name = "OptionsView";
         this.OptionsView.Size = new System.Drawing.Size(267, 301);
         this.OptionsView.TabIndex = 1;
         this.OptionsView.UseCompatibleStateImageBehavior = false;
         this.OptionsView.View = System.Windows.Forms.View.List;
         this.OptionsView.SelectedIndexChanged += new System.EventHandler(this.OptionsView_SelectedIndexChanged);
         // 
         // pluginTimer
         // 
         this.pluginTimer.Enabled = true;
         this.pluginTimer.Tick += new System.EventHandler(this.pluginTimer_Tick);
         // 
         // TimeTracking
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.ClientSize = new System.Drawing.Size(671, 490);
         this.ControlBox = false;
         this.Controls.Add(this.OptionsView);
         this.Controls.Add(this.StopTracking);
         this.Controls.Add(this.StartTracking);
         this.Controls.Add(this.ExpectedTime);
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
      private System.Windows.Forms.ProgressBar ExpectedTime;
      private System.Windows.Forms.Button StartTracking;
      private System.Windows.Forms.Button StopTracking;
      private System.Windows.Forms.ListView OptionsView;
      private System.Windows.Forms.Timer pluginTimer;
   }
}

