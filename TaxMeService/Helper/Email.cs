using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxMeService.Helper
{
    public class Email
    {
        public  string Subject { get; set; }
        public string Body { get; set; }

        public string from { get; set; }
        public string To { get; set; }
    }
}
