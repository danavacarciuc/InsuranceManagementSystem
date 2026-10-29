using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceManagementSystem.Models
{
    public class PropertyInsurance : Insurance
    {
        public string PropertyAddress { get; set; }
        public double PropertyType { get; set; }
        public double PropertyValue { get; set; }
        public override string InsuranceType
        {
            get { return "Property Insurance"; }
        }
    }
}