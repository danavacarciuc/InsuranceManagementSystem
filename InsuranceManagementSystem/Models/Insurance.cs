using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceManagementSystem.Models
{
    public abstract class Insurance
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public abstract string InsuranceType { get; }
        public bool IsActive
        {
            get { return DateTime.Now >= StartDate && DateTime.Now <= EndDate; }
        }
    }
}
