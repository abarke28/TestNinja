using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TestNinja.Mocking
{
    public static class HousekeeperHelper
    {
        private static IUnitOfWork _unitOfWork;
        private static IHouseKeeperUtilities _houseKeeperUtilities;

        public static bool SendStatementEmails(DateTime statementDate, IHouseKeeperUtilities houseKeeperUtilities = null, IUnitOfWork unitOfWork = null)
        {
            _houseKeeperUtilities = houseKeeperUtilities ?? new HouseKeeperUtilities();
            _unitOfWork = unitOfWork ?? new UnitOfWork();

            var housekeepers = _unitOfWork.Query<Housekeeper>();

            foreach (var housekeeper in housekeepers)
            {
                if (housekeeper.Email == null)
                    continue;

                var statementFilename = _houseKeeperUtilities.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    _houseKeeperUtilities.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                        MessageBoxButtons.OK);
                }
            }
            return true;
        }
    }

    public enum MessageBoxButtons
    {
        OK
    }

    public class XtraMessageBox
    {
        public static void Show(string s, string housekeeperStatements, MessageBoxButtons ok)
        {

            System.Diagnostics.Debug.WriteLine(s + housekeeperStatements + ok.ToString());
        }
    }

    public class MainForm
    {
        public bool HousekeeperStatementsSending { get; set; }
    }

    public class DateForm
    {
        public DateForm(string statementDate, object endOfLastMonth)
        {

            System.Diagnostics.Debug.WriteLine(statementDate + endOfLastMonth.ToString());
        }

        public DateTime Date { get; set; }

        public DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }
    }

    public enum DialogResult
    {
        Abort,
        OK
    }

    public class SystemSettingsHelper
    {
        public static string EmailSmtpHost { get; set; }
        public static int EmailPort { get; set; }
        public static string EmailUsername { get; set; }
        public static string EmailPassword { get; set; }
        public static string EmailFromEmail { get; set; }
        public static string EmailFromName { get; set; }
    }

    public class Housekeeper
    {
        public string Email { get; set; }
        public int Oid { get; set; }
        public string FullName { get; set; }
        public string StatementEmailBody { get; set; }
    }

    public class HousekeeperStatementReport
    {
        public HousekeeperStatementReport(int housekeeperOid, DateTime statementDate)
        {

            System.Diagnostics.Debug.WriteLine(housekeeperOid.ToString()+statementDate.ToString());
        }

        public bool HasData { get; set; }

        public void CreateDocument()
        {
        }

        public void ExportToPdf(string filename)
        {

            System.Diagnostics.Debug.WriteLine(filename);
        }
    }
}