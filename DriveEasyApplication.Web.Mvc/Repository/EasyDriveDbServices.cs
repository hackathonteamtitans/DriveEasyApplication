using DriveEasyApplication.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DriveEasyApplication.Web.Mvc.Services
{
    public class EasyDriveDbServices : Sqlite, IEasyDriveDbService
    {
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

        private static List<T> ConvertDataTable<T>(DataTable dt)
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
    }
}