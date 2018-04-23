using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomJQuery.Models
{
    public class CustomAttribute : ValidationAttribute, IClientValidatable
    {
        // Fields...
        private int _MinDate;
        public int MinDate
        {
            get { return _MinDate; }
            set { _MinDate = value; }
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Person p = validationContext.ObjectInstance as Person;
            if (p == null)
                return new ValidationResult("Internal  error");
            if (!p.CheckAge)
                return ValidationResult.Success;            
            TimeSpan ts = DateTime.Now - p.BirthDate;
            if (ts.TotalDays / 365 < MinDate)
                return new ValidationResult("Age must be more than " + MinDate.ToString());
            else
                return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield  return new ModelClientValidationRangeDateRule("Age must be more than " + MinDate.ToString(), MinDate);  
            
        }
        public class ModelClientValidationRangeDateRule : ModelClientValidationRule
        {
            public ModelClientValidationRangeDateRule(string errorMessage, int minDate)
            {
                ErrorMessage = errorMessage;
                ValidationType = "rangedate";
                ValidationParameters["mindate"] = minDate;
            }
        }
    }
}
