using DriveEasyApplication.Web.Mvc.Models;
using DriveEasyApplication.Web.Mvc.Services;
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
using System.Data;
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
        private readonly IEasyDriveDbService _easyDriveDbService;
        public DrivesController(IEasyDriveDbService easyDriveDbService)
        {
            _easyDriveDbService = easyDriveDbService;
        }
        static string[] Scopes = {
            SheetsService.Scope.SpreadsheetsReadonly,
            CalendarService.Scope.Calendar,
            CalendarService.Scope.CalendarEvents,
            CalendarService.Scope.CalendarEventsReadonly
        };

        static string ApplicationName = "Interview Drive Google Sheets";

        #region hardcoded data
        //Drive drive = new Drive
        //{
        //    Name = "23/10/2021 HPS Merchant Drive",
        //    DriveStartTime = new DateTime(2021, 10, 23, 10, 00, 00),
        //    DriveEndTime = new DateTime(2021, 10, 23, 18, 00, 00),
        //    BreakStartTime = new DateTime(2021, 10, 23, 13, 00, 00),
        //    BreakEndTime = new DateTime(2021, 10, 23, 14, 00, 00),
        //    DriveDate = new DateTime(2021, 10, 23)
        //};

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
                    StartTime = new DateTime(2021, 10, 30, 9, 00, 00),
                    EndTime = new DateTime(2021, 10, 30, 16, 00, 00),
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
                    StartTime = new DateTime(2021, 10, 30, 9, 00, 00),
                    EndTime = new DateTime(2021, 10, 30, 13, 00, 00),
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
                    StartTime = new DateTime(2021, 10, 30, 9, 00, 00),
                    EndTime = new DateTime(2021, 10, 30, 18, 00, 00),
                },
                new PanelDetail
                {
                    ID = 4,
                    Name = "Abhishek Chorage",
                    EmployeeID = "TSYS1110158",
                    Manager = "Dattatray Misal",
                    Department = "HPS",
                    Title = "Software Engineer",
                    Experience = "1.5",
                    StartTime = new DateTime(2021, 10, 30, 9, 00, 00),
                    EndTime = new DateTime(2021, 10, 30, 18, 00, 00),
                },
                new PanelDetail
                {
                    ID = 5,
                    Name = "Chandan Gupta",
                    EmployeeID = "TSYS111200",
                    Manager = "Dattatray Misal",
                    Department = "HPS",
                    Title = "Senior SDET Analyst",
                    Experience = "11",
                    StartTime = new DateTime(2021, 10, 30, 9, 00, 00),
                    EndTime = new DateTime(2021, 10, 30, 18, 00, 00),
                },
                new PanelDetail
                {
                    ID = 6,
                    Name = "Vinod Patil",
                    EmployeeID = "TSYS11125",
                    Manager = "Dattatray Misal",
                    Department = "HPS",
                    Title = "SDET Analyst",
                    Experience = "2",
                    StartTime = new DateTime(2021, 10, 30, 9, 00, 00),
                    EndTime = new DateTime(2021, 10, 30, 18, 00, 00),
                }
        };
        #endregion

        public IActionResult Index()
        {
            try
            {   
                return View(new DriveDetailsViewModel() { Drives = GetDriveDetails() });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public List<Drive> GetDriveDetails()
        {
            List<Drive> drivesList = new List<Drive>();
            try
            {
                using (EasyDriveDbServices easyDriveDbServices = new EasyDriveDbServices())
                {
                    //var result = easyDriveDbServices.ReadTableAsList("Drive");
                    var dbData = easyDriveDbServices.ReadTable("Drive");
                    var result  = dbData.AsEnumerable().Cast<DataRow>().ToList();
                    if (result != null && result.Count > 0)
                    {
                        foreach (DataRow dr in result)
                        {
                            Drive drive = new Drive();
                            drive.DriveID = Convert.ToInt32(dr["DriveID"]);
                            drive.Name = (string)dr["Name"];
                            drive.DriveDate = Convert.ToDateTime((string)dr["DriveDate"]);
                            drive.Department = (string)dr["Department"];
                            drive.Organizer = (string)dr["Organizer"];
                            drive.Status = (string)dr["DriveStatus"];
                            drive.DriveStatus = (int)Enum.Parse(typeof(DriveStatus), drive.Status);
                            drive.DriveStartTime = Convert.ToDateTime((string)dr["DriveStartTime"]);
                            drive.DriveEndTime = Convert.ToDateTime((string)dr["DriveEndTime"]);
                            drive.BreakStartTime = Convert.ToDateTime((string)dr["BreakStartTime"]);
                            drive.BreakEndTime = Convert.ToDateTime((string)dr["BreakEndTime"]);
                            drivesList.Add(drive);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            

            return drivesList.OrderByDescending(d => d.DriveID).ToList();
        }

        public List<Candidate> GetCandidateDetails(string driveId)
        {
            List<Candidate> candidatesList = new List<Candidate>();
            try
            {
                using (EasyDriveDbServices easyDriveDbServices = new EasyDriveDbServices())
                {
                    string query = $"SELECT * FROM CANDIDATE WHERE FK_DRIVEID = {Convert.ToInt32(driveId)}";
                    var result = easyDriveDbServices.ExecuteQuerryAsList(query);
                    if (result != null && result.Count > 0)
                    {
                        foreach (DataRow dr in result)
                        {
                            Candidate candidate = new Candidate();
                            candidate.CandidateID = Convert.ToInt32(dr["CandidateID"]);
                            candidate.FK_DriveID = Convert.ToInt64(driveId);
                            candidate.Name = (string)dr["Name"];
                            candidate.MobileNumber = (string)dr["MobileNumber"];
                            candidate.Skills = (string)dr["Skills"];
                            candidate.Experience = (string)dr["Experience"];
                            candidate.NoticePeriod = Convert.ToInt32(dr["NoticePeriod"]);
                            candidate.Source = (string)dr["Source"];
                            candidate.Confirmed = (string)dr["Confirmed"];
                            candidate.CurrentOrganization = (string)dr["CurrentOrganization"];
                            candidate.MeetingLink = dr["MeetingLink"] == DBNull.Value ? string.Empty : (string)dr["MeetingLink"];
                            candidate.FormattedInterviewTime = dr["InterviewTime"] == DBNull.Value || dr["InterviewTime"].ToString().Trim() == "" ? string.Empty : DateTime.ParseExact((string)dr["InterviewTime"], "MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy hh:mm tt");
                            candidate.TechnicalPanel = dr["TechnicalPanel"] == DBNull.Value ? string.Empty : (string)dr["TechnicalPanel"];
                            candidate.TechnicalPanelFeedback = dr["TechnicalPanelFeedback"] == DBNull.Value ? string.Empty : (string)dr["TechnicalPanelFeedback"];
                            candidate.ManagerPanel = dr["ManagerPanel"] == DBNull.Value ? string.Empty : (string)dr["ManagerPanel"];
                            candidate.ManagerPanelFeedback = dr["ManagerPanelFeedback"] == DBNull.Value ? string.Empty : (string)dr["ManagerPanelFeedback"];
                            candidate.HRPanel = dr["HRPanel"] == DBNull.Value ? string.Empty : (string)dr["HRPanel"];
                            candidate.HRPanelFeedback = dr["HRPanelFeedback"] == DBNull.Value ? string.Empty : (string)dr["HRPanelFeedback"];
                            candidate.FeedbackForm = dr["FeedbackForm"] == DBNull.Value ? string.Empty : (string)dr["FeedbackForm"];
                            candidate.ResumeLink = (string)dr["ResumeLink"];
                            candidate.Email = (string)dr["Email"];
                            candidate.CandidateStatus = Convert.ToInt32(dr["CandidateStatus"]);
                            candidatesList.Add(candidate);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return candidatesList.OrderByDescending(c => c.CandidateID).ToList();
        }

        public IActionResult DrivesDetails(string driveId)
        {
            try
            {
                var candidatesList= GetCandidateDetails(driveId);
                ViewBag.DriveID = driveId.ToString();
                return View(candidatesList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult CandidateDetails(int candidateId)
        {
            // Read data from database
            Candidate dbCandidates = _easyDriveDbService.GetCandidate("CandidateID", candidateId.ToString()).FirstOrDefault(); ;
            return View(dbCandidates);
        }
       
        [HttpPost]
        public IActionResult CreateDrive(DriveDetailsViewModel driveDetailsViewModel)
        {
            long? driveID = null;

            var drive = new Drive()
            {
                Name = driveDetailsViewModel.Name,
                Department = driveDetailsViewModel.Department,
                Organizer = driveDetailsViewModel.Organizer,
                SheetLink = driveDetailsViewModel.SheetLink,
                DriveDate = driveDetailsViewModel?.DriveDate ?? DateTime.Now,
                DriveStartTime = driveDetailsViewModel.DriveStartTime ?? DateTime.Now,
                DriveEndTime = driveDetailsViewModel.DriveEndTime ?? DateTime.Now,
                BreakStartTime = driveDetailsViewModel.BreakStartTime ?? DateTime.Now,
                BreakEndTime = driveDetailsViewModel.BreakEndTime ?? DateTime.Now,
                DriveStatus = (int)driveDetailsViewModel.DriveStatus
            };
            try
            {
                driveID = _easyDriveDbService.Add<Drive>(drive);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Read Spreadsheet
            SheetsService sheetsService = CreateSheetsService();
            IEnumerable<Candidate> candidates = FetchSpreadsheetData(sheetsService, driveID.Value).Result;

            // Save in Database
            IEasyDriveDbService dbService = new EasyDriveDbServices();
            dbService.Add<Candidate>(candidates.ToList());

            // Redirect to Index
            return RedirectToAction("Index");
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

        public async Task<IEnumerable<Candidate>> FetchSpreadsheetData(SheetsService sheetsService, long driveID)
        {
            List<Candidate> Candidates = new List<Candidate>();
            // Define request parameters.
            String spreadsheetId = "1dxIixDj9ypI3U39OLBSN4JnEHzhTxd3b90IwtO92DsI";
            //String spreadsheetId = "1_T-8hgakOdeWE0xCMCYwNvDuSGvPWPb16jPic2ZvXhA";
              String range = "Drive!A2:K";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1_T-8hgakOdeWE0xCMCYwNvDuSGvPWPb16jPic2ZvXhA/edit
            // https://docs.google.com/spreadsheets/d/1dxIixDj9ypI3U39OLBSN4JnEHzhTxd3b90IwtO92DsI/edit
            ValueRange response = null;
            try
            {
                response = request.Execute();
            }
            catch (Exception ex)
            {

            }
            
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
                        //CandidateID = row[0] != null ? Convert.ToInt16(row[0]) : 0,
                        Name = row[1] != null ? row[1].ToString() : string.Empty,
                        Skills = row[2] != null ? row[2].ToString() : null,
                        Source = row[3] != null ? row[3].ToString() : string.Empty,
                        Confirmed = row[4] != null ? row[4].ToString() : "No",
                        MobileNumber = row[5] != null ? row[5].ToString() : string.Empty,
                        Email = row[6] != null ? row[6].ToString() : string.Empty,
                        Experience = row[7] != null ? Convert.ToString(row[7]) : "0",
                        NoticePeriod = row[8] != null ? Convert.ToInt16(row[8]) : 0,                        
                        ResumeLink = row[10] != null ? row[10].ToString() : string.Empty,
                        FK_DriveID = driveID,
                        CandidateStatus = (int)CandidateStatus.Unscheduled,
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

        public IActionResult SendInvites(string driveId)
        {
            long id = Convert.ToInt64(driveId);
            var driveDetails = GetDriveDetails().Where(drive => drive.DriveID == id).FirstOrDefault();
            var candidates = GetCandidateDetails(driveId);
            List<Candidate> updatedCandidates = RunPanelAssignementAlgo(driveDetails, candidates, panelDetails);
            List<Candidate> scheduledCandidates = CreateCalendarEventsData(updatedCandidates);
            // Need to update in database
            foreach (var candidate in scheduledCandidates)
            {
                candidate.CandidateStatus = (int)Enum.Parse(typeof(CandidateStatus), CandidateStatus.Scheduled.ToString());
                _easyDriveDbService.Edit<Candidate>(candidate, "CandidateID", candidate.CandidateID.ToString());
                //break; // Need to remove later
            }

            return RedirectToAction("DrivesDetails", "Drives", new { driveId = driveId });
        }

        public List<Candidate> RunPanelAssignementAlgo(Drive drive, List<Candidate> candidates, List<PanelDetail> panelDetails)
        {
            //int maxInterviews = candidates.Count / panelDetails.Count;
            List<long> candidateIDs = new List<long>();
            TimeSpan interviewTime = new TimeSpan(01, 00, 00);
            List<Candidate> updateInterviewDatas = new List<Candidate>();

            DateTime? currentInterviewEnd, currentInterviewStart = null;
            if (!currentInterviewStart.HasValue)
                currentInterviewStart = drive.DriveStartTime;
            currentInterviewEnd = currentInterviewStart + interviewTime;
            while (currentInterviewEnd.Value <= drive.DriveEndTime)
            {
                foreach (PanelDetail panelDetail in panelDetails)
                {
                    if ((panelDetail.StartTime <= currentInterviewStart.Value && panelDetail.EndTime >= currentInterviewEnd.Value) &&
                       ((currentInterviewStart.Value < drive.BreakStartTime && currentInterviewEnd.Value <= drive.BreakEndTime) || currentInterviewStart.Value >= drive.BreakEndTime))
                    {
                        foreach (Candidate candidate in candidates.Where(data => !candidateIDs.Contains(data.CandidateID)))
                        {
                            if (Convert.ToDecimal(candidate.Experience) <= Convert.ToDecimal(panelDetail.Experience))
                            {
                                candidate.TechnicalPanel = panelDetail.Name;
                                candidate.InterviewTime = currentInterviewStart.Value;
                                candidateIDs.Add(candidate.CandidateID);
                                updateInterviewDatas.Add(candidate);
                                break;
                            }
                        }
                    }                    
                }

                currentInterviewStart = currentInterviewEnd;
                currentInterviewEnd = currentInterviewStart + interviewTime;
            }

            return updateInterviewDatas;
        }

        private List<Candidate> CreateCalendarEventsData(List<Candidate> candidates)
        {
            CalendarService calendarService = this.CreateCalendarService();
            List<Candidate> updatedInterviewDatas = new List<Candidate>();
            foreach (Candidate interviewData in candidates)
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
            start.DateTime = candidate.InterviewTime;
            EventDateTime end = new EventDateTime();
            end.DateTime = start.DateTime + new TimeSpan(1, 0, 0);
            body.Start = start;
            body.End = end;

            body.Attachments = new List<EventAttachment>();

            // Attach Candidate Resume with Email and Event
            EventAttachment attachment = new EventAttachment();
            attachment.Title = "Candidate resume";
            attachment.FileUrl = candidate.ResumeLink;
            attachment.MimeType = "application/vnd.google-apps.document";
            body.Attachments.Add(attachment);

            attachment = new EventAttachment();
            attachment.Title = "TSYS A Global Payments Company";
            attachment.FileUrl = "https://drive.google.com/file/d/1sOe9XVHrkuUS-SNajOIqfDAcjT0MkWKX/view?usp=sharing";
            attachment.MimeType = "application/vnd.google-apps.document";
            body.Attachments.Add(attachment);

            // Generate Google meet
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
            EventsResource.InsertRequest request = new EventsResource.InsertRequest(_service, body, "hackathonteamtitansprod@gmail.com");
            request.SupportsAttachments = true;
            request.ConferenceDataVersion = 1;
            request.SendNotifications = true;
            Event response = request.Execute();

            candidate.MeetingLink = response.HangoutLink;
            return candidate;
        }

        public string GetEventDescription(Candidate candidate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hi " + candidate.Name + ",");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("Thank you for applying to TSYS.");
            sb.AppendLine();
            sb.Append("We would like to invite you for an interview at our office[s] to get to know you a bit better.");
            sb.AppendLine();
            sb.Append("You will meet with " + candidate.TechnicalPanel + ". The interview will last about 60 minutes and you’ll have the chance to discuss the position and learn more about our company.");
            sb.AppendLine();
            sb.Append("Looking forward to hearing from you,");
            sb.AppendLine();
            sb.Append("All the best");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("Kind regards,");
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
