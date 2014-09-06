using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace squeeze_pages.Controllers
{
    public class SellController : Controller
    {
        // GET: Sell
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult SubmitDetails(string email, string name, string phone, string address, string amount, string sqft)
        {
            try
            {
                //send the email

                var msg = new System.Net.Mail.MailMessage();
                msg.From = new System.Net.Mail.MailAddress("rebirthpropertiesinbound@gmail.com"); //TODO: Update this to be the same as the setting email account
                msg.Bcc.Add("ashton.stockman@live.com");
                msg.Bcc.Add("rebirthpropertiesllc@gmail.com");
                msg.Subject = "New Sales Lead";
                msg.Body = "Email: " + email + "<br />";
                msg.Body += "Name: " + name + "<br />";
                msg.Body += "Phone: " + phone + "<br />";
                msg.Body += "Address: " + address + "<br />";
                msg.Body += "Amount: " + amount + "<br />";
                msg.Body += "Sqft: " + sqft;
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