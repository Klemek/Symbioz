using Symbioz.ORM;

namespace Symbioz.RawData.Records
{
    [Table("BugReports", false)]
    public class BugReportRecord : ITable
    {
        public string Content;
        public BugReportRecord(string content)
        {
            this.Content = content;
        }
    }
}
