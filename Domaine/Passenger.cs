using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaine
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string passportNumber { get; set; }
        public string EmailAdress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> flights { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
        //polymorphisme par signature
        //10-a
        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;

        }
        //qst 10-b
        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            return FirstName == firstName && LastName == lastName && EmailAdress == email;

        }
        public bool CheckProfile1(string firstName, string lastName, string email = null)
        {
            if (email != null)
            {
                return FirstName == firstName && LastName == lastName && EmailAdress == email;
            }
            else
            {
                return FirstName == firstName && LastName == lastName;
            }

        }

        //polymorphisme par héritage
        public virtual void PassengerType()
        { Console.WriteLine("i am passenger"); }

    }
}
