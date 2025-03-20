using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask2.Models
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public MinAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }

        public override bool IsValid(object value)
        {
            var dob = (DateTime)value;
            var diff = DateTime.Now.Year - dob.Year;

            if (dob > DateTime.Now.AddYears(-diff))
            {
                diff--;
            }

            return diff >= 18;
        }

    }
}