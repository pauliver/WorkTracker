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
      }
   }
}
