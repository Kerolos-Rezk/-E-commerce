using Demo.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Demo.BLL.Helper;

namespace Demo.Controllers
{
    public class MailController : Controller
    {
        public IActionResult CreateMail()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateMail(MailVM model)
        {
            var result = MailSender.SendMail(model);
            TempData["Msg"] = result;
            return View();
        }
    }
}
