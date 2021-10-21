using DriveEasyApplication.Web.Mvc.Models;
using System.Collections.Generic;

namespace DriveEasyApplication.Web.Mvc.Services
{
    public interface IEasyDriveDbService
    {
        long? Add<T>(T data);

        void Add<T>(IList<T> data);

        void Edit<T>(T data, string colName, string value);

        void Delete<T>(string id);

        List<Panel> GetPanel(string colName, object value);

        List<Candidate> GetCandidate(string colName, object value);
    }
}
