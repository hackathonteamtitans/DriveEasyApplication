using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using DriveEasyApplication.Web.API.Models;

namespace DriveEasyApplication.Web.API.Controllers
{
    public class DrivesController : ApiController
    {
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Interview Drive Google Sheets";
        // GET: Drives
        public IEnumerable<InterviewData> Get()
        {
            List<InterviewData> InterviewDatas = new List<InterviewData>();

            UserCredential credential;

            string path = AppContext.BaseDirectory;
            path = path + "credentials.json";
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
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
            
            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1_T-8hgakOdeWE0xCMCYwNvDuSGvPWPb16jPic2ZvXhA";
            String range = "Drive!A2:K";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1_T-8hgakOdeWE0xCMCYwNvDuSGvPWPb16jPic2ZvXhA/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            List<InterviewData> data = new List<InterviewData>();
            CultureInfo culture = new CultureInfo("en-US");
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Print columns
                    data.Add(new InterviewData
                    {
                        SrNo = row[0] != null ? Convert.ToInt16(row[0]) : 0,
                        Name = row[1] != null ? row[1].ToString() : string.Empty,
                        SkillSet = row[2] != null ? row[2].ToString().Split(',').ToList() : null,
                        Source = row[3] != null ? row[3].ToString() : string.Empty,
                        Show = row[4] != null && row[4].ToString() == "Yes" ? Show.Yes : Show.No,
                        Contact = row[5] != null ? row[5].ToString() : string.Empty,
                        Email = row[6] != null ? row[6].ToString() : string.Empty,
                        Experience = row[7] != null ? Convert.ToDecimal(row[7]) : 0,
                        NoticePeriod = row[8] != null ? Convert.ToInt16(row[8]) : 0,
                        InterviewTime = Convert.ToDateTime(row[9], culture),
                        ResumeLink = row[10] != null ? row[10].ToString() : string.Empty,
                    });
                }

                InterviewDatas = data;
            }
            else
            {

                InterviewDatas = null;
            }

            return InterviewDatas;
        }
    }
}