using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace squeeze_pages.Controllers
{
    public class InvestController : Controller
    {
        // GET: Invest
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult SubmitDetails(string email)
        {
            try
            {
                //send the email
            
                var msg = new System.Net.Mail.MailMessage();
                msg.From = new System.Net.Mail.MailAddress("rebirthpropertiesinbound@gmail.com"); //TODO: Update this to be the same as the setting email account
                msg.Bcc.Add("ashton.stockman@live.com");
                msg.Bcc.Add("rebirthpropertiesllc@gmail.com");
                msg.Subject = "New Investor Lead";
                msg.Body = "Email: " + email;
                msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("rebirthpropertiesinbound@gmail.com", "P@$$w0rd99")
                };

                smtp.Send(msg);            
            }
            catch
            {
                return Json(new { errors = "There was an error saving your information. Please try again." });
            }

            return Json(new { errors = "0" });
        }
    }
}