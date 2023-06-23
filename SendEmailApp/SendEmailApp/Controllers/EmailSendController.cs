using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmailApp.Interfaces;
using SendEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSendController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public EmailSendController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        //Ref --> https://stackoverflow.com/questions/23137012/535-5-7-8-username-and-password-not-accepted
        //[HttpGet]
        //public string SendMail()
        //{
        //    var message = new Message(new string[] { "skselva312000@gmail.com" }, "Wecome Kit", "Hi Selva, welcome to ShopMe");
        //    _emailSender.SendEmail(message);
        //    return "Email Sent Successfully";
        //}

        [HttpGet]
        public async Task<string> SendMailAsync()
        {
            var message = new Message(new string[] { "skselva312000@gmail.com" }, "Wecome To ShopMe Portal",
               "Greetings from ShopMe", null);
            await _emailSender.SendEmailAsync(message,"Selvakumar Raman");
            return "Email Sent Successfully";
        }

        [HttpPost]
        public async Task<string> SendMailWithAttachementsAsync()
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            var message = new Message(new string[] { "skselva312000@gmail.com" }, 
                "Wecome Kit with attachements", "Hi Selva, welcome to ShopMe", files);
            await _emailSender.SendEmailAsync(message, "selva");
            return "Email Sent Successfully";
        }


    }
}
