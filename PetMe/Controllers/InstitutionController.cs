using PetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PetMe.Controllers
{
    public class InstitutionController : Controller
    {
        // GET: Institution
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(ContactMail _mail)
        {
            if (ModelState.IsValid)
            {
                //Instância classe email
                MailMessage mail = new MailMessage();
                mail.To.Add(_mail.To);
                mail.From = new MailAddress(_mail.From);
                mail.Subject = _mail.Subject;
                string Body = _mail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //Instância smtp do servidor, neste caso o gmail.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("username", "password");// Login e senha do e-mail.
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", _mail);
            }
            else
            {
                return View();
            }
        }
    }
}