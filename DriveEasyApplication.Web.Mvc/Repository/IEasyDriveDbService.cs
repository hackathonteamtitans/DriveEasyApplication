using DriveEasyApplication.Web.Mvc.Models;
using System.Collections.Generic;

namespace DriveEasyApplication.Web.Mvc.Services
{
    public interface IEasyDriveDbService
    {
        void Add<T>(T data);

        void Add<T>(IList<T> data);

        List<Panel> GetPanel(string colName, object value);

        List<Candidate> GetCandidate(string colName, object value);
    }
}
