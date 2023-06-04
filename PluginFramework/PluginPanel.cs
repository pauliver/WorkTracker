using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginArchitecture
{
   public partial class PluginPanel : UserControl
   {
      protected PluginManager PluginManager = null;
      public PluginPanel()
      {
         InitializeComponent();
      }
      public void SetPluginManager(PluginManager pluginManager)
      {
         PluginManager = pluginManager;
      }

      private void PluginPanel_Load(object sender, EventArgs e)
      {
         OptionsView.Clear();
         if(PluginManager == null)
         {
            Debugger.Break();
            Debugger.Log(2, "PluginManager", "PluginManager is null");
            return;
         }

         foreach (var item in PluginManager.Plugins)
         {
            OptionsView.Items.Add(item.Name);
         }
         if (OptionsView.Items.Count > 0)
         {
            OptionsView.Items[0].Selected = true;
         }

      }

      private void OptionsView_SelectedIndexChanged(object sender, EventArgs e)
      {

         TDPropertyGrid.SelectedObjects = null;
         ListView.SelectedListViewItemCollection selected = this.OptionsView.SelectedItems;
         if (selected != null && selected.Count > 0)
         {
            List<Object> selected_objects = new List<object>();
            foreach (ListViewItem selected_item in selected)
            {
               if (selected_item != null && selected_item.Text.Trim() != "")
               {
                  var displayobject = this.PluginManager.GetPluginByName(selected_item.Text);
                  if (displayobject != null)
                  {
                     selected_objects.Add(displayobject);
                  }
                  else
                  {
                     Debugger.Break();
                     Debugger.Log(2, "Invalid Selection", "Display Object, in the options menu, is invalid");
                  }
               }
            }
            TDPropertyGrid.SelectedObjects = selected_objects.ToArray();
         }
      }
   }
}
