using DriveEasyApplication.Web.Mvc.Models;
using System.Collections.Generic;

namespace DriveEasyApplication.Web.Mvc.Services
{
    interface IEasyDriveDbService
    {
        void Add<T>(T data);

        void Add<T>(IList<T> data);

    }
}
