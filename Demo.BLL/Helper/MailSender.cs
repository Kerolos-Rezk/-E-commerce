using Demo.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Helper
{
    public static class MailSender
    {
        public static string SendMail(MailVM model)
        {
            try
            {

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                    smtp.Send("as8338873@gmail.com", "elgendya160@gmail.com", model.Title, model.Message);
                }

                return "Done !  Mail Sent Successfully";

            }catch(Exception ex)
            {
                return "Faild To Send";
            }
        }
    }
}
