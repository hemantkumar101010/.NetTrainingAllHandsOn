using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinemaTicketBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
             LoginModule loginModule = new LoginModule();
             loginModule.RegisterOrLogin();
        }
    }
}
