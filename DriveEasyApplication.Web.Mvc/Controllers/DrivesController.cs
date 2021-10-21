using DriveEasyApplication.Web.Mvc.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriveEasyApplication.Web.Mvc.Controllers
{
    public class DrivesController : Controller
    {
        static string[] Scopes = {
            SheetsService.Scope.SpreadsheetsReadonly,
            CalendarService.Scope.Calendar,
            CalendarService.Scope.CalendarEvents,
            CalendarService.Scope.CalendarEventsReadonly
        };

        static string ApplicationName = "Interview Drive Google Sheets";
        List<Candidate> Candidates = new List<Candidate>();

        #region hardcoded data
        Drive drive = new Drive
        {
            Name = "23/10/2021 HPS Merchant Drive",
            DriveStartTime = new DateTime(2021, 10, 23, 10, 00, 00),
            DriveEndTime = new DateTime(2021, 10, 23, 18, 00, 00),
            BreakStartTime = new DateTime(2021, 10, 23, 13, 00, 00),
            BreakEndTime = new DateTime(2021, 10, 23, 14, 00, 00),
            DriveDate = new DateTime(2021, 10, 23)
        };

        List<PanelDetail> panelDetails = new List<PanelDetail>()
            {
                new PanelDetail
                {
                    ID = 1,
                    Name = "Sharique Nadeem",
                    EmployeeID = "TSYS111013",
                    Manager = "Dattatray Misal",
                    Department = "HPS",
                    Title = "Senior Software Engineer",
                    Experience = "7.5",                    
                    StartTime = new DateTime(2021, 10, 23, 11, 00, 00),
                    EndTime = new DateTime(2021, 10, 23, 16, 00, 00),                    
                },
                new PanelDetail
                {
                    ID = 2,
                    Name = "Mohsin Mulla",
                    EmployeeID = "TSYS111014",
                    Manager = "Dattatray Misal",
                    Department = "HPS",
                    Title = "Senior Software Engineer",
                    Experience = "7",                    
                    StartTime = new DateTime(2021, 10, 23, 10, 00, 00),
                    EndTime = new DateTime(2021, 10, 23, 13, 00, 00),                    
                },
                new PanelDetail
                {
                    ID = 3,
                    Name = "Suraj Patel",
                    EmployeeID = "TSYS111015",
                    Manager = "Dattatray Misal",
                    Department = "HPS",
                    Title = "Senior SDET Analyst",
                    Experience = "6.5",                    
                    StartTime = new DateTime(2021, 10, 23, 14, 00, 00),
                    EndTime = new DateTime(2021, 10, 23, 18, 00, 00),
                }
        };
        #endregion

        public IActionResult Index()
        {
            // SheetsService sheetsService = CreateSheetsService();
            // IEnumerable<Candidate> Candidates = FetchSpreadsheetData(sheetsService).Result;
            // SendInvites();
            // return View(Candidates);
            return View();
        }

        public IActionResult DrivesDetails()
        {
            return View();
        }

        public IActionResult CandidateDetails(int driveId)
        {
            return View();
        }

        public IActionResult SendInvites(int driveId)
        {
            return null;
        }

        private SheetsService CreateSheetsService()
        {
            UserCredential credential;

            string path = AppContext.BaseDirectory;
            path = path + "credentials.json";
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        public async Task<IEnumerable<Candidate>> FetchSpreadsheetData(SheetsService sheetsService)
        {
            // Define request parameters.
            String spreadsheetId = "1_T-8hgakOdeWE0xCMCYwNvDuSGvPWPb16jPic2ZvXhA";
            String range = "Drive!A2:K";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1_T-8hgakOdeWE0xCMCYwNvDuSGvPWPb16jPic2ZvXhA/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            List<Candidate> data = new List<Candidate>();
            CultureInfo culture = new CultureInfo("en-US");
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Print columns
                    data.Add(new Candidate
                    {
                        CandidateID = row[0] != null ? Convert.ToInt16(row[0]) : 0,
                        Name = row[1] != null ? row[1].ToString() : string.Empty,
                        Skills = row[2] != null ? row[2].ToString() : null,
                        Source = row[3] != null ? row[3].ToString() : string.Empty,
                        MobileNumber = row[5] != null ? row[5].ToString() : string.Empty,
                        Email = row[6] != null ? row[6].ToString() : string.Empty,
                        Experience = row[7] != null ? Convert.ToString(row[7]) : "0",
                        NoticePeriod = row[8] != null ? Convert.ToInt16(row[8]) : 0,                        
                        ResumeLink = row[10] != null ? row[10].ToString() : string.Empty,                        
                    });
                }

                Candidates = data;
            }
            else
            {

                Candidates = null;
            }

            return Candidates;
        }

        public IActionResult SendInvites()
        {   
            List<Candidate> interviewDatas = RunPanelAssignementAlgo(drive, Candidates, panelDetails);
            List<Candidate> updatedInterviewDatas = CreateCalendarEventsData(interviewDatas);
            return View(updatedInterviewDatas);
        }

        public List<Candidate> RunPanelAssignementAlgo(Drive drive, List<Candidate> candidates, List<PanelDetail> panelDetails)
        {
            int maxInterviews = candidates.Count / panelDetails.Count;
            List<int> SrNos = new List<int>();
            TimeSpan interviewTime = new TimeSpan(01, 00, 00);
            List<Candidate> updateInterviewDatas = new List<Candidate>();
            foreach (PanelDetail panelDetail in panelDetails)
            {
                int interviewsAssigned = 0;
                DateTime? currentInterviewEnd, currentInterviewStart = null;
                if (!currentInterviewStart.HasValue)
                    currentInterviewStart = drive.DriveStartTime;
                currentInterviewEnd = currentInterviewStart + interviewTime;
                while (currentInterviewEnd.Value <= drive.DriveEndTime && interviewsAssigned <= maxInterviews)
                {
                    if ((panelDetail.StartTime <= currentInterviewStart.Value && panelDetail.EndTime >= currentInterviewEnd.Value) &&
                       ((currentInterviewStart.Value < drive.BreakStartTime && currentInterviewEnd.Value <= drive.BreakEndTime) || currentInterviewStart.Value >= drive.BreakEndTime))
                    {
                        foreach (Candidate candidate in candidates.Where(data => !SrNos.Contains(data.CandidateID)))
                        {
                            if (Convert.ToDecimal(candidate.Experience) <= Convert.ToDecimal(panelDetail.Experience))
                            {
                                candidate.TechnicalPanel = panelDetail.Name;
                                candidate.FromTime = currentInterviewStart;
                                candidate.ToTime = currentInterviewEnd;                                
                                SrNos.Add(candidate.CandidateID);
                                updateInterviewDatas.Add(candidate);
                                interviewsAssigned++;
                                break;
                            }
                        }
                    }
                    currentInterviewStart = currentInterviewEnd;
                    currentInterviewEnd = currentInterviewStart + interviewTime;
                }
            }

            return updateInterviewDatas;
        }

        private List<Candidate> CreateCalendarEventsData(List<Candidate> candidates)
        {
            CalendarService calendarService = this.CreateCalendarService();
            List<Candidate> updatedInterviewDatas = new List<Candidate>();
            foreach (Candidate interviewData in Candidates)
            {
                Candidate updatedInterviewData = CreateEvent(calendarService, interviewData);
                updatedInterviewDatas.Add(updatedInterviewData);
            }

            return updatedInterviewDatas;
        }

        private CalendarService CreateCalendarService()
        {
            CalendarService service = null;
            try
            {
                UserCredential credential;
                string keyfilepath = AppContext.BaseDirectory;
                keyfilepath = "credentials.json";
                using (var stream = new FileStream(keyfilepath, FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Calendar API service.    
                service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Calendar Sample",
                });
            }
            catch (Exception ex)
            {
                throw;
            }

            return service;
        }

        private Candidate CreateEvent(CalendarService _service, Candidate candidate)
        {
            Event body = new Event();
            EventAttendee a = new EventAttendee();
            a.Email = candidate.Email;
            EventAttendee b = new EventAttendee();
            b.Email = "maheshdwaghmare@gmail.com"; // interviewData.TechnicalPanel;
            List<EventAttendee> attendes = new List<EventAttendee>();
            attendes.Add(a);
            attendes.Add(b);
            body.Attendees = attendes;
            EventDateTime start = new EventDateTime();
            start.DateTime = candidate.FromTime;
            EventDateTime end = new EventDateTime();
            end.DateTime = candidate.ToTime;
            body.Start = start;
            body.End = end;

            body.ConferenceData = new ConferenceData
            {
                CreateRequest = new CreateConferenceRequest
                {
                    RequestId = "1234abcdef",
                    ConferenceSolutionKey = new ConferenceSolutionKey
                    {
                        Type = "hangoutsMeet"
                    }
                },
            };

            body.Location = "Avengers Mansion";
            body.Summary = "Invitation to interview – TSYS / Interview with " + candidate.TechnicalPanel;
            body.Description = GetEventDescription(candidate);
            EventsResource.InsertRequest request = new EventsResource.InsertRequest(_service, body, "hackathonteamtitans@gmail.com");
            request.ConferenceDataVersion = 1;
            Event response = request.Execute();
            candidate.MeetingLink = response.HangoutLink;

            return candidate;
        }

        public string GetEventDescription(Candidate candidate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hi " + candidate.Name + ",");
            sb.AppendLine();
            sb.Append("Thank you for applying to TSYS.");
            sb.AppendLine();
            sb.Append("We would like to invite you for an interview at our office[s] to get to know you a bit better.");
            sb.AppendLine();
            sb.Append("You will meet with " + candidate.TechnicalPanel + ". The interview will last about 60 minutes and you’ll have the chance to discuss the [Job_title] position and learn more about our company.");
            sb.AppendLine();
            sb.Append("Looking forward to hearing from you,");
            sb.AppendLine();
            sb.Append("All the best / Kind regards,");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("HR");

            return sb.ToString();
        }

        #region old code
        private void GetDriveDataOld()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44356/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Drives");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
        }

        #endregion
    }
}
