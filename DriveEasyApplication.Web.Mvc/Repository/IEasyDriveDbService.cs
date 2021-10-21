using DriveEasyApplication.Web.Mvc.Models;
using System.Collections.Generic;

namespace DriveEasyApplication.Web.Mvc.Services
{
    public interface IEasyDriveDbService
    {
        void Add<T>(T data);

        void Add<T>(IList<T> data);

        IList<T> Get<T>(string id);

        void Edit<T>(T data);

        void Delete<T>(string id);
    }
}
