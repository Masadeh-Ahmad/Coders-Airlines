using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Models.Interfaces
{
    public interface IEmail
    {
        public Task SendMail(string email, Flight flight);
        public Task WelcomeMail(string email);
    }
}
