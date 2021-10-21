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

        public void Add<T>(T data)
        {
            switch (data)
            {
                case Candidate candidate:
                    InsertData(DbName, "Candidate", candidate.ToDictionary());
                    break;
                case Drive drive:
                    var result = InsertData(DbName, "Drive", drive.ToDictionary());
                    break;
                case Panel panel:
                    InsertData(DbName, "Panel", panel.ToDictionary());
                    break;
                case PanelAvailability panelAvailability:
                    InsertData(DbName, "PanelAvailability", panelAvailability.ToDictionary());
                    break;
            }
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

        public List<Panel> GetPanel(string colName, object value)
        {
            List<Panel> panel = new List<Panel>();
            DataTable dataTable = ExecuteQuerry($"Select * from Panel where {colName} = '{value}'");

            foreach (DataRow row in dataTable.Rows)
            {
                panel.Add(new Panel(row));
            }
            return panel;
        }

        public List<Candidate> GetCandidate(string colName, object value)
        {
            throw new NotImplementedException();
        }
    }
}