using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Record
    {
        public string Mail, SkypeId;
        public Record(string Mail, string SkypeId)
        {
            this.Mail = Mail;
            this.SkypeId = SkypeId;
        }
    }
}
