using Coders_Airlines.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Services
{
    public class EmailService : IEmail
    {
        public string CartCookie { get; set; }
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// This method gets the user's email and the list of products from his/her cart, and sends 3 seperate emails for the Admin, Sales, Warehouse.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public async Task SendMail(string email, Flight flight)
        {
            SendGridClient client = new SendGridClient(_configuration.GetConnectionString("APIKEY"));
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("21028869@student.ltuc.com", "IT Team");
            msg.AddTo(email);
            msg.SetSubject("Purchase Recite");
            msg.AddContent(MimeType.Html, $"Thank you for your purchase! \n");

            await client.SendEmailAsync(msg);

        }

        /// <summary>
        /// This method sets up the email to be sent as a welcoming email after the user registers.
        /// </summary>
        /// <param name="email"></param>
        /// <returns> None. </returns>
        public async Task WelcomeMail(string email)
        {
            SendGridClient client = new SendGridClient(_configuration.GetConnectionString("APIKEY"));
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("21028869@student.ltuc.com", "Store Team");
            msg.AddTo(email);
            msg.SetSubject("Welcome to our store!");
            msg.AddContent(MimeType.Html, "You have successfully registered an account to our store, Welcome!");
            await client.SendEmailAsync(msg);
        }

    }
}
