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

        void AddPanelist(Panelist panelist);

        void AddCandidates(IList<Candidate> candidates);

        void AddPanelists(IList<Panelist> panelists);

        void DeleteCandidate(string id);

        void DeletePanelist(string id);

        void UpdateCandidate(Candidate candidate);

        void UpdatePanelist(Panelist panelist);

        void AddInterviewData(InterviewData interviewData);

        void AddInterviewDataList(List<InterviewData> interviewDataList);

        void UpdateInterviewData(InterviewData interviewData);

        void DeleteInterviewData(string id);
    }
}
