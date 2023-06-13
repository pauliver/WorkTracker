using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;

namespace OutlookPlugin
{
    public partial class ThisAddIn
   {
      public static Microsoft.Office.Interop.Outlook.Application OA;

      Outlook.Inspectors inspectors;
      Outlook.Reminders reminders;

      OutlookComsPlugin.Client client;

      private void ThisAddIn_Startup(object sender, System.EventArgs e)
      {
         client = new OutlookComsPlugin.Client();

         OA = this.Application;
         inspectors = OA.Inspectors;
         reminders = OA.Reminders;
         inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
         reminders.ReminderFire += new Microsoft.Office.Interop.Outlook.ReminderCollectionEvents_ReminderFireEventHandler( Reminders_ReminderFire);
      }

      private void Reminders_ReminderFire(Reminder ReminderObject)
      {
         if (ReminderObject == null)
         {
            return;
         }else if (ReminderObject is Outlook.AppointmentItem)
         {
            Outlook.AppointmentItem RAI = (Outlook.AppointmentItem)ReminderObject;
     
         }else if(ReminderObject is Outlook.TaskItem)
         {
            Outlook.TaskItem RAI = (Outlook.TaskItem)ReminderObject;
         }
         else if(ReminderObject is Outlook.Reminder)
         {
            Outlook.Reminder RAI = (Outlook.Reminder) ReminderObject;
            
         }
      }

      void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
      {
         Outlook.MeetingItem meetingItem = Inspector.CurrentItem as Outlook.MeetingItem;
         if (meetingItem != null)
         {

         }

         Outlook.AppointmentItem appointmentItem = Inspector.CurrentItem as Outlook.AppointmentItem;
         if(appointmentItem != null)
         {

         }
      }

      private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
      {
         // Note: Outlook no longer raises this event. If you have code that 
         //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
      }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
