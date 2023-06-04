namespace PluginArchitecture
{
   partial class PluginPanel
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.OptionsView = new System.Windows.Forms.ListView();
         this.ActivatePlugin = new System.Windows.Forms.Button();
         this.DeactivatePlugin = new System.Windows.Forms.Button();
         this.LoadPlugin = new System.Windows.Forms.Button();
         this.TDPropertyGrid = new System.Windows.Forms.PropertyGrid();
         this.UnloadPlugin = new System.Windows.Forms.Button();
         this.RefreshPlugins = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
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
         this.OptionsView.Location = new System.Drawing.Point(19, 7);
         this.OptionsView.Margin = new System.Windows.Forms.Padding(4);
         this.OptionsView.Name = "OptionsView";
         this.OptionsView.Size = new System.Drawing.Size(353, 153);
         this.OptionsView.TabIndex = 14;
         this.OptionsView.UseCompatibleStateImageBehavior = false;
         this.OptionsView.View = System.Windows.Forms.View.List;
         this.OptionsView.SelectedIndexChanged += new System.EventHandler(this.OptionsView_SelectedIndexChanged);
         // 
         // ActivatePlugin
         // 
         this.ActivatePlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.ActivatePlugin.Location = new System.Drawing.Point(379, 7);
         this.ActivatePlugin.Name = "ActivatePlugin";
         this.ActivatePlugin.Size = new System.Drawing.Size(144, 47);
         this.ActivatePlugin.TabIndex = 11;
         this.ActivatePlugin.Text = "&Activate Plugin";
         this.ActivatePlugin.UseVisualStyleBackColor = true;
         // 
         // DeactivatePlugin
         // 
         this.DeactivatePlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.DeactivatePlugin.Location = new System.Drawing.Point(379, 60);
         this.DeactivatePlugin.Name = "DeactivatePlugin";
         this.DeactivatePlugin.Size = new System.Drawing.Size(144, 47);
         this.DeactivatePlugin.TabIndex = 12;
         this.DeactivatePlugin.Text = "&DeActivate Plugin";
         this.DeactivatePlugin.UseVisualStyleBackColor = true;
         // 
         // LoadPlugin
         // 
         this.LoadPlugin.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.LoadPlugin.Location = new System.Drawing.Point(130, 167);
         this.LoadPlugin.Name = "LoadPlugin";
         this.LoadPlugin.Size = new System.Drawing.Size(118, 47);
         this.LoadPlugin.TabIndex = 10;
         this.LoadPlugin.Text = "&Load Plugin";
         this.LoadPlugin.UseVisualStyleBackColor = true;
         // 
         // TDPropertyGrid
         // 
         this.TDPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.TDPropertyGrid.Location = new System.Drawing.Point(21, 272);
         this.TDPropertyGrid.Name = "TDPropertyGrid";
         this.TDPropertyGrid.Size = new System.Drawing.Size(502, 331);
         this.TDPropertyGrid.TabIndex = 13;
         // 
         // UnloadPlugin
         // 
         this.UnloadPlugin.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.UnloadPlugin.Location = new System.Drawing.Point(254, 167);
         this.UnloadPlugin.Name = "UnloadPlugin";
         this.UnloadPlugin.Size = new System.Drawing.Size(118, 47);
         this.UnloadPlugin.TabIndex = 15;
         this.UnloadPlugin.Text = "&UnloadPlugin";
         this.UnloadPlugin.UseVisualStyleBackColor = true;
         // 
         // RefreshPlugins
         // 
         this.RefreshPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.RefreshPlugins.Location = new System.Drawing.Point(379, 167);
         this.RefreshPlugins.Name = "RefreshPlugins";
         this.RefreshPlugins.Size = new System.Drawing.Size(144, 47);
         this.RefreshPlugins.TabIndex = 16;
         this.RefreshPlugins.Text = "RefreshPlugins";
         this.RefreshPlugins.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(6, 167);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(118, 47);
         this.button1.TabIndex = 17;
         this.button1.Text = "Scan for Plugins";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // PluginPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.button1);
         this.Controls.Add(this.RefreshPlugins);
         this.Controls.Add(this.UnloadPlugin);
         this.Controls.Add(this.OptionsView);
         this.Controls.Add(this.ActivatePlugin);
         this.Controls.Add(this.DeactivatePlugin);
         this.Controls.Add(this.LoadPlugin);
         this.Controls.Add(this.TDPropertyGrid);
         this.Name = "PluginPanel";
         this.Size = new System.Drawing.Size(542, 606);
         this.Load += new System.EventHandler(this.PluginPanel_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListView OptionsView;
      private System.Windows.Forms.Button ActivatePlugin;
      private System.Windows.Forms.Button DeactivatePlugin;
      private System.Windows.Forms.Button LoadPlugin;
      private System.Windows.Forms.PropertyGrid TDPropertyGrid;
      private System.Windows.Forms.Button UnloadPlugin;
      private System.Windows.Forms.Button RefreshPlugins;
      private System.Windows.Forms.Button button1;
   }
}
