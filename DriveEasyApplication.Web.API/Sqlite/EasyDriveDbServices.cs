using DriveEasyApplication.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DriveEasyApplication.Web.API.Sqlite
{
    public class EasyDriveDbServices : Sqlite, IEasyDriveDbService
    {
        public EasyDriveDbServices() : base("EasyDrive")
        {

        }

        public EasyDriveDbServices(string dbName) : base(dbName)
        {

        }

        public void AddCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public void AddCandidates(IList<Candidate> candidates)
        {
            throw new NotImplementedException();
        }

        public void AddInterviewData(InterviewData interviewData)
        {
            InsertData(DbName, "InterviewData", interviewData.ToDictionary());
        }

        public void AddInterviewDataList(List<InterviewData> interviewDataList)
        {
            foreach (var interviewData in interviewDataList)
            {
                AddInterviewData(interviewData);
            }
        }

        public void AddPanelist(Panelist panelist)
        {
            throw new NotImplementedException();
        }

        public void AddPanelists(IList<Panelist> panelists)
        {
            throw new NotImplementedException();
        }

        public void DeleteCandidate(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteInterviewData(string id)
        {
            throw new NotImplementedException();
        }

        public void DeletePanelist(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public void UpdateInterviewData(InterviewData interviewData)
        {
            throw new NotImplementedException();
        }

        public void UpdatePanelist(Panelist panelist)
        {
            throw new NotImplementedException();
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
    }
}