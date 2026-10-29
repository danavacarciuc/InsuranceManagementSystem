using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceManagementSystem.Models
{
    public class LifeInsurance : Insurance
    {
        public decimal CoverageAmount { get; set; }
        public string Beneficiary { get; set; }

        public override string InsuranceType
        {
            get { return "Life Insurance"; }
        }
    }
}
