using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaxMeService.Helper
{
   public static class EmailSetteings
    {

        public static void SendEmail()
        { 
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl= true;
            //client.Credentials = new NetwrkaCer
        }  

    }
}
