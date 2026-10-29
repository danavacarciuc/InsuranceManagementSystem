using System;
using System.Collections.Generic;
namespace InsuranceManagementSystem.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public DateTime RegistrationDate { get; set; }
        public List<Insurance> Insurances { get; set; }
            = new List<Insurance>();
        public Client()
        {
            RegistrationDate = DateTime.Now;
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}