using DriveEasyApplication.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.API.Sqlite
{
    interface IEasyDriveDbService
    {
        void AddCandidate(Candidate candidate);

        void AddPanelist(Panel panelist);

        void AddCandidates(IList<Candidate> candidates);

        void AddPanelists(IList<Panel> panelists);

        void DeleteCandidate(string id);

        void DeletePanelist(string id);

        void UpdateCandidate(Candidate candidate);

        void UpdatePanelist(Panel panelist);

    }
}
