using DriveEasyApplication.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace DriveEasyApplication.Web.Mvc.Services
{
    public class EasyDriveDbServices : Sqlite, IEasyDriveDbService, IDisposable
    {
        private bool disposed = false;

        private IntPtr handle;

        private Component component = new Component();
        public EasyDriveDbServices() : base("EasyDrive")
        {

        }

        public EasyDriveDbServices(string dbName) : base(dbName)
        {

        }

        public long? Add<T>(T data)
        {
            switch (data)
            {
                case Candidate candidate:
                    return InsertData(DbName, "Candidate", candidate.ToDictionary());
                    break;
                case Drive drive:
                    return InsertData(DbName, "Drive", drive.ToDictionary());
                    break;
                case Panel panel:
                    return InsertData(DbName, "Panel", panel.ToDictionary());
                    break;
                case PanelAvailability panelAvailability:
                    return InsertData(DbName, "PanelAvailability", panelAvailability.ToDictionary());
                    break;
            }

            return null;
        }

        public void Add<T>(IList<T> data)
        {
            switch (data)
            {
                case  List<Candidate> candidates:
                    foreach (var candidate in candidates)
                    {
                        Add(candidate);
                    }
                    break;

                case List<Drive> drives:
                    foreach (var drive in drives)
                    {
                        Add(drive);
                    }
                    break;

                case List<Panel> panels:
                    foreach (var panel in panels)
                    {
                        Add(panel);
                    }
                    break;

                case List<PanelAvailability> panelAvailabilities:
                    foreach (var panelAvailability in panelAvailabilities)
                    {
                        Add(panelAvailability);
                    }
                    break;
            }
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public IList<T> Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public void Edit<T>(T data)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~EasyDriveDbServices()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(disposing: false) is optimal in terms of
            // readability and maintainability.
            Dispose(disposing: false);
        }
    }
}