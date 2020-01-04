using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string _allowedDamain;

        public ValidEmailDomainAttribute(string allowedDamain)
        {
            this._allowedDamain = allowedDamain;
        }
        public override bool IsValid(object value)
        {
            string[] email = value.ToString().Split('@');
            return email[1].ToUpper() == _allowedDamain.ToUpper(); // this expression returns true or false
        }
    }
}
