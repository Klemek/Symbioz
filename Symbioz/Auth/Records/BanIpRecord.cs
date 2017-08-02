using Symbioz.ORM;
using System.Collections.Generic;

namespace Symbioz.Auth.Records
{
    [Table("BanIp")]
    public class BanIpRecord : ITable
    {
        public static List<BanIpRecord> BanIp = new List<BanIpRecord>();

        public string Ip;

        public BanIpRecord(string ip)
        {
            this.Ip = ip;
        }
        public static void Add(string ip)
        {
            if (!IsBanned(ip))
            {
                new BanIpRecord(ip).AddElement();
            }
        }
        public static bool IsBanned(string ip)
        {
            return BanIp.Find(x => x.Ip == ip) != null;
        }
    }
}
