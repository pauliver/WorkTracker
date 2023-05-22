using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PMTimeTracker
{
   public class IndividualSettings<T> where T : IEnumerable, new()
   {
      protected System.IO.FileInfo SettingsFile { get; set; }
      public IndividualSettings(FileInfo settingsFile)
      {
         SettingsFile = settingsFile;
      }

      public T SettingsObject { get; set; }


      // Don't pass around the settings object, passs around the settings
      public static explicit operator T(IndividualSettings<T> settings)
      {
         return settings.SettingsObject;
      }

      virtual public void Create()
      {
         var fi = SettingsFile;
         if (fi.Exists)
         {
            //return;
         }
         var serializer = new JavaScriptSerializer();
         try
         {
            var serializedResult = serializer.Serialize(SettingsObject);
            System.IO.File.WriteAllText(fi.FullName, serializedResult);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      virtual public void Load()
      {
         var serializer = new JavaScriptSerializer();
         try
         {
            var fi = SettingsFile;
            if (!fi.Exists)
            {
               return;
            }
            var searilizationstring = System.IO.File.ReadAllText(fi.FullName);
            var deserializedResult = serializer.Deserialize<T>(searilizationstring);
            if (deserializedResult == null)
            {
               Debugger.Break();
            }
            SettingsObject = deserializedResult;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      virtual public void Save()
      {
         var serializer = new JavaScriptSerializer();
         try
         {
            var fi = SettingsFile;

            var serializedResult = serializer.Serialize(SettingsObject);
            System.IO.File.WriteAllText(fi.FullName, serializedResult);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

   }

   public class IndividualSettingsDictionary<T,X,Y> :   IndividualSettings<T> 
      where T : IDictionary<X,Y>, IEnumerable, new()
      //where X : new()
      //where Y : new()
   {
      public IndividualSettingsDictionary(FileInfo settingsFile):base
         (settingsFile)
      {
      }

      virtual public void RefreshSave()
      {
         var serializer = new JavaScriptSerializer();
         T UpdateObject = new T();
         try
         {
            var fi = base.SettingsFile;
            if (fi.Exists)
            {
               var searilizationstring = System.IO.File.ReadAllText(fi.FullName);
               UpdateObject = serializer.Deserialize<T>(searilizationstring);
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
         {
            foreach (var item in SettingsObject)
            {
               if (UpdateObject.ContainsKey(item.Key))
               {
                  UpdateObject[item.Key] = item.Value; // Replace the old value completely
               }
               else
               {
                  UpdateObject.Add(item.Key, item.Value); // Add the new values
               }
            }
         }
         try
         {
            var fi = base.SettingsFile;

            var serializedResult = serializer.Serialize(UpdateObject);
            System.IO.File.WriteAllText(fi.FullName, serializedResult);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
   }
}
